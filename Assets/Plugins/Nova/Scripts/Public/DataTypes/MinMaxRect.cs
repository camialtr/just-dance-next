// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.InteropServices;

namespace Nova
{
    /// <summary>
    /// A min/max range, per 2D edge (Left, Right, Top, and Bottom) offset.
    /// </summary>
    /// <seealso cref="LengthRect"/>
    /// <seealso cref="LengthRect.Calculated"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_3022)]
    public struct MinMaxRect : IEquatable<MinMaxRect>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_3022 = 2 * MinMax2.InternalField_3024;

        /// <summary>
        /// The <see cref="MinMax"/> used to clamp <see cref="LengthRect.Left"/>.
        /// </summary>
        [FieldOffset(0 * MinMax.InternalField_3025)]
        public MinMax Left;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp <see cref="LengthRect.Right"/>.
        /// </summary>
        [FieldOffset(1 * MinMax.InternalField_3025)]
        public MinMax Right;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp <see cref="LengthRect.Bottom"/>.
        /// </summary>
        [FieldOffset(2 * MinMax.InternalField_3025)]
        public MinMax Bottom;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp <see cref="LengthRect.Top"/>.
        /// </summary>
        [FieldOffset(3 * MinMax.InternalField_3025)]
        public MinMax Top;

        /// <summary>
        /// The <see cref="MinMax2"/> used to clamp <see cref="LengthRect.X"/>.
        /// </summary>
        [NonSerialized]
        [FieldOffset(0 * MinMax2.InternalField_3024)]
        public MinMax2 X;
        /// <summary>
        /// The <see cref="MinMax2"/> used to clamp <see cref="LengthRect.Y"/>.
        /// </summary>
        [NonSerialized]
        [FieldOffset(1 * MinMax2.InternalField_3024)]
        public MinMax2 Y;

        /// <summary>
        /// Access each <see cref="MinMax2"/> by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>.
        /// </param>
        /// <returns>The <see cref="MinMax2"/> for the given <paramref name="axis"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 1</exception>
        public MinMax2 this[int axis]
        {
            readonly get
            {
                switch (axis)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                }

                throw new IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 1].");
            }
            set
            {
                switch (axis)
                {
                    case 0:
                        X = value;
                        return;
                    case 1:
                        Y = value;
                        return;
                }

                throw new IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 1].");
            }
        }

        internal bool InternalMethod_2411()
        {
            return Left.Min != Right.Min || Left.Min != Bottom.Min || Left.Min != Top.Min;
        }

        internal bool InternalMethod_2410()
        {
            return Left.Max != Right.Max || Left.Max != Bottom.Max || Left.Max != Top.Max;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Left == <paramref name="rhs"/>.Left &amp;&amp; <paramref name="lhs"/>.Right == <paramref name="rhs"/>.Right
        /// &amp;&amp; <paramref name="lhs"/>.Bottom == <paramref name="rhs"/>.Bottom &amp;&amp; <paramref name="lhs"/>.Top == <paramref name="rhs"/>.Top</c>.</returns>
        public static bool operator ==(MinMaxRect lhs, MinMaxRect rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Left != <paramref name="rhs"/>.Left || <paramref name="lhs"/>.Right != <paramref name="rhs"/>.Right
        /// || <paramref name="lhs"/>.Bottom != <paramref name="rhs"/>.Bottom || <paramref name="lhs"/>.Top != <paramref name="rhs"/>.Top</c>.</returns>
        public static bool operator !=(MinMaxRect lhs, MinMaxRect rhs)
        {
            return lhs.X != rhs.X && lhs.Y != rhs.Y;
        }


        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMaxRect"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is MinMaxRect MinMaxRect)
            {
                return this == MinMaxRect;
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="MinMaxRect"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Left.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Right.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Top.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Bottom.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string representation of this <see cref="MinMaxRect"/>.
        /// </summary>
        public override string ToString()
        {
            if (Left == Right)
            {
                if (Left == Bottom && Left == Top)
                {
                    return $"MinMaxRectRect(All: {Left})";
                }

                if (Bottom == Top)
                {
                    return $"MinMaxRectRect(X: {Left}, Y: {Bottom})";
                }
            }

            return $"MinMaxRect(L: {Left}, R: {Right}], B: {Bottom}, T: {Top})";
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMaxRect"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(MinMaxRect other)
        {
            return this == other;
        }

        /// <summary>
        /// A <see cref="MinMaxRect"/> where <see cref="MinMax.Min"/> == 0 and <see cref="MinMax.Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static readonly MinMaxRect Positive = new MinMaxRect()
        {
            Left = MinMax.Positive,
            Right = MinMax.Positive,
            Bottom = MinMax.Positive,
            Top = MinMax.Positive,
        };

        /// <summary>
        /// Constructs a new <see cref="MinMaxRect"/>, specified per face.
        /// </summary>
        /// <param name="left">The length assigned to <see cref="Left">Left</see>.</param>
        /// <param name="right">The length assigned to <see cref="Right">Right</see>.</param>
        /// <param name="bottom">The length assigned to <see cref="Bottom">Bottom</see>.</param>
        /// <param name="top">The length assigned to <see cref="Top">Top</see>.</param>
        public MinMaxRect(MinMax left, MinMax right, MinMax bottom, MinMax top)
        {
            Left = left;
            Right = right;
            Bottom = bottom;
            Top = top;

            X = new MinMax2(left, right);
            Y = new MinMax2(bottom, top);
        }

        /// <summary>
        /// Constructs a new <see cref="MinMaxRect"/>. specified per axis.
        /// </summary>
        /// <param name="x">The lengths assigned to <see cref="X">X</see>.</param>
        /// <param name="y">The lengths assigned to <see cref="Y">Y</see>.</param>
        public MinMaxRect(MinMax2 x, MinMax2 y)
        {
            Left = x.First;
            Right = x.Second;
            Bottom = y.First;
            Top = y.Second;

            X = x;
            Y = y;
        }
    }
}
