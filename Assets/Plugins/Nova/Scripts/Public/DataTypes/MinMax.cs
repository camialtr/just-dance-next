// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A min/max range.
    /// </summary>
    ///<seealso cref="Length"/>
    ///<seealso cref="Length.Calculated"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_3025)]
    public struct MinMax : IEquatable<MinMax>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_3025 = InternalNamespace_0.InternalType_45.InternalType_46.InternalField_147;

        /// <summary>
        /// The minimum allowed measurement in units.
        /// </summary>
        [SerializeField]
        [FieldOffset(0 * sizeof(float))]
        public float Min;
        /// <summary>
        /// The maximum allowed measurement in units.
        /// </summary>
        [SerializeField]
        [FieldOffset(1 * sizeof(float))]
        public float Max;

        /// <summary>
        /// Indicates whether or not this MinMax has a minimum.
        /// </summary>
        /// <returns><see langword="true"/> if <see cref="Min"/> is finite.</returns>
        public readonly bool HasMin => !float.IsInfinity(Min);

        /// <summary>
        /// Indicates whether or not this MinMax has a maximum.
        /// </summary>
        /// <returns><see langword="true"/> if <see cref="Max"/> is finite.</returns>
        public readonly bool HasMax => !float.IsInfinity(Max);

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Min == <paramref name="rhs"/>.Min &amp;&amp; <paramref name="lhs"/>.Max == <paramref name="rhs"/>.Max</c>.</returns>
        public static bool operator ==(in MinMax lhs, in MinMax rhs)
        {
            return lhs.Min == rhs.Min && lhs.Max == rhs.Max;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Min != <paramref name="rhs"/>.Min || <paramref name="lhs"/>.Max != <paramref name="rhs"/>.Max</c>.</returns>
        public static bool operator !=(in MinMax lhs, in MinMax rhs)
        {
            return lhs.Max != rhs.Max || lhs.Min != rhs.Min;
        }

        /// <summary>
        /// Clamps <paramref name="value"/> to the range defined by <see cref="Min"/> and <see cref="Max"/>.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns><paramref name="value"/> clamped to the range defined by <see cref="Min"/> and <see cref="Max"/>.</returns>
        public float Clamp(float value)
        {
            if (!float.IsInfinity(value))
            {
                return Min > value ? Min :
                       Max < value ? Max :
                       value;
            }

            if (HasMin)
            {
                return Min;
            }

            if (HasMax)
            {
                return Max;
            }

            return 0;
        }

        /// <summary>
        /// Clamps <paramref name="value"/> to the range defined by <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The min value of the acceptable range.</param>
        /// <param name="max">The max value of the acceptable range.</param>
        /// <returns><paramref name="value"/> clamped to the range defined by <paramref name="min"/> and <paramref name="max"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max)
        {
            return new MinMax(min, max).Clamp(value);
        }

        /// <summary>Construct a new <see cref="MinMax"/> for the given range.</summary>
        /// <param name="min">The min value of the acceptable range.</param>
        /// <param name="max">The max value of the acceptable range.</param>
        public MinMax(float min, float max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// A <see cref="MinMax"/> where <see cref="Min"/> == <c>float.NegativeInfinity</c> and <see cref="Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static readonly MinMax Unclamped = new MinMax() { Min = float.NegativeInfinity, Max = float.PositiveInfinity };
        /// <summary>
        /// A <see cref="MinMax"/> where <see cref="Min"/> == 0 and <see cref="Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static readonly MinMax Positive = new MinMax() { Min = 0, Max = float.PositiveInfinity };

        /// <summary>The hashcode for this <see cref="MinMax"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Min.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Max.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="object"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == other</c>.</returns>
        public override bool Equals(object other)
        {
            if (other is MinMax minMax)
            {
                return this == minMax;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMax"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == other</c>.</returns>
        public bool Equals(MinMax other)
        {
            return this == other;
        }

        /// <summary>
        /// The string representation of this <see cref="MinMax"/>.
        /// </summary>
        public override string ToString()
        {
            return $"[{Min.ToString(InternalType_667.InternalField_3021, InternalType_667.InternalField_3020)}, {Max.ToString(InternalType_667.InternalField_3021, InternalType_667.InternalField_3020)}]";
        }
    }
}
