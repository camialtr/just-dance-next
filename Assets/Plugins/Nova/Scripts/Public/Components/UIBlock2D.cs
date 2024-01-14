// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A <see cref="UIBlock"/> with an adjustable, rounded-corner rectangle mesh.
    /// </summary>
    /// <remarks>
    /// Supports a wide range of stylistic features including:
    /// <list type="bullet">
    /// <item><description>Rendering images</description></item>
    /// <item><description><see cref="Nova.Border"/></description></item>
    /// <item><description><see cref="RadialGradient"/></description></item>
    /// <item><description><see cref="Nova.Shadow"/></description></item>
    /// </list>
    /// </remarks>
    [ExecuteAlways]
    [HelpURL("https://novaui.io/manual/UIBlock2D.html")]
    [AddComponentMenu("Nova/UIBlock 2D")]
    public sealed class UIBlock2D : UIBlock, InternalType_7
    {
        #region Public

        /// <summary>
        /// A gradient effect, visually blended with the body <see cref="Color">Color</see> and image (i.e. <see cref="Sprite">Sprite</see>, <see cref="Texture">Texture</see>, or <see cref="RenderTexture">RenderTexture</see>), if it exists.
        /// </summary>
        /// <remarks>
        /// <see cref="Gradient">Gradient</see>.<see cref="RadialGradient.Center">Center</see>.<see cref="Length.Percent">Percent</see> and 
        /// <see cref="Gradient">Gradient</see>.<see cref="RadialGradient.Radius">Radius</see>.<see cref="Length.Percent">Percent</see> are relative to
        /// <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. Mathematically speaking:<br/>
        /// <c>Vector2 calculatedGradientCenter = Gradient.Center.Percent * CalculatedSize.XY.Value <br/>
        /// Vector2 calculatedGradientRadii = Gradient.Radius.Percent * CalculatedSize.XY.Value</c>
        /// </remarks>
        /// <seealso cref="RadialGradient"/>
        public ref RadialGradient Gradient
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_268.InternalMethod_953<InternalNamespace_0.InternalType_108, RadialGradient>();
        }

        /// <summary>
        /// A visual border drawn around the perimeter of the body.
        /// </summary>
        /// <remarks>
        /// <see cref="Border">Border</see>.<see cref="Border.Width">Width</see>.<see cref="Length.Percent">Percent</see> is relative to half 
        /// the minimum dimension (X or Y) of <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. Mathematically speaking:<br/>
        /// <c>float calculatedBorderWidth = Border.Width.Percent * 0.5f * Mathf.Min(CalculatedSize.X.Value, CalculatedSize.Y.Value)</c>
        /// </remarks>
        /// <seealso cref="Nova.Border"/>
        public ref Border Border
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_269.InternalMethod_953<InternalNamespace_0.InternalType_106, Border>();
        }

        /// <summary>
        /// The radial fill/cutout configuration.
        /// </summary>
        /// <remarks>
        /// <see cref="RadialFill">RadialFill</see>.<see cref="RadialFill.Center">Center</see>.<see cref="Length.Percent">Percent</see> is 
        /// relative to <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. Mathematically speaking:<br/>
        /// <c>Vector2 calculatedRadialFillCenter = RadialFill.Center.Percent * CalculatedSize.XY.Value</c>
        /// </remarks>
        public ref RadialFill RadialFill
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_3412.InternalMethod_953<InternalNamespace_0.InternalType_486, RadialFill>();
        }

        /// <summary>
        /// A drop shadow, inner shadow, or glow effect.
        /// </summary>
        /// <remarks>
        /// <see cref="Shadow">Shadow</see>.<see cref="Shadow.Width">Width</see>.<see cref="Length.Percent">Percent</see> and 
        /// <see cref="Shadow">Shadow</see>.<see cref="Shadow.Blur">Blur</see>.<see cref="Length.Percent">Percent</see> are 
        /// relative to half the minimum dimension (X or Y) of <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. 
        /// Mathematically speaking:<br/>
        /// <c>float calculatedShadowWidth = Shadow.Width.Percent * 0.5f * Mathf.Min(CalculatedSize.X.Value, CalculatedSize.Y.Value) <br/>
        /// float calculatedShadowBlur = Shadow.Blur.Percent * 0.5f * Mathf.Min(CalculatedSize.X.Value, CalculatedSize.Y.Value)</c> <br/><br/>
        /// <see cref="Shadow">Shadow</see>.<see cref="Shadow.Offset">Offset</see>.<see cref="Length.Percent">Percent</see> is relative to 
        /// <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. Mathematically speaking:<br/>
        ///  <c>Vector2 calculatedShadowOffset = Shadow.Offset.Percent * CalculatedSize.XY.Value</c>
        /// </remarks>
        /// <seealso cref="Nova.Shadow"/>
        public ref Shadow Shadow
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_270.InternalMethod_953<InternalNamespace_0.InternalType_107, Shadow>();

        }

        /// <summary>
        /// The position and scale adjustments applied to the attached image (i.e. <see cref="Sprite">Sprite</see>, <see cref="Texture">Texture</see>, or <see cref="RenderTexture">RenderTexture</see>), if it exists.
        /// </summary>
        /// <seealso cref="Nova.ImageAdjustment"/>
        /// <seealso cref="Texture"/>
        /// <seealso cref="Sprite"/>
        /// <seealso cref="SetImage(RenderTexture)"/>
        /// <seealso cref="SetImage(Sprite)"/>
        /// <seealso cref="SetImage(Texture2D)"/>
        public ref ImageAdjustment ImageAdjustment
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_271.InternalField_274.InternalMethod_953<InternalNamespace_0.InternalType_113, ImageAdjustment>();
        }

        /// <summary>
        /// Configures the render order of this UIBlock within a <see cref="SortGroup"/>.
        /// </summary>
        /// <remarks><see cref="UIBlock"/>s with a higher ZIndex are rendered on top of <see cref="UIBlock"/>s with a lower ZIndex.</remarks>
        public short ZIndex
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => visibility.ZIndex;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                visibility.ZIndex = value;
                InternalType_274.InternalProperty_190.InternalMethod_3031(this);
            }
        }

        /// <summary>
        /// Specifies whether the body <see cref="UIBlock.Color">Color</see>, <see cref="Gradient">Gradient</see>, and image (i.e. <see cref="Sprite">Sprite</see>, <see cref="Texture">Texture</see>, or <see cref="RenderTexture">RenderTexture</see>) should render.
        /// </summary>
        public bool BodyEnabled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_273;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_273 = value;
            }
        }

        /// <summary>
        /// Apply local anti-aliasing to edges around the body and <see cref="Border"/>.
        /// </summary>
        /// <remarks>
        /// Drastically improves visual quality in most user interfaces. In certain situations, however, such as rendering a transparent image or<br/>
        /// if an image has edge softening already baked into its texture, enabling this property may result in some undesired visual artifacts.
        /// </remarks>
        public bool SoftenEdges
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_272;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_272 = value;
            }
        }

        /// <summary>
        /// The primary body content color.
        /// </summary>
        public override Color Color
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_266;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_266 = value;
            }
        }

        /// <summary>
        /// The <see cref="Length"/> configuration used to calculate a corner radius, applies to all four corners of the body, <see cref="Border"/>, and <see cref="Shadow"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="CornerRadius">CornerRadius</see>.<see cref="Length.Percent">Percent</see> is relative to half 
        /// the minimum dimension (X or Y) of <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. Mathematically speaking:<br/>
        /// <c>float calculatedCornerRadius = CornerRadius.Percent * 0.5f * Mathf.Min(CalculatedSize.X.Value, CalculatedSize.Y.Value)</c>
        /// </remarks>
        public ref Length CornerRadius
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_267.InternalMethod_9();
        }

        /// <summary>
        /// Configure how to store (and attempt to batch) the attached image's (i.e. <see cref="Sprite">Sprite</see>, <see cref="Texture">Texture</see>, or <see cref="RenderTexture">RenderTexture</see>) underlying texture.
        /// </summary>
        /// <seealso cref="NovaSettings.PackedImagesEnabled"/>
        public ImagePackMode ImagePackMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (ImagePackMode)InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_271.InternalField_275;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ref InternalNamespace_0.InternalType_81 InternalVar_1 = ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_271;
                InternalVar_1.InternalField_275 = (InternalNamespace_0.InternalType_695)value;
                InternalMethod_142(ref InternalVar_1);
                visuals.Image.Mode = value;
            }
        }

        #region 
        /// <summary>
        /// Retrieve the image texture previously assigned through <see cref="SetImage(Texture2D)"/> or in the Editor.
        /// </summary>
        /// <remarks>
        /// Will be null if the image is actually a <see cref="UnityEngine.RenderTexture"/> or <see cref="UnityEngine.Sprite"/>.
        /// </remarks>
        /// <seealso cref="RenderTexture"/>
        /// <seealso cref="Sprite"/>
        public Texture2D Texture
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => texture as Texture2D;
        }

        /// <summary>
        /// Retrieve the image texture previously assigned through <see cref="SetImage(RenderTexture)"/> or in the Editor.
        /// </summary>
        /// <remarks>
        /// Will be null if the image is actually a <see cref="Texture2D"/> or <see cref="UnityEngine.Sprite"/>.
        /// </remarks>
        /// <seealso cref="Texture"/>
        /// <seealso cref="Sprite"/>
        public RenderTexture RenderTexture
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => texture as RenderTexture;
        }

        /// <summary>
        /// Retrieve the sprite previously assigned through <see cref="SetImage(Sprite)"/> or in the Editor.
        /// </summary>
        /// <remarks>
        /// Will be null if the image is actually a <see cref="Texture2D"/> or <see cref="UnityEngine.RenderTexture"/>.
        /// </remarks>
        /// <seealso cref="Texture"/>
        /// <seealso cref="RenderTexture"/>
        public Sprite Sprite
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => sprite;
        }
        #endregion

        #region 
        /// <summary>
        /// Clear the current image assignment.
        /// </summary>
        /// <remarks>
        /// Clears anything previously assigned via <see cref="SetImage(Texture2D)"/>, <see cref="SetImage(Sprite)"/>, <see cref="SetImage(RenderTexture)"/> or in the Editor.
        /// </remarks>
        public void ClearImage()
        {
            sprite = null;
            texture = null;

            if (!InternalProperty_27.InternalProperty_197)
            {
                return;
            }

            InternalMethod_141();
        }

        /// <summary>
        /// Render the provided <paramref name="texture"/> in the body of this <see cref="UIBlock2D"/>. Replaces any existing image assignment.
        /// </summary>
        /// <param name="texture">The texture to render in the body of this <see cref="UIBlock2D"/>.</param>
        public void SetImage(Texture2D texture) => InternalMethod_140(texture);

        /// <summary>
        /// Render the provided <paramref name="renderTexture"/> in the body of this <see cref="UIBlock2D"/>. Replaces any existing image assignment.
        /// </summary>
        /// <param name="renderTexture">The texture to render in the body of this <see cref="UIBlock2D"/>.</param>
        public void SetImage(RenderTexture renderTexture) => InternalMethod_140(renderTexture);

        /// <summary>
        /// Render the provided <paramref name="sprite"/> in the body of this <see cref="UIBlock2D"/>. Replaces any existing image assignment.
        /// </summary>
        /// <remarks>
        /// Sliced sprites and <see cref="SpritePackingMode.Tight"/> packed sprites are not supported.
        /// </remarks>
        /// <param name="sprite">The sprite to render in the body of this <see cref="UIBlock2D"/>.</param>
        public void SetImage(Sprite sprite)
        {
            if (sprite != null && sprite.packed && sprite.packingMode == SpritePackingMode.Tight)
            {
                Debug.LogError("Tight-packed sprite atlas not supported");
                return;
            }

            texture = null;
            this.sprite = sprite;

            if (!InternalProperty_27.InternalProperty_197)
            {
                return;
            }
            InternalMethod_141();
        }
        #endregion
        #endregion

        #region Internal
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_8 visuals = InternalType_8.InternalField_61;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Texture texture = null;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Sprite sprite = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_80 InternalType_256<InternalNamespace_0.InternalType_80>.InternalProperty_270
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref visuals.InternalMethod_953<InternalType_8, InternalNamespace_0.InternalType_80>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InternalMethod_140(Texture InternalParameter_84)
        {
            sprite = null;
            texture = InternalParameter_84;

            if (!InternalProperty_27.InternalProperty_197)
            {
                return;
            }

            InternalMethod_141();
        }

        private protected override void InternalMethod_111()
        {
            InternalMethod_142(ref visuals.Image.InternalMethod_953<InternalType_39, InternalNamespace_0.InternalType_81>());
            base.InternalMethod_111();
        }

        private void InternalMethod_141()
        {
            ref InternalNamespace_0.InternalType_81 InternalVar_1 = ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_271;
            InternalMethod_142(ref InternalVar_1);
            visuals.Image.InternalField_135 = InternalVar_1.InternalField_276;
        }

        private void InternalMethod_142(ref InternalNamespace_0.InternalType_81 InternalParameter_85)
        {
            if (sprite != null)
            {
                InternalType_274.InternalProperty_190.InternalField_876.InternalMethod_2334(Sprite, InternalParameter_85.InternalField_275, ref InternalParameter_85.InternalField_276);
            }
            else if (texture != null)
            {
                InternalType_274.InternalProperty_190.InternalField_876.InternalMethod_2332(texture, InternalParameter_85.InternalField_275, ref InternalParameter_85.InternalField_276);
            }
            else if (InternalParameter_85.InternalField_276.InternalProperty_185)
            {
                InternalType_274.InternalProperty_190.InternalField_876.InternalMethod_2332(texture, InternalParameter_85.InternalField_275, ref InternalParameter_85.InternalField_276);
            }
            visuals.Image.InternalField_135 = InternalParameter_85.InternalField_276;
        }

        private protected override void InternalMethod_112()
        {
            base.InternalMethod_112();

            if (visuals.Image.InternalField_135.InternalProperty_86 && InternalType_274.InternalProperty_190 != null)
            {
                ref InternalNamespace_0.InternalType_81 InternalVar_1 = ref visuals.Image.InternalMethod_953<InternalType_39, InternalNamespace_0.InternalType_81>();
                InternalType_274.InternalProperty_190.InternalField_876.InternalMethod_1386(ref InternalVar_1.InternalField_276);
            }
        }

        internal override void InternalMethod_1856()
        {
            if (InternalProperty_27.InternalProperty_197)
            {
                InternalMethod_142(ref visuals.Image.InternalMethod_953<InternalType_39, InternalNamespace_0.InternalType_81>());
            }

            base.InternalMethod_1856();
        }

        [Obfuscation]
        private protected override void OnDidApplyAnimationProperties()
        {
            base.OnDidApplyAnimationProperties();
            InternalMethod_141();
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal InternalType_8.Calculated InternalProperty_42 => InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalMethod_953<InternalNamespace_0.InternalType_80, InternalType_8>().InternalMethod_148(CalculatedSize.XY.Value);

        private UIBlock2D() : base()
        {
            visibility = InternalType_36.InternalMethod_307(InternalType_11.InternalField_64);
        }

        #endregion
    }
}
