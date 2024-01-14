// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A set of <see cref="Length">Lengths</see> used to configure offsets from each edge of a rectangle.
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct LengthRect : IEquatable<LengthRect>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_12 = 4 * InternalNamespace_0.InternalType_45.InternalField_144;

        /// <summary>
        /// The <see cref="Length">Length</see> offset from a rectangle's left edge.
        /// </summary>
        [FieldOffset(0 * Length.InternalField_2)]
        public Length Left;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a rectangle's right edge.
        /// </summary>
        [FieldOffset(1 * Length.InternalField_2)]
        public Length Right;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a rectangle's bottom edge.
        /// </summary>
        [FieldOffset(2 * Length.InternalField_2)]
        public Length Bottom;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a rectangle's top edge.
        /// </summary>
        [FieldOffset(3 * Length.InternalField_2)]
        public Length Top;

        /// <summary>
        /// <see cref="Left">Left</see> and <see cref="Right">Right</see> as a <see cref="Length2"/> pair.
        /// </summary>
        /// <remarks>
        /// <value><c>this.<see cref="Left">Left</see></c> => <see cref="X">X</see>.<see cref="Length2.First">First</see></value><br/>
        /// <value><c>this.<see cref="Right">Right</see></c> => <see cref="X">X</see>.<see cref="Length2.Second">Second</see></value>.
        /// </remarks>
        [NonSerialized]
        [FieldOffset(0 * Length.InternalField_2)]
        public Length2 X;
        /// <summary>
        /// <see cref="Bottom">Bottom</see> and <see cref="Top">Top</see> as a <see cref="Length2"/> pair.
        /// </summary>
        /// <remarks>
        /// <value><c>this.<see cref="Bottom">Bottom</see></c> => <see cref="Y">Y</see>.<see cref="Length2.First">First</see></value><br/>
        /// <value><c>this.<see cref="Top">Top</see></c> => <see cref="Y">Y</see>.<see cref="Length2.Second">Second</see></value>.
        /// </remarks>
        [NonSerialized]
        [FieldOffset(2 * Length.InternalField_2)]
        public Length2 Y;

        /// <summary>
        /// Assign all offsets, <see cref="Left">Left</see>, <see cref="Right">Right</see>, <see cref="Bottom">Bottom</see>, and <see cref="Top">Top</see>, to a <see cref="LengthType.Value">Value</see> <see cref="Length"/> with the given value.
        /// </summary>
        public float Value
        {
            set
            {
                Length InternalVar_1 = Length.FixedValue(value);

                Left = InternalVar_1;
                Right = InternalVar_1;
                Bottom = InternalVar_1;
                Top = InternalVar_1;
            }
        }

        /// <summary>
        /// Assign all offsets, <see cref="Left">Left</see>, <see cref="Right">Right</see>, <see cref="Bottom">Bottom</see>, and <see cref="Top">Top</see>, to a <see cref="LengthType.Percent">Percent</see> <see cref="Length"/> with the given percent, <c>1 == 100%</c>.
        /// </summary>
        public float Percent
        {
            set
            {
                Length InternalVar_1 = Length.Percentage(value);

                Left = InternalVar_1;
                Right = InternalVar_1;
                Bottom = InternalVar_1;
                Top = InternalVar_1;
            }
        }

        /// <summary>
        /// Access each <see cref="Length2"/> by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>.
        /// </param>
        /// <returns>The <see cref="Length2"/> for the given <paramref name="axis"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 1</exception>
        public Length2 this[int axis]
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

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Left == <paramref name="rhs"/>.Left &amp;&amp; <paramref name="lhs"/>.Right == <paramref name="rhs"/>.Right
        /// &amp;&amp; <paramref name="lhs"/>.Bottom == <paramref name="rhs"/>.Bottom &amp;&amp; <paramref name="lhs"/>.Top == <paramref name="rhs"/>.Top</c>.</returns>
        public static bool operator ==(LengthRect lhs, LengthRect rhs)
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
        public static bool operator !=(LengthRect lhs, LengthRect rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="LengthRect"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is LengthRect length)
            {
                return this == length;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="LengthRect"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(LengthRect other)
        {
            return this == other;
        }

        /// <summary>The hashcode for this <see cref="LengthRect"/>.</summary>
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
        /// The string representation of this <see cref="LengthRect"/>.
        /// </summary>
        public override string ToString()
        {
            if (Left == Right)
            {
                if (Left == Bottom && Left == Top)
                {
                    return $"LengthRect(All: {Left})";
                }

                if (Bottom == Top)
                {
                    return $"LengthRect(X: {Left}, Y: {Bottom})";
                }
            }

            return $"LengthRect(L: {Left}, R: {Right}, B: {Bottom}, T: {Top})";
        }

        internal bool InternalMethod_28()
        {
            return X.First != X.Second || X.First != Y.First || X.First != Y.Second;
        }

        /// <summary>
        /// Constructs a new LengthRect and assigns each edge offset to a <see cref="LengthType.Value">Value</see> <see cref="Length"/> of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The length to assign in units.</param>
        public static implicit operator LengthRect(float value)
        {
            return new LengthRect()
            {
                Left = value,
                Right = value,
                Top = value,
                Bottom = value,
            };
        }

        /// <summary>
        /// Constructs a new LengthRect and assigns each edge offset to the provided <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The length to assign to each edge offset.</param>
        public static implicit operator LengthRect(Length length)
        {
            return new LengthRect()
            {
                Left = length,
                Right = length,
                Top = length,
                Bottom = length,
            };
        }

        /// <summary>
        /// Constructs a new LengthRect and assigns each edge offset to a <see cref="LengthType.Value">Value</see> <see cref="Length"/> along its respective axis.
        /// </summary>
        /// <param name="v">The lengths to assign to each edge offset, by axis, in units.</param>
        public static implicit operator LengthRect(Vector2 v)
        {
            return new LengthRect()
            {
                Left = v.x,
                Right = v.x,
                Top = v.y,
                Bottom = v.y,
            };
        }

        /// <summary>
        /// Constructs a new LengthRect and assigns each edge offset to the provided <see cref="Length"/> along its respective axis.
        /// </summary>
        /// <param name="lengths">The lengths to assign to each edge offset, by axis.</param>
        public static implicit operator LengthRect(Length2 lengths)
        {
            return new LengthRect()
            {
                Left = lengths.X,
                Right = lengths.X,
                Top = lengths.Y,
                Bottom = lengths.Y,
            };
        }

        /// <summary>
        /// Constructs a new <see cref="LengthRect"/>, specified per face.
        /// </summary>
        /// <param name="left">The length assigned to <see cref="Left">Left</see>.</param>
        /// <param name="right">The length assigned to <see cref="Right">Right</see>.</param>
        /// <param name="bottom">The length assigned to <see cref="Bottom">Bottom</see>.</param>
        /// <param name="top">The length assigned to <see cref="Top">Top</see>.</param>
        public LengthRect(Length left, Length right, Length bottom, Length top)
        {
            Left = left;
            Right = right;
            Bottom = bottom;
            Top = top;

            X = new Length2(left, right);
            Y = new Length2(bottom, top);
        }

        /// <summary>
        /// Constructs a new <see cref="LengthRect"/>, specified per axis.
        /// </summary>
        /// <param name="x">The lengths assigned to <see cref="X">X</see>.</param>
        /// <param name="y">The lengths assigned to <see cref="Y">Y</see>.</param>
        public LengthRect(Length2 x, Length2 y)
        {
            Left = x.First;
            Right = x.Second;
            Bottom = y.First;
            Top = y.Second;

            X = x;
            Y = y;
        }

        #region 
        /// <summary>
        /// A calculated, readonly output of a <see cref="LengthRect"/>.
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_14)]
        public readonly struct Calculated : IEquatable<Calculated>
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            internal const int InternalField_14 = 2 * Length2.Calculated.InternalField_6;

            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthRect.Left"/>.
            /// </summary>
            [FieldOffset(0 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Left;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthRect.Right"/>.
            /// </summary>
            [FieldOffset(1 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Right;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthRect.Bottom"/>.
            /// </summary>
            [FieldOffset(2 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Bottom;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthRect.Top"/>.
            /// </summary>
            [FieldOffset(3 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Top;

            /// <summary>
            /// The <see cref="Length2.Calculated"/> output of <see cref="LengthRect.X"/>.
            /// </summary>
            [NonSerialized, FieldOffset(0 * Length2.Calculated.InternalField_6)]
            public readonly Length2.Calculated X;
            /// <summary>
            /// The <see cref="Length2.Calculated"/> output of <see cref="LengthRect.Y"/>.
            /// </summary>
            [NonSerialized, FieldOffset(1 * Length2.Calculated.InternalField_6)]
            public readonly Length2.Calculated Y;

            /// <summary>
            /// Access each <see cref="Length2.Calculated"/> by <paramref name="axis"/> index.
            /// </summary>
            /// <param name="axis">The axis index to read<br/>
            /// <value>0 => <see cref="X"/></value><br/>
            /// <value>1 => <see cref="Y"/></value><br/>.
            /// </param>
            /// <returns>The <see cref="Length2.Calculated"/> for the given <paramref name="axis"/>.</returns>
            /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 1</exception>
            public readonly Length2.Calculated this[int axis]
            {
                get
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
            }

            /// <summary>The sum of edge offsets along the X axis in units</summary>
            /// <remarks>
            /// Equivalent to <c><see cref="Left">Left</see>.<see cref="Length.Calculated.Value">Value</see> + <see cref="Right">Right</see>.<see cref="Length.Calculated.Value">Value</see></c>.
            /// </remarks>
            public readonly float Width => Left.Value + Right.Value;

            /// <summary>The sum of edge offsets along the Y axis in units</summary>
            /// <remarks>
            /// Equivalent to <c><see cref="Bottom">Bottom</see>.<see cref="Length.Calculated.Value">Value</see> + <see cref="Top">Top</see>.<see cref="Length.Calculated.Value">Value</see> </c>.
            /// </remarks>
            public readonly float Height => Bottom.Value + Top.Value;

            /// <summary>
            /// A per-axis sum of edge offsets.
            /// </summary>
            /// <returns>A Vector2, <c>v</c>, where <c>v.x == <see cref="Width">Width</see></c> and <c>v.y == <see cref="Height">Height</see></c>.</returns>
            public Vector2 Size => new Vector2(Width, Height);

            /// <summary>
            /// The midpoint shift of the combined edge offsets along their respective axes.
            /// </summary>
            /// 
            /// <remarks>
            /// Equivalent to <c>0.5f * <see langword="new"/> Vector2(<see cref="Left">Left</see>.<see cref="Length.Calculated.Value">Value</see> - <see cref="Right">Right</see>.<see cref="Length.Calculated.Value">Value</see>
            /// , <see cref="Bottom">Bottom</see>.<see cref="Length.Calculated.Value">Value</see> - <see cref="Top">Top</see>.<see cref="Length.Calculated.Value">Value</see>)</c>.
            /// </remarks>
            public Vector2 Offset => 0.5f * new Vector2(Left.Value - Right.Value, Bottom.Value - Top.Value);

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="Calculated"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is Calculated length)
                {
                    return this == length;
                }

                return false;
            }

            /// <summary>The hashcode for this <see cref="Calculated"/>.</summary>
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
            /// The string representation of this <see cref="Calculated"/>.
            /// </summary>
            public override string ToString()
            {
                if (Left == Right)
                {
                    if (Left == Bottom && Left == Top)
                    {
                        return $"CalcRect(All: {Left})";
                    }

                    if (Bottom == Top)
                    {
                        return $"CalcRect(X: {Left}, Y: {Bottom})";
                    }
                }

                return $"Calc(L: {Left}, R: {Right}], B: {Bottom}, T: {Top})";
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="Calculated"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(Calculated other)
            {
                return this == other;
            }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Left == <paramref name="rhs"/>.Left &amp;&amp; <paramref name="lhs"/>.Right == <paramref name="rhs"/>.Right
            /// &amp;&amp; <paramref name="lhs"/>.Bottom == <paramref name="rhs"/>.Bottom &amp;&amp; <paramref name="lhs"/>.Top == <paramref name="rhs"/>.Top</c>.</returns>
            public static bool operator ==(Calculated lhs, Calculated rhs)
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
            public static bool operator !=(Calculated lhs, Calculated rhs)
            {
                return lhs.X != rhs.X || lhs.Y != rhs.Y;
            }


            /// <summary>
            /// Constructs a new <see cref="Calculated"/>.
            /// </summary>
            /// <param name="left">The length assigned to <see cref="Left">Left</see>.</param>
            /// <param name="right">The length assigned to <see cref="Right">Right</see>.</param>
            /// <param name="bottom">The length assigned to <see cref="Bottom">Bottom</see>.</param>
            /// <param name="top">The length assigned to <see cref="Top">Top</see>.</param>
            public Calculated(Length.Calculated left, Length.Calculated right, Length.Calculated bottom, Length.Calculated top)
            {
                Left = left;
                Right = right;
                Bottom = bottom;
                Top = top;

                X = new Length2.Calculated(left, right);
                Y = new Length2.Calculated(bottom, top);
            }

            /// <summary>
            /// Constructs a new <see cref="Calculated"/>.
            /// </summary>
            /// <param name="x">The lengths assigned to <see cref="X">X</see>.</param>
            /// <param name="y">The lengths assigned to <see cref="Y">Y</see>.</param>
            public Calculated(Length2.Calculated x, Length2.Calculated y)
            {
                Left = x.First;
                Right = x.Second;
                Bottom = y.First;
                Top = y.Second;

                X = x;
                Y = y;
            }
        }
        #endregion
    }
}
