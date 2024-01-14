using Nova;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NovaSamples.Effects
{
    /// <summary>
    /// The automated cadence to perform a target action
    /// </summary>
    public enum UpdateFrequency
    {
        FrameInterval,
        OnEnable,
        ManualOnly
    }

    /// <summary>
    /// The usage of a given blur effect
    /// </summary>
    public enum BlurMode
    {
        /// <summary>
        /// Blurs the input texture, doesn't modify UVs.
        /// </summary>
        LayerBlur,

        /// <summary>
        /// Will modify the UVs of the UIBlock 
        /// to align the input texture to the UIBlock's 
        /// position within the viewport
        /// </summary>
        BackgroundBlur
    }

    /// <summary>
    /// Applies a gaussian-style blur (as well as optional color filters) using the given <see cref="InputTexture"/> to create the <see cref="OutputTexture"/>,
    /// which then gets rendered via the attached <see cref="UIBlock"/>.
    /// </summary>
    /// <remarks>
    /// Only the pixels rendered by the attached <see cref="UIBlock"/> will be be blurred. For scenarios looking to share the <see cref="OutputTexture"/> across
    /// multiple UIBlocks (e.g. via <see cref="AlignUVsToViewportPosition(UIBlock2D, Camera)"/>), this component should be attached to a UIBlock2D which fills the 
    /// entire screen (but can then have <see cref="UIBlock.Visible"/> set to <c>false</c> or <see cref="UIBlock2D.BodyEnabled"/> set to <c>false</c>). 
    /// </remarks>
    [ExecuteAlways, RequireComponent(typeof(UIBlock2D)), DisallowMultipleComponent]
    public class BlurEffect : MonoBehaviour
    {
        #region Public Fields
        internal const int MinDownscale = BlurFilter.MinDownscale;
        internal const int MaxDownscale = BlurFilter.MaxDownscale;
        private static readonly Vector2 Vector2_Half = new Vector2(0.5f, 0.5f);

        /// <summary>
        /// Event fired at the end of <see cref="Reblur"/> whenever the underlying <see cref="OutputTexture"/> object
        /// changes, which can happen will happen when the resolution of the input texture changes.
        /// dimensions.
        /// </summary>
        public event Action<RenderTexture> OnOutputTextureObjectChanged = null;

        [Header("Texture To Blur")]
        [Tooltip("This is the texture to blur and assign to the attached UI Block.\n\nThis texture will be copied before the blur is applied and will not be modified directly.")]
        public Texture InputTexture = null;

        [Header("Blur Options")]
        [SerializeField, Min(0), Tooltip("Effectively the blur strength. Higher values means \"more blurred\".")]
        private float blurRadius = 8;
        public float BlurRadius
        {
            get => blurRadius;
            set => blurRadius = Mathf.Max(value, 0);
        }

        [Tooltip("When set to \"Background Blur\", this will adjust the Image Scale and Center on the attached UI Block (and will change the Image Scale Mode to Manual to do so), which is useful in creating the effect that the attached UI block is blurring the content directly behind it.\n\n\"Layer Blur\" will just blur the texture and won't change any UI Block properties other than assigning the output texture.")]
        public BlurMode BlurMode = BlurMode.LayerBlur;
        [ShowIf(nameof(BlurMode), BlurMode.BackgroundBlur), Tooltip("This camera's perspective is used to determine the proper background \"cutout\" for the attached UI Block, which means this Crop Camera should not be attached to this Game Object - because then the attached UI Block cannot be within the camera's viewport.\n\nIf left unassigned, the Screen Space target camera will be used if it exists, and the main camera will be used as a fallback.\n\nThis only needs to be set explicitly in scenarios where the background camera has a different projection/perspective than the primary camera rendering the UI.\n\nOnly applicable when \"Blur Mode\" is set to \"Background Blur\".")]
        public Camera CropCamera = null;

        [Header("Color Adjustments")]
        [SerializeField, Range(-1, 1), Tooltip("Adjust the contrast of the final image. 0 means default contrast.")]
        private float contrast = 0;
        public float Contrast
        {
            get => contrast;
            set => contrast = Mathf.Clamp(value, -1, 1);
        }
        [SerializeField, Range(-1, 1), Tooltip("Adjust the saturation of the final image. 0 means default saturation.")]
        private float saturation = 0;
        public float Saturation
        {
            get => saturation;
            set => saturation = Mathf.Clamp(value, -1, 1);
        }
        [SerializeField, Range(-1, 1), Tooltip("Adjust the brightness of the final image. 0 means default brightness.")]
        private float brightness = 0;
        public float Brightness
        {
            get => brightness;
            set => brightness = Mathf.Clamp(value, -1, 1);
        }
        [SerializeField, Range(0, 1), Tooltip("Adjust the grain of the final image. 0 means no grain.\n\nGrain is applied per pixel, which means low resolution images rendered at a large size will have more visible \"noise grains\".\n\nFor world-space background blurs, the grain will \"drift\" as the camera moves relative to this object.")]
        private float grain = 0;
        public float Grain
        {
            get => grain;
            set => grain = Mathf.Clamp(value, 0, 1);
        }

        [Header("Performance")]
        [Range(MinDownscale, MaxDownscale), Tooltip("This is the resolution downscale factor, relative to the input texture, to use for the intermediate blur steps when creating the effect.\n\nThe blur step resolution will be \"Full Res / (2 ^ DownscaleFactor)\".\n\n0 => Full Res\n1 => Half Res\n2 => Quarter Res\nEtc.\n\nHigher is more performant because it means fewer texture samples in the shader, but too high may come at the cost of blur \"accuracy\" or may start to appear pixelated and/or display downsampling artifacts with a lower blur radius and/or larger UI Block size.\n\nWith a high resolution image, large blur radius, or small UI Block size, this value can be relatively high, e.g. 4 or 5, with minimal perceptible loss to blur quality.\n\n*Notes here about UI Block size only apply when \"Blur Mode\" is set to \"Layer Blur\".")]
        public int BlurDownscaleFactor = 0;
        [Tooltip("The automated cadence the \"Input Texture\" should be reblurred.")]
        public UpdateFrequency BlurFrequency = UpdateFrequency.FrameInterval;
        [ShowIf(nameof(BlurFrequency), UpdateFrequency.FrameInterval), Min(1), Tooltip("Reblur every this number of frames. A value of 1 will reblur on every frame. Only applicable when \"Blur Frequency\" is set to \"Frame Interval\".")]
        public int BlurFrameInterval = 1;
        [SerializeField, Tooltip("Not all devices/platforms support compute shaders*, but typically the compute shader implementation is much faster than the fragment shader implementation.\n\nWhen enabled, the compute shader implementation will be used wherever it's supported, and the fragment shader will be used as a fallback. When disabled, the fragment shader implementation will always be used.\n\nGeneral recommendation is to leave this enabled. It's mainly exposed for debugging purposes as well as an option in unforseen nuances with certain hardware + graphics API combinations.\n\n*Known configurations which will use the fallback implementation:\n- WebGL\n- Android + OpenGLES + Linear Space")]
        private bool defaultToComputeShader = true;
        public bool DefaultToComputeShader
        {
            get => defaultToComputeShader;
            set
            {
                defaultToComputeShader = value;
            }
        }

        public RenderTexture OutputTexture => textureBlur.OutputTexture;

        [NonSerialized, HideInInspector]
        private UIBlock2D uiBlock = null;
        public UIBlock2D UIBlock
        {
            get
            {
                if (uiBlock == null)
                {
                    uiBlock = GetComponent<UIBlock2D>();
                }

                return uiBlock;
            }
        }
        #endregion

        #region Private Fields
        #region Cached Values for Diffing
        [NonSerialized, HideInInspector]
        private Vector3 previousUIBlockPosition = Vector3.zero;
        #endregion

        [NonSerialized]
        private TextureBlur textureBlur = new TextureBlur();

        private bool BlurOnUpdate => BlurFrequency == UpdateFrequency.FrameInterval && Time.renderedFrameCount % BlurFrameInterval == 0;

#if UNITY_EDITOR
        [NonSerialized, HideInInspector]
        private bool editorReblur = false;
#endif
        #endregion

        #region Public API
        /// <summary>
        /// Update the <see cref="OutputTexture"/> by applying a guassian blur and color filters to the assigned <see cref="InputTexture"/>.
        /// </summary>
        public void Reblur()
        {
#if UNITY_EDITOR
            bool wasDirtiedInEditor = editorReblur;
            editorReblur = false;
#endif
            if (InputTexture == null)
            {
                RenderTexture prevTexture = textureBlur.OutputTexture;
                textureBlur.Unset(uiBlock);

                if (textureBlur.OutputTexture != prevTexture)
                {
                    OnOutputTextureObjectChanged?.Invoke(textureBlur.OutputTexture);
                }

                return;
            }

            if (previousUIBlockPosition != UIBlock.transform.localPosition)
            {
                // CalculateLayout will overwrite the modified transform position,
                // but this will honor it and calculate the other layout properties
                UIBlock.TrySetLocalPosition(UIBlock.transform.localPosition);
            }
            else
            {
                UIBlock.CalculateLayout();
            }

            previousUIBlockPosition = UIBlock.transform.localPosition;

            Vector2 uvExtents = 0.5f * Vector2.one / Vector2.Max(TextureBlur.GetUVScale(UIBlock, InputTexture), Vector2.one);
            Rect viewportRect = Rect.MinMaxRect(-uvExtents.x + 0.5f, -uvExtents.y + 0.5f, uvExtents.x + 0.5f, uvExtents.y + 0.5f);

            if (BlurMode == BlurMode.BackgroundBlur)
            {
                viewportRect = GetViewportRect(UIBlock, CropCamera);

                ref ImageAdjustment adjustment = ref uiBlock.ImageAdjustment;
                Vector2 uvScale = Vector2.one / viewportRect.size;
                Vector2 uvCenter = (viewportRect.center - (Vector2.one * 0.5f)) / 0.5f;
#if UNITY_EDITOR
                if (wasDirtiedInEditor && (adjustment.ScaleMode != ImageScaleMode.Manual || adjustment.UVScale != uvScale || adjustment.CenterUV != uvCenter))
                {
                    UnityEditor.Undo.RecordObject(UIBlock, "Image Crop");
                }
#endif
                adjustment.ScaleMode = ImageScaleMode.Manual;
                adjustment.UVScale = uvScale;
                adjustment.CenterUV = uvCenter;
            }

            BlurFilter filter = new BlurFilter()
            {
                BlurRadius = BlurRadius,
                BlurMode = BlurMode,
                Contrast = Contrast,
                Saturation = Saturation,
                Brightness = Brightness,
                Grain = Grain,
                UseComputeShader = DefaultToComputeShader,
                BlurDownscaleFactor = BlurDownscaleFactor,
            };

            textureBlur.ApplyFilter(UIBlock, viewportRect, filter, InputTexture, out bool blurOutputTextureChanged);

            if (UIBlock.ImagePackMode != ImagePackMode.Unpacked)
            {
#if UNITY_EDITOR
                if (wasDirtiedInEditor)
                {
                    UnityEditor.Undo.RecordObject(UIBlock, "Image Mode");
                }
#endif
                UIBlock.ImagePackMode = ImagePackMode.Unpacked;
            }

            if (UIBlock.RenderTexture != textureBlur.OutputTexture)
            {
                UIBlock.SetImage(textureBlur.OutputTexture);
            }

            if (blurOutputTextureChanged)
            {
                OnOutputTextureObjectChanged?.Invoke(textureBlur.OutputTexture);
            }
        }

        /// <summary>
        /// Modifies the <paramref name="uiBlock"/> Image's Scale/Center UVs to align to the <paramref name="uiBlock"/>'s position within the camera viewport.
        /// Useful when looking to reuse a single full-screen blurred texture as the image assigned to multiple UIBlocks.
        /// </summary>
        /// <param name="uiBlock">The UIBlock2D whose <see cref="UIBlock2D.ImageAdjustment"/> will be modified.</param>
        /// <param name="camera">The camera to use as the viewport reference. ScreenSpace.TargetCamera or Camera.main will be used if left null.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="uiBlock"/> is null.</exception>
        public static void AlignUVsToViewportPosition(UIBlock2D uiBlock, Camera camera = null)
        {
            Rect viewportRect = GetViewportRect(uiBlock, camera);

            ref ImageAdjustment adjustment = ref uiBlock.ImageAdjustment;
            adjustment.ScaleMode = ImageScaleMode.Manual;
            adjustment.UVScale = Vector2.one / viewportRect.size;
            adjustment.CenterUV = (viewportRect.center - (Vector2.one * 0.5f)) / 0.5f;
        }
        #endregion

        #region Private API
        private void OnEnable()
        {
            if (BlurFrequency != UpdateFrequency.ManualOnly && !BlurOnUpdate)
            {
                Reblur();
            }

#if UNITY_EDITOR
            UnityEditor.SceneManagement.EditorSceneManager.sceneSaved += DisposeCommandBuffer;
#endif
        }

        private void LateUpdate()
        {
            if (InputTexture == null)
            {
                RenderTexture rt = textureBlur.OutputTexture;
                textureBlur.Unset(uiBlock);

                if (textureBlur.OutputTexture != rt)
                {
                    OnOutputTextureObjectChanged?.Invoke(textureBlur.OutputTexture);
                }
            }

            if (!BlurOnUpdate)
            {
#if UNITY_EDITOR
                if (Application.IsPlaying(this) && !editorReblur)
                {
                    return;
                }
#else
                return;
#endif
            }

            Reblur();
        }

        private void OnDisable()
        {
            RenderTexture rt = textureBlur.OutputTexture;
            textureBlur.Unset(uiBlock);

            if (textureBlur.OutputTexture != rt)
            {
                OnOutputTextureObjectChanged?.Invoke(textureBlur.OutputTexture);
            }

            if (gameObject.activeSelf)
            {
                switch (InputTexture)
                {
                    case Texture2D tex2D:
                        UIBlock.SetImage(tex2D);
                        break;
                    case RenderTexture renderTexture:
                        UIBlock.SetImage(renderTexture);
                        break;
                }
            }

#if UNITY_EDITOR
            UnityEditor.SceneManagement.EditorSceneManager.sceneSaved -= DisposeCommandBuffer;
#endif
        }

        private void OnDestroy() => textureBlur.Dispose();

        private void DisposeCommandBuffer(Scene scene = default) => textureBlur.DisposeCommandBuffer();

#if UNITY_EDITOR
        private void OnValidate() => editorReblur = gameObject.activeInHierarchy && enabled;
#endif

        private static Rect GetViewportRect(UIBlock2D uiBlock, Camera camera)
        {
            if (uiBlock == null)
            {
                throw new ArgumentNullException(nameof(uiBlock));
            }

            camera = GetReferenceCamera(uiBlock, camera, out bool screenSpace);

            if (camera == null)
            {
                Debug.LogError($"A main camera could not be found. Please provide a {nameof(camera)} value explicitly.", uiBlock);
                return new Rect(0, 0, 1, 1);
            }

            if (camera.orthographic || screenSpace)
            {
                return GetViewportRect(uiBlock.CalculatedSize.XY.Value, uiBlock.transform.localToWorldMatrix, camera);
            }

            float depth = Mathf.Abs(camera.transform.InverseTransformPoint(uiBlock.transform.position).z);
            Vector3 positionAtCameraFovCenter = camera.transform.position + camera.transform.forward * depth;
            Quaternion cameraRotation = camera.transform.rotation;
            
            // Get the localToWorld of the camera-axis-aligned UIBlock positioned directly in front of the camera
            Matrix4x4 adjustedUIBlockToWorld = Matrix4x4.TRS(positionAtCameraFovCenter, cameraRotation, uiBlock.transform.lossyScale);
                        
            // Size at unrotated camera center to minimize skew from projection
            Vector2 size = GetViewportRect(uiBlock.CalculatedSize.XY.Value, adjustedUIBlockToWorld, camera).size;

            // Apply z-rotation to projected center position
            Matrix4x4 cameraZ = Matrix4x4.Rotate(Quaternion.Euler(0, 0, camera.transform.eulerAngles.z));
            Matrix4x4 uiBlockToProjection = cameraZ * camera.projectionMatrix * camera.worldToCameraMatrix * uiBlock.transform.localToWorldMatrix;

            // Center rotated for UV alignment
            Vector2 center = ProjectedPointToViewport(uiBlockToProjection * new Vector4(0, 0, 0, 1));

            Vector2 fromMiddle = Vector2.Max(center - Vector2_Half, Vector2_Half - center);
            Vector2 baseScalar = (Vector2_Half + fromMiddle) / Vector2_Half;

            float xWeight = Mathf.Abs(AngleBetweenAroundAxis(camera.transform.forward, uiBlock.transform.forward, camera.transform.up)) / (camera.fieldOfView * camera.aspect);
            float yWeight = Mathf.Abs(AngleBetweenAroundAxis(camera.transform.forward, uiBlock.transform.forward, camera.transform.right)) / camera.fieldOfView;

            Vector2 distortionScalar = new Vector2(Mathf.Lerp(1, baseScalar.x, xWeight),
                                                   Mathf.Lerp(1, baseScalar.y, yWeight));

            size *= distortionScalar;

            return CreateRect(center, size);
        }

        private static Rect GetViewportRect(Vector2 uiBlockSize, Matrix4x4 modelMatrix, Camera camera)
        {
            Vector2 extents = 0.5f * uiBlockSize;

            Matrix4x4 uiBlockToProjection = camera.projectionMatrix * camera.worldToCameraMatrix * modelMatrix;

            Vector4 p1 = ProjectedPointToViewport(uiBlockToProjection * new Vector4(-extents.x, -extents.y, 0, 1));
            Vector4 p2 = ProjectedPointToViewport(uiBlockToProjection * new Vector4(-extents.x, extents.y, 0, 1));
            Vector4 p3 = ProjectedPointToViewport(uiBlockToProjection * new Vector4(extents.x, -extents.y, 0, 1));
            Vector4 p4 = ProjectedPointToViewport(uiBlockToProjection * new Vector4(extents.x, extents.y, 0, 1));

            Vector2 maxPoint = Vector2.Max(Vector2.Max(p1, p2), Vector2.Max(p3, p4));
            Vector2 minPoint = Vector2.Min(Vector2.Min(p1, p2), Vector2.Min(p3, p4));

            Vector2 size = maxPoint - minPoint;
            Vector2 center = 0.5f * (maxPoint + minPoint);

            return CreateRect(center, size);
        }

        private static Vector2 ProjectedPointToViewport(Vector4 projected) => projected.w == 0 ? Vector2.zero : new Vector2((0.5f * projected.x / projected.w) + 0.5f, (0.5f * projected.y / projected.w) + 0.5f);
        private static Rect CreateRect(Vector2 center, Vector2 size) => new Rect(center - 0.5f * size, size);
        private static float AngleBetweenAroundAxis(Vector3 from, Vector3 to, Vector3 axis)
        {
            Vector3 right = Vector3.Cross(axis, from);
            from = Vector3.Cross(right, axis);

            return Mathf.Rad2Deg * Mathf.Atan2(Vector3.Dot(to, right), Vector3.Dot(to, from));
        }

        internal static Camera GetReferenceCamera(UIBlock uiBlock, Camera referenceCamera, out bool screenSpaceCamera)
        {
            UIBlock root = uiBlock.Root;
            ScreenSpace screenSpace = null;

            screenSpaceCamera = root != null && root.TryGetComponent(out screenSpace) && screenSpace.enabled;

            if (referenceCamera != null)
            {
                return referenceCamera;
            }

            if (screenSpaceCamera)
            {
                referenceCamera = screenSpace.TargetCamera;
            }

            if (referenceCamera != null)
            {
                return referenceCamera;
            }

            return Camera.main;
        }
        #endregion
    }
}
