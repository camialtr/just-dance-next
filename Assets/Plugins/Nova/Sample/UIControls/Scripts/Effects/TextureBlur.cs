using Nova;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace NovaSamples.Effects
{
    internal struct BlurFilter : IEquatable<BlurFilter>
    {
        public const int MinDownscale = 0;
        public const int MaxDownscale = 6;

        public float BlurRadius;
        public float Contrast;
        public float Saturation;
        public float Brightness;
        public float Grain;

        public BlurMode BlurMode;
        public int BlurDownscaleFactor;
        public bool UseComputeShader;

        public int GetBlurableSize(Texture texture)
        {
            if (texture == null)
            {
                return 1;
            }

            int downscale = Mathf.Clamp(BlurDownscaleFactor, MinDownscale, MaxDownscale);

            int max = Mathf.Max(texture.width, texture.height);

            return Mathf.Max(Mathf.RoundToInt(max / Mathf.Pow(2, downscale)), 1);
        }

        public bool Equals(BlurFilter other)
        {
            return BlurRadius == other.BlurRadius &&
                   Contrast == other.Contrast &&
                   Saturation == other.Saturation &&
                   Brightness == other.Brightness &&
                   Grain == other.Grain &&
                   BlurMode == other.BlurMode &&
                   UseComputeShader == other.UseComputeShader &&
                   BlurDownscaleFactor == other.BlurDownscaleFactor;

        }
    }

    internal class TextureBlur : IDisposable
    {
        #region Constants
        private const string BlurShaderName = "BlurSinglePassShader";
        private const string BlurComputeName = "BlurSinglePassCompute";
        private const int MinPasses = 1;
        private const int MaxPasses = 6;
        private const float BlurPixelSize = 0.25f;
        private const float BlurLogBase = 2;
        private const float TexelPassDownScale = 1 / BlurLogBase;
        private const int TempTextureDepth = 0;
        private const int BlurPass = 0;
        private const int ColorFiltersPass = 1;
        private const string COLOR_ADJUSTMENT_ON = "COLOR_ADJUSTMENT_ON";
        private const string LINEAR_SPACE = "LINEAR_SPACE";
        private const string GRAIN_ON = "GRAIN_ON";
        private const string BlurKernel = "Blur";
        private const float Epsilon = 1e-5f;

        /// An arbitrary scalar, but grain values over ~0.2 are very noisy and seem less useful
        private const float GrainScalar = 1 / 5f;

        private static readonly Vector4 DefaultColors = new Vector4(0, 1, 1, 1);

        [NonSerialized]
        private static uint NextInstanceID = 0;

        [NonSerialized]
        private static int BlurID = Shader.PropertyToID("_BlurBox");
        [NonSerialized]
        private static int UVScaleID = Shader.PropertyToID("_UVScale");
        [NonSerialized]
        private static int InputTextureID = Shader.PropertyToID("_Input");
        [NonSerialized]
        private static int OutputTextureID = Shader.PropertyToID("_Output");
        [NonSerialized]
        private static int ColorAdjustmentID = Shader.PropertyToID("_ColorAdjustments");
        [NonSerialized]
        private static int GrainID = Shader.PropertyToID("_Grain");
        [NonSerialized]
        private static int OffsetID = Shader.PropertyToID("_Offset");
        [NonSerialized]
        private static int ClipUVsID = Shader.PropertyToID("_ClipUVs");
        [NonSerialized]
        private static int GrainUVsID = Shader.PropertyToID("_GrainUVs");
        #endregion

        #region Properties
        public RenderTexture OutputTexture => finalBlurredTexture;


        private Material[] blurMaterials = new Material[MaxPasses];

        [NonSerialized]
        private static Shader blurShader = null;
        private static Shader BlurShader
        {
            get
            {
                if (blurShader == null)
                {
                    blurShader = Resources.Load(BlurShaderName) as Shader;
                }

                return blurShader;
            }
        }

        [NonSerialized]
        private static ComputeShader sharedComputeShader = null;
        private static ComputeShader SharedComputeShader
        {
            get
            {
                if (sharedComputeShader == null)
                {
                    sharedComputeShader = Resources.Load(BlurComputeName) as ComputeShader;
                }

                return sharedComputeShader;
            }
        }

        #region Materials
        /// <summary>
        /// Need multiple materials because material.SetFloat() doesn't
        /// have a CommandBuffer equivalent and therefore can't be queued
        /// without preconfiguring multiple materials for the different steps.
        /// </summary>
        private Material[] BlurMaterials
        {
            get
            {
                if (blurMaterials[0] == null)
                {
                    for (int i = 0; i < MaxPasses; ++i)
                    {
                        blurMaterials[i] = new Material(BlurShader);
                        blurMaterials[i].hideFlags = HideFlags.HideAndDontSave;
                    }
                }

                return blurMaterials;
            }
        }

        private Material colorAdjustmentMaterial = null;
        private Material ColorAdjustmentMaterial
        {
            get
            {
                if (colorAdjustmentMaterial == null)
                {
                    colorAdjustmentMaterial = new Material(BlurShader);
                    colorAdjustmentMaterial.hideFlags = HideFlags.HideAndDontSave;
                    colorAdjustmentMaterial.EnableKeyword(COLOR_ADJUSTMENT_ON);
                }

                return colorAdjustmentMaterial;
            }
        }

        private Material grainMaterial = null;
        private Material GrainMaterial
        {
            get
            {
                if (grainMaterial == null)
                {
                    grainMaterial = new Material(BlurShader);
                    grainMaterial.hideFlags = HideFlags.HideAndDontSave;
                    grainMaterial.EnableKeyword(GRAIN_ON);
                }

                return grainMaterial;
            }
        }
        #endregion

        #region Compute Shaders
        private ComputeShader computeShader = null;
        private ComputeShader ComputeShader
        {
            get
            {
                if (computeShader == null && SharedComputeShader != null)
                {
                    computeShader = ComputeShader.Instantiate(SharedComputeShader);
                    computeShader.hideFlags = HideFlags.HideAndDontSave;

                    if (UseLinearSpaceComputeShader)
                    {
                        computeShader.EnableKeyword(LINEAR_SPACE);
                    }
                }

                return computeShader;
            }
        }

        private ComputeShader colorAdjustmentComputeShader = null;
        private ComputeShader ColorAdjustmentComputeShader
        {
            get
            {
                if (colorAdjustmentComputeShader == null && SharedComputeShader != null)
                {
                    colorAdjustmentComputeShader = ComputeShader.Instantiate(SharedComputeShader);
                    colorAdjustmentComputeShader.hideFlags = HideFlags.HideAndDontSave;
                    colorAdjustmentComputeShader.EnableKeyword(COLOR_ADJUSTMENT_ON);

                    if (UseLinearSpaceComputeShader)
                    {
                        colorAdjustmentComputeShader.EnableKeyword(LINEAR_SPACE);
                    }
                }

                return colorAdjustmentComputeShader;
            }
        }

        private int computeKernel = -1;
        private int ComputeKernel
        {
            get
            {
                if (computeKernel < 0)
                {
                    computeKernel = ComputeShader.FindKernel(BlurKernel);
                }
                return computeKernel;
            }
        }

        private Vector3Int computeThreads = Vector3Int.zero;
        private Vector3Int ComputeThreads
        {
            get
            {
                if (computeThreads == Vector3Int.zero)
                {
                    ComputeShader.GetKernelThreadGroupSizes(ComputeKernel, out uint x, out uint y, out uint z);
                    computeThreads = new Vector3Int((int)x, (int)y, (int)z);
                }

                return computeThreads;
            }
        }
        #endregion

        private CommandBuffer commandBuffer = null;
        private CommandBuffer CommandBuffer
        {
            get
            {
                if (commandBuffer == null)
                {
                    commandBuffer = new CommandBuffer() { name = $"Blur Effect {NextInstanceID++}" };
                }

                return commandBuffer;
            }
        }

        private int prevMaxBlurableSize = 0;
        private BlurFilter prevParams = default;
        private Vector2 prevUVScale = Vector2.zero;
        private Vector2 prevUIBlockSize = Vector2.zero;
        private Rect prevViewportRect;
        private List<Vector4> computeBlurs = new List<Vector4>();
        private int[] tempTextureIDs = new int[]
        {
            Shader.PropertyToID("_TextureBlurTemp1"),
            Shader.PropertyToID("_TextureBlurTemp2"),
        };
        private RenderTexture finalBlurredTexture = null;
        #endregion

        public void ApplyFilter(UIBlock2D uiBlock, Rect viewportRect, BlurFilter filter, Texture texture, out bool blurTextureChanged)
        {
            Vector2 uiBlockSize = uiBlock.CalculatedSize.XY.Value;
            Vector2 uvScale = GetUVScale(uiBlock, texture);
            int blurableSize = filter.GetBlurableSize(texture);

            blurTextureChanged = TryUpdateOutputTexture(uiBlock, texture);

            bool propertyChanged = !prevParams.Equals(filter);
            propertyChanged |= prevUIBlockSize != uiBlockSize;
            propertyChanged |= prevUVScale != uvScale;
            propertyChanged |= prevViewportRect != viewportRect;
            propertyChanged |= prevMaxBlurableSize != blurableSize;

            if (blurTextureChanged || propertyChanged || CommandBuffer.sizeInBytes == 0)
            {
                prevParams = filter;
                prevUIBlockSize = uiBlockSize;
                prevUVScale = uvScale;
                prevMaxBlurableSize = blurableSize;
                prevViewportRect = viewportRect;

                UpdateBlurCommands(uiBlock, filter, uvScale, viewportRect, texture);
            }

            Graphics.ExecuteCommandBuffer(CommandBuffer);
        }

        private bool TryUpdateOutputTexture(UIBlock2D uiBlock, Texture texture)
        {
            Vector2 inputTextureSize = texture.Size();

            bool needFinalTexture = finalBlurredTexture == null;
            bool finalTextureDimensionsChanged = !needFinalTexture && finalBlurredTexture.Size() != inputTextureSize;

            if (!needFinalTexture && !finalTextureDimensionsChanged)
            {
                return false;
            }

            ReleaseOutputTexture(uiBlock);

            finalBlurredTexture = RenderTexture.GetTemporary((int)inputTextureSize.x, (int)inputTextureSize.y, TempTextureDepth);
            finalBlurredTexture.name = "Blurred Texture";

            return true;
        }

        private void ReleaseOutputTexture(UIBlock2D uiBlock)
        {
            if (finalBlurredTexture != null)
            {
                RenderTexture.ReleaseTemporary(finalBlurredTexture);
                finalBlurredTexture = null;
                uiBlock.ClearImage();
            }
        }

        private void UpdateBlurCommands(UIBlock2D uiBlock, BlurFilter filter, Vector2 uvScale, Rect viewportRect, Texture inputTexture)
        {
            CommandBuffer.Clear();

            float blur = Mathf.Max(filter.BlurRadius, 0);

            // input is in range -1 to 1, so we shift by default colors to put into range 0 to 2
            Vector4 csb = new Vector4(filter.Contrast, filter.Saturation, filter.Brightness, 0) + DefaultColors;

            float grainFilter = filter.Grain * GrainScalar;

            float baseWidth = finalBlurredTexture.width;
            float baseHeight = finalBlurredTexture.height;
            float basis = Mathf.Min(filter.GetBlurableSize(inputTexture), Mathf.Max(baseWidth, baseHeight));

            int blurableWidth = Mathf.RoundToInt(baseWidth > baseHeight ? basis : basis * baseWidth / baseHeight);
            int blurableHeight = Mathf.RoundToInt(baseHeight > baseWidth ? basis : basis * baseHeight / baseWidth);
            Vector2 blurTextureSize = new Vector2(blurableWidth, blurableHeight);

            Vector2 inputTextureSize = inputTexture.Size();

            Vector2 pixelsPerUnit = (inputTextureSize / uvScale) / uiBlock.CalculatedSize.XY.Value;

            float pixelSize = BlurPixelSize * Mathf.Max(pixelsPerUnit.x, pixelsPerUnit.y);

            Vector2 texelBlur = blur * new Vector2(pixelSize / inputTextureSize.x, pixelSize / inputTextureSize.y);

            // Divide by BlurPixelSize because, while texelBlur is technically the right offset,
            // the algorithm will sample the pixels adjacent to the exterior edges in the first pass
            // those external samples will bleed into the actual UIBlock rect over sequential passes.
            // So we clip extra pixels to have the final interior rectangle only include samples from
            // the input texture. 
            Vector2 blurUVs = texelBlur / BlurPixelSize;

            Rect scissor = GetScissorRect(blurTextureSize, viewportRect, blurUVs);

            Vector2 centerUV = viewportRect.center;
            Vector2 sizeUV = viewportRect.size;

            if (blur == 0)
            {
                bool colorAdjustments = !IsDefaultColors(csb);
                bool grain = grainFilter > 0;

                if (colorAdjustments || grain)
                {
                    ColorAdjustmentMaterial.SetKeyword(COLOR_ADJUSTMENT_ON, colorAdjustments);
                    ColorAdjustmentMaterial.SetKeyword(GRAIN_ON, grain);
                    ColorAdjustmentMaterial.SetVector(ClipUVsID, GetClipUVs(scissor, blurTextureSize));
                    ColorAdjustmentMaterial.SetVector(GrainUVsID, new Vector4(centerUV.x, centerUV.y, sizeUV.x, sizeUV.y));
                    ColorAdjustmentMaterial.SetVector(ColorAdjustmentID, csb);
                    ColorAdjustmentMaterial.SetFloat(GrainID, grainFilter);
                    ColorAdjustmentMaterial.SetVector(UVScaleID, GetShaderUVScale(finalBlurredTexture));

                    CommandBuffer.Blit(inputTexture, finalBlurredTexture, ColorAdjustmentMaterial, ColorFiltersPass);
                }
                else
                {
                    CommandBuffer.Blit(inputTexture, finalBlurredTexture);
                }

                return;
            }


            float blurMax = Mathf.Max(blurTextureSize.x, blurTextureSize.y);

            float passBasis = Mathf.Min(blurMax, blur);

            int logPass = Mathf.FloorToInt(Mathf.Log(passBasis, BlurLogBase)) + 1;
            int passes = Mathf.Clamp(logPass, MinPasses, MaxPasses);

            bool useComputeShader = filter.UseComputeShader && ComputeShader != null && ComputeShaderSupported;

            UnityEngine.Experimental.Rendering.GraphicsFormat format = QualitySettings.activeColorSpace == ColorSpace.Linear ? UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_SRGB :
                                                                                                                               UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_UNorm;

            CommandBuffer.GetTemporaryRT(tempTextureIDs[0], (int)blurTextureSize.x, (int)blurTextureSize.y, TempTextureDepth, FilterMode.Bilinear, format, antiAliasing: 1, enableRandomWrite: useComputeShader);
            CommandBuffer.GetTemporaryRT(tempTextureIDs[1], (int)blurTextureSize.x, (int)blurTextureSize.y, TempTextureDepth, FilterMode.Bilinear, format, antiAliasing: 1, enableRandomWrite: useComputeShader);

            if (useComputeShader)
            {
                UpdateComputeCommands(passes, texelBlur, csb, blurTextureSize, scissor, inputTexture);
            }
            else
            {
                UpdateBlitCommands(passes, texelBlur, csb, blurTextureSize, scissor, inputTexture);
            }

            GrainMaterial.SetKeyword(GRAIN_ON, grainFilter > 0);
            GrainMaterial.SetFloat(GrainID, grainFilter);
            GrainMaterial.SetVector(ClipUVsID, GetClipUVs(scissor, blurTextureSize));
            GrainMaterial.SetVector(GrainUVsID, new Vector4(centerUV.x, centerUV.y, sizeUV.x, sizeUV.y));
            GrainMaterial.SetVector(UVScaleID, GetShaderUVScale(finalBlurredTexture));

            CommandBuffer.Blit(tempTextureIDs[0], finalBlurredTexture, GrainMaterial, ColorFiltersPass);

            CommandBuffer.ReleaseTemporaryRT(tempTextureIDs[0]);
            CommandBuffer.ReleaseTemporaryRT(tempTextureIDs[1]);
        }

        private void UpdateComputeCommands(int passes, Vector2 texelBlur, Vector4 csb, Vector2 blurableSize, Rect scissor, Texture inputTexture)
        {
            Vector3Int threads = ComputeThreads;

            int blurGroupsX = Mathf.Max(Mathf.CeilToInt((float)scissor.width / threads.x), 1);
            int blurGroupsY = Mathf.Max(Mathf.CeilToInt((float)scissor.height / threads.y), 1);
            int blurGroupsZ = Mathf.Max(threads.z, 1);

            int kernel = ComputeKernel;

            computeBlurs.Clear();

            computeBlurs.Add(new Vector4(-texelBlur.x, -texelBlur.y, texelBlur.x, texelBlur.y));

            ComputeShader firstShader = !IsDefaultColors(csb) ? ColorAdjustmentComputeShader : ComputeShader;

            CommandBuffer.SetComputeVectorParam(firstShader, OffsetID, scissor.position);
            CommandBuffer.SetComputeVectorParam(firstShader, ColorAdjustmentID, csb);
            CommandBuffer.SetComputeVectorParam(firstShader, BlurID, computeBlurs[0]);
            CommandBuffer.SetComputeVectorParam(firstShader, UVScaleID, GetShaderUVScale((int)blurableSize.x, (int)blurableSize.y));
            CommandBuffer.SetComputeTextureParam(firstShader, kernel, InputTextureID, inputTexture);
            CommandBuffer.SetComputeTextureParam(firstShader, kernel, OutputTextureID, tempTextureIDs[0]);
            CommandBuffer.DispatchCompute(firstShader, kernel, blurGroupsX, blurGroupsY, blurGroupsZ);

            CommandBuffer.SetComputeVectorParam(ComputeShader, OffsetID, scissor.position);
            CommandBuffer.SetComputeVectorParam(ComputeShader, UVScaleID, GetShaderUVScale((int)blurableSize.x, (int)blurableSize.y));

            texelBlur *= TexelPassDownScale;

            for (int pass = 1; pass < passes; ++pass)
            {
                computeBlurs.Add(new Vector4(-texelBlur.x, -texelBlur.y, texelBlur.x, texelBlur.y));

                CommandBuffer.SetComputeVectorParam(ComputeShader, BlurID, computeBlurs[pass]);
                CommandBuffer.SetComputeTextureParam(ComputeShader, kernel, InputTextureID, tempTextureIDs[0]);
                CommandBuffer.SetComputeTextureParam(ComputeShader, kernel, OutputTextureID, tempTextureIDs[1]);
                CommandBuffer.DispatchCompute(ComputeShader, kernel, blurGroupsX, blurGroupsY, blurGroupsZ);

                Swap01(tempTextureIDs);

                texelBlur *= TexelPassDownScale;
            }

            for (int pass = passes - 2; pass >= 0; --pass)
            {
                CommandBuffer.SetComputeVectorParam(ComputeShader, BlurID, computeBlurs[pass]);
                CommandBuffer.SetComputeTextureParam(ComputeShader, kernel, InputTextureID, tempTextureIDs[0]);
                CommandBuffer.SetComputeTextureParam(ComputeShader, kernel, OutputTextureID, tempTextureIDs[1]);
                CommandBuffer.DispatchCompute(ComputeShader, kernel, blurGroupsX, blurGroupsY, blurGroupsZ);

                Swap01(tempTextureIDs);
            }
        }

        private void UpdateBlitCommands(int passes, Vector2 texelBlur, Vector4 csb, Vector2 blurableSize, Rect scissor, Texture inputTexture)
        {
            ColorAdjustmentMaterial.EnableKeyword(COLOR_ADJUSTMENT_ON);
            ColorAdjustmentMaterial.DisableKeyword(GRAIN_ON);

            Material blurMaterial = !IsDefaultColors(csb) ? ColorAdjustmentMaterial : BlurMaterials[0];

            Vector4 clipUVs = GetClipUVs(scissor, blurableSize);

            blurMaterial.SetVector(BlurID, new Vector4(-texelBlur.x, -texelBlur.y, texelBlur.x, texelBlur.y));
            BlurMaterials[0].SetVector(BlurID, new Vector4(-texelBlur.x, -texelBlur.y, texelBlur.x, texelBlur.y));
            blurMaterial.SetVector(ColorAdjustmentID, csb);

            BlurMaterials[0].SetVector(ClipUVsID, clipUVs);
            blurMaterial.SetVector(ClipUVsID, clipUVs);

            CommandBuffer.Blit(inputTexture, tempTextureIDs[0], blurMaterial, BlurPass);

            texelBlur *= TexelPassDownScale;

            for (int pass = 1; pass < passes; ++pass)
            {
                blurMaterial = BlurMaterials[pass];

                blurMaterial.SetVector(BlurID, new Vector4(-texelBlur.x, -texelBlur.y, texelBlur.x, texelBlur.y));
                blurMaterial.SetVector(ClipUVsID, clipUVs);

                CommandBuffer.Blit(tempTextureIDs[0], tempTextureIDs[1], blurMaterial, BlurPass);

                Swap01(tempTextureIDs);

                texelBlur *= TexelPassDownScale;
            }

            for (int pass = passes - 2; pass >= 0; --pass)
            {
                CommandBuffer.Blit(tempTextureIDs[0], tempTextureIDs[1], BlurMaterials[pass], BlurPass);

                Swap01(tempTextureIDs);
            }
        }

        public void Unset(UIBlock2D uiBlock)
        {
            ReleaseOutputTexture(uiBlock);
            CommandBuffer.Clear();
            prevParams = default;
        }

        public void Dispose()
        {
            DisposeCommandBuffer();

            for (int i = 0; i < MaxPasses; ++i)
            {
                Destroy(blurMaterials[i]);
                blurMaterials[i] = null;
            }

            Destroy(colorAdjustmentMaterial);
            colorAdjustmentMaterial = null;
            Destroy(computeShader);
            computeShader = null;
            Destroy(colorAdjustmentComputeShader);
            colorAdjustmentComputeShader = null;
        }

        public void DisposeCommandBuffer()
        {
            if (commandBuffer == null)
            {
                return;
            }

            commandBuffer.Dispose();
            commandBuffer = null;
        }

        private static void Swap01<T>(T[] textures)
        {
            T temp = textures[0];
            textures[0] = textures[1];
            textures[1] = temp;
        }

        public static Vector2 GetUVScale(UIBlock2D uiBlock, Texture image)
        {
            ImageAdjustment imageAdjustment = uiBlock.ImageAdjustment;

            if (imageAdjustment.ScaleMode == ImageScaleMode.Manual)
            {
                return imageAdjustment.UVScale;
            }

            Vector2 imageSize = new Vector2(image.width, image.height);
            Vector2 uiBlockSize = uiBlock.CalculatedSize.XY.Value;
            float imageAspectRatio = imageSize.x / imageSize.y;
            float uiBlockAspectRatio = uiBlockSize.x / uiBlockSize.y;
            float relativeAspectRatio = imageAspectRatio / uiBlockAspectRatio;

            switch (imageAdjustment.ScaleMode)
            {
                case ImageScaleMode.Fit:
                    return relativeAspectRatio > 1 ? new Vector2(1, 1 / relativeAspectRatio) : new Vector2(relativeAspectRatio, 1);
                case ImageScaleMode.Envelope:
                    return relativeAspectRatio > 1 ? new Vector2(relativeAspectRatio, 1) : new Vector2(1, 1 / relativeAspectRatio);
                default:
                    return Vector2.one;
            }
        }

        private static Vector4 GetShaderUVScale(Texture image) => GetShaderUVScale(image.width, image.height);
        private static Vector4 GetShaderUVScale(int width, int height) => new Vector4(1f / width, 1f / height, width, height);

        private static Rect GetScissorRect(Vector2 blurableSize, Rect viewportRect, Vector2 blurUVs)
        {
            float x = Mathf.Max(Mathf.FloorToInt((viewportRect.x - blurUVs.x) * blurableSize.x), 0);
            float y = Mathf.Max(Mathf.FloorToInt((viewportRect.y - blurUVs.y) * blurableSize.y), 0);
            float width = Mathf.Min(Mathf.CeilToInt((viewportRect.width + 2 * blurUVs.x) * blurableSize.x), blurableSize.x);
            float height = Mathf.Min(Mathf.CeilToInt((viewportRect.height + 2 * blurUVs.y) * blurableSize.y), blurableSize.y);

            return new Rect(x, y, width, height);
        }

        private Vector4 GetClipUVs(Rect scissor, Vector2 full)
        {
            Vector2 minUV = Vector2.Max(scissor.min, Vector2.zero) / full;
            Vector2 maxUV = Vector2.Min(scissor.max, full) / full;

            return new Vector4(minUV.x, minUV.y, maxUV.x, maxUV.y);
        }

        private static void Destroy<T>(T obj) where T : UnityEngine.Object
        {
            if (obj == null)
            {
                return;
            }

            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(obj);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(obj);
            }
        }

        private static bool IsDefaultColors(Vector4 csb)
        {
            return Mathf.Abs(csb.x - DefaultColors.x) < Epsilon &&
                   Mathf.Abs(csb.y - DefaultColors.y) < Epsilon &&
                   Mathf.Abs(csb.z - DefaultColors.z) < Epsilon &&
                   Mathf.Abs(csb.w - DefaultColors.w) < Epsilon;
        }

        private static bool ComputeShaderSupported => SystemInfo.supportsComputeShaders && !IsMobileOpenGLLinear;

        /// <summary>
        /// https://issuetracker.unity3d.com/issues/android-compute-shader-is-not-working-with-linear-color-space-when-it-is-built-to-android-device
        /// https://forum.unity.com/threads/compute-shaders-dont-work-on-android-with-linear-lighting.611314/
        /// </summary>
        private static bool IsMobileOpenGLLinear => QualitySettings.activeColorSpace == ColorSpace.Linear && IsOpenGL(SystemInfo.graphicsDeviceType) && Application.isMobilePlatform;
        private static bool IsOpenGL(GraphicsDeviceType deviceType) => deviceType == GraphicsDeviceType.OpenGLES3 || deviceType == GraphicsDeviceType.OpenGLCore;
        private static bool UseLinearSpaceComputeShader => QualitySettings.activeColorSpace == ColorSpace.Linear && SystemInfo.graphicsDeviceType != GraphicsDeviceType.Metal;
    }

    internal static class TextureExtensions
    {
        public static Vector2 Size(this Texture texture) => new Vector2(texture.width, texture.height);
    }

    internal static class MaterialExtensions
    {
        public static void SetKeyword(this Material material, string keyword, bool enable)
        {
            if (enable)
            {
                material.EnableKeyword(keyword);
            }
            else
            {
                material.DisableKeyword(keyword);
            }
        }
    }
}
