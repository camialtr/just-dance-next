// Copyright (c) Supernova Technologies LLC
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A 3D <see cref="Length"/>.
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct Length3 : IEquatable<Length3>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_7 = 3 * Length.InternalField_2;

        /// <summary>
        /// The X-axis component of this 3D Length.
        /// </summary>
        [SerializeField]
        [FieldOffset(0 * Length.InternalField_2)]
        public Length X;

        /// <summary>
        /// The Y-axis component of this 3D Length.
        /// </summary>
        [SerializeField]
        [FieldOffset(1 * Length.InternalField_2)]
        public Length Y;

        /// <summary>
        /// The Z-axis component of this 3D Length.
        /// </summary>
        [SerializeField]
        [FieldOffset(2 * Length.InternalField_2)]
        public Length Z;

        /// <summary>
        /// The XY components of this 3D Length as a <see cref="Length2"/>.
        /// </summary>
        [FieldOffset(0 * Length.InternalField_2)]
        [NonSerialized]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Length2 XY;

        /// <summary>
        /// The numeric values associated with this <see cref="Length3"/>.
        /// </summary>
        /// <value>
        /// If <see cref="Length.Type"/> == <see cref="LengthType.Percent"/>, <see cref="Raw"/> represents a measurement as a percentage, <c>1 == 100%</c>.
        /// <br/>
        /// If <see cref="Length.Type"/> == <see cref="LengthType.Value"/>, <see cref="Raw"/> represents a measurement in units.
        /// </value>
        public Vector3 Raw
        {
            readonly get
            {
                return new Vector3(X.Raw, Y.Raw, Z.Raw);
            }
            set
            {
                X.Raw = value.x;
                Y.Raw = value.y;
                Z.Raw = value.z;
            }
        }

        /// <summary>
        /// <c>get</c>: If <c><see cref="Type"/> == <see cref="LengthType.Value"/></c>, returns <see cref="Raw"/>. Otherwise returns <c>float.NaN</c>.<br/>
        /// <c>set</c>: Assigns <see cref="Raw"/> to the provided float value and assigns <see cref="Type"/> to <see cref="LengthType.Value"/>.
        /// </summary>
        public Vector3 Value
        {
            readonly get
            {
                return new Vector3(X.Value, Y.Value, Z.Value);
            }
            set
            {
                X.Value = value.x;
                Y.Value = value.y;
                Z.Value = value.z;
            }
        }

        /// <summary>
        /// <c>get</c>: If <c><see cref="Type"/> == <see cref="LengthType.Percent"/></c>, returns <see cref="Raw"/>. Otherwise returns <c>float.NaN</c>.<br/>
        /// <c>set</c>: Assigns <see cref="Raw"/> to the provided float value and assigns <see cref="Type"/> to <see cref="LengthType.Percent"/>.<br/><br/>
        /// <c>1 == 100%</c>.
        /// </summary>
        public Vector3 Percent
        {
            readonly get
            {
                return new Vector3(X.Percent, Y.Percent, Z.Percent);
            }
            set
            {
                X.Percent = value.x;
                Y.Percent = value.y;
                Z.Percent = value.z;
            }
        }

        /// <summary>
        /// The type of each <seealso cref="Length"/>. Tells the system how to interpret <see cref="Raw"/> per component.
        /// </summary>
        public ThreeD<LengthType> Type
        {
            readonly get
            {
                return new ThreeD<LengthType>(X.Type, Y.Type, Z.Type);
            }
            set
            {
                X.Type = value.X;
                Y.Type = value.Y;
                Z.Type = value.Z;
            }
        }

        /// <summary>
        /// Access each component by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>
        /// <value>2 => <see cref="Z"/></value><br/>.
        /// </param>
        /// <returns>The <see cref="Length"/> for the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
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
                    case 2:
                        return Z;
                }

                throw new IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 2].");
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
                    case 2:
                        Z = value;
                        return;
                }

                throw new IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 2].");
            }
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Value">Value</see> <see cref="Length3"/>.
        /// </summary>
        /// <param name="value">The measurement of the length in units.</param>
        /// <returns>A new <see cref="LengthType.Value">Value</see> <see cref="Length3"/>.</returns>
        public static Length3 FixedValue(Vector3 value)
        {
            Length3 InternalVar_1 = new Length3();
            InternalVar_1.X = Length.FixedValue(value.x);
            InternalVar_1.Y = Length.FixedValue(value.y);
            InternalVar_1.Z = Length.FixedValue(value.z);

            return InternalVar_1;
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Value">Value</see> <see cref="Length3"/> from <paramref name="x"/>, <paramref name="y"/>, and <paramref name="z"/>.
        /// </summary>
        /// <param name="x">The measurement of the x-axis in units.</param>
        /// <param name="y">The measurement of the y-axis in units.</param>
        /// <param name="z">The measurement of the z-axis in units.</param>
        /// <returns>A new <see cref="LengthType.Value">Value</see> <see cref="Length3"/>.</returns>
        public static Length3 FixedValue(float x, float y, float z)
        {
            Length3 InternalVar_1 = new Length3();
            InternalVar_1.X = Length.FixedValue(x);
            InternalVar_1.Y = Length.FixedValue(y);
            InternalVar_1.Z = Length.FixedValue(z);
            return InternalVar_1;
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Percent">Percent</see> <see cref="Length3"/>.
        /// </summary>
        /// <param name="percent">The measurement of the length as a percentage.</param>
        /// <returns>A new <see cref="Length3"/> as a component-wise percentage.</returns>
        public static Length3 Percentage(Vector3 percent)
        {
            Length3 InternalVar_1 = new Length3();
            InternalVar_1.X = Length.Percentage(percent.x);
            InternalVar_1.Y = Length.Percentage(percent.y);
            InternalVar_1.Z = Length.Percentage(percent.z);

            return InternalVar_1;
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Percent">Percent</see> <see cref="Length3"/> from <paramref name="x"/>, <paramref name="y"/>, and <paramref name="z"/>.
        /// </summary>
        /// <param name="x">The measurement of the x-axis as a percentage.</param>
        /// <param name="y">The measurement of the y-axis as a percentage.</param>
        /// <param name="z">The measurement of the z-axis as a percentage.</param>
        /// <returns>A new <see cref="Length3"/> as a component-wise percentage.</returns>
        public static Length3 Percentage(float x, float y, float z)
        {
            Length3 InternalVar_1 = new Length3();
            InternalVar_1.X = Length.Percentage(x);
            InternalVar_1.Y = Length.Percentage(y);
            InternalVar_1.Z = Length.Percentage(z);

            return InternalVar_1;
        }

        /// <summary>
        /// A fixed <see cref="Length3"/> set to <see cref="Length.Zero"/> along all dimensions.
        /// </summary>
        public static readonly Length3 Zero = new Length3()
        {
            X = Length.Zero,
            Y = Length.Zero,
            Z = Length.Zero,
        };

        /// <summary>
        /// A fixed <see cref="Length3"/> set to <see cref="Length.One"/> along all dimensions.
        /// </summary>
        public static readonly Length3 One = new Length3()
        {
            X = Length.One,
            Y = Length.One,
            Z = Length.One,
        };

        /// <summary>
        /// Multiplication operator, scales <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length3"/>.</returns>
        public static Length3 operator *(Length3 lhs, float rhs)
        {
            lhs.X *= rhs;
            lhs.Y *= rhs;
            lhs.Z *= rhs;

            return lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length3"/>.</returns>
        public static Length3 operator /(Length3 lhs, float rhs)
        {
            lhs.X /= rhs;
            lhs.Y /= rhs;
            lhs.Z /= rhs;

            return lhs;
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="rhs"/> by <paramref name="lhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length3"/>.</returns>
        public static Length3 operator *(float lhs, Length3 rhs)
        {
            return rhs * lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length3"/>.</returns>
        public static Length3 operator /(float lhs, Length3 rhs)
        {
            rhs.X = lhs / rhs.X;
            rhs.Y = lhs / rhs.Y;
            rhs.Z = lhs / rhs.Z;

            return rhs;
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="lhs"/> by <paramref name="rhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length3"/>.</returns>
        public static Length3 operator *(Length3 lhs, Vector3 rhs)
        {
            lhs.X *= rhs.x;
            lhs.Y *= rhs.y;
            lhs.Z *= rhs.z;

            return lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length3"/>.</returns>
        public static Length3 operator /(Length3 lhs, Vector3 rhs)
        {
            lhs.X /= rhs.x;
            lhs.Y /= rhs.y;
            lhs.Z /= rhs.z;

            return lhs;
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="rhs"/> by <paramref name="lhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length3"/>.</returns>
        public static Length3 operator *(Vector3 lhs, Length3 rhs)
        {
            return rhs * lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/> component-wise.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length3"/>.</returns>
        public static Length3 operator /(Vector3 lhs, Length3 rhs)
        {
            rhs.X = lhs.x / rhs.X;
            rhs.Y = lhs.y / rhs.Y;
            rhs.Z = lhs.z / rhs.Z;

            return rhs;
        }

        /// <summary>
        /// Numeric negation operator, multiplies <paramref name="rhs"/> by -1.
        /// </summary>
        /// <param name="rhs">Right hand size.</param>
        /// <returns>A new <see cref="Length3"/>, <c>lengths</c>, where <c>lengths.Raw == -<paramref name="rhs"/>.Raw</c>.</returns>
        public static Length3 operator -(Length3 rhs)
        {
            return rhs * -1;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.X == <paramref name="rhs"/>.X &amp;&amp; <paramref name="lhs"/>.Y == <paramref name="rhs"/>.Y &amp;&amp; <paramref name="lhs"/>.Z == <paramref name="rhs"/>.Z</c>.</returns>
        public static bool operator ==(Length3 lhs, Length3 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.X != <paramref name="rhs"/>.X || <paramref name="lhs"/>.Y != <paramref name="rhs"/>.Y || <paramref name="lhs"/>.Z != <paramref name="rhs"/>.Z</c>.</returns>
        public static bool operator !=(Length3 lhs, Length3 rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
        }

        /// <summary>
        /// Constructs a new <see cref="Length3"/> and assigns each component to the provided <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The <see cref="Length"/> to assign.</param>
        public static implicit operator Length3(Length length)
        {
            return new Length3(length, length, length);
        }

        /// <summary>
        /// Constructs a new <see cref="Length3"/> with the <see cref="X">X</see> and <see cref="Y">Y</see> components assigned to <paramref name="lengths"/>.<see cref="Length2.X">X</see> and <paramref name="lengths"/>.<see cref="Length2.Y">Y</see>, respectively, and the <see cref="Z">Z</see> component to <see cref="Length.Zero"/>.
        /// </summary>
        /// <param name="lengths">The <see cref="Length"/>s to assign.</param>
        public static implicit operator Length3(Length2 lengths)
        {
            return new Length3(lengths, Length.Zero);
        }

        /// <summary>
        /// Converts a <see cref="Vector3"/>, <paramref name="v"/>, into a <see cref="LengthType.Value">Value</see> <see cref="Length3"/>.
        /// </summary>
        /// <param name="v">The length in units, <see cref="Value"/>.</param>
        /// <returns>A <see cref="LengthType.Value">Value</see> <see cref="Length3"/> where <c><see cref="Value"/> == <paramref name="v"/></c>.</returns>
        public static implicit operator Length3(Vector3 v)
        {
            return FixedValue(v);
        }

        /// <summary>
        /// Constructs a new <see cref="Length3"/>.
        /// </summary>
        /// <param name="x">The length assigned to <see cref="X">X</see>.</param>
        /// <param name="y">The length assigned to <see cref="Y">Y</see>.</param>
        /// <param name="z">The length assigned to <see cref="Z">Z</see>.</param>
        public Length3(Length x, Length y, Length z)
        {
            X = x;
            Y = y;
            Z = z;

            XY = new Length2(x, y);
        }

        /// <summary>
        /// Constructs a new <see cref="Length3"/> from a <see cref="Length2"/> and <paramref name="z"/> component.
        /// </summary>
        /// <param name="xy">The lengths assigned to <see cref="X">X</see> and <see cref="Y">Y</see>.</param>
        /// <param name="z">The length assigned to <see cref="Z">Z</see>.</param>
        public Length3(Length2 xy, Length z)
        {
            X = xy.X;
            Y = xy.Y;
            Z = z;

            XY = xy;
        }

        internal static Vector3 InternalMethod_2424(Vector3 InternalParameter_2630, Length3 InternalParameter_2594, MinMax3 InternalParameter_2593, Vector3 InternalParameter_2592)
        {
            return new Vector3(Length.InternalMethod_2428(InternalParameter_2630.x, InternalParameter_2594.X, InternalParameter_2593.X, InternalParameter_2592.x),
                               Length.InternalMethod_2428(InternalParameter_2630.y, InternalParameter_2594.Y, InternalParameter_2593.Y, InternalParameter_2592.y),
                               Length.InternalMethod_2428(InternalParameter_2630.z, InternalParameter_2594.Z, InternalParameter_2593.Z, InternalParameter_2592.z));
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Length3"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is Length3 length)
            {
                return this == length;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Length3"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(Length3 other)
        {
            return this == other;
        }

        /// <summary>The hashcode for this <see cref="Length3"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Z.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string representation of this <see cref="Length3"/>.
        /// </summary>
        public override string ToString()
        {
            return $"Length3({X}, {Y}, {Z})";
        }

        #region 
        /// <summary>
        /// A calculated, readonly output of a <see cref="Length3"/>.
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_9)]
        public readonly struct Calculated : IEquatable<Calculated>
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            internal const int InternalField_9 = 3 * Length.Calculated.InternalField_4;

            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="Length3.X"/>.
            /// </summary>
            [FieldOffset(0 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated X;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="Length3.Y"/>.
            /// </summary>
            [FieldOffset(1 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Y;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="Length3.Z"/>.
            /// </summary>
            [FieldOffset(2 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Z;

            /// <summary>
            /// The <see cref="Length2.Calculated"/> output of <see cref="Length3.XY"/>.
            /// </summary>
            [NonSerialized]
            [FieldOffset(0 * Length.Calculated.InternalField_4)]
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public readonly Length2.Calculated XY;

            /// <summary>
            /// Access each component by <paramref name="axis"/> index.
            /// </summary>
            /// <param name="axis">The axis index to read<br/>
            /// <value>0 => <see cref="X"/></value><br/>
            /// <value>1 => <see cref="Y"/></value><br/>
            /// <value>2 => <see cref="Z"/></value><br/>.
            /// </param>
            /// <returns>The <see cref="Length.Calculated"/> for the given index.</returns>
            /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
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
                        case 2:
                            return Z;
                    }

                    throw new IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 2].");
                }
            }

            /// <summary>
            /// A component-wise measurement of the relevant <seealso cref="Length3"/> in units.
            /// </summary>
            /// <value><c>Value = <see cref="Percent">Percent</see> * relative</c></value>
            public readonly Vector3 Value => new Vector3(X.Value, Y.Value, Z.Value);

            /// <summary>
            /// A component-wise measurement of the relevant <seealso cref="Length3"/> as a percent of a relative value, <c>1 == 100%</c>.
            /// </summary>
            /// <value><c>Percent = <see cref="Value">Value</see> / relative</c></value>
            public readonly Vector3 Percent => new Vector3(X.Percent, Y.Percent, Z.Percent);

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.<see cref="X">X</see> == <paramref name="rhs"/>.<see cref="X">X</see>
            /// &amp;&amp; <paramref name="lhs"/>.<see cref="Y">Y</see> == <paramref name="rhs"/>.<see cref="Y">Y</see>
            /// &amp;&amp; <paramref name="lhs"/>.<see cref="Z">Z</see> == <paramref name="rhs"/>.<see cref="Z">Z</see></c>.</returns>
            public static bool operator ==(Calculated lhs, Calculated rhs)
            {
                return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.<see cref="X">X</see> != <paramref name="rhs"/>.<see cref="X">X</see>
            /// || <paramref name="lhs"/>.<see cref="Y">Y</see> != <paramref name="rhs"/>.<see cref="Y">Y</see>
            /// || <paramref name="lhs"/>.<see cref="Z">Z</see> != <paramref name="rhs"/>.<see cref="Z">Z</see></c>.</returns>
            public static bool operator !=(Calculated lhs, Calculated rhs)
            {
                return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
            }

            /// <summary>The hashcode for this <see cref="Calculated"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Z.GetHashCode();
                return InternalVar_1;
            }

            /// <summary>
            /// The string representation of this <see cref="Calculated"/>.
            /// </summary>
            public override string ToString()
            {
                return $"Calc3({X}, {Y}, {Z})";
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

            /// <summary>
            /// Constructs a new <see cref="Calculated"/>.
            /// </summary>
            /// <param name="x">The length assigned to <see cref="X">X</see>.</param>
            /// <param name="y">The length assigned to <see cref="Y">Y</see>.</param>
            /// <param name="z">The length assigned to <see cref="Z">Z</see>.</param>
            public Calculated(Length.Calculated x, Length.Calculated y, Length.Calculated z)
            {
                X = x;
                Y = y;
                Z = z;

                XY = new Length2.Calculated(x, y);
            }
        }
        #endregion
    }
}
