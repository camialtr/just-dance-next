// Copyright (c) Supernova Technologies LLC
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Nova
{ 
    /// <summary>
    /// A generic 3D wrapper.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to store per 3D axis, X, Y, and Z.</typeparam>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ThreeD<T> : IEquatable<ThreeD<T>> where T : unmanaged
    {
        /// <summary>
        /// The value mapped to the X axis.
        /// </summary>
        public T X;
        /// <summary>
        /// The value mapped to the Y axis.
        /// </summary>
        public T Y;
        /// <summary>
        /// The value mapped to the Z axis.
        /// </summary>
        public T Z;

        /// <summary>
        /// Maps the X and Y values to a <see cref="TwoD{T}"/>.
        /// </summary>
        /// <remarks>
        /// <value><see cref="X"/> &lt;=&gt; <see cref="TwoD{T}.X"/></value><br/>
        /// <value><see cref="Y"/> &lt;=&gt; <see cref="TwoD{T}.Y"/></value>
        /// </remarks>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public TwoD<T> XY
        {
            get
            {
                return new TwoD<T>(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Maps the X and Z values to a <see cref="TwoD{T}"/>.
        /// </summary>
        /// <remarks>
        /// <value><see cref="X"/> &lt;=&gt; <see cref="TwoD{T}.X"/></value><br/>
        /// <value><see cref="Z"/> &lt;=&gt; <see cref="TwoD{T}.Y"/></value>
        /// </remarks>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public TwoD<T> XZ
        {
            get
            {
                return new TwoD<T>(X, Z);
            }
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Maps the Y and Z values to a <see cref="TwoD{T}"/>.
        /// </summary>
        /// <remarks>
        /// <value><see cref="Y"/> &lt;=&gt; <see cref="TwoD{T}.X"/></value><br/>
        /// <value><see cref="Z"/> &lt;=&gt; <see cref="TwoD{T}.Y"/></value>
        /// </remarks>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public TwoD<T> YZ
        {
            get
            {
                return new TwoD<T>(Y, Z);
            }
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Access each <typeparamref name="T"/> by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>
        /// <value>2 => <see cref="Z"/></value><br/>
        /// </param>
        /// <returns>The <typeparamref name="T"/> for the given <paramref name="axis"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
        public T this[int axis]
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
        /// Constructs a new <see cref="ThreeD{T}"/>.
        /// </summary>
        /// <param name="x">The value assigned to <see cref="X"/>.</param>
        /// <param name="y">The value assigned to <see cref="Y"/>.</param>
        /// <param name="z">The value assigned to <see cref="Z"/>.</param>
        public ThreeD(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The string representation of this <see cref="ThreeD{T}"/>.
        /// </summary>
        public override string ToString()
        {
            return $"3D({X}, {Y}, {Z})";
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <typeparamref name="T"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this.X == <paramref name="other"/>.X &amp;&amp; this.Y == <paramref name="other"/>.Y &amp;&amp; this.Z == <paramref name="other"/>.Z</c>.</returns>
        public bool Equals(ThreeD<T> other)
        {
            return EqualityComparer<T>.Default.Equals(X, other.X) && EqualityComparer<T>.Default.Equals(Y, other.Y) && EqualityComparer<T>.Default.Equals(Z, other.Z);
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <typeparamref name="T"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this.X == <paramref name="other"/>.X &amp;&amp; this.Y == <paramref name="other"/>.Y &amp;&amp; this.Z == <paramref name="other"/>.Z</c>.</returns>
        public override bool Equals(object other)
        {
            if (other is ThreeD<T> threeD)
            {
                return Equals(threeD);
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="ThreeD{T}"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Z.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// A component-wise Equality operator. For an all-or-nothing Equality compare., use <see cref="Equals(ThreeD{T})"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>A <see cref="bool"/> per axis. If the compared values along that axis are equal, the returned value for that axis will be <see langword="true"/>.</returns>
        public static ThreeD<bool> operator ==(ThreeD<T> lhs, ThreeD<T> rhs)
        {
            return new ThreeD<bool>(EqualityComparer<T>.Default.Equals(lhs.X, rhs.X),
                                    EqualityComparer<T>.Default.Equals(lhs.Y, rhs.Y),
                                    EqualityComparer<T>.Default.Equals(lhs.Z, rhs.Z));
        }

        /// <summary>
        /// A component-wise Inequality operator. For an all-or-nothing inEquality compare., use !<see cref="Equals(ThreeD{T})"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>A <see cref="bool"/> per axis. If the compared values along that axis are not equal, the returned value for that axis will be <see langword="true"/>.</returns>
        public static ThreeD<bool> operator !=(ThreeD<T> lhs, ThreeD<T> rhs)
        {
            return new ThreeD<bool>(!EqualityComparer<T>.Default.Equals(lhs.X, rhs.X),
                                    !EqualityComparer<T>.Default.Equals(lhs.Y, rhs.Y),
                                    !EqualityComparer<T>.Default.Equals(lhs.Z, rhs.Z));
        }


        /// <summary>
        /// Assigns both <see cref="X"/>, <see cref="Y"/>, and <see cref="Z"/> to the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator ThreeD<T>(T value)
        {
            return new ThreeD<T>(value, value, value);
        }

        /// <summary>
        /// Assigns both <see cref="X"/> and <see cref="Y"/> to <paramref name="value"/>.X and <paramref name="value"/>.Y, respectively, and assigns <see cref="Z"/> to <c>default</c>"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator ThreeD<T>(TwoD<T> value)
        {
            return new ThreeD<T>(value.X, value.Y, default(T));
        }

        /// <summary>
        /// Drops the <see cref="Z"/> component and returns <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator TwoD<T>(ThreeD<T> value)
        {
            return value.XY;
        }
    }
}
