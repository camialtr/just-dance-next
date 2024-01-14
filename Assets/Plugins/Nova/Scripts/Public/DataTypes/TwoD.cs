// Copyright (c) Supernova Technologies LLC
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Nova
{
    /// <summary>
    /// A generic 2D wrapper.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to store per 2D axis, X and Y.</typeparam>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct TwoD<T> : IEquatable<TwoD<T>> where T : unmanaged
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
        /// Access each <typeparamref name="T"/> by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>
        /// </param>
        /// <returns>The <typeparamref name="T"/> for the given <paramref name="axis"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 1</exception>
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
        /// Assigns both <see cref="X"/> and <see cref="Y"/> to the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator TwoD<T>(T value)
        {
            return new TwoD<T>(value, value);
        }

        /// <summary>
        /// A component-wise Equality operator. For an all-or-nothing Equality compare., use <see cref="Equals(TwoD{T})"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>A <see cref="bool"/> per axis. If the compared values along that axis are equal, the returned value for that axis will be <see langword="true"/>.</returns>
        public static TwoD<bool> operator ==(TwoD<T> lhs, TwoD<T> rhs)
        {
            return new TwoD<bool>(EqualityComparer<T>.Default.Equals(lhs.X, rhs.X),
                                  EqualityComparer<T>.Default.Equals(lhs.Y, rhs.Y));
        }

        /// <summary>
        /// A component-wise Inequality operator. For an all-or-nothing inEquality compare., use !<see cref="Equals(TwoD{T})"/>.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>A <see cref="bool"/> per axis. If the compared values along that axis are not equal, the returned value for that axis will be <see langword="true"/>.</returns>
        public static TwoD<bool> operator !=(TwoD<T> lhs, TwoD<T> rhs)
        {
            return new TwoD<bool>(!EqualityComparer<T>.Default.Equals(lhs.X, rhs.X),
                                  !EqualityComparer<T>.Default.Equals(lhs.Y, rhs.Y));
        }

        /// <summary>
        /// Construct a new <see cref="TwoD{T}"/>.
        /// </summary>
        /// <param name="x">The value assigned to <see cref="X"/>.</param>
        /// <param name="y">The value assigned to <see cref="Y"/>.</param>
        public TwoD(T x, T y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <typeparamref name="T"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this.X == <paramref name="other"/>.X &amp;&amp; this.Y == <paramref name="other"/>.Y</c>.</returns>
        public bool Equals(TwoD<T> other)
        {
            return EqualityComparer<T>.Default.Equals(X, other.X) && EqualityComparer<T>.Default.Equals(Y, other.Y);
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <typeparamref name="T"/> to compare to.</param>
        /// <returns><see langword="true"/> if <c>this.X == <paramref name="other"/>.X &amp;&amp; this.Y == <paramref name="other"/>.Y</c>.</returns>
        public override bool Equals(object other)
        {
            if (other is TwoD<T> twoD)
            {
                return Equals(twoD);
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="TwoD{T}"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + X.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Y.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string repesentation of this <see cref="TwoD{T}"/>.
        /// </summary>
        public override string ToString()
        {
            return $"2D({X}, {Y})";
        }
    }
}
