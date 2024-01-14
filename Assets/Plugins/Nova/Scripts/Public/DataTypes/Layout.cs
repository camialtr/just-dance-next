// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Have an element resize automatically based on the size of its parent or the size of its children
    /// </summary>
    public enum AutoSize
    {
        /// <summary>
        /// No autosizing
        /// </summary>
        None = InternalNamespace_0.InternalType_83.InternalField_280,
        /// <summary>
        /// Match size of parent
        /// </summary>
        Expand = InternalNamespace_0.InternalType_83.InternalField_281,
        /// <summary>
        /// Match size of children
        /// </summary>
        Shrink = InternalNamespace_0.InternalType_83.InternalField_282,
    };

    /// <summary>
    /// The configurable set of layout properties used for sizing/positioning elements in a hierarchy
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    [System.Serializable]
    public struct Layout : System.IEquatable<Layout>
    {
        /// <summary>
        /// The 3D size configuration of this <see cref="Layout"/>
        /// </summary>
        [SerializeField]
        public Length3 Size;
        /// <summary>
        /// The 3D position configuration of this <see cref="Layout"/>
        /// </summary>
        [SerializeField]
        public Length3 Position;
        /// <summary>
        /// The 3D padding configuration of this <see cref="Layout"/>
        /// </summary>
        /// <remarks>
        /// Padding is space applied inwards from the size bounds
        /// </remarks>
        [SerializeField]
        public LengthBounds Padding;
        /// <summary>
        /// The 3D margin configuration of this <see cref="Layout"/>
        /// </summary>
        /// <remarks>
        /// Margin is space applied outwards from the size bounds
        /// </remarks>
        [SerializeField]
        public LengthBounds Margin;

        /// <summary>
        /// The min/max range used to clamp <see cref="Size"/> during the layout calculation process 
        /// </summary>
        [SerializeField]
        public MinMax3 SizeMinMax;

        /// <summary>
        /// The min/max range used to clamp <see cref="Position"/> during the layout calculation process 
        /// </summary>
        [SerializeField]
        public MinMax3 PositionMinMax;
        /// <summary>
        /// The min/max range used to clamp <see cref="Padding"/> during the layout calculation process 
        /// </summary>
        [SerializeField]
        public MinMaxBounds PaddingMinMax;
        /// <summary>
        /// The min/max range used to clamp <see cref="Margin"/> during the layout calculation process 
        /// </summary>
        [SerializeField]
        public MinMaxBounds MarginMinMax;

        /// <summary>
        /// The 3D alignment configuration for this <see cref="Layout"/>
        /// </summary>
        /// <remarks><see cref="Position"/> is a configured offset from the point of alignment per-axis </remarks>
        [SerializeField]
        public Alignment Alignment;

        /// <summary>
        /// Allows <see cref="Size"/> to automatically adapt to the size of a parent <see cref="Layout"/> or set of child <see cref="Layout">Layouts</see>
        /// </summary>
        [SerializeField]
        public ThreeD<AutoSize> AutoSize;

        /// <summary>
        /// A flag indicating to the layout system to account for the owner's rotation when performing certain <see cref="Size"/> and <see cref="Position"/> calculations 
        /// </summary>
        [SerializeField]
        public bool RotateSize;

        [SerializeField, HideInInspector]
        [InternalType_22]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal Vector3 AspectRatio;

        /// <summary>
        /// Lock the aspect ratio of <see cref="Size"/> by setting the "unlocked" axis
        /// </summary>
        [SerializeField]
        public Axis AspectRatioAxis;

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to all field of <paramref name="rhs"/></returns>
        public static bool operator ==(Layout lhs, Layout rhs)
        {
            return lhs.Size == rhs.Size &&
                   lhs.Position == rhs.Position &&
                   lhs.Padding == rhs.Padding &&
                   lhs.Margin == rhs.Margin &&
                   lhs.SizeMinMax == rhs.SizeMinMax &&
                   lhs.PositionMinMax == rhs.PositionMinMax &&
                   lhs.PaddingMinMax == rhs.PaddingMinMax &&
                   lhs.MarginMinMax == rhs.MarginMinMax &&
                   lhs.Alignment == rhs.Alignment &&
                   lhs.AutoSize.Equals(rhs.AutoSize) &&
                   lhs.RotateSize == rhs.RotateSize &&
                   lhs.AspectRatio == rhs.AspectRatio &&
                   lhs.AspectRatioAxis == rhs.AspectRatioAxis;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if any field of <paramref name="lhs"/> is <b>not</b> equal to its corresponding field of <paramref name="rhs"/></returns>
        public static bool operator !=(Layout lhs, Layout rhs)
        {
            return lhs.Size != rhs.Size ||
                   lhs.Position != rhs.Position ||
                   lhs.Padding != rhs.Padding ||
                   lhs.Margin != rhs.Margin ||
                   lhs.SizeMinMax != rhs.SizeMinMax ||
                   lhs.PositionMinMax != rhs.PositionMinMax ||
                   lhs.PaddingMinMax != rhs.PaddingMinMax ||
                   lhs.MarginMinMax != rhs.MarginMinMax ||
                   lhs.Alignment != rhs.Alignment ||
                   !lhs.AutoSize.Equals(rhs.AutoSize) ||
                   lhs.RotateSize != rhs.RotateSize ||
                   lhs.AspectRatio != rhs.AspectRatio ||
                   lhs.AspectRatioAxis != rhs.AspectRatioAxis;
        }

        /// <summary>
        /// The hashcode for this <see cref="Layout"/>
        /// </summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Size.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Position.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Padding.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Margin.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + SizeMinMax.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + PositionMinMax.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + PaddingMinMax.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + MarginMinMax.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Alignment.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + AutoSize.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + RotateSize.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + AspectRatio.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + AspectRatioAxis.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The <see cref="Layout"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public override bool Equals(object other)
        {
            if (other is Layout layout)
            {
                return this == layout;
            }

            return false;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The <see cref="Layout"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(Layout other)
        {
            return this == other;
        }

        /// <summary>
        /// A <see cref="Length.One"/> cube layout
        /// </summary>
        public static readonly Layout ThreeD = new Layout()
        {
            Size = Length3.FixedValue(10, 10, 10),
            SizeMinMax = MinMax3.Positive,
            Position = Length3.Zero,
            PositionMinMax = MinMax3.Unclamped,
            PaddingMinMax = MinMaxBounds.Positive,
            MarginMinMax = MinMaxBounds.Unclamped,
        };

        /// <summary>
        /// A <see cref="Length.One"/> rectangle layout
        /// </summary>
        public static readonly Layout TwoD = new Layout()
        {
            Size = Length2.FixedValue(10, 10),
            SizeMinMax = MinMax3.Positive,
            Position = Length3.Zero,
            PositionMinMax = MinMax3.Unclamped,
            PaddingMinMax = MinMaxBounds.Positive,
            MarginMinMax = MinMaxBounds.Unclamped,
        };
    }
}
