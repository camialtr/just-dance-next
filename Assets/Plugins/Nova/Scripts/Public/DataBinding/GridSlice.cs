// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A layout and 2D visual configuration of a "grid slice", a row <i> or </i> column in a <see cref="GridView"/> that's positioned along the <see cref="GridView.PrimaryAxis"/>
    /// </summary>
    /// <seealso cref="GridSlice"/>
    /// <seealso cref="GridSlice3D"/>
    [Serializable]
    public struct GridSlice2D : IEquatable<GridSlice2D>
    {
        /// <summary>
        /// The layout configuration of this grid slice
        /// </summary>
        /// <remarks>
        /// Identical to the <see cref="UIBlock.Layout"/> configuration on <see cref="UIBlock"/>s
        /// </remarks>
        public Layout Layout;

        /// <summary>
        /// The auto layout configuration of this grid slice
        /// </summary>
        /// <remarks>
        /// Identical to the <see cref="UIBlock.AutoLayout"/> configuration on <see cref="UIBlock"/>s
        /// </remarks>
        public AutoLayout AutoLayout;

        /// <summary>
        /// The fill color of this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock.Color"/> configuration on <see cref="UIBlock"/>s</remarks>
        public Color Color;

        /// <summary>
        /// The surface effect when there's scene lighting
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock.Surface"/> configuration on <see cref="UIBlock"/>s</remarks>
        public Surface Surface;

        /// <summary>
        /// The corner radius of this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock3D.CornerRadius"/> configuration on <see cref="UIBlock2D"/>s</remarks>
        public Length CornerRadius;

        /// <summary>
        /// The border around this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock2D.Border"/> configuration on <see cref="UIBlock2D"/>s</remarks>
        public Border Border;

        /// <summary>
        /// The drop shadow/inner shadow of this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock2D.Shadow"/> configuration on <see cref="UIBlock2D"/>s</remarks>
        public Shadow Shadow;

        /// <summary>
        /// The gradient fill of this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock2D.Gradient"/> configuration on <see cref="UIBlock2D"/>s</remarks>
        public RadialGradient Gradient;
        /// <summary>
        /// Create a new <see cref="GridSlice2D"/> configuration
        /// </summary>
        /// <param name="primaryAxis">The scrollable axis of this grid slice's parent</param>
        /// <param name="crossAxis">The <see cref="AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> of this grid slice</param>
        public GridSlice2D(Axis primaryAxis, Axis crossAxis)
        {
            Layout = Layout.TwoD;
            AutoLayout = AutoLayout.Disabled;

            AutoLayout.Axis = crossAxis;
            Layout.AutoSize = AutoSize.Expand;

            if (primaryAxis.TryGetIndex(out int InternalVar_1))
            {
                Layout.AutoSize[InternalVar_1] = AutoSize.Shrink;
            }

            Color = Color.clear;
            Border = Border.InternalField_58;
            Shadow = Shadow.InternalField_59;
            CornerRadius = Length.Zero;
            Gradient = RadialGradient.InternalField_57;
            Surface = Surface.InternalField_49;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to all field of <paramref name="rhs"/></returns>
        public static bool operator ==(GridSlice2D lhs, GridSlice2D rhs)
        {
            return lhs.Layout == rhs.Layout &&
                   lhs.AutoLayout == rhs.AutoLayout &&
                   lhs.Color == rhs.Color &&
                   lhs.Surface == rhs.Surface &&
                   lhs.CornerRadius == rhs.CornerRadius &&
                   lhs.Border == rhs.Border &&
                   lhs.Shadow == rhs.Shadow &&
                   lhs.Gradient == rhs.Gradient;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if any field of <paramref name="lhs"/> is <b>not</b> equal to its corresponding field of <paramref name="rhs"/></returns>
        public static bool operator !=(GridSlice2D lhs, GridSlice2D rhs)
        {
            return lhs.Layout != rhs.Layout ||
                   lhs.AutoLayout != rhs.AutoLayout ||
                   lhs.Color != rhs.Color ||
                   lhs.Surface != rhs.Surface ||
                   lhs.CornerRadius != rhs.CornerRadius ||
                   lhs.Border != rhs.Border ||
                   lhs.Shadow != rhs.Shadow ||
                   lhs.Gradient != rhs.Gradient;
        }

        /// <summary>
        /// The hashcode for this <see cref="GridSlice2D"/>
        /// </summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Layout.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + AutoLayout.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Color.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Surface.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + CornerRadius.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Border.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Shadow.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Gradient.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridSlice2D"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public override bool Equals(object other)
        {
            if (other is GridSlice2D slice)
            {
                return this == slice;
            }

            return false;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridSlice2D"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(GridSlice2D other)
        {
            return this == other;
        }
    }

    /// <summary>
    /// A layout and 3D visual configuration of a "grid slice", a row <i> or </i> column in a <see cref="GridView"/> that's positioned along the <see cref="GridView.PrimaryAxis"/>
    /// </summary>
    /// <seealso cref="GridSlice"/>
    /// <seealso cref="GridSlice2D"/>
    [Serializable]
    public struct GridSlice3D : IEquatable<GridSlice3D>
    {
        /// <summary>
        /// The layout configuration of this grid slice
        /// </summary>
        /// <remarks>
        /// Identical to the <see cref="UIBlock.Layout"/> configuration on <see cref="UIBlock"/>s
        /// </remarks>
        public Layout Layout;

        /// <summary>
        /// The auto layout configuration of this grid slice
        /// </summary>
        /// <remarks>
        /// Identical to the <see cref="UIBlock.AutoLayout"/> configuration on <see cref="UIBlock"/>s
        /// </remarks>
        public AutoLayout AutoLayout;

        /// <summary>
        /// The fill color of this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock.Color"/> configuration on <see cref="UIBlock"/>s</remarks>
        public Color Color;
        /// <summary>
        /// The surface effect when there's scene lighting
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock.Surface"/> configuration on <see cref="UIBlock"/>s</remarks>
        public Surface Surface;
        /// <summary>
        /// The corner radius of this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock3D.CornerRadius"/> configuration on <see cref="UIBlock3D"/>s</remarks>
        public Length CornerRadius;

        /// <summary>
        /// The edge radius of this grid slice
        /// </summary>
        /// <remarks>Identical to the <see cref="UIBlock3D.EdgeRadius"/> configuration on <see cref="UIBlock3D"/>s</remarks>
        public Length EdgeRadius;

        /// <summary>
        /// Create a new <see cref="GridSlice3D"/> configuration
        /// </summary>
        /// <param name="primaryAxis">The scrollable axis of this grid slice's parent</param>
        /// <param name="crossAxis">The <see cref="AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> of this grid slice</param>
        public GridSlice3D(Axis primaryAxis, Axis crossAxis)
        {
            Layout = Layout.ThreeD;
            AutoLayout = AutoLayout.Disabled;

            AutoLayout.Axis = crossAxis;
            Layout.AutoSize = AutoSize.Expand;
            
            if (primaryAxis.TryGetIndex(out int InternalVar_1))
            {
                Layout.AutoSize[InternalVar_1] = AutoSize.Shrink;
            }

            Color = Color.clear;
            CornerRadius = Length.Zero;
            EdgeRadius = Length.Zero;
            Surface = Surface.InternalField_50;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to all field of <paramref name="rhs"/></returns>
        public static bool operator ==(GridSlice3D lhs, GridSlice3D rhs)
        {
            return lhs.Layout == rhs.Layout && 
                   lhs.AutoLayout == rhs.AutoLayout &&
                   lhs.Color == rhs.Color &&
                   lhs.Surface == rhs.Surface &&
                   lhs.CornerRadius == rhs.CornerRadius &&
                   lhs.EdgeRadius == rhs.EdgeRadius;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if any field of <paramref name="lhs"/> is <b>not</b> equal to its corresponding field of <paramref name="rhs"/></returns>
        public static bool operator !=(GridSlice3D lhs, GridSlice3D rhs)
        {
            return lhs.Layout != rhs.Layout ||
                   lhs.AutoLayout != rhs.AutoLayout ||
                   lhs.Color != rhs.Color ||
                   lhs.Surface != rhs.Surface ||
                   lhs.CornerRadius != rhs.CornerRadius ||
                   lhs.EdgeRadius != rhs.EdgeRadius;
        }

        /// <summary>
        /// The hashcode for this <see cref="GridSlice3D"/>
        /// </summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Layout.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + AutoLayout.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Color.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Surface.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + CornerRadius.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + EdgeRadius.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridSlice3D"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public override bool Equals(object other)
        {
            if (other is GridSlice3D slice)
            {
                return this == slice;
            }

            return false;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridSlice3D"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(GridSlice3D other)
        {
            return this == other;
        }
    }

    /// <summary>
    /// A layout-only configuration of a "grid slice", a row <i> or </i> column in a <see cref="GridView"/> that's positioned along the <see cref="GridView.PrimaryAxis"/>
    /// </summary>
    /// <seealso cref="GridSlice2D"/>
    /// <seealso cref="GridSlice3D"/>
    [Serializable]
    public struct GridSlice : IEquatable<GridSlice>
    {
        /// <summary>
        /// The layout configuration of this grid slice
        /// </summary>
        /// <remarks>
        /// Identical to the <see cref="UIBlock.Layout"/> configuration on <see cref="UIBlock"/>s
        /// </remarks>
        public Layout Layout;

        /// <summary>
        /// The auto layout configuration of this grid slice
        /// </summary>
        /// <remarks>
        /// Identical to the <see cref="UIBlock.AutoLayout"/> configuration on <see cref="UIBlock"/>s
        /// </remarks>
        public AutoLayout AutoLayout;

        /// <summary>
        /// Create a new <see cref="GridSlice"/> configuration
        /// </summary>
        /// <param name="primaryAxis">The scrollable axis of this grid slice's parent</param>
        /// <param name="crossAxis">The <see cref="AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> of this grid slice</param>
        public GridSlice(Axis primaryAxis, Axis crossAxis)
        {
            Layout = Layout.TwoD;
            AutoLayout = AutoLayout.Disabled;
            AutoLayout.Alignment = 0;

            AutoLayout.Axis = crossAxis;
            Layout.AutoSize = AutoSize.Expand;
            
            if (primaryAxis.TryGetIndex(out int InternalVar_1))
            {
                Layout.AutoSize[InternalVar_1] = AutoSize.Shrink;
            }            
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Layout == <paramref name="rhs"/>.Layout &amp;&amp; <paramref name="lhs"/>.AutoLayout == <paramref name="rhs"/>.AutoLayout</c></returns>
        public static bool operator ==(GridSlice lhs, GridSlice rhs)
        {
            return lhs.Layout == rhs.Layout && lhs.AutoLayout == rhs.AutoLayout;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Layout != <paramref name="rhs"/>.Layout || <paramref name="lhs"/>.AutoLayout != <paramref name="rhs"/>.AutoLayout</c></returns>
        public static bool operator !=(GridSlice lhs, GridSlice rhs)
        {
            return lhs.Layout != rhs.Layout || lhs.AutoLayout != rhs.AutoLayout;
        }

        /// <summary>
        /// The hashcode for this <see cref="GridSlice"/>
        /// </summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Layout.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + AutoLayout.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridSlice"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public override bool Equals(object other)
        {
            if (other is GridSlice slice)
            {
                return this == slice;
            }

            return false;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridSlice"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(GridSlice other)
        {
            return this == other;
        }
    }

    internal class InternalType_35 : IDisposable
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Queue<InternalType_42> InternalField_127 = new Queue<InternalType_42>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Queue<InternalType_43> InternalField_128 = new Queue<InternalType_43>();

        public InternalType_33 InternalMethod_294(Type InternalParameter_210)
        {
            if (InternalMethod_297(InternalParameter_210, out InternalType_33 InternalVar_1))
            {
                return InternalVar_1;
            }

            switch (InternalParameter_210)
            {
                case Type twoD when twoD == typeof(InternalType_42):
                    return new InternalType_42();
                case Type threeD when threeD == typeof(InternalType_43):
                    return new InternalType_43();
                default:
                    return null;
            }
        }

        public void InternalMethod_295(InternalType_33 InternalParameter_211)
        {
            if (InternalParameter_211 == null)
            {
                return;
            }

            switch (InternalParameter_211)
            {
                case InternalType_42 twoDBlock:
                    InternalField_127.Enqueue(twoDBlock);
                    break;
                case InternalType_43 threeDBlock:
                    InternalField_128.Enqueue(threeDBlock);
                    break;
            }
        }

        public bool InternalMethod_296(out InternalType_33 InternalParameter_212)
        {
            if (InternalField_127.Count > 0)
            {
                InternalParameter_212 = InternalField_127.Dequeue();
                return true;
            }

            if (InternalField_128.Count > 0)
            {
                InternalParameter_212 = InternalField_128.Dequeue();
                return true;
            }

            InternalParameter_212 = null;
            return false;
        }

        public bool InternalMethod_297(Type InternalParameter_213, out InternalType_33 InternalParameter_214)
        {
            switch (InternalParameter_213)
            {
                case Type twoD when twoD == typeof(InternalType_42) && InternalField_127.Count > 0:
                    InternalParameter_214 = InternalField_127.Dequeue();
                    return true;
                case Type threeD when threeD == typeof(InternalType_43) && InternalField_128.Count > 0:
                    InternalParameter_214 = InternalField_128.Dequeue();
                    return true;
                default:
                    InternalParameter_214 = null;
                    return false;
            }
        }

        public int InternalMethod_298(Type InternalParameter_215)
        {
            switch (InternalParameter_215)
            {
                case Type twoD when twoD == typeof(InternalType_42):
                    return InternalField_127.Count;
                case Type threeD when threeD == typeof(InternalType_43):
                    return InternalField_128.Count;
                default:
                    return 0;
            }
        }

        public void Dispose()
        {
            while (InternalMethod_296(out InternalType_33 InternalVar_1))
            {
                InternalVar_1.Dispose();
            }
        }
    }
}
