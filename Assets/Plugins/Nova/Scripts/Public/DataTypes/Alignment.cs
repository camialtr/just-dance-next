// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Diagnostics;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Alignment along the X axis.
    /// </summary>
    public enum HorizontalAlignment : int
    {
        /// <summary>
        /// Positive offset shifts right. Negative offset shifts left.
        /// </summary>
        Left = -1,
        /// <summary>
        /// Positive offset shifts right. Negative offset shifts left.
        /// </summary>
        Center = 0,
        /// <summary>
        /// Positive offset shifts left. Negative offset shifts right.
        /// </summary>
        Right = 1,
    }

    /// <summary>
    /// Alignment along the Y axis.
    /// </summary>
    public enum VerticalAlignment : int
    {
        /// <summary>
        /// Positive offset shifts up. Negative offset shifts down.
        /// </summary>
        Bottom = -1,
        /// <summary>
        /// Positive offset shifts up. Negative offset shifts down.
        /// </summary>
        Center = 0,
        /// <summary>
        /// Positive offset shifts down. Negative offset shifts up.
        /// </summary>
        Top = 1,
    }

    /// <summary>
    /// Alignment along the Z axis.
    /// </summary>
    public enum DepthAlignment : int
    {
        /// <summary>
        /// Positive offset shifts forward. Negative offset shifts backward.
        /// </summary>
        Front = -1,
        /// <summary>
        /// Positive offset shifts forward. Negative offset shifts backward.
        /// </summary>
        Center = 0,
        /// <summary>
        /// Positive offset shifts backward. Negative offset shifts forward.
        /// </summary>
        Back = 1,
    }

    /// <summary>
    /// A <see cref="HorizontalAlignment"/>, <see cref="VerticalAlignment"/>, and <see cref="DepthAlignment"/>.
    /// </summary>
    [System.Serializable]
    public struct Alignment : System.IEquatable<Alignment>
    {
        #region 
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment Center = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Center, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment Left = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Center, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment Right = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Center, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment Top = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Top, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment Bottom = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Bottom, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment Front = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Center, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment Back = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Center, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopLeft = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Top);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopRight = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Top);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopCenter = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Top);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomLeft = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Bottom);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomRight = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Bottom);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomCenter = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Bottom);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterLeft = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterRight = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterCenter = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Center);

        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopLeftFront = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Top, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopLeftBack = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Top, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopLeftCenter = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Top, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopRightFront = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Top, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopRightBack = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Top, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopRightCenter = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Top, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopCenterFront = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Top, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopCenterBack = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Top, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment TopCenterCenter = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Top, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomLeftFront = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Bottom, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomLeftBack = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Bottom, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomLeftCenter = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Bottom, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomRightFront = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Bottom, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomRightBack = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Bottom, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomRightCenter = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Bottom, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomCenterFront = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Bottom, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomCenterBack = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Bottom, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment BottomCenterCenter = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Bottom, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterLeftFront = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Center, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterLeftBack = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Center, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterLeftCenter = new Alignment(HorizontalAlignment.Left, VerticalAlignment.Center, DepthAlignment.Center);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterRightFront = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Center, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterRightBack = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Center, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterRightCenter = new Alignment(HorizontalAlignment.Right, VerticalAlignment.Center, DepthAlignment.Center);

        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Front"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterCenterFront = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Center, DepthAlignment.Front);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Back"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterCenterBack = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Center, DepthAlignment.Back);
        /// <summary>
        /// <see cref="X"/> == <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="Y"/> == <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="Z"/> == <see cref="DepthAlignment.Center"/>
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly Alignment CenterCenterCenter = new Alignment(HorizontalAlignment.Center, VerticalAlignment.Center, DepthAlignment.Center);
        #endregion

        /// <summary>
        /// The X axis alignment
        /// </summary>
        /// <value>
        /// <see cref="HorizontalAlignment.Left"/><br/>
        /// <see cref="HorizontalAlignment.Center"/><br/>
        /// <see cref="HorizontalAlignment.Right"/>
        /// </value>
        [SerializeField]
        public HorizontalAlignment X;
        /// <summary>
        /// The Y axis alignment
        /// </summary>
        /// <value>
        /// <see cref="VerticalAlignment.Bottom"/><br/>
        /// <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="VerticalAlignment.Top"/>
        /// </value>
        [SerializeField]
        public VerticalAlignment Y;
        /// <summary>
        /// The Z axis alignment
        /// </summary>
        /// <value>
        /// <see cref="DepthAlignment.Front"/><br/>
        /// <see cref="DepthAlignment.Center"/><br/>
        /// <see cref="DepthAlignment.Back"/>
        /// </value>
        [SerializeField]
        public DepthAlignment Z;

        /// <summary>
        /// Construct a new alignment
        /// </summary>
        /// <param name="x">The alignment assigned to <see cref="X"/></param>
        /// <param name="y">The alignment assigned to <see cref="Y"/></param>
        /// <param name="z">The alignment assigned to <see cref="Z"/></param>
        public Alignment(HorizontalAlignment x, VerticalAlignment y, DepthAlignment z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Construct a 3D alignment
        /// </summary>
        /// <param name="x">
        /// The alignment assigned to <see cref="X"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="HorizontalAlignment.Left"/><br/>
        ///  0 => <see cref="HorizontalAlignment.Center"/><br/>
        ///  1 => <see cref="HorizontalAlignment.Right"/>
        /// </param>
        /// <param name="y">The alignment assigned to <see cref="Y"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="VerticalAlignment.Bottom"/><br/>
        ///  0 => <see cref="VerticalAlignment.Center"/><br/>
        ///  1 => <see cref="VerticalAlignment.Top"/>
        ///  </param>
        /// <param name="z">The alignment assigned to <see cref="Z"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="DepthAlignment.Front"/><br/>
        ///  0 => <see cref="DepthAlignment.Center"/><br/>
        ///  1 => <see cref="DepthAlignment.Back"/>
        ///  </param>
        public Alignment(int x, int y, int z)
        {
            X = (HorizontalAlignment)Mathf.Clamp(x, (int)HorizontalAlignment.Left, (int)HorizontalAlignment.Right);
            Y = (VerticalAlignment)Mathf.Clamp(y, (int)VerticalAlignment.Bottom, (int)VerticalAlignment.Top);
            Z = (DepthAlignment)Mathf.Clamp(z, (int)DepthAlignment.Front, (int)DepthAlignment.Back);
        }

        /// <summary>
        /// Construct a 3D alignment.
        /// </summary>
        /// <param name="x">
        /// The alignment assigned to <see cref="X"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="HorizontalAlignment.Left"/><br/>
        ///  0 => <see cref="HorizontalAlignment.Center"/><br/>
        ///  1 => <see cref="HorizontalAlignment.Right"/>
        /// </param>
        /// <param name="y">The alignment assigned to <see cref="Y"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="VerticalAlignment.Bottom"/><br/>
        ///  0 => <see cref="VerticalAlignment.Center"/><br/>
        ///  1 => <see cref="VerticalAlignment.Top"/>
        ///  </param>
        /// <param name="z">The alignment assigned to <see cref="Z"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="DepthAlignment.Front"/><br/>
        ///  0 => <see cref="DepthAlignment.Center"/><br/>
        ///  1 => <see cref="DepthAlignment.Back"/>
        ///  </param>
        public Alignment(float x, float y, float z) : this((int)InternalType_187.InternalMethod_892(x), (int)InternalType_187.InternalMethod_892(y), (int)InternalType_187.InternalMethod_892(z)) { }

        /// <summary>
        /// Construct a 2D alignment.
        /// </summary>
        /// <param name="x">The alignment assigned to <see cref="X"/></param>
        /// <param name="y">The alignment assigned to <see cref="Y"/></param>
        /// <remarks><see cref="Z"/> will be assigned to <see cref="DepthAlignment.Center"/></remarks>
        public Alignment(HorizontalAlignment x, VerticalAlignment y) : this(x, y, DepthAlignment.Center) { }

        /// <summary>
        /// Construct a 2D alignment.
        /// </summary>
        /// <param name="x">
        /// The alignment assigned to <see cref="X"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="HorizontalAlignment.Left"/><br/>
        ///  0 => <see cref="HorizontalAlignment.Center"/><br/>
        ///  1 => <see cref="HorizontalAlignment.Right"/>
        /// </param>
        /// <param name="y">The alignment assigned to <see cref="Y"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="VerticalAlignment.Bottom"/><br/>
        ///  0 => <see cref="VerticalAlignment.Center"/><br/>
        ///  1 => <see cref="VerticalAlignment.Top"/>
        ///  </param>
        /// <remarks><see cref="Z"/> will be assigned to <see cref="DepthAlignment.Center"/></remarks>
        public Alignment(int x, int y) : this(x, y, (int)DepthAlignment.Center) { }

        /// <summary>
        /// Construct a 2D alignment.
        /// </summary>
        /// <param name="x">
        /// The alignment assigned to <see cref="X"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="HorizontalAlignment.Left"/><br/>
        ///  0 => <see cref="HorizontalAlignment.Center"/><br/>
        ///  1 => <see cref="HorizontalAlignment.Right"/>
        /// </param>
        /// <param name="y">The alignment assigned to <see cref="Y"/>, clamped between [-1, 1] <br/>
        /// -1 => <see cref="VerticalAlignment.Bottom"/><br/>
        ///  0 => <see cref="VerticalAlignment.Center"/><br/>
        ///  1 => <see cref="VerticalAlignment.Top"/>
        ///  </param>
        /// <remarks><see cref="Z"/> will be assigned to <see cref="DepthAlignment.Center"/></remarks>
        public Alignment(float x, float y) : this((int)InternalType_187.InternalMethod_892(x), (int)InternalType_187.InternalMethod_892(y)) { }

        /// <summary>
        /// Access each alignment by <paramref name="axis"/> index.
        /// </summary>
        /// <param name="axis">The axis index to read or write.<br/>
        /// <value>0 => <see cref="X"/></value><br/>
        /// <value>1 => <see cref="Y"/></value><br/>
        /// <value>2 => <see cref="Z"/></value><br/>
        /// </param>
        /// <returns>
        /// The alignment for the given <paramref name="axis"/> index.<br/><br/>
        /// <see cref="HorizontalAlignment.Left"/> => -1<br/>
        /// <see cref="HorizontalAlignment.Center"/> => 0 <br/>
        /// <see cref="HorizontalAlignment.Right"/> => 1<br/><br/>
        /// <see cref="VerticalAlignment.Bottom"/> => -1<br/>
        /// <see cref="VerticalAlignment.Center"/> => 0<br/>
        /// <see cref="VerticalAlignment.Top"/> => 1<br/><br/>
        /// <see cref="DepthAlignment.Front"/> => -1<br/>
        /// <see cref="DepthAlignment.Center"/> => 0<br/>
        /// <see cref="DepthAlignment.Back"/> => 1
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">if <paramref name="axis"/> &lt; 0 || <paramref name="axis"/> &gt; 2</exception>
        public int this[int axis]
        {
            readonly get
            {
                switch (axis)
                {
                    case 0:
                        return (int)X;
                    case 1:
                        return (int)Y;
                    case 2:
                        return (int)Z;
                }

                throw new System.IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 2].");
            }
            set
            {
                switch (axis)
                {
                    case 0:
                        X = (HorizontalAlignment)value;
                        return;
                    case 1:
                        Y = (VerticalAlignment)value;
                        return;
                    case 2:
                        Z = (DepthAlignment)value;
                        return;
                }

                throw new System.IndexOutOfRangeException($"Invalid {nameof(axis)}, [{axis}]. Expected within range [0, 2].");
            }
        }

        /// <summary>
        /// Converts an <see cref="Alignment"/> to a Vector3.
        /// </summary>
        /// <param name="alignment">The alignment to convert.</param>
        /// <returns>        
        /// <see cref="HorizontalAlignment.Left"/> => -1<br/>
        /// <see cref="HorizontalAlignment.Center"/> => 0 <br/>
        /// <see cref="HorizontalAlignment.Right"/> => 1<br/><br/>
        /// <see cref="VerticalAlignment.Bottom"/> => -1<br/>
        /// <see cref="VerticalAlignment.Center"/> => 0<br/>
        /// <see cref="VerticalAlignment.Top"/> => 1<br/><br/>
        /// <see cref="DepthAlignment.Front"/> => -1<br/>
        /// <see cref="DepthAlignment.Center"/> => 0<br/>
        /// <see cref="DepthAlignment.Back"/> => 1
        /// </returns>
        public static explicit operator Vector3(Alignment alignment)
        {
            return new Vector3((int)alignment.X, (int)alignment.Y, (int)alignment.Z);
        }

        /// <summary>
        /// Converts a Vector3 to an <see cref="Alignment"/>.
        /// </summary>
        /// <param name="alignment">The alignment to convert.</param>
        /// <returns>        
        /// <paramref name="alignment"/>.x &lt; 0 => <see cref="HorizontalAlignment.Left"/><br/>
        /// <paramref name="alignment"/>.x == 0 => <see cref="HorizontalAlignment.Center"/><br/>
        /// <paramref name="alignment"/>.x &gt; 0 =>  <see cref="HorizontalAlignment.Right"/><br/><br/>
        /// <paramref name="alignment"/>.y &lt; 0 => <see cref="VerticalAlignment.Bottom"/><br/>
        /// <paramref name="alignment"/>.y == 0 => <see cref="VerticalAlignment.Center"/><br/>
        /// <paramref name="alignment"/>.y &gt; 0 => <see cref="VerticalAlignment.Top"/><br/><br/>
        /// <paramref name="alignment"/>.z &lt; 0 => <see cref="DepthAlignment.Front"/><br/>
        /// <paramref name="alignment"/>.z == 0 => <see cref="DepthAlignment.Center"/><br/>
        /// <paramref name="alignment"/>.z &gt; 0 => <see cref="DepthAlignment.Back"/>
        /// </returns>
        public static explicit operator Alignment(Vector3 alignment)
        {
            return new Alignment(alignment.x, alignment.y, alignment.z);
        }

        /// <summary>
        /// Converts a Vector2 to an <see cref="Alignment"/>.
        /// </summary>
        /// <param name="alignment">The alignment to convert.</param>
        /// <returns>        
        /// <paramref name="alignment"/>.x &lt; 0 => <see cref="HorizontalAlignment.Left"/><br/>
        /// <paramref name="alignment"/>.x == 0 => <see cref="HorizontalAlignment.Center"/><br/>
        /// <paramref name="alignment"/>.x &gt; 0 =>  <see cref="HorizontalAlignment.Right"/><br/><br/>
        /// <paramref name="alignment"/>.y &lt; 0 => <see cref="VerticalAlignment.Bottom"/><br/>
        /// <paramref name="alignment"/>.y == 0 => <see cref="VerticalAlignment.Center"/><br/>
        /// <paramref name="alignment"/>.y &gt; 0 => <see cref="VerticalAlignment.Top"/><br/><br/>
        /// <paramref name="alignment"/>.z == 0 => <see cref="DepthAlignment.Center"/><br/>
        /// </returns>
        public static explicit operator Alignment(Vector2 alignment)
        {
            return new Alignment(alignment.x, alignment.y);
        }

        /// <summary>
        /// Converts an alignment to a Vector2.
        /// </summary>
        /// <param name="alignment">The alignment to convert.</param>
        /// <returns>        
        /// <see cref="HorizontalAlignment.Left"/> => -1<br/>
        /// <see cref="HorizontalAlignment.Center"/> => 0 <br/>
        /// <see cref="HorizontalAlignment.Right"/> => 1<br/><br/>
        /// <see cref="VerticalAlignment.Bottom"/> => -1<br/>
        /// <see cref="VerticalAlignment.Center"/> => 0<br/>
        /// <see cref="VerticalAlignment.Top"/> => 1<br/><br/>
        /// </returns>
        public static explicit operator Vector2(Alignment alignment)
        {
            return new Vector2((int)alignment.X, (int)alignment.Y);
        }

        /// <summary>
        /// Negation operator, inverts the alignment.
        /// </summary>
        /// <param name="alignment">The alignment to negate.</param>
        /// <returns>
        /// <see cref="HorizontalAlignment.Left"/> => <see cref="HorizontalAlignment.Right"/><br/>
        /// <see cref="HorizontalAlignment.Center"/> => <see cref="HorizontalAlignment.Center"/> <br/>
        /// <see cref="HorizontalAlignment.Right"/> => <see cref="HorizontalAlignment.Left"/><br/><br/>
        /// <see cref="VerticalAlignment.Bottom"/> => <see cref="VerticalAlignment.Top"/><br/>
        /// <see cref="VerticalAlignment.Center"/> => <see cref="VerticalAlignment.Center"/><br/>
        /// <see cref="VerticalAlignment.Top"/> => <see cref="VerticalAlignment.Bottom"/><br/><br/>
        /// <see cref="DepthAlignment.Front"/> => <see cref="DepthAlignment.Back"/><br/>
        /// <see cref="DepthAlignment.Center"/> => <see cref="DepthAlignment.Center"/><br/>
        /// <see cref="DepthAlignment.Back"/> => <see cref="DepthAlignment.Front"/>
        /// </returns>
        public static Alignment operator -(Alignment alignment)
        {
            return (Alignment)(-(Vector3)alignment);
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>
        /// <see langword="true"/> if 
        /// <c>
        /// <paramref name="lhs"/>.X == <paramref name="rhs"/>.X &amp;&amp; <paramref name="lhs"/>.Y == <paramref name="rhs"/>.Y &amp;&amp; <paramref name="lhs"/>.Z == <paramref name="rhs"/>.Z
        /// </c>
        /// </returns>
        public static bool operator ==(Alignment lhs, Alignment rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>
        /// <see langword="true"/> if 
        /// <c>
        /// <paramref name="lhs"/>.X != <paramref name="rhs"/>.X || <paramref name="lhs"/>.Y != <paramref name="rhs"/>.Y || <paramref name="lhs"/>.Z != <paramref name="rhs"/>.Z
        /// </c>
        /// </returns>
        public static bool operator !=(Alignment lhs, Alignment rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Alignment"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            if (other is Alignment alignment)
            {
                return this == alignment;
            }

            return false;
        }

        /// <summary>The hashcode for this <see cref="Alignment"/>.</summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + ((int)X).GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + ((int)Y).GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + ((int)Z).GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// The string representation of this <see cref="Alignment"/>.
        /// </summary>
        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="Alignment"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(Alignment other)
        {
            return this == other;
        }
    }
}
