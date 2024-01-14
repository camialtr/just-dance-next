// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Describes a type of <see cref="Length"/>.
    /// </summary>
    public enum LengthType
    {
        /// <summary>
        /// A fixed value measurement.
        /// </summary>
        Value = InternalNamespace_0.InternalType_59.InternalField_201,

        /// <summary>
        /// A relative measurement as a percentage.
        /// </summary>
        Percent = InternalNamespace_0.InternalType_59.InternalField_202,
    };

    /// <summary>
    /// A measurement represented as a fixed value or as a percentage.
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_2)]
    public struct Length : IEquatable<Length>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_2 = InternalNamespace_0.InternalType_45.InternalField_144;

        /// <summary>
        /// Zero <see cref="Length"/>.
        /// </summary>
        /// <value>An empty <see cref="Length"/>.</value>
        public static readonly Length Zero = default(Length);

        /// <summary>
        /// Fixed <see cref="Length"/> of 1.
        /// </summary>
        /// <value>A unit <see cref="Length"/>.</value>
        public static readonly Length One = new Length() { Raw = 1, Type = LengthType.Value };

        /// <summary>
        /// The numeric value associated with this <see cref="Length"/>.
        /// </summary>
        /// <value>
        /// If <c><see cref="Type"/> == <see cref="LengthType.Percent"/></c>, <see cref="Raw"/> represents a measurement as a percentage, <c>1 == 100%</c>.
        /// <br/>
        /// If <c><see cref="Type"/> == <see cref="LengthType.Value"/></c>, <see cref="Raw"/> represents a measurement in units.
        /// </value>
        [SerializeField]
        [field: FieldOffset(0 * sizeof(float))]
        public float Raw;

        /// <summary>
        /// The type of <seealso cref="Length"/>.
        /// </summary>
        /// <value>Tells the system how to interpret <see cref="Raw"/></value>.
        [SerializeField]
        [field: FieldOffset(1 * sizeof(float))]
        public LengthType Type;

        /// <summary>
        /// <c>get</c>: If <c><see cref="Type"/> == <see cref="LengthType.Value"/></c>, returns <see cref="Raw"/>. Otherwise returns <c>float.NaN</c>.<br/>
        /// <c>set</c>: Assigns <see cref="Raw"/> to the provided float value and assigns <see cref="Type"/> to <see cref="LengthType.Value"/>.
        /// </summary>
        public float Value
        {
            readonly get
            {
                return Type == LengthType.Value ? Raw : float.NaN;
            }
            set
            {
                if (float.IsNaN(value))
                {
                    return;
                }

                Type = LengthType.Value;
                Raw = value;
            }
        }

        /// <summary>
        /// <c>get</c>: If <c><see cref="Type"/> == <see cref="LengthType.Percent"/></c>, returns <see cref="Raw"/>. Otherwise returns <c>float.NaN</c>.<br/>
        /// <c>set</c>: Assigns <see cref="Raw"/> to the provided float value and assigns <see cref="Type"/> to <see cref="LengthType.Percent"/>.<br/><br/>
        /// <c>1 == 100%</c>.
        /// </summary>
        public float Percent
        {
            readonly get
            {
                return Type == LengthType.Percent ? Raw : float.NaN;
            }
            set
            {
                if (float.IsNaN(value))
                {
                    return;
                }

                Type = LengthType.Percent;
                Raw = value;
            }
        }

        /// <summary>Construct a new <see cref="Length"/>.</summary>
        /// <param name="raw">The numeric value, <see cref="Raw"/>.</param>
        /// <param name="type">The type of length, <see cref="Type"/>.</param>
        public Length(float raw, LengthType type)
        {
            Raw = raw;
            Type = type;
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Percent">Percent</see> <see cref="Length"/>, <c>1 == 100%</c>.
        /// </summary>
        /// <param name="percent">The measurement of the length as a percent, <c>1 == 100%</c>.</param>
        /// <returns>A new <see cref="LengthType.Percent">Percent</see> <see cref="Length"/>.</returns>
        public static Length Percentage(float percent)
        {
            return new Length(percent, LengthType.Percent);
        }

        /// <summary>
        /// Create a new <see cref="LengthType.Value">Value</see> <see cref="Length"/>.
        /// </summary>
        /// <param name="value">The measurement of the length in units.</param>
        /// <returns>A new <see cref="LengthType.Value">Value</see> <see cref="Length"/>.</returns>
        public static Length FixedValue(float value)
        {
            return new Length(value, LengthType.Value);
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length"/>.</returns>
        public static Length operator *(Length lhs, float rhs)
        {
            lhs.Raw *= rhs;
            return lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length"/>.</returns>
        public static Length operator /(Length lhs, float rhs)
        {
            return lhs * (1 / rhs);
        }

        /// <summary>
        /// Multiplication operator, scales <paramref name="rhs"/> by <paramref name="lhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The product as a <see cref="Length"/>.</returns>
        public static Length operator *(float lhs, Length rhs)
        {
            return rhs * lhs;
        }

        /// <summary>
        /// Division operator, divides <paramref name="lhs"/> by <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>The quotient as a <see cref="Length"/>.</returns>
        public static Length operator /(float lhs, Length rhs)
        {
            rhs.Raw = lhs / rhs.Raw;
            return rhs;
        }

        /// <summary>
        /// Numeric negation operator, multiplies <paramref name="rhs"/> by -1.
        /// </summary>
        /// <param name="rhs">Right hand size.</param>
        /// <returns>A new <see cref="Length"/>, <c>length</c>, where <c>length.Raw == -<paramref name="rhs"/>.Raw</c>.</returns>
        public static Length operator -(Length rhs)
        {
            return rhs * -1;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Raw == <paramref name="rhs"/>.Raw &amp;&amp; <paramref name="lhs"/>.Type == <paramref name="rhs"/>.Type</c>.</returns>
        public static bool operator ==(Length lhs, Length rhs)
        {
            return lhs.Raw == rhs.Raw && lhs.Type == rhs.Type;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Raw != <paramref name="rhs"/>.Raw || <paramref name="lhs"/>.Type != <paramref name="rhs"/>.Type</c>.</returns>
        public static bool operator !=(Length lhs, Length rhs)
        {
            return lhs.Raw != rhs.Raw || lhs.Type != rhs.Type;
        }

        /// <summary>
        /// Converts a float, <paramref name="f"/> to a <see cref="LengthType.Value">Value</see> <see cref="Length"/>.
        /// </summary>
        /// <param name="f">The length in units, <see cref="Value"/>.</param>
        public static implicit operator Length(float f)
        {
            return FixedValue(f);
        }

        internal static float InternalMethod_2428(float InternalParameter_2638, Length InternalParameter_2637, MinMax InternalParameter_2636, float InternalParameter_2635)
        {
            return InternalParameter_2637.Type == LengthType.Percent ? InternalParameter_2635 == 0 ? InternalParameter_2637.Raw : InternalParameter_2636.Clamp(InternalParameter_2638) / InternalParameter_2635 : InternalParameter_2636.Clamp(InternalParameter_2638);
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Length"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is Length length)
            {
                return this == length;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Length"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(Length other)
        {
            return this == other;
        }

        /// <summary>The hashcode for this <see cref="Length"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + ((int)Type).GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Raw.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string representation of this <see cref="Length"/>.
        /// </summary>
        public override string ToString()
        {
            return Type == LengthType.Value ? $"{Raw.ToString(InternalType_667.InternalField_3021, InternalType_667.InternalField_3020)}" : $"{(Raw * 100).ToString(InternalType_667.InternalField_3021, InternalType_667.InternalField_3020)}%";
        }

        #region 
        /// <summary>
        /// A calculated, readonly output of a <see cref="Length"/>.
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_4)]
        public readonly struct Calculated : IEquatable<Calculated>
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            internal const int InternalField_4 = InternalNamespace_0.InternalType_45.InternalType_47.InternalField_152;

            /// <summary>
            /// The measurement of the relevant <seealso cref="Length"/> in units.
            /// </summary>
            /// <value><c>Value = <see cref="Percent">Percent</see> * relative</c>.</value>
            [FieldOffset(0 * sizeof(float))]
            public readonly float Value;

            /// <summary>
            /// The measurement of the relevant <seealso cref="Length"/> as a percent of a relative value, <c>1 == 100%</c>.
            /// </summary>
            /// <value><c>Percent = <see cref="Value">Value</see> / relative</c>.</value>
            [FieldOffset(1 * sizeof(float))]
            public readonly float Percent;

            /// <summary>
            /// Addition operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns>A new <see cref="Calculated"/>, <c>length</c>, where <c>length.Value == <paramref name="lhs"/>.Value + <paramref name="rhs"/>.Value</c> and <c>length.Percent == <paramref name="lhs"/>.Percent + <paramref name="rhs"/>.Percent</c>.</returns>
            public static Calculated operator +(Calculated lhs, Calculated rhs)
            {
                return new Calculated(lhs.Value + rhs.Value, lhs.Percent + rhs.Percent);
            }

            /// <summary>
            /// Subtraction operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns>A new <see cref="Calculated"/>, <c>length</c>, where <c>length.Value == <paramref name="lhs"/>.Value - <paramref name="rhs"/>.Value</c> and <c>length.Percent == <paramref name="lhs"/>.Percent - <paramref name="rhs"/>.Percent</c>.</returns>
            public static Calculated operator -(Calculated lhs, Calculated rhs)
            {
                return new Calculated(lhs.Value - rhs.Value, lhs.Percent - rhs.Percent);
            }

            /// <summary>
            /// Division operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns>A new <see cref="Calculated"/>, <c>length</c>, where <c>length.Value == <paramref name="lhs"/>.Value / <paramref name="rhs"/>.Value</c> and <c>length.Percent == <paramref name="lhs"/>.Percent / <paramref name="rhs"/>.Percent</c>.</returns>
            public static Calculated operator /(Calculated lhs, Calculated rhs)
            {
                return new Calculated(lhs.Value / rhs.Value, lhs.Percent / rhs.Percent);
            }

            /// <summary>
            /// Multiplication operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns>A new <see cref="Calculated"/>, <c>length</c>, where <c>length.Value == <paramref name="lhs"/>.Value * <paramref name="rhs"/>.Value</c> and <c>length.Percent == <paramref name="lhs"/>.Percent * <paramref name="rhs"/>.Percent</c>.</returns>
            public static Calculated operator *(Calculated lhs, Calculated rhs)
            {
                return new Calculated(lhs.Value * rhs.Value, lhs.Percent * rhs.Percent);
            }

            /// <summary>
            /// Multiplication operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns>A new <see cref="Calculated"/>, <c>length</c>, where <c>length.Value == <paramref name="lhs"/>.Value * <paramref name="rhs"/></c> and <c>length.Percent == <paramref name="lhs"/>.Percent * <paramref name="rhs"/></c>.</returns>
            public static Calculated operator *(Calculated lhs, float rhs)
            {
                return new Calculated(lhs.Value * rhs, lhs.Percent * rhs);
            }

            /// <summary>
            /// Division operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns>A new <see cref="Calculated"/>, <c>length</c>, where <c>length.Value == <paramref name="lhs"/>.Value / <paramref name="rhs"/></c> and <c>length.Percent == <paramref name="lhs"/>.Percent / <paramref name="rhs"/></c>.</returns>
            public static Calculated operator /(Calculated lhs, float rhs)
            {
                return new Calculated(lhs.Value / rhs, lhs.Percent / rhs);
            }

            /// <summary>
            /// Numeric negation operator.
            /// </summary>
            /// <param name="rhs">Right hand side.</param>
            /// <returns>A new <see cref="Calculated"/>, <c>length</c>, where <c>length.Value == -<paramref name="lhs"/>.Value</c> and <c>length.Percent == -<paramref name="lhs"/>.Percent</c>.</returns>
            public static Calculated operator -(Calculated rhs)
            {
                return new Calculated(-rhs.Value, -rhs.Percent);
            }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Value == <paramref name="rhs"/>.Value &amp;&amp; <paramref name="lhs"/>.Percent == <paramref name="lhs"/>.Percent</c>.</returns>
            public static bool operator ==(Calculated lhs, Calculated rhs)
            {
                return lhs.Value == rhs.Value && lhs.Percent == rhs.Percent;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Value != <paramref name="rhs"/>.Value || <paramref name="lhs"/>.Percent != <paramref name="lhs"/>.Percent</c>.</returns>
            public static bool operator !=(Calculated lhs, Calculated rhs)
            {
                return lhs.Value != rhs.Value || lhs.Percent != rhs.Percent;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The other <see cref="Calculated"/> to compare to.</param>
            /// <returns><see langword="true"/> if <c>this == other</c>.</returns>
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
            /// <param name="other">The other <see cref="Calculated"/> to compare to.</param>
            /// <returns><see langword="true"/> if <c>this == other</c>.</returns>
            public bool Equals(Calculated other)
            {
                return this == other;
            }

            /// <summary>The hashcode for this <see cref="Calculated"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + Percent.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Value.GetHashCode();
                return InternalVar_1;
            }

            /// <param name="value">The measurement of the length in units.</param>
            /// <param name="percent">The measurement of the length as a percent.</param>
            public Calculated(float value, float percent)
            {
                Value = value;
                Percent = percent;
            }

            /// <summary>
            /// The string representation of this <see cref="Calculated"/>.
            /// </summary>
            public override string ToString()
            {
                return $"{{Val = {Value.ToString(InternalType_667.InternalField_3021, InternalType_667.InternalField_3020)}, {(Percent * 100).ToString(InternalType_667.InternalField_3021, InternalType_667.InternalField_3020)}%}}";
            }
        }
        #endregion
    }
}