// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A min/max range, per 2D component, X and Y.
    /// </summary>
    /// <remarks><see cref="X"/> and <see cref="First"/> read from and write to the same location in memory, as do <see cref="Y"/> and <see cref="Second"/>. This makes them interchangable and subject to user preference or context.</remarks>
    /// <seealso cref="Length2"/>
    /// <seealso cref="Length2.Calculated"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_3024)]
    public struct MinMax2 : IEquatable<MinMax2>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_3024 = 2 * MinMax.InternalField_3025;

        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the X component.
        /// </summary>
        /// <remarks>Memory aligned with <see cref="First"/>, making the two interchangeable.</remarks>
        [FieldOffset(0 * MinMax.InternalField_3025)]
        public MinMax X;

        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Y component.
        /// </summary>
        /// <remarks>Memory aligned with <see cref="Second"/>, making the two interchangeable.</remarks>
        [FieldOffset(1 * MinMax.InternalField_3025)]
        public MinMax Y;

        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the First component.
        /// </summary>
        /// <remarks>Memory aligned with <see cref="X"/>, making the two interchangeable.</remarks>
        [NonSerialized, FieldOffset(0 * MinMax.InternalField_3025)]
        public MinMax First;

        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Second component.
        /// </summary>
        /// <remarks>Memory aligned with <see cref="Y"/>, making the two interchangeable.</remarks>
        [NonSerialized, FieldOffset(1 * MinMax.InternalField_3025)]
        public MinMax Second;

        /// <summary>
        /// The minimum allowed measurement in units, component-wise.
        /// </summary>
        public Vector2 Min
        {
            readonly get => new Vector2(X.Min, Y.Min);
            set
            {
                X.Min = value.x;
                Y.Min = value.y;
            }
        }

        /// <summary>
        /// The maximum allowed measurement in units, component-wise.
        /// </summary>
        public Vector2 Max
        {
            readonly get => new Vector2(X.Max, Y.Max);
            set
            {
                X.Max = value.x;
                Y.Max = value.y;
            }
        }

        /// <summary>
        /// Construct a new <see cref="MinMax2"/>.
        /// </summary>
        /// <param name="x">The <see cref="MinMax"/> to assign to <see cref="X"/>, <see cref="First"/>.</param>
        /// <param name="y">The <see cref="MinMax"/> to assign to <see cref="Y"/>, <see cref="Second"/>.</param>
        public MinMax2(MinMax x, MinMax y)
        {
            X = First = x;
            Y = Second = y;
        }

        /// <summary>
        /// Access each component by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/>, <see cref="First"/></value><br/>
        /// <value>1 => <see cref="Y"/>, <see cref="Second"/></value><br/>.
        /// </param>
        /// <returns>The <see cref="MinMax"/> for the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 1</exception>
        public MinMax this[int axis]
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
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.<see cref="X">X</see> == <paramref name="rhs"/>.<see cref="X">X</see> &amp;&amp; <paramref name="lhs"/>.<see cref="Y">Y</see> == <paramref name="rhs"/>.<see cref="Y">Y</see></c>.</returns>
        public static bool operator ==(MinMax2 lhs, MinMax2 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.<see cref="X">X</see> != <paramref name="rhs"/>.<see cref="X">X</see> || <paramref name="lhs"/>.<see cref="Y">Y</see> != <paramref name="rhs"/>.<see cref="Y">Y</see></c>.</returns>
        public static bool operator !=(MinMax2 lhs, MinMax2 rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMax2"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is MinMax2 minMax)
            {
                return this == minMax;
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="MinMax2"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMax2"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(MinMax2 other)
        {
            return X == other.X && Y == other.Y;
        }


        /// <summary>
        /// The string representation of this <see cref="MinMax2"/>.
        /// </summary>
        public override string ToString()
        {
            return $"MinMax2({X}, {Y})";
        }

        /// <summary>
        /// A <see cref="MinMax2"/> where <see cref="Min"/> == <c>float.NegativeInfinity</c> and <see cref="Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static readonly MinMax2 Unclamped = new MinMax2() { Min = float.NegativeInfinity * Vector2.one, Max = float.PositiveInfinity * Vector2.one };

        /// <summary>
        /// A <see cref="MinMax2"/> where <see cref="Min"/> == 0 and <see cref="Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static readonly MinMax2 Positive = new MinMax2() { Min = Vector2.zero, Max = float.PositiveInfinity * Vector2.one };
    }
}
