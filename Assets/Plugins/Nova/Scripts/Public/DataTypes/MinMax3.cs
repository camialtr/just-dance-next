// Copyright (c) Supernova Technologies LLC
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A min/max range, per 3D component, X, Y, and Z.
    /// </summary>
    /// <seealso cref="Length3"/>
    /// <seealso cref="Length3.Calculated"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit, Size = InternalField_3023)]
    public struct MinMax3 : IEquatable<MinMax3>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_3023 = 3 * MinMax.InternalField_3025;

        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the X component.
        /// </summary>
        [SerializeField]
        [FieldOffset(0 * MinMax.InternalField_3025)]
        public MinMax X;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Y component.
        /// </summary>
        [SerializeField]
        [FieldOffset(1 * MinMax.InternalField_3025)]
        public MinMax Y;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Z component.
        /// </summary>
        [SerializeField]
        [FieldOffset(2 * MinMax.InternalField_3025)]
        public MinMax Z;

        /// <summary>
        /// The <see cref="MinMax2"/> used to clamp the X and Y components.
        /// </summary>
        [NonSerialized]
        [FieldOffset(0 * MinMax.InternalField_3025)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public MinMax2 XY;

        /// <summary>
        /// The minimum allowed measurement in units, component-wise.
        /// </summary>
        public Vector3 Min
        {
            readonly get => new Vector3(X.Min, Y.Min, Z.Min);
            set
            {
                X.Min = value.x;
                Y.Min = value.y;
                Z.Min = value.z;
            }
        }

        /// <summary>
        /// The maximum allowed measurement in units, component-wise.
        /// </summary>
        public Vector3 Max
        {
            readonly get => new Vector3(X.Max, Y.Max, Z.Max);
            set
            {
                X.Max = value.x;
                Y.Max = value.y;
                Z.Max = value.z;
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
        /// <returns>The <see cref="MinMax"/> for the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
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
        /// Clamps <paramref name="value"/> to the range defined by <see cref="Min"/> and <see cref="Max"/>.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns><paramref name="value"/> clamped to the range defined by <see cref="Min"/> and <see cref="Max"/>.</returns>
        public Vector3 Clamp(Vector3 value)
        {
            return new Vector3(X.Clamp(value.x), Y.Clamp(value.y), Z.Clamp(value.z));
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Min == <paramref name="rhs"/>.Min &amp;&amp; <paramref name="lhs"/>.Max == <paramref name="rhs"/>.Max</c>.</returns>
        public static bool operator ==(MinMax3 lhs, MinMax3 rhs)
        {
            return lhs.Min == rhs.Min && lhs.Max == rhs.Max;
        }


        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Min != <paramref name="rhs"/>.Min || <paramref name="lhs"/>.Max != <paramref name="rhs"/>.Max</c>.</returns>
        public static bool operator !=(MinMax3 lhs, MinMax3 rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMax3"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is MinMax3 MinMax3)
            {
                return this == MinMax3;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMax3"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(MinMax3 other)
        {
            return this == other;
        }

        /// <summary>The hashcode for this <see cref="MinMax3"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Z.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string representation of this <see cref="MinMax3"/>.
        /// </summary>
        public override string ToString()
        {
            return $"MinMax3({X}, {Y}, {Z})";
        }

        /// <summary>
        /// Construct a new <see cref="MinMax3"/>.
        /// </summary>
        /// <param name="x">The <see cref="MinMax"/> to assign to <see cref="X"/>.</param>
        /// <param name="y">The <see cref="MinMax"/> to assign to <see cref="Y"/>.</param>
        /// <param name="z">The <see cref="MinMax"/> to assign to <see cref="Z"/>.</param>
        public MinMax3(MinMax x, MinMax y, MinMax z)
        {
            X = x;
            Y = y;
            Z = z;

            XY = new MinMax2(x, y);
        }

        /// <summary>
        /// A <see cref="MinMax3"/> where <see cref="Min"/> == <c>float.NegativeInfinity</c> and <see cref="Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static MinMax3 Unclamped = new MinMax3()
        {
            X = MinMax.Unclamped,
            Y = MinMax.Unclamped,
            Z = MinMax.Unclamped,
        };

        /// <summary>
        /// A <see cref="MinMax3"/> where <see cref="Min"/> == 0 and <see cref="Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static MinMax3 Positive = new MinMax3()
        {
            X = MinMax.Positive,
            Y = MinMax.Positive,
            Z = MinMax.Positive,
        };
    }
}
