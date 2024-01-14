// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Specifies how a parent element renders an image based on the aspect ratio of the image and the parent element itself.
    /// </summary>
    /// <seealso cref="UIBlock2D.ImageAdjustment"/>
    /// <seealso cref="ImageAdjustment"/>
    public enum ImageScaleMode
    {
        /// <summary>
        /// No automatic adjustment is made to the image's scale. If the aspect ratio of the parent element and image do not match, the image will stretch.
        /// </summary>
        Manual = InternalNamespace_0.InternalType_112.InternalField_362,
        /// <summary>
        /// As the parent's size changes, the image scale will adjust automatically to ensure the full
        /// image fits within its parent container. Preserves the image's native aspect ratio (unstretched).
        /// </summary>
        Fit = InternalNamespace_0.InternalType_112.InternalField_363,
        /// <summary>
        /// As the parent's size changes, the image scale will adjust automatically to ensure the image
        /// maximally fills its parent container. Preserves the image's native aspect ratio (unstretched).
        /// </summary>
        Envelope = InternalNamespace_0.InternalType_112.InternalField_364,
        /// <summary>
        /// The image will be displayed as a 9-sliced sprite.<br/> NOTE: the <see cref="ImageAdjustment.PixelsPerUnitMultiplier"/>
        /// value determines the width of the borders.
        /// </summary>
        /// <seealso cref="ImageScaleMode.Tiled"/>
        Sliced = InternalNamespace_0.InternalType_112.InternalField_3426,
        /// <summary>
        /// The image will be displayed as a 9-sliced sprite with the sections being tiled instead of stretched.<br/> 
        /// NOTE: the <see cref="ImageAdjustment.PixelsPerUnitMultiplier"/>
        /// value determines the width of the borders and the size of the tiles.
        /// </summary>
        Tiled = InternalNamespace_0.InternalType_112.InternalField_3427,
    }

    /// <summary>
    /// The position and scale adjustments to apply when rendering an image.
    /// </summary>
    /// <seealso cref="UIBlock2D.ImageAdjustment"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ImageAdjustment : IEquatable<ImageAdjustment>
    {
        /// <summary>
        /// Specifies the center position of the image in UV space, where UVs go from <c>(-1, -1)</c> (bottom-left) to <c>(1, 1)</c> (top-right).
        /// </summary>
        [SerializeField]
        public Vector2 CenterUV;
        /// <summary>
        /// Specifies how much to scale the image in UV space, where UVs go from <c>(-1, -1)</c> (bottom-left) to <c>(1, 1)</c> (top-right).</summary>
        /// <remarks>E.g.<br/>
        /// <list type="bullet">
        /// <item><description><c>UVScale == Vector2.one * 2</c> will zoom <i>in</i> by a factor of <c>2</c>, rendering the inner half of the image and clipping the outer half.</description></item>
        /// <item><description><c>UVScale == Vector2.one * 0.5f</c> will zoom <i>out</i> by a factor of <c>2</c>, rendering the full image surrounded by either empty space, tiling of the same image, or adjacent<br/>
        /// sprites in the source sprite sheet. Surrounding content is dependent on the underlying <see cref="Texture">Texture</see> or <see cref="Sprite">Sprite</see> settings, not this <see cref="UVScale">UVScale</see> field.</description></item>
        /// </list>
        /// </remarks>
        [SerializeField]
        public Vector2 UVScale;
        /// <summary>
        /// A multiplier that scales how <see cref="ImageScaleMode.Sliced"/> and <see cref="ImageScaleMode.Tiled"/> images are rendered.
        /// Specifically, <see cref="PixelsPerUnitMultiplier">PixelsPerUnitMultiplier</see> determines how many pixels from the target image
        /// fit into a 1x1 square in the target <see cref="UIBlock2D"/>'s local space.
        /// </summary>
        [SerializeField]
        public float PixelsPerUnitMultiplier;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private ImageScaleMode scaleMode;

        /// <summary>
        /// <c>get</c>: Gets the current scale mode.<br/>
        /// <c>set</c>: Sets the scale mode and resets both <see cref="CenterUV"/> and <see cref="UVScale"/> to 
        /// <c>Vector2.zero</c> and <c>Vector2.one</c>, respectively.
        /// </summary>
        public ImageScaleMode ScaleMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => scaleMode;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (scaleMode == value)
                {
                    return;
                }

                scaleMode = value;
                CenterUV = Vector2.zero;
                UVScale = Vector2.one;
            }
        }

        /// <summary>
        /// Constructs a new <see cref="ImageAdjustment"/> with <see cref="ScaleMode"/> set to <see cref="ImageScaleMode.Manual"/>.
        /// </summary>
        /// <param name="centerUV"></param>
        /// <param name="uvScale"></param>
        public ImageAdjustment(Vector2 centerUV, Vector2 uvScale)
        {
            CenterUV = centerUV;
            UVScale = uvScale;
            scaleMode = ImageScaleMode.Manual;
            PixelsPerUnitMultiplier = 1f;
        }

        public static bool operator ==(ImageAdjustment lhs, ImageAdjustment rhs)
        {
            return
                lhs.CenterUV.Equals(rhs.CenterUV) &&
                lhs.UVScale.Equals(rhs.UVScale) &&
                lhs.scaleMode == rhs.ScaleMode &&
                lhs.PixelsPerUnitMultiplier.Equals(rhs.PixelsPerUnitMultiplier);
        }
        public static bool operator !=(ImageAdjustment lhs, ImageAdjustment rhs) => !(rhs == lhs);

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + CenterUV.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + UVScale.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + scaleMode.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + PixelsPerUnitMultiplier.GetHashCode();
            return InternalVar_1;
        }

        public override bool Equals(object other)
        {
            if (other is ImageAdjustment asType)
            {
                return this == asType;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="ImageAdjustment"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(ImageAdjustment other) => this == other;


        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static readonly ImageAdjustment InternalField_60 = new ImageAdjustment()
        {
            UVScale = Vector2.one,
            CenterUV = Vector2.zero,
            scaleMode = ImageScaleMode.Fit,
            PixelsPerUnitMultiplier = 1f,
        };
    }
}