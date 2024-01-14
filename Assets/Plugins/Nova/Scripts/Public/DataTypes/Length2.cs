// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A 2D <see cref="Length"/> or a <see cref="Length"/> Pair.
    /// </summary>
    /// <remarks><see cref="X"/> and <see cref="First"/> read from and write to the same location in memory, as do <see cref="Y"/> and <see cref="Second"/>. This makes them interchangable and subject to user preference or context.</remarks>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct Length2 : IEquatable<Length2>
    {
        /// <summary>
        /// The X-axis component of this 2D Length.
        /// </summary>
        /// <remarks>Memory aligned with <see cref="First"/>, making the two interchangeable.</remarks>
        [SerializeField]
        [FieldOffset(0 * Length.InternalField_2)]
        public Length X;
        /// <summary>
        /// The Y-axis component of this 2D Length.
        /// </summary>
        /// <remarks>Memory aligned with <see cref="Second"/>, making the two interchangeable.</remarks>
        [SerializeField]
        [FieldOffset(1 * Length.InternalField_2)]
        public Length Y;

        /// <summary>
        /// The first component of this Length Pair.
        /// </summary>
        /// <remarks>Memory aligned  with <see cref="X"/>, making the two interchangeable.</remarks>
        [FieldOffset(0 * Length.InternalField_2)]
        [NonSerialized]
        public Length First;

        /// <summary>
        /// The second component of this Length Pair.
        /// </summary>
        /// <remarks>Memory aligned  with <see cref="Y"/>, making the two interchangeable.</remarks>
        [FieldOffset(1 * Length.InternalField_2)]
        [NonSerialized]
        public Length Second;

        /// <summary>
        /// <c>get</c>: If <c><see cref="Type"/> == <see cref="LengthType.Value"/></c>, returns <see cref="Raw"/>. Otherwise returns <c>float.NaN</c>.<br/>
        /// <c>set</c>: Assigns <see cref="Raw"/> to the provided float value and assigns <see cref="Type"/> to <see cref="LengthType.Value"/>.
        /// </summary>
        public Vector2 Value
        {
            readonly get
            {
                return new Vector2(X.Value, Y.Value);
            }
            set
            {
                X.Value = value.x;
                Y.Value = value.y;
            }
        }

        /// <summary>
        /// <c>get</c>: If <c><see cref="Type"/> == <see cref="LengthType.Percent"/></c>, returns <see cref="Raw"/>. Otherwise returns <c>float.NaN</c>.<br/>
        /// <c>set</c>: Assigns <see cref="Raw"/> to the provided float value and assigns <see cref="Type"/> to <see cref="LengthType.Percent"/>.<br/><br/>
        /// <c>1 == 100%</c>.
        /// </summary>
        public Vector2 Percent
        {
            readonly get
            {
                return new Vector2(X.Percent, Y.Percent);
            }
            set
            {
                X.Percent = value.x;
                Y.Percent = value.y;
            }
        }

        /// <summary>
        /// The numeric values associated with this <see cref="Length2"/>.
        /// </summary>
        /// <value>
        /// If <see cref="Length.Type"/> == <see cref="LengthType.Percent"/>, <see cref="Raw"/> represents a measurement as a percentage, <c>1 == 100%</c>.
        /// <br/>
        /// If <see cref="Length.Type"/> == <see cref="LengthType.Value"/>, <see cref="Raw"/> represents a measurement in units.
        /// </value>
        public Vector2 Raw
        {
            readonly get
            {
                return new Vector2(X.Raw, Y.Raw);
            }
            set
            {
                X.Raw = value.x;
                Y.Raw = value.y;
            }
        }

        /// <summary>
        /// The type of each <seealso cref="Length"/>. Tells the system how to interpret <see cref="Raw"/> per component.
        /// </summary>
        public TwoD<LengthType> Type
        {
            readonly get
            {
                return new TwoD<LengthType>(X.Type, Y.Type);
            }
            set
            {
                X.Type = value.X;
                Y.Type = value.Y;
            }
        }

        /// <summary>
        /// Access each component by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The index to read or write<br/>
        /// <value>0 => <see cref="X"/>, <see cref="First"/></value><br/>
        /// <value>1 => <see cref="Y"/>, <see cref="Second"/></value><br/>.
        /// </param>
        /// <returns>The <see cref="Length"/> for the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 1</exception>
        public Length this[int axis]
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
        /// Create a new <see cref="LengthType.Value">Value</see> <see cref="Length2"/>.
        /// </summary>
        /// <param name="value">The measurement of the length in units.</param>
        /// <returns>A new <see cref="LengthType.Value">Value</see> <see cref="Length2"/>.</returns>
        public static Length2 FixedValue(Vector2 value)
        {
            Length2 InternalVar_1 = new Length2();
            InternalVar_1.X = Length.FixedValue(value.x);
            InternalVar_1.Y = Length.FixedValue(value.y);

            return InternalVar_1;
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Value">Value</see> <see cref="Length2"/> from <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <param name="x">The measurement of the x-axis in units.</param>
        /// <param name="y">The measurement of the y-axis in units.</param>
        /// <returns>A new <see cref="LengthType.Value">Value</see> <see cref="Length2"/>.</returns>
        public static Length2 FixedValue(float x, float y)
        {
            Length2 InternalVar_1 = new Length2();
            InternalVar_1.X = Length.FixedValue(x);
            InternalVar_1.Y = Length.FixedValue(y);
            return InternalVar_1;
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Percent">Percent</see> <see cref="Length2"/>.
        /// </summary>
        /// <param name="percent">The measurement of the length as a percentage.</param>
        /// <returns>A new <see cref="Length2"/> as a component-wise percentage.</returns>
        public static Length2 Percentage(Vector2 percent)
        {
            Length2 InternalVar_1 = new Length2();
            InternalVar_1.X = Length.Percentage(percent.x);
            InternalVar_1.Y = Length.Percentage(percent.y);

            return InternalVar_1;
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Percent">Percent</see> <see cref="Length2"/> from <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <param name="x">The measurement of the x-axis as a percentage.</param>
        /// <param name="y">The measurement of the y-axis as a percentage.</param>
        /// <returns>A new <see cref="Length2"/> as a component-wise percentage.</returns>
        public static Length2 Percentage(float x, float y)
        {
            Length2 InternalVar_1 = new Length2();
            InternalVar_1.X = Length.Percentage(x);
            InternalVar_1.Y = Length.Percentage(y);
            return InternalVar_1;
        }

        /// <summary>
        /// Constructs a new Length2 and assigns each component to <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The <see cref="Length"/> to assign.</param>
        public static implicit operator Length2(Length length)
        {
            return new Length2()
            {
                X = length,
                Y = length,
            };
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length2"/>.</returns>
        public static Length2 operator *(Length2 lhs, float rhs)
        {
            lhs.X *= rhs;
            lhs.Y *= rhs;

            return lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length2"/>.</returns>
        public static Length2 operator /(Length2 lhs, float rhs)
        {
            lhs.X /= rhs;
            lhs.Y /= rhs;

            return lhs;
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="rhs"/> by <paramref name="lhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length2"/>.</returns>
        public static Length2 operator *(float lhs, Length2 rhs)
        {
            return rhs * lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length2"/>.</returns>
        public static Length2 operator /(float lhs, Length2 rhs)
        {
            rhs.X = lhs / rhs.X;
            rhs.Y = lhs / rhs.Y;

            return rhs;
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="lhs"/> by <paramref name="rhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length2"/>.</returns>
        public static Length2 operator *(Length2 lhs, Vector2 rhs)
        {
            lhs.X *= rhs.x;
            lhs.Y *= rhs.y;

            return lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length2"/>.</returns>
        public static Length2 operator /(Length2 lhs, Vector2 rhs)
        {
            lhs.X /= rhs.x;
            lhs.Y /= rhs.y;

            return lhs;
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="rhs"/> by <paramref name="lhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length2"/>.</returns>
        public static Length2 operator *(Vector2 lhs, Length2 rhs)
        {
            return rhs * lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>A new <see cref="Length2"/> quotient.</returns>
        public static Length2 operator /(Vector2 lhs, Length2 rhs)
        {
            rhs.X = lhs.x / rhs.X;
            rhs.Y = lhs.y / rhs.Y;

            return rhs;
        }

        /// <summary>
        /// Numeric negation operator, multiplies <paramref name="rhs"/> by -1.
        /// </summary>
        /// <param name="rhs">Right hand size.</param>
        /// <returns>A new <see cref="Length2"/>, <c>lengths</c>, where <c>lengths.Raw == -<paramref name="rhs"/>.Raw</c>.</returns>
        public static Length2 operator -(Length2 rhs)
        {
            return rhs * -1;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.X == <paramref name="rhs"/>.X &amp;&amp; <paramref name="lhs"/>.Y == <paramref name="rhs"/>.Y</c>.</returns>
        public static bool operator ==(Length2 lhs, Length2 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.X != <paramref name="rhs"/>.X || <paramref name="lhs"/>.Y != <paramref name="rhs"/>.Y</c>.</returns>
        public static bool operator !=(Length2 lhs, Length2 rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }

        /// <summary>
        /// Converts a <see cref="Vector2"/>, <paramref name="v"/>, into a <see cref="LengthType.Value">Value</see> <see cref="Length2"/>.
        /// </summary>
        /// <param name="v">The length in units, <see cref="Value"/>.</param>
        /// <returns>A <see cref="LengthType.Value">Value</see> <see cref="Length2"/> where <c><see cref="Value"/> == <paramref name="v"/></c>.</returns>
        public static implicit operator Length2(Vector2 v)
        {
            return FixedValue(v);
        }

        /// <summary>
        /// Constructs a new <see cref="Length2"/>.
        /// </summary>
        /// <param name="x">The length to assign to <see cref="X"/>.</param>
        /// <param name="y">The length to assign to <see cref="Y"/>.</param>
        public Length2(Length x, Length y)
        {
            X = First = x;
            Y = Second = y;
        }

        internal static Vector2 InternalMethod_2426(Vector2 InternalParameter_2634, Length2 InternalParameter_2633, MinMax2 InternalParameter_2632, Vector2 InternalParameter_2631)
        {
            return new Vector2(Length.InternalMethod_2428(InternalParameter_2634.x, InternalParameter_2633.X, InternalParameter_2632.X, InternalParameter_2631.x),
                               Length.InternalMethod_2428(InternalParameter_2634.y, InternalParameter_2633.Y, InternalParameter_2632.Y, InternalParameter_2631.y));
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Length2"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(Length2 other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Length2"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is Length2 length)
            {
                return this == length;
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="Length2"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string representation of this <see cref="Length2"/>.
        /// </summary>
        public override string ToString()
        {
            return $"Length2({X}, {Y})";
        }

        /// <summary>
        /// A fixed <see cref="Length2"/> set to <see cref="Length.Zero"/> along all dimensions.
        /// </summary>
        public static readonly Length2 Zero = new Length2(Length.Zero, Length.Zero);

        /// <summary>
        /// A fixed <see cref="Length2"/> set to <see cref="Length.One"/> along along all dimensions.
        /// </summary>
        public static readonly Length2 One = new Length2()
        {
            X = Length.One,
            Y = Length.One
        };

        #region 

        /// <summary>
        /// A calculated, readonly output of a <see cref="Length2"/>.
        /// </summary>
        /// <remarks><see cref="X"/> and <see cref="First"/> read from the same location in memory, as do <see cref="Y"/> and <see cref="Second"/>. This makes them interchangable and subject to user preference or context.</remarks>
        [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_6)]
        public readonly struct Calculated : IEquatable<Calculated>
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            internal const int InternalField_6 = 2 * Length.Calculated.InternalField_4;

            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="Length2.X"/>.
            /// </summary>
            /// <remarks>Memory aligned with <see cref="First"/>, making the two interchangeable.</remarks>
            [FieldOffset(0 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated X;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="Length2.Y"/>.
            /// </summary>
            /// <remarks>Memory aligned with <see cref="Second"/>, making the two interchangeable.</remarks>
            [FieldOffset(1 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Y;

            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="Length2.First"/>.
            /// </summary>
            /// <remarks>Memory aligned with <see cref="X"/>, making the two interchangeable.</remarks>
            [NonSerialized, FieldOffset(0 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated First;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="Length2.Second"/>.
            /// </summary>
            /// <remarks>Memory aligned with <see cref="Y"/>, making the two interchangeable.</remarks>
            [NonSerialized, FieldOffset(1 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Second;

            /// <summary>
            /// The sum of <c><see cref="First">First</see>.<see cref="Length.Calculated.Value">Value</see> + <see cref="Second">Second</see>.<see cref="Length.Calculated.Value">Value</see></c>.
            /// </summary>
            public readonly Length.Calculated Sum() => First + Second;

            /// <summary>
            /// Access each component by <paramref name="axis"/> index.
            /// </summary>
            /// <param name="axis">The axis index to read<br/>
            /// <value>0 => <see cref="X"/>, <see cref="First"/></value><br/>
            /// <value>1 => <see cref="Y"/>, <see cref="Second"/></value><br/>.
            /// </param>
            /// <returns>The <see cref="Length.Calculated"/> for the given index.</returns>
            /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 1</exception>
            public readonly Length.Calculated this[int axis]
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

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.<see cref="X">X</see> == <paramref name="rhs"/>.<see cref="X">X</see>
            /// &amp;&amp; <paramref name="lhs"/>.<see cref="Y">Y</see> == <paramref name="rhs"/>.<see cref="Y">Y</see></c>.</returns>
            public static bool operator ==(Calculated lhs, Calculated rhs)
            {
                return lhs.X == rhs.X && lhs.Y == rhs.Y;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.<see cref="X">X</see> != <paramref name="rhs"/>.<see cref="X">X</see> || <paramref name="lhs"/>.<see cref="Y">Y</see> != <paramref name="rhs"/>.<see cref="Y">Y</see></c>.</returns>
            public static bool operator !=(Calculated lhs, Calculated rhs)
            {
                return lhs.X != rhs.X || lhs.Y != rhs.Y;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="Calculated"/> to compare to.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is Calculated length)
                {
                    return this == length;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="Calculated"/> to compare to.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(Calculated other)
            {
                return this == other;
            }

            /// <summary>The hashcode for this <see cref="Calculated"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
                return InternalVar_1;
            }

            /// <summary>
            /// The string representation of this <see cref="Calculated"/>.
            /// </summary>
            public override string ToString()
            {
                return $"Calc2({X}, {Y})";
            }

            /// <summary>
            /// The measurement of the relevant <seealso cref="Length2"/> in units.
            /// </summary>
            public readonly Vector2 Value => new Vector2(X.Value, Y.Value);

            /// <summary>
            /// The measurement of the relevant <seealso cref="Length2"/> as a percent of a relative value, <c>1 == 100%</c>.
            /// </summary>
            public readonly Vector2 Percent => new Vector2(X.Percent, Y.Percent);

            public Calculated(Length.Calculated x, Length.Calculated y)
            {
                X = First = x;
                Y = Second = y;
            }
        }
        #endregion
    }
}

