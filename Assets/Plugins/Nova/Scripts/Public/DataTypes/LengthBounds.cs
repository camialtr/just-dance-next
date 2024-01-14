// Copyright (c) Supernova Technologies LLC
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A set of <see cref="Length">Lengths</see> used to configure offsets from each face of an axis-aligned bounding box.
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct LengthBounds : IEquatable<LengthBounds>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal const int InternalField_10 = InternalNamespace_0.InternalType_56.InternalField_181;

        /// <summary>
        /// The <see cref="Length">Length</see> offset from a bounds' left face.
        /// </summary>
        [SerializeField]
        [FieldOffset(0 * Length.InternalField_2)]
        public Length Left;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a bounds' right face.
        /// </summary>
        [SerializeField]
        [FieldOffset(1 * Length.InternalField_2)]
        public Length Right;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a bounds' bottom face.
        /// </summary>
        [SerializeField]
        [FieldOffset(2 * Length.InternalField_2)]
        public Length Bottom;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a bounds' top face.
        /// </summary>
        [SerializeField]
        [FieldOffset(3 * Length.InternalField_2)]
        public Length Top;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a bounds' front face.
        /// </summary>
        [SerializeField]
        [FieldOffset(4 * Length.InternalField_2)]
        public Length Front;
        /// <summary>
        /// The <see cref="Length">Length</see> offset from a bounds' back face.
        /// </summary>
        [SerializeField]
        [FieldOffset(5 * Length.InternalField_2)]
        public Length Back;

        /// <summary>
        /// The XY face offsets of this <see cref="LengthBounds"/> as a <see cref="LengthRect"/>.
        /// </summary>
        [NonSerialized]
        [FieldOffset(0)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public LengthRect XY;

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
        /// <see cref="Front">Front</see> and <see cref="Back">Back</see> as a <see cref="Length2"/> pair.
        /// </summary>
        /// <remarks>
        /// <value><c>this.<see cref="Front">Front</see></c> => <see cref="Z">Z</see>.<see cref="Length2.First">First</see></value><br/>
        /// <value><c>this.<see cref="Back">Back</see></c> => <see cref="Z">Z</see>.<see cref="Length2.Second">Second</see></value>.
        /// </remarks>
        [NonSerialized]
        [FieldOffset(4 * Length.InternalField_2)]
        public Length2 Z;

        /// <summary>
        /// Assign all offsets, <see cref="Left">Left</see>, <see cref="Right">Right</see>, <see cref="Bottom">Bottom</see>, <see cref="Top">Top</see>,
        /// <see cref="Front">Front</see>, and <see cref="Back">Back</see>, to a <see cref="LengthType.Value">Value</see> <see cref="Length"/> with the given value.
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
                Front = InternalVar_1;
                Back = InternalVar_1;
            }
        }

        /// <summary>
        /// Assign all offsets, <see cref="Left">Left</see>, <see cref="Right">Right</see>, <see cref="Bottom">Bottom</see>, <see cref="Top">Top</see>,
        /// <see cref="Front">Front</see>, and <see cref="Back">Back</see>, to a <see cref="LengthType.Percent">Percent</see> <see cref="Length"/> with the given percent, <c>1 == 100%</c>.
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
                Front = InternalVar_1;
                Back = InternalVar_1;
            }
        }

        /// <summary>
        /// Access each <see cref="Length2"/> by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>
        /// <value>2 => <see cref="Z"/></value><br/>
        /// </param>
        /// <returns>The <see cref="Length2"/> for the given <paramref name="axis"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
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

        internal bool InternalMethod_25()
        {
            return XY.InternalMethod_28() || X.First != Z.First || X.First != Z.Second;
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
        public static bool operator ==(LengthBounds lhs, LengthBounds rhs)
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
        public static bool operator !=(LengthBounds lhs, LengthBounds rhs)
        {
            return lhs.XY != rhs.XY && lhs.Z != rhs.Z;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="LengthBounds"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is LengthBounds length)
            {
                return this == length;
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="LengthBounds"/>.</summary>
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
        /// The string representation of this <see cref="LengthBounds"/>.
        /// </summary>
        public override string ToString()
        {
            if (Left == Right)
            {
                if (Left == Bottom && Left == Top &&
                    Left == Front && Left == Back)
                {
                    return $"LengthBounds(All: {Left})";
                }

                if (Bottom == Top && Front == Back)
                {
                    return $"LengthBounds(X: {Left}, Y: {Bottom}, Z: {Front})";
                }
            }

            return $"Length(L: {Left}, R: {Right}, B: {Bottom}, T: {Top}, F: {Front}, B: {Back})";
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="LengthBounds"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(LengthBounds other)
        {
            return this == other;
        }

        /// <summary>
        /// Constructs a new <see cref="LengthBounds"/> and assigns each edge offset to a <see cref="LengthType.Value">Value</see> <see cref="Length"/> of <paramref name="value"/>.
        /// </summary>
        /// <param name="length">The length to assign in units.</param>
        public static implicit operator LengthBounds(float length)
        {
            return new LengthBounds()
            {
                Left = length,
                Right = length,
                Bottom = length,
                Top = length,
                Front = length,
                Back = length,
            };
        }

        /// <summary>
        /// Constructs a new <see cref="LengthBounds"/> and assigns each edge offset to the provided <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The length to assign to each edge offset.</param>
        public static implicit operator LengthBounds(Length length)
        {
            return new LengthBounds()
            {
                Left = length,
                Right = length,
                Bottom = length,
                Top = length,
                Front = length,
                Back = length,
            };
        }

        /// <summary>
        /// Constructs a new <see cref="LengthBounds"/> where <see cref="XY"/> == <paramref name="rect"/> and <see cref="Z"/> == <see cref="Length2.Zero"/>.
        /// </summary>
        /// <param name="rect">The values assigned to <see cref="XY"/>.</param>
        public static implicit operator LengthBounds(LengthRect rect)
        {
            return new LengthBounds()
            {
                XY = rect,
                Z = Length2.Zero
            };
        }

        /// <summary>
        /// Constructs a new <see cref="LengthBounds"/>, specified per face.
        /// </summary>
        /// <param name="left">The length assigned to <see cref="Left">Left</see>.</param>
        /// <param name="right">The length assigned to <see cref="Right">Right</see>.</param>
        /// <param name="bottom">The length assigned to <see cref="Bottom">Bottom</see>.</param>
        /// <param name="top">The length assigned to <see cref="Top">Top</see>.</param>
        /// <param name="front">The length assigned to <see cref="Front">Front</see>.</param>
        /// <param name="back">The length assigned to <see cref="Back">Back</see>.</param>
        public LengthBounds(Length left, Length right, Length bottom, Length top, Length front, Length back)
        {
            Left = left;
            Right = right;
            Bottom = bottom;
            Top = top;
            Front = front;
            Back = back;

            X = new Length2(left, right);
            Y = new Length2(bottom, top);
            Z = new Length2(front, back);

            XY = new LengthRect()
            {
                X = X,
                Y = Y,
            };
        }

        /// <summary>
        /// Constructs a new <see cref="LengthBounds"/>, specified per axis.
        /// </summary>
        /// <param name="x">The lengths assigned to <see cref="X">X</see>.</param>
        /// <param name="y">The lengths assigned to <see cref="Y">Y</see>.</param>
        /// <param name="z">The lengths assigned to <see cref="Z">Z</see>.</param>
        public LengthBounds(Length2 x, Length2 y, Length2 z)
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

            XY = new LengthRect()
            {
                X = x,
                Y = y
            };
        }

        #region 
        /// <summary>
        /// A calculated, readonly output of a <see cref="LengthBounds"/>.
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Explicit, Size = 3 * Length2.Calculated.InternalField_6)]
        public readonly struct Calculated : IEquatable<Calculated>
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            internal const int InternalField_11 = 6 * InternalNamespace_0.InternalType_45.InternalType_47.InternalField_152;

            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthBounds.Left"/>.
            /// </summary>
            [FieldOffset(0 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Left;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthBounds.Right"/>.
            /// </summary>
            [FieldOffset(1 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Right;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthBounds.Bottom"/>.
            /// </summary>
            [FieldOffset(2 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Bottom;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthBounds.Top"/>.
            /// </summary>
            [FieldOffset(3 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Top;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthBounds.Front"/>.
            /// </summary>
            [FieldOffset(4 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Front;
            /// <summary>
            /// The <see cref="Length.Calculated"/> output of <see cref="LengthBounds.Back"/>.
            /// </summary>
            [FieldOffset(5 * Length.Calculated.InternalField_4)]
            public readonly Length.Calculated Back;

            /// <summary>
            /// The <see cref="Length2.Calculated"/> output of <see cref="LengthBounds.X"/>.
            /// </summary>
            [NonSerialized, FieldOffset(0 * Length2.Calculated.InternalField_6)]
            public readonly Length2.Calculated X;
            /// <summary>
            /// The <see cref="Length2.Calculated"/> output of <see cref="LengthBounds.Y"/>.
            /// </summary>
            [NonSerialized, FieldOffset(1 * Length2.Calculated.InternalField_6)]
            public readonly Length2.Calculated Y;
            /// <summary>
            /// The <see cref="Length2.Calculated"/> output of <see cref="LengthBounds.Z"/>.
            /// </summary>
            [NonSerialized, FieldOffset(2 * Length2.Calculated.InternalField_6)]
            public readonly Length2.Calculated Z;

            /// <summary>
            /// The <see cref="LengthRect.Calculated"/> output of <see cref="LengthBounds.XY"/>.
            /// </summary>
            [NonSerialized, FieldOffset(0 * LengthRect.Calculated.InternalField_14)]
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public readonly LengthRect.Calculated XY;

            /// <summary>The sum of face offsets along the X axis in units</summary>
            /// <remarks>
            /// Equivalent to <c><see cref="Left">Left</see>.<see cref="Length.Calculated.Value">Value</see> + <see cref="Right">Right</see>.<see cref="Length.Calculated.Value">Value</see></c>.
            /// </remarks>
            public readonly float Width => Left.Value + Right.Value;
            /// <summary>The sum of face offsets along the Y axis in units</summary>
            /// <remarks>
            /// Equivalent to <c><see cref="Bottom">Bottom</see>.<see cref="Length.Calculated.Value">Value</see> + <see cref="Top">Top</see>.<see cref="Length.Calculated.Value">Value</see> </c>.
            /// </remarks>
            public readonly float Height => Bottom.Value + Top.Value;
            /// <summary>The sum of face offsets along the Z axis in units</summary>
            /// <remarks>
            /// Equivalent to <c><see cref="Front">Front</see>.<see cref="Length.Calculated.Value">Value</see> + <see cref="Back">Back</see>.<see cref="Length.Calculated.Value">Value</see> </c>.
            /// </remarks>
            public readonly float Depth => Front.Value + Back.Value;

            /// <summary>
            /// A per-axis sum of face offsets.
            /// </summary>
            /// <returns>A Vector3, <c>v</c>, where <c>v.x == <see cref="Width">Width</see></c>, <c>v.y == <see cref="Height">Height</see></c>, and <c>v.z == <see cref="Depth">Depth</see></c>.</returns>
            public readonly Vector3 Size => new Vector3(Width, Height, Depth);

            /// <summary>
            /// The midpoint shift of the combined face offsets along their respective axes.
            /// </summary>
            /// 
            /// <remarks>
            /// Equivalent to <c>0.5f * <see langword="new"/> Vector3(<see cref="Left">Left</see>.<see cref="Length.Calculated.Value">Value</see> - <see cref="Right">Right</see>.<see cref="Length.Calculated.Value">Value</see>,
            /// <see cref="Bottom">Bottom</see>.<see cref="Length.Calculated.Value">Value</see> - <see cref="Top">Top</see>.<see cref="Length.Calculated.Value">Value</see>,
            /// <see cref="Front">Front</see>.<see cref="Length.Calculated.Value">Value</see> - <see cref="Back">Back</see>.<see cref="Length.Calculated.Value">Value</see>)</c>.
            /// </remarks>
            public readonly Vector3 Offset => 0.5f * new Vector3(Left.Value - Right.Value, Bottom.Value - Top.Value, Front.Value - Back.Value);

            /// <summary>
            /// Access each <see cref="Length2.Calculated"/> by <paramref name="axis"/> index.
            /// </summary>
            /// <param name="axis">The axis index to read<br/>
            /// <value>0 => <see cref="X"/></value><br/>
            /// <value>1 => <see cref="Y"/></value><br/>
            /// <value>2 => <see cref="Z"/></value><br/>.
            /// </param>
            /// <returns>The <see cref="Length2.Calculated"/> for the given <paramref name="axis"/>.</returns>
            /// <exception cref="IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
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
                        case 2:
                            return Z;
                    }

                    throw new IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 2].");
                }
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
            public static bool operator ==(Calculated lhs, Calculated rhs)
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
            public static bool operator !=(Calculated lhs, Calculated rhs)
            {
                return lhs.XY != rhs.XY && lhs.Z != rhs.Z;
            }

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
                InternalVar_1 = (InternalVar_1 * 7) + Front.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Back.GetHashCode();
                return InternalVar_1;
            }

            /// <summary>
            /// The string representation of this <see cref="Calculated"/>.
            /// </summary>
            public override string ToString()
            {
                if (Left == Right)
                {
                    if (Left == Bottom && Left == Top &&
                        Left == Front && Left == Back)
                    {
                        return $"CalcBounds(All: {Left})";
                    }

                    if (Bottom == Top && Front == Back)
                    {
                        return $"CalcBounds(X: {Left}, Y: {Bottom}, Z: {Front})";
                    }
                }

                return $"Calc(L: {Left}, R: {Right}, B: {Bottom}, T: {Top}, F: {Front}, B: {Back})";
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
            /// Constructs a new <see cref="Calculated"/>.
            /// </summary>
            /// <param name="left">The length assigned to <see cref="Left">Left</see>.</param>
            /// <param name="right">The length assigned to <see cref="Right">Right</see>.</param>
            /// <param name="bottom">The length assigned to <see cref="Bottom">Bottom</see>.</param>
            /// <param name="top">The length assigned to <see cref="Top">Top</see>.</param>
            /// <param name="front">The length assigned to <see cref="Front">Front</see>.</param>
            /// <param name="back">The length assigned to <see cref="Back">Back</see>.</param>
            public Calculated(Length.Calculated left, Length.Calculated right, Length.Calculated bottom, Length.Calculated top, Length.Calculated front, Length.Calculated back)
            {
                Left = left;
                Right = right;
                Bottom = bottom;
                Top = top;
                Front = front;
                Back = back;

                X = new Length2.Calculated(left, right);
                Y = new Length2.Calculated(bottom, top);
                Z = new Length2.Calculated(front, back);

                XY = new LengthRect.Calculated(X, Y);
            }

            /// <summary>
            /// Constructs a new <see cref="Calculated"/>.
            /// </summary>
            /// <param name="x">The lengths assigned to <see cref="X">X</see>.</param>
            /// <param name="y">The lengths assigned to <see cref="Y">Y</see>.</param>
            /// <param name="z">The lengths assigned to <see cref="Z">Z</see>.</param>
            public Calculated(Length2.Calculated x, Length2.Calculated y, Length2.Calculated z)
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

                XY = new LengthRect.Calculated(x, y);
            }
        }
        #endregion
    }
}
