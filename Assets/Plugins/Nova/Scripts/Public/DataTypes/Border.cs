// Copyright (c) Supernova Technologies LLC
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Specifies the direction for a border to expand.
    /// </summary>
    /// <seealso cref="UIBlock2D.Border"/>
    /// <seealso cref="Border"/>
    public enum BorderDirection
    {
        /// <summary>
        /// The border expands outward.
        /// </summary>
        Out = InternalNamespace_0.InternalType_111.InternalField_359,
        /// <summary>
        /// The border is centered on the edge, expands both inward and outward.
        /// </summary>
        Center = InternalNamespace_0.InternalType_111.InternalField_360,
        /// <summary>
        /// The border expands inward.
        /// </summary>
        In = InternalNamespace_0.InternalType_111.InternalField_361,
    }

    /// <summary>
    /// A visual border to draw around a parent element.
    /// </summary>
    /// <seealso cref="UIBlock2D.Border"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Border : IEquatable<Border>
    {
        /// <summary>
        /// The color of the border.
        /// </summary>
        [SerializeField]
        public Color Color;
        /// <summary>
        /// The <see cref="Length"/> configuration for the width of the border.
        /// </summary>
        [SerializeField]
        public Length Width;
        /// <summary>
        /// A flag to toggle the visibility of the border.
        /// </summary>
        [SerializeField]
        public bool Enabled;
        /// <summary>
        /// The direction the border will expand as <see cref="Width"/> increases. Either <see cref="BorderDirection.In"/>, <see cref="BorderDirection.Center"/>, or <see cref="BorderDirection.Out"/>.
        /// </summary>
        [SerializeField]
        public BorderDirection Direction;

        /// <summary>
        /// Constructs a new <see cref="Border"/>.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="enabled"></param>
        /// <param name="borderDirection"></param>
        public Border(Color color, Length width, bool enabled = true, BorderDirection borderDirection = BorderDirection.Out)
        {
            Color = color;
            Width = width;
            Enabled = enabled;
            Direction = borderDirection;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static readonly Border InternalField_58 = new Border()
        {
            Enabled = false,
            Color = Color.white,
            Width = Length.One,
            Direction = BorderDirection.In,
        };

        public static bool operator ==(Border lhs, Border rhs)
        {
            return
                lhs.Color.Equals(rhs.Color) &&
                lhs.Width.Equals(rhs.Width) &&
                lhs.Enabled.Equals(rhs.Enabled) &&
                lhs.Direction == rhs.Direction;

        }

        public static bool operator !=(Border lhs, Border rhs) => !(rhs == lhs);

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Color.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Width.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Enabled.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Direction.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="Border"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public override bool Equals(object other)
        {
            if (other is Border border)
            {
                return this == border;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="Border"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(Border other) => this == other;

        /// <summary>
        /// The string representation of this <see cref="Border"/>.
        /// </summary>
        public override string ToString()
        {
            if (!Enabled)
            {
                return "Disabled";
            }

            return $"Color = {Color}, Width = {Width}, Direction = {Direction}";
        }

        internal Calculated InternalMethod_146(float InternalParameter_87)
        {
            return new Calculated(Width, InternalParameter_87);
        }

        [Obfuscation]
        internal readonly struct Calculated
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Length.Calculated Width;

            internal Calculated(Length borderWidth, float relativeTo)
            {
                var InternalVar_1 = new InternalNamespace_0.InternalType_45.InternalType_47(borderWidth.InternalMethod_1(), InternalNamespace_0.InternalType_45.InternalType_46.InternalField_151, relativeTo);
                Width = InternalVar_1.InternalMethod_18();
            }
        }
    }
}