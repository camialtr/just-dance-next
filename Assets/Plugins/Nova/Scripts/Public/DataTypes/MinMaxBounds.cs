// Copyright (c) Supernova Technologies LLC
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A min/max range, per 3D face (Left, Right, Top, Bottom, Front, and Back) offset.
    /// </summary>
    /// <seealso cref="LengthBounds"/>
    /// <seealso cref="LengthBounds.Calculated"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit, Size = 3 * MinMax2.InternalField_3024)]
    public struct MinMaxBounds : IEquatable<MinMaxBounds>
    {
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Left offset.
        /// </summary>
        [SerializeField]
        [FieldOffset(0 * MinMax.InternalField_3025)]
        public MinMax Left;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Right offset.
        /// </summary>
        [SerializeField]
        [FieldOffset(1 * MinMax.InternalField_3025)]
        public MinMax Right;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Bottom offset.
        /// </summary>
        [SerializeField]
        [FieldOffset(2 * MinMax.InternalField_3025)]
        public MinMax Bottom;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Top offset.
        /// </summary>
        [SerializeField]
        [FieldOffset(3 * MinMax.InternalField_3025)]
        public MinMax Top;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Front offset.
        /// </summary>
        [SerializeField]
        [FieldOffset(4 * MinMax.InternalField_3025)]
        public MinMax Front;
        /// <summary>
        /// The <see cref="MinMax"/> used to clamp the Back offset.
        /// </summary>
        [SerializeField]
        [FieldOffset(5 * MinMax.InternalField_3025)]
        public MinMax Back;

        /// <summary>
        /// The <see cref="MinMax2"/> used to clamp the X offsets, <see cref="Left"/> and <see cref="Right"/>.
        /// </summary>
        [NonSerialized]
        [FieldOffset(0 * MinMax2.InternalField_3024)]
        public MinMax2 X;
        /// <summary>
        /// The <see cref="MinMax2"/> used to clamp the Y offsets, <see cref="Bottom"/> and <see cref="Top"/>.
        /// </summary>
        [NonSerialized]
        [FieldOffset(1 * MinMax2.InternalField_3024)]
        public MinMax2 Y;
        /// <summary>
        /// The <see cref="MinMax2"/> used to clamp the Z offsets, <see cref="Front"/> and <see cref="Back"/>.
        /// </summary>
        [NonSerialized]
        [FieldOffset(2 * MinMax2.InternalField_3024)]
        public MinMax2 Z;

        /// <summary>
        /// The <see cref="MinMaxRect"/> used to clamp the 2D edge offsets, <see cref="Left"/>, <see cref="Right"/>, <see cref="Bottom"/>, and <see cref="Top"/>.
        /// </summary>
        [NonSerialized]
        [FieldOffset(0 * MinMaxRect.InternalField_3022)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public MinMaxRect XY;

        /// <summary>
        /// Access each <see cref="MinMax2"/> by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>
        /// <value>2 => <see cref="Z"/></value><br/>
        /// </param>
        /// <returns>The <see cref="MinMax2"/> for the given <paramref name="axis"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
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

        internal bool InternalMethod_2415()
        {
            return XY.InternalMethod_2411() || Left.Min != Front.Min || Left.Min != Back.Min;
        }

        internal bool InternalMethod_2414()
        {
            return XY.InternalMethod_2410() || Left.Max != Front.Max || Left.Max != Back.Max;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>
        /// <see langword="true"/> if 
        /// <c>
        /// <paramref name="lhs"/>.Left == <paramref name="rhs"/>.Left &amp;&amp; <paramref name="lhs"/>.Right == <paramref name="rhs"/>.Right
        /// &amp;&amp; <paramref name="lhs"/>.Bottom == <paramref name="rhs"/>.Bottom &amp;&amp; <paramref name="lhs"/>.Top == <paramref name="rhs"/>.Top
        /// &amp;&amp; <paramref name="lhs"/>.Front == <paramref name="rhs"/>.Front &amp;&amp; <paramref name="lhs"/>.Back == <paramref name="rhs"/>.Back
        /// </c>.
        /// </returns>
        public static bool operator ==(MinMaxBounds lhs, MinMaxBounds rhs)
        {
            return lhs.XY == rhs.XY && lhs.Z == rhs.Z;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Left != <paramref name="rhs"/>.Left || <paramref name="lhs"/>.Right != <paramref name="rhs"/>.Right
        /// || <paramref name="lhs"/>.Bottom != <paramref name="rhs"/>.Bottom || <paramref name="lhs"/>.Top != <paramref name="rhs"/>.Top
        /// || <paramref name="lhs"/>.Front != <paramref name="rhs"/>.Front || <paramref name="lhs"/>.Back != <paramref name="rhs"/>.Back</c>.</returns>
        public static bool operator !=(MinMaxBounds lhs, MinMaxBounds rhs)
        {
            return lhs.XY != rhs.XY || lhs.Z != rhs.Z;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="LengthBounds"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is MinMaxBounds MinMaxBounds)
            {
                return this == MinMaxBounds;
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="MinMaxBounds"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Left.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Right.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Top.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Bottom.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Front.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Back.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string representation of this <see cref="MinMaxBounds"/>.
        /// </summary>
        public override string ToString()
        {
            if (Left == Right)
            {
                if (Left == Bottom && Left == Top &&
                    Left == Front && Left == Back)
                {
                    return $"MinMaxBoundsBounds(All: {Left})";
                }

                if (Bottom == Top && Front == Back)
                {
                    return $"MinMaxBoundsBounds(X: {Left}, Y: {Bottom}, Z: {Front})";
                }
            }

            return $"MinMaxBounds(L: {Left}, R: {Right}, B: {Bottom}, T: {Top}], F: {Front}, B: {Back})";
        }

        /// <summary>
        /// Constructs a new <see cref="MinMaxBounds"/>, specified per face.
        /// </summary>
        /// <param name="left">The length assigned to <see cref="Left">Left</see>.</param>
        /// <param name="right">The length assigned to <see cref="Right">Right</see>.</param>
        /// <param name="bottom">The length assigned to <see cref="Bottom">Bottom</see>.</param>
        /// <param name="top">The length assigned to <see cref="Top">Top</see>.</param>
        /// <param name="front">The length assigned to <see cref="Front">Front</see>.</param>
        /// <param name="back">The length assigned to <see cref="Back">Back</see>.</param>
        public MinMaxBounds(MinMax left, MinMax right, MinMax bottom, MinMax top, MinMax front, MinMax back)
        {
            Left = left;
            Right = right;
            Bottom = bottom;
            Top = top;
            Front = front;
            Back = back;

            X = new MinMax2(left, right);
            Y = new MinMax2(bottom, top);
            Z = new MinMax2(front, back);

            XY = new MinMaxRect()
            {
                X = X,
                Y = Y,
            };
        }

        /// <summary>
        /// Constructs a new <see cref="MinMaxBounds"/>, specified per axis.
        /// </summary>
        /// <param name="x">The lengths assigned to <see cref="X">X</see>.</param>
        /// <param name="y">The lengths assigned to <see cref="Y">Y</see>.</param>
        /// <param name="z">The lengths assigned to <see cref="Z">Z</see>.</param>
        public MinMaxBounds(MinMax2 x, MinMax2 y, MinMax2 z)
        {
            Left = x.First;
            Right = x.Second;
            Bottom = y.First;
            Top = y.Second;
            Front = z.First;
            Back = z.Second;

            X = x;
            Y = y;
            Z = z;

            XY = new MinMaxRect()
            {
                X = x,
                Y = y
            };
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="MinMaxBounds"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(MinMaxBounds other)
        {
            return this == other;
        }

        /// <summary>
        /// A <see cref="MinMaxBounds"/> where <see cref="MinMax.Min"/> == <c>0</c> and <see cref="MinMax.Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static readonly MinMaxBounds Positive = new MinMaxBounds()
        {
            Left = MinMax.Positive,
            Right = MinMax.Positive,
            Bottom = MinMax.Positive,
            Top = MinMax.Positive,
            Front = MinMax.Positive,
            Back = MinMax.Positive,
        };

        /// <summary>
        /// A <see cref="MinMaxBounds"/> where <see cref="MinMax.Min"/> == <c>float.NegativeInfinity</c> and <see cref="MinMax.Max"/> == <c>float.PositiveInfinity</c>.
        /// </summary>
        public static readonly MinMaxBounds Unclamped = new MinMaxBounds()
        {
            Left = MinMax.Unclamped,
            Right = MinMax.Unclamped,
            Bottom = MinMax.Unclamped,
            Top = MinMax.Unclamped,
            Front = MinMax.Unclamped,
            Back = MinMax.Unclamped,
        };
    }
}
