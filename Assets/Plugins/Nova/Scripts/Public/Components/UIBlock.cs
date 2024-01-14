// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_16;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

using InputModule = Nova.InternalNamespace_0.InternalType_759<Nova.UIBlock>; 

namespace Nova
{
    /// <summary>
    /// Applies a set of <see cref="Nova.Layout"/> properties and <see cref="Nova.AutoLayout"/> properties across a connected transform hierarchy of UIBlocks
    /// </summary>
    [ExecuteAlways, AddComponentMenu("Nova/UIBlock")]
    [HelpURL("https://novaui.io/manual/UIBlock.html")]
    public class UIBlock : CoreBlock, InternalType_5
    {
        #region Public
        /// <summary>
        /// The UIBlock on <c>transform.parent</c>. If <c>transform.parent</c> is <c>null</c> or there is no UIBlock on <c>transform.parent</c>, this value will be <c>null</c>.
        /// </summary>
        /// <remarks>If <c>gameObject.activeInHierarchy</c> is <c><see langword="false"/></c>, this value will be <c>null</c>.</remarks>
        public UIBlock Parent => InternalProperty_27.InternalProperty_210 as UIBlock;

        /// <summary>
        /// The root of this UIBlock's connected UIBlock hierarchy.
        /// </summary>
        /// <remarks>If <c>gameObject.activeInHierarchy</c> is <c><see langword="false"/></c>, this value will be <c>null</c>.</remarks>
        public UIBlock Root => InternalProperty_27.InternalProperty_211 as UIBlock;

        /// <summary>
        /// Retrieves the child UIBlock at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the child to retrieve</param>
        /// <returns>The child UIBlock at the provided <paramref name="index"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when <c><paramref name="index"/> &lt; 0</c> or <c><paramref name="index"/> &gt;= <see cref="ChildCount"/></c></exception>
        /// <seealso cref="ChildCount"/>
        public UIBlock GetChild(int index)
        {
            return InternalMethod_109(index) as UIBlock;
        }

        /// <summary>
        /// The number of enabled child <see cref="GameObject"/>'s with a UIBlock component.
        /// </summary>
        /// <remarks>If <c>gameObject.activeInHierarchy</c> is <see langword="false"/>, this value will be <c>0</c>.</remarks>
        /// <seealso cref="GetChild(int)"/>
        public int ChildCount => InternalProperty_32.InternalProperty_433;
        #region 
        /// <summary>
        /// The primary body content color.
        /// </summary>
        [field: NonSerialized]
        public virtual Color Color { get; set; }

        /// <summary>
        /// The <see cref="Nova.Surface"/> configuration for this UIBlock, adjusts the mesh surface's appearance under scene lighting.
        /// </summary>
        public ref Surface Surface
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalNamespace_0.InternalType_73, Surface>(ref InternalType_274.InternalProperty_190.InternalMethod_1266(this));
        }

        /// <summary>
        /// Specifies whether any visual properties should render.
        /// </summary>
        /// <remarks>
        /// This is a global toggle for this <see cref="UIBlock"/> and, when set to <see langword="false"/>, will hide all visual properties. Layout behavior remains unchanged.
        /// </remarks>
        public bool Visible
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => visibility.Visible;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                visibility.Visible = value;
                InternalType_274.InternalProperty_190.InternalMethod_3031(this);
            }
        }

        /// <summary>
        /// Sets the GameObject's layer. Should be used instead of <c>gameobject.layer</c> to ensure that
        /// Nova is tracking the new layer.
        /// </summary>
        public int GameObjectLayer
        {
            get => gameObject.layer;
            set
            {
                gameObject.layer = value;

                if (gameObject.layer == visibility.InternalField_130)
                {
                    return;
                }

                visibility.InternalField_130 = value;
                InternalType_274.InternalProperty_190.InternalMethod_3031(this);
            }
        }
        #endregion

        #region 
        /// <summary>
        /// The entire set of uncalculated UIBlock layout properties.
        /// </summary>
        public ref Layout Layout
        {
            get
            {
                if (!InternalProperty_27.InternalProperty_197)
                {
                    return ref layout;
                }

                unsafe
                {
                    return ref UnsafeUtility.AsRef<Layout>(InternalType_457.InternalProperty_190.InternalMethod_14(this).InternalField_1836);
                }
            }
        }

        /// <summary>
        /// The <see cref="Length3"/> configuration used to calculate <see cref="CalculatedSize">Calculated Size</see>.
        /// </summary>
        /// <remarks><c>Size.<see cref="Length3.Percent">Percent</see></c> is a percentage of the <see cref="Parent">Parent's</see> <see cref="PaddedSize">Padded Size</see>.</remarks>
        /// <seealso cref="SizeMinMax"/>
        /// <seealso cref="CalculatedSize"/>
        public ref Length3 Size
        {
            get
            {
                return ref Layout.Size;
            }
        }

        /// <summary>
        /// The <see cref="MinMax3"/> used to clamp <see cref="Size">Size</see> and <see cref="AutoSize">Auto Size</see> when calculating <see cref="CalculatedSize">CalculatedSize.</see>.
        /// </summary>
        public ref MinMax3 SizeMinMax
        {
            get
            {
                return ref Layout.SizeMinMax;
            }
        }

        /// <summary>
        /// The size of the UIBlock. Calculated by the Nova Engine once per dirty frame and whenenever <see cref="CalculateLayout"/> is called explicitly.
        /// </summary>
        /// <remarks>The final value here accounts for a combination of inputs from <see cref="Size">Size</see>, <see cref="SizeMinMax">Size Min Max</see>, 
        /// <see cref="AutoSize">Auto Size</see>, <see cref="AspectRatioAxis">Aspect Ratio Axis</see>, and the <see cref="PaddedSize">Padded Size</see> of its <see cref="Parent">Parent</see>.
        /// </remarks>
        /// <seealso cref="Size"/>
        /// <seealso cref="SizeMinMax"/>
        /// <seealso cref="AutoSize"/>
        /// <seealso cref="AspectRatioAxis"/>
        public ref readonly Length3.Calculated CalculatedSize
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_53.InternalType_55, Length3.Calculated>(ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1832);
            }
        }

        /// <summary>
        /// An <see cref="Nova.AutoSize"/> value for each axis. Provides a way to have this UIBlock's <see cref="CalculatedSize">Calculated Size</see> adapt to the size of its <see cref="Parent">Parent</see> or size of its children automatically.
        /// </summary>
        /// <remarks>When set to a value other than <see cref="AutoSize.None"/> for a given axis, this will override any <see cref="Size">Size</see> configuration along that same axis.</remarks>
        public ref ThreeD<AutoSize> AutoSize
        {
            get
            {
                return ref Layout.AutoSize;
            }
        }

        /// <summary>
        /// When set to a value other than <see cref="Axis.None"/>, the aspect ratio of this UIBlock's <see cref="CalculatedSize">Calculated Size</see> will remain constant, even as <see cref="Size">Size</see> is modified.
        /// </summary>
        /// <remarks>Can be used in conjuction with <see cref="AutoSize">Auto Size</see>, but only <see cref="AutoSize">Auto Size</see> along the AspectRatioAxis will be honored.</remarks>
        public ref Axis AspectRatioAxis
        {
            get
            {
                return ref Layout.AspectRatioAxis;
            }
        }

        /// <summary>
        /// The <see cref="LengthBounds"/> configuration used to calculate <see cref="CalculatedMargin">CalculatedMargin</see>. Describes a spatial buffer applied outward from <see cref="CalculatedSize">Calculated Size</see>.
        /// </summary>
        /// <remarks>
        /// <c>Margin.<see cref="LengthBounds.Percent">Percent</see></c> is a percentage of the <see cref="Parent">Parent's</see> <see cref="PaddedSize">Padded Size</see>.
        /// </remarks>
        /// <seealso cref="MarginMinMax"/>
        /// <seealso cref="CalculatedMargin"/>
        /// <seealso cref="LayoutSize"/>
        public ref LengthBounds Margin
        {
            get
            {
                return ref Layout.Margin;
            }
        }

        /// <summary>
        /// The <see cref="MinMaxBounds"/> used to clamp <see cref="Margin">Margin</see> when calculating <see cref="CalculatedMargin">Calculated Margin</see>.
        /// </summary>
        /// <seealso cref="Margin"/>
        /// <seealso cref="CalculatedMargin"/>
        /// <seealso cref="LayoutSize"/>
        public ref MinMaxBounds MarginMinMax
        {
            get
            {
                return ref Layout.MarginMinMax;
            }
        }

        /// <summary>
        /// The amount of space applied <i>outward</i> from the bounds defined by <see cref="RotatedSize">Rotated Size</see>. Calculated by the Nova Engine once per dirty frame and whenenever <see cref="CalculateLayout"/> is called explicitly.
        /// </summary>
        /// <remarks>
        /// The final value here accounts for a combination of inputs from <see cref="Margin">Margin</see>, <see cref="MarginMinMax">Margin Min Max</see>, and the <see cref="PaddedSize">Padded Size</see> of its <see cref="Parent">Parent</see>.
        /// </remarks>
        /// <seealso cref="Margin"/>
        /// <seealso cref="MarginMinMax"/>
        /// <seealso cref="LayoutSize"/>
        public ref readonly LengthBounds.Calculated CalculatedMargin
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_56.InternalType_58, LengthBounds.Calculated>(ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1835);
            }
        }

        /// <summary>
        /// A per-axis alignment for this UIBlock relative to its <see cref="Parent">Parent's</see> bounds (<see cref="PaddedSize"/>). <see cref="CalculatedPosition">CalculatedPosition</see> is an offset in the <see cref="Alignment"/> coordinate space.
        /// </summary>
        /// <remarks>
        /// <list type="table">
        /// <listheader>
        /// <term>Axis Alignment</term>
        /// <description>Shift Direction</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="HorizontalAlignment.Left"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.X</c> shifts right</description><br/></item>
        /// <item>
        /// <term><see cref="HorizontalAlignment.Center"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.X</c> shifts right</description><br/></item>
        /// <item>
        /// <term><see cref="HorizontalAlignment.Right"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.X</c> shifts left</description><br/>
        /// </item>
        /// <item>
        /// <term><see cref="VerticalAlignment.Bottom"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.Y</c> shifts up</description><br/></item>
        /// <item>
        /// <term><see cref="VerticalAlignment.Center"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.Y</c> shifts up</description><br/></item>
        /// <item>
        /// <term><see cref="VerticalAlignment.Top"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.Y</c> shifts down</description><br/>
        /// </item>
        /// <item>
        /// <term><see cref="DepthAlignment.Front"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.Z</c> shifts forward</description><br/></item>
        /// <item>
        /// <term><see cref="DepthAlignment.Center"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.Z</c> shifts forward</description><br/></item>
        /// <item>
        /// <term><see cref="DepthAlignment.Back"/></term>
        /// <description>A positive <c><see cref="CalculatedPosition">Calculated Position</see>.Z</c>  shifts backward</description><br/>
        /// </item>
        /// </list>
        /// </remarks>
        public ref Alignment Alignment
        {
            get
            {
                return ref Layout.Alignment;
            }
        }

        /// <summary>
        /// If <see langword="true"/>, the <see cref="LayoutSize">Layout Size</see> will account for the bounds of <see cref="CalculatedSize">Calculated Size</see> rotated by <c><see cref="Transform.localRotation">transform.localRotation</see></c>.<br/>
        /// If <see langword="false"/>, the UIBlock will still render rotated, but the <see cref="LayoutSize">Layout Size</see> will not account for <c><see cref="Transform.localRotation">transform.localRotation</see></c>.
        /// </summary>
        public ref bool RotateSize
        {
            get
            {
                return ref Layout.RotateSize;
            }
        }

        /// <summary>
        /// If <see cref="RotateSize">Rotate Size</see> is <see langword="true"/>, returns <see cref="CalculatedSize">Calculated Size</see> rotated by <c><see cref="Transform.localRotation">transform.localRotation</see></c>.<br/>
        /// If <see cref="RotateSize">Rotate Size</see> is <see langword="false"/>, returns <see cref="CalculatedSize">Calculated Size</see>.
        /// </summary>
        public Vector3 RotatedSize
        {
            get
            {
                if (RotateSize)
                {
                    return InternalType_182.InternalMethod_859(CalculatedSize.Value, transform.localRotation);
                }

                return CalculatedSize.Value;
            }
        }

        /// <summary>
        /// The total <see cref="Bounds"/> of this UIBlock's immediate children in local space. 
        /// </summary>
        /// <remarks>
        /// May require a call to <see cref="CalculateLayout"/> for up-to-date values if child content has changed within a frame.
        /// </remarks>
        public Bounds ChildBounds => new Bounds(InternalProperty_19, InternalProperty_18);

        /// <summary>
        /// The total <see cref="Bounds"/> of this UIBlock's hierarchy, inclusive of all decendent HierarchyBounds, in local space.
        /// </summary>
        /// <remarks>
        /// May require a call to <see cref="CalculateLayout"/> for up-to-date values if hierarchy content has changed within a frame.
        /// </remarks>
        public Bounds HierarchyBounds => new Bounds(InternalProperty_21, InternalProperty_20);

        /// <summary>
        /// The <see cref="Length3"/> configuration used to calculate <see cref="CalculatedPosition">Calculated Position</see>. Describes a per-axis offset from its <see cref="Alignment">Alignment</see>.</summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>
        /// <c>Position.<see cref="Length3.Percent">Percent</see></c> is a percentage of
        /// the <see cref="Parent">Parent's</see> <see cref="PaddedSize">Padded Size</see>.
        /// </description></item>
        /// <item><description>
        /// This value will be converted and written to <c><see cref="Transform.localPosition">transform.localPosition</see></c>
        /// as part of the Nova Engine update at the end of the current frame.
        /// </description></item>
        /// <item><description>
        /// If the <see cref="Parent">Parent's</see> <c><see cref="AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Enabled">Enabled</see> == <see langword="true"/></c>,
        /// the <see cref="AutoLayout"/> will override this <c>Position</c> along the <see cref="Nova.AutoLayout"/>.<see cref="AutoLayout.Axis">Axis.</see>
        /// </description></item>
        /// </list>
        /// </remarks>
        /// <seealso cref="Alignment"/>
        /// <seealso cref="PositionMinMax"/>
        /// <seealso cref="CalculatedPosition"/>
        public ref Length3 Position
        {
            get
            {
                return ref Layout.Position;
            }
        }

        /// <summary>
        /// The <see cref="MinMax3"/> used to clamp <see cref="Position">Position</see> when calculating <see cref="CalculatedPosition">Calculated Position</see>.
        /// </summary>
        public ref MinMax3 PositionMinMax
        {
            get
            {
                return ref Layout.PositionMinMax;
            }
        }

        /// <summary>
        /// The local position of the UIBlock, offset from its configured <see cref="Alignment">Alignment</see>. Calculated by the Nova Engine once per dirty frame and whenenever <see cref="CalculateLayout"/> is called explicitly.
        /// </summary>
        /// <remarks>
        /// The final value here accounts for a combination of inputs from <see cref="Position">Position</see>, <see cref="PositionMinMax">Position Min Max</see>, <c><see cref="Transform.localPosition">transform.localPosition</see></c>, 
        /// the <see cref="PaddedSize">Padded Size</see> of its <see cref="Parent">Parent</see>, and the <see cref="AutoLayout">AutoLayout</see> of its <see cref="Parent">Parent</see>.
        /// </remarks>
        /// <seealso cref="Position"/>
        /// <seealso cref="PositionMinMax"/>
        /// <seealso cref="AutoLayout"/>
        /// <seealso cref="Alignment"/>
        public ref readonly Length3.Calculated CalculatedPosition
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_53.InternalType_55, Length3.Calculated>(ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1833);
            }
        }

        /// <summary>
        /// The <see cref="LengthBounds"/> configuration used to calculate <see cref="CalculatedPadding">Calculated Padding</see>. Describes a spatial buffer applied inward from <see cref="CalculatedSize">Calculated Size</see>.
        /// </summary>
        /// <remarks><c>Padding.<see cref="LengthBounds.Percent">Percent</see></c> is a percentage of this UIBlock's <see cref="CalculatedSize">Calculated Size</see>.</remarks>
        /// <seealso cref="PaddingMinMax"/>
        /// <seealso cref="CalculatedPadding"/>
        /// <seealso cref="PaddedSize"/>
        public ref LengthBounds Padding
        {
            get
            {
                return ref Layout.Padding;
            }
        }

        /// <summary>
        /// The <see cref="MinMaxBounds"/> used to clamp <see cref="Padding">Padding</see> when calculating <see cref="CalculatedPadding">Calculated Padding</see>.
        /// </summary>
        /// <seealso cref="Padding"/>
        /// <seealso cref="CalculatedPadding"/>
        /// <seealso cref="PaddedSize"/>
        public ref MinMaxBounds PaddingMinMax
        {
            get
            {
                return ref Layout.PaddingMinMax;
            }
        }

        /// <summary>
        /// The amount of space applied <i>inward</i> from the bounds defined by <see cref="CalculatedSize">Calculated Size</see>. Calculated by the Nova Engine once per dirty frame and whenenever <see cref="CalculateLayout"/> is called explicitly.
        /// </summary>
        /// <remarks>
        /// The final value here accounts for a combination of inputs from <see cref="Padding">Padding</see>, <see cref="PaddingMinMax">Padding Min Max</see>, and <see cref="CalculatedSize">Calculated Size</see>.
        /// </remarks>
        /// <seealso cref="Padding"/>
        /// <seealso cref="PaddingMinMax"/>
        /// <seealso cref="PaddedSize"/>
        public ref readonly LengthBounds.Calculated CalculatedPadding
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_56.InternalType_58, LengthBounds.Calculated>(ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1834);
            }
        }

        /// <summary>
        /// Equivalent to <c><see cref="CalculatedSize">CalculatedSize</see> - <see cref="CalculatedPadding">CalculatedPadding</see>.<see cref="LengthBounds.Calculated.Size">Size</see></c>.
        /// </summary>
        /// <remarks>A UIBlock is laid-out (positioned, sized, autosized, etc.) relative to its <see cref="Parent">Parent's</see> <see cref="PaddedSize">Padded Size</see>.</remarks>
        public Vector3 PaddedSize
        {
            get
            {
                return InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalProperty_403;
            }
        }

        /// <summary>
        /// The final, unscaled size of this UIBlock in its <see cref="Parent">Parent's</see> local space, used for positioning.<br/>
        /// Equivalent to <c><see cref="RotatedSize">RotatedSize</see> + <see cref="CalculatedMargin">CalculatedMargin</see>.<see cref="LengthBounds.Calculated.Size">Size</see></c>.
        /// </summary>
        /// <seealso cref="RotateSize"/>
        public Vector3 LayoutSize
        {
            get
            {
                return RotatedSize + CalculatedMargin.Size;
            }
        }

        /// <summary>
        /// Position all direct child UIBlocks sequentially along the X, Y, or Z axis.
        /// </summary>
        public ref AutoLayout AutoLayout
        {
            get
            {
                if (!InternalProperty_27.InternalProperty_197)
                {
                    return ref autoLayout;
                }

                unsafe
                {
                    return ref UnsafeUtility.AsRef<AutoLayout>(InternalType_457.InternalProperty_190.InternalMethod_14(this).InternalField_1227);
                }
            }
        }

        /// <summary>
        /// The calculated output of <see cref="AutoLayout.Spacing"/>. Calculated by the Nova Engine once per dirty frame and whenenever <see cref="CalculateLayout"/> is called explicitly.
        /// </summary>
        /// <remarks>
        /// The final value here accounts for a combination of inputs from <see cref="AutoLayout.Spacing"/>, <see cref="AutoLayout.SpacingMinMax"/>, and the <see cref="PaddedSize">Padded Size</see> of this UIBlock.</remarks>
        public ref readonly Length.Calculated CalculatedSpacing
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_45.InternalType_47, Length.Calculated>(ref InternalType_457.InternalProperty_190.InternalMethod_3753(this).InternalField_3739);
            }
        }

        /// <summary>
        /// The calculated output of <see cref="AutoLayout.Cross"/>.<see cref="CrossLayout.Spacing">Spacing</see>. Calculated by the Nova Engine once per dirty frame and whenenever <see cref="CalculateLayout"/> is called explicitly.
        /// </summary>
        /// <remarks>
        /// The final value here accounts for a combination of inputs from <see cref="AutoLayout.Cross"/>.<see cref="CrossLayout.Spacing">Spacing</see>, <see cref="AutoLayout.Cross"/>.<see cref="CrossLayout.SpacingMinMax">SpacingMinMax</see>, and the <see cref="PaddedSize">Padded Size</see> of this UIBlock.</remarks>
        public ref readonly Length.Calculated CalculatedCrossSpacing
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_45.InternalType_47, Length.Calculated>(ref InternalType_457.InternalProperty_190.InternalMethod_3753(this).InternalField_3740);
            }
        }

        /// <summary>
        /// The Nova Engine will automatically process all modified layout properties at the end of each frame. However, some UI scenarios may require knowing the <see cref="CalculatedSize">Calculated Size</see>
        /// or another calculated layout value intra-frame, before the Nova Engine has had a chance to run. Calling this method will force an inline recalculation of all modified layout properties on this UIBlock. 
        /// </summary>
        /// <remarks>
        /// This method only guarantees up-to-date calculated values for this UIBlock alone, meaning other UIBlocks in this UIBlock's hierarchy may not be updated in their entirety until the Nova Engine runs without
        /// their own explicit call to <c>CalculateLayout()</c>.<br/>
        /// This call will always overwrite <c>transform.localPosition</c> with the calculated layout position.
        /// <c><see cref="GameObject.activeInHierarchy">gameObject.activeInHierarchy</see></c> must be <see langword="true"/>, otherwise nothing will be recalculated.
        /// </remarks>
        public void CalculateLayout()
        {
            if (!InternalProperty_25)
            {
                return;
            }

            InternalType_64.InternalProperty_200.InternalMethod_427(InternalProperty_29);

            transform.localPosition = InternalType_457.InternalProperty_190.InternalMethod_1851(this);
        }

        /// <summary>
        /// Move this <see cref="UIBlock"/> to the given Transform <paramref name="worldPosition"/> 
        /// and update <see cref="Position"/> accordingly such that when the Nova Engine
        /// recalculates the modified layout properties, the <i>resulting</i>
        /// <c>transform.position</c> will equal <paramref name="worldPosition"/>.
        /// </summary>
        /// <remarks>
        /// Preserves <see cref="Alignment"/> and the current <see cref="Position"/>'s <see cref="LengthType"/>s.
        /// </remarks>
        /// <param name="worldPosition">The <c>transform.position</c> to convert to a layout position.</param>
        /// <returns>
        /// <see langword="false"/> if <c>gameObject.activeInHierarchy == false</c>, since layout properties 
        /// cannot be calculated in that state, otherwise returns <see langword="true"/>.
        /// </returns>
        /// <seealso cref="TrySetLocalPosition(Vector3)"/>
        public bool TrySetWorldPosition(Vector3 worldPosition)
        {
            if (!InternalProperty_25)
            {
                return false;
            }

            Vector3 InternalVar_1 = worldPosition;

            if (transform.parent != null)
            {
                InternalVar_1 = transform.parent.InverseTransformPoint(worldPosition);
            }

            return TrySetLocalPosition(InternalVar_1);
        }

        /// <summary>
        /// Move this <see cref="UIBlock"/> to the given Transform <paramref name="localPosition"/> 
        /// and update <see cref="Position"/> accordingly such that when the Nova Engine
        /// recalculates the modified layout properties, the <i>resulting</i> 
        /// <c>transform.localPosition</c> will equal <paramref name="localPosition"/>.
        /// </summary>
        /// <remarks>
        /// Preserves <see cref="Alignment"/> and the current <see cref="Position"/>'s <see cref="LengthType"/>s.
        /// </remarks>
        /// <param name="localPosition">The <c>transform.localPosition</c> to convert to a layout position.</param>
        /// <returns>
        /// <see langword="false"/> if <c>gameObject.activeInHierarchy == false</c>, since layout properties 
        /// cannot be calculated in that state, otherwise returns <see langword="true"/>.
        /// </returns>
        /// <seealso cref="TrySetWorldPosition(Vector3)"/>
        public bool TrySetLocalPosition(Vector3 localPosition)
        {
            if (!InternalProperty_25)
            {
                return false;
            }

            CalculateLayout();

            InternalType_21.InternalMethod_2736(this, localPosition);
            transform.localPosition = localPosition;

            return true;
        }
        #endregion

        #region 
        /// <summary>
        /// Subscribe to a gesture event on this <see cref="UIBlock"/> and optionally on its descendent hierarchy, depending on the value of <paramref name="includeHierarchy"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="includeHierarchy"/> is <see langword="true"/>, <paramref name="gestureHandler"/> will be invoked whenever the given gesture type is triggered on this <see cref="UIBlock"/> <i>or</i> one of its decendents.<br/>
        /// If <paramref name="includeHierarchy"/> is <see langword="false"/>, <paramref name="gestureHandler"/> will be invoked only when the given gesture type occurs on <i>this</i> <see cref="UIBlock"/> directy.
        /// </remarks>
        /// <typeparam name="TGesture">The type of gesture event to handle.</typeparam>
        /// <param name="gestureHandler">The callback invoked when the gesture event fires.</param>
        /// <param name="includeHierarchy">Capture gestures from the descendent hierarchy or scope to this <i>this</i> <see cref="UIBlock"/> directy.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="gestureHandler"/> is <c>null</c>.</exception>
        /// <seealso cref="Gesture.OnClick"/>
        /// <seealso cref="Gesture.OnPress"/>
        /// <seealso cref="Gesture.OnRelease"/>
        /// <seealso cref="Gesture.OnHover"/>
        /// <seealso cref="Gesture.OnUnhover"/>
        /// <seealso cref="Gesture.OnScroll"/>
        /// <seealso cref="Gesture.OnMove"/>
        /// <seealso cref="Gesture.OnDrag"/>
        /// <seealso cref="Gesture.OnCancel"/>
        /// <seealso cref="FireGestureEvent{TGesture}(TGesture)"/>
        public void AddGestureHandler<TGesture>(UIEventHandler<TGesture> gestureHandler, bool includeHierarchy = true) where TGesture : struct, IGestureEvent
        {
            if (gestureHandler == null)
            {
                throw new ArgumentNullException(nameof(gestureHandler));
            }

            InternalMethod_3272(gestureHandler, includeHierarchy);
        }

        /// <summary>
        /// Unsubscribe from a gesture event previously subscribed to via <see cref="AddGestureHandler{TGesture}(UIEventHandler{TGesture}, bool)"/>.
        /// </summary>
        /// <typeparam name="TGesture">The type of gesture event to handle.</typeparam>
        /// <param name="gestureHandler">The callback to remove from the subscription list.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="gestureHandler"/> is <c>null</c>.</exception>
        /// <seealso cref="Gesture.OnClick"/>
        /// <seealso cref="Gesture.OnPress"/>
        /// <seealso cref="Gesture.OnRelease"/>
        /// <seealso cref="Gesture.OnHover"/>
        /// <seealso cref="Gesture.OnUnhover"/>
        /// <seealso cref="Gesture.OnScroll"/>
        /// <seealso cref="Gesture.OnMove"/>
        /// <seealso cref="Gesture.OnDrag"/>
        /// <seealso cref="Gesture.OnCancel"/>
        /// <seealso cref="FireGestureEvent{TGesture}(TGesture)"/>
        public void RemoveGestureHandler<TGesture>(UIEventHandler<TGesture> gestureHandler) where TGesture : struct, IGestureEvent
        {
            if (gestureHandler == null)
            {
                throw new ArgumentNullException(nameof(gestureHandler));
            }

            InternalMethod_3271(gestureHandler);
        }

        /// <summary>
        /// Fire a gesture event on this <see cref="UIBlock"/>.
        /// </summary>
        /// <remarks>
        /// The event will traverse <i>up</i> the <see cref="UIBlock"/> hierarchy until it reaches a <see cref="UIBlock"/> ancestor (inclusive of this <see cref="UIBlock"/>) with a registered event handler for the given gesture type, <typeparamref name="TGesture"/>.
        /// </remarks>
        /// <typeparam name="TGesture">The type of gesture event to fire.</typeparam>
        /// <seealso cref="Gesture.OnClick"/>
        /// <seealso cref="Gesture.OnPress"/>
        /// <seealso cref="Gesture.OnRelease"/>
        /// <seealso cref="Gesture.OnHover"/>
        /// <seealso cref="Gesture.OnUnhover"/>
        /// <seealso cref="Gesture.OnScroll"/>
        /// <seealso cref="Gesture.OnMove"/>
        /// <seealso cref="Gesture.OnDrag"/>
        /// <seealso cref="Gesture.OnCancel"/>
        /// <seealso cref="AddGestureHandler{TGesture}(UIEventHandler{TGesture}, bool)"/>
        /// <seealso cref="RemoveGestureHandler{TGesture}(UIEventHandler{TGesture})"/>
        public void FireGestureEvent<TGesture>(TGesture gestureEvent) where TGesture : struct, IGestureEvent
        {
            gestureEvent.Receiver = this;
            gestureEvent.Target = this;
            InternalMethod_91(gestureEvent);
        }
        #endregion

        #endregion

        #region Internal
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Layout layout = Layout.TwoD;

        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private AutoLayout autoLayout = AutoLayout.Disabled;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_69 InternalType_67.InternalProperty_142 => ref UnsafeUtility.As<Layout, InternalNamespace_0.InternalType_69>(ref layout);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_70 InternalType_67.InternalProperty_143 => ref UnsafeUtility.As<AutoLayout, InternalNamespace_0.InternalType_70>(ref autoLayout);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_67.InternalProperty_87 { get => PreviewSize; set { PreviewSize = value; } }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_53.InternalType_55 InternalType_67.InternalProperty_144 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1832;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_53.InternalType_55 InternalType_67.InternalProperty_145 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1833;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_56.InternalType_58 InternalType_67.InternalProperty_146 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1834;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_56.InternalType_58 InternalType_67.InternalProperty_147 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1835;

        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected InternalType_36 visibility = InternalType_36.InternalMethod_307(InternalType_11.InternalField_63);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_71 InternalType_255.InternalProperty_267 => ref UnsafeUtility.As<InternalType_36, InternalNamespace_0.InternalType_71>(ref visibility);

        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected Surface surface = Surface.InternalField_49;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_73 InternalType_255.InternalProperty_268
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<Surface, InternalNamespace_0.InternalType_73>(ref surface);
        }

        [SerializeField, HideInInspector]
        [InternalType_22]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal Vector3 PreviewSize = Vector2.one;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected override bool InternalProperty_28 => InternalType_274.InternalProperty_190.InternalMethod_1258(InternalProperty_29);
        private protected override void InternalMethod_115()
        {
            InternalType_274.InternalProperty_190.InternalMethod_1260(InternalProperty_29, InternalProperty_27.InternalProperty_207);
        }

        private protected override void InternalMethod_102() => InternalType_457.InternalProperty_190.InternalProperty_206.InternalMethod_685(this);

        private void Reset()
        {
            InternalType_67 InternalVar_1 = this;

            if (!InternalType_457.InternalProperty_190.InternalMethod_1852(InternalVar_1))
            {
                InternalNamespace_0.InternalType_53 InternalVar_2 = InternalVar_1.InternalProperty_142.InternalField_214;
                InternalVar_2.InternalProperty_115 = transform.localPosition;
                InternalVar_2.InternalProperty_118 = false;
                InternalVar_1.InternalProperty_142.InternalField_214 = InternalVar_2;
            }

            if (InternalProperty_27.InternalProperty_197)
            {
                InternalMethod_73();
            }
        }


        internal void InternalMethod_73()
        {
            visibility.InternalField_130 = gameObject.layer;
            InternalType_253.InternalProperty_190.InternalMethod_622(this);
            InternalType_457.InternalProperty_190.InternalMethod_622(this);
            InternalType_274.InternalProperty_190.InternalMethod_622(this);
        }

        internal override void InternalMethod_114(InternalType_131 InternalParameter_77)
        {
            InternalType_253.InternalProperty_190.InternalMethod_624(InternalParameter_77, this);
            InternalType_457.InternalProperty_190.InternalMethod_624(InternalParameter_77, this);
            InternalType_274.InternalProperty_190.InternalMethod_624(InternalParameter_77, this);
        }

        internal override void InternalMethod_113()
        {
            InternalType_253.InternalProperty_190.InternalMethod_623(this);
            InternalType_457.InternalProperty_190.InternalMethod_623(this);
            InternalType_274.InternalProperty_190.InternalMethod_623(this);
        }

        private protected override void InternalMethod_111()
        {
            visibility.InternalField_130 = gameObject.layer;
            InternalType_253.InternalProperty_190.InternalMethod_626(this);
            InternalType_457.InternalProperty_190.InternalMethod_626(this);
            InternalType_274.InternalProperty_190.InternalMethod_626(this);
        }

        private protected override void InternalMethod_112()
        {
            InternalType_274.InternalProperty_190.InternalMethod_627(this);
            InternalType_457.InternalProperty_190.InternalMethod_627(this);
            InternalType_253.InternalProperty_190.InternalMethod_627(this);
        }

        
        internal virtual void InternalMethod_1856()
        {
            InternalMethod_73();
        }

        private protected override void InternalMethod_117() { }

        private protected override void InternalMethod_118()
        {
            if (Application.isPlaying)
            {
                InternalMethod_83();
            }
        }

        
        [Obfuscation]
        private protected virtual void OnDidApplyAnimationProperties()
        {
            InternalMethod_73();
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_255.InternalProperty_269
        {
            get => Visible;
            set => Visible = value;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal CalculatedLayout InternalProperty_17 => InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalMethod_953<InternalNamespace_0.InternalNamespace_12.InternalType_454, CalculatedLayout>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal Vector3 InternalProperty_18 => InternalProperty_27.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1847(this) : Vector3.zero;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal Vector3 InternalProperty_19 => InternalProperty_27.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1848(this) : Vector3.zero;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal Vector3 InternalProperty_20 => InternalProperty_27.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1849(this) : Vector3.zero;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal Vector3 InternalProperty_21 => InternalProperty_27.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1850(this) : Vector3.zero;


        
        internal Vector3 InternalMethod_3351(bool InternalParameter_678)
        {
            if (!InternalParameter_678)
            {
                return Vector3.Scale(RotatedSize, transform.lossyScale);
            }

            Vector3 InternalVar_1 = transform.parent == null ? Vector3.one : transform.parent.lossyScale;

            return Vector3.Scale(RotatedSize, transform.lossyScale) + Vector3.Scale(CalculatedMargin.Size, InternalVar_1);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_67.InternalProperty_148 => PaddedSize;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_67.InternalProperty_149 => RotatedSize;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_67.InternalProperty_150 => LayoutSize;

        internal ref readonly AutoLayout InternalMethod_79()
        {
            if (!InternalProperty_27.InternalProperty_197)
            {
                return ref autoLayout;
            }

            unsafe
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_70, AutoLayout>(ref InternalType_457.InternalProperty_190.InternalMethod_1859(this));
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal bool InternalProperty_22
        {
            get
            {
                return InternalType_457.InternalProperty_190.InternalMethod_1855(this);
            }
        }

        void InternalType_67.InternalMethod_442() => CalculateLayout();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_74 InternalType_5.InternalProperty_34 => InternalProperty_23;

        [HideInInspector, NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InputModule InternalField_36 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal InternalType_74 InternalProperty_23
        {
            get
            {
                if (InternalField_36 == null)
                {
                    InternalField_36 = new InputModule(this);
                }

                return InternalField_36;
            }
        }

        
        internal bool InternalMethod_82<T>() where T : unmanaged, IEquatable<T>
        {
            if (InternalField_36 == null)
            {
                return false;
            }

            return InternalProperty_23.InternalMethod_463<T>();
        }

        
        private protected void InternalMethod_83()
        {
            if (InternalField_36 == null)
            {
                return;
            }

            InternalProperty_23.InternalMethod_468();
        }

        [HideInInspector, NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_522 InternalField_37 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal InternalType_522 InternalProperty_24
        {
            get
            {
                if (InternalField_37 == null)
                {
                    InternalField_37 = new InternalType_522(this);
                }

                return InternalField_37;
            }
        }

        /// <summary>
        /// Prevent users from inheriting
        /// </summary>
        internal UIBlock() { }

        internal void InternalMethod_3272<TEvent>(UIEventHandler<TEvent> InternalParameter_3094, bool InternalParameter_3056) where TEvent : struct, IEvent => InternalProperty_24.InternalMethod_1634(InternalParameter_3094, !InternalParameter_3056);
        internal void InternalMethod_3271<TEvent>(UIEventHandler<TEvent> InternalParameter_3055) where TEvent : struct, IEvent => InternalProperty_24.InternalMethod_1633(InternalParameter_3055);
        internal void InternalMethod_3270<TEvent, TTarget>(UIEventHandler<TEvent, TTarget> InternalParameter_3054) where TEvent : struct, IEvent where TTarget : class, InternalType_273 => InternalProperty_24.InternalMethod_1632(InternalParameter_3054);
        internal void InternalMethod_3269<TEvent, TTarget>(UIEventHandler<TEvent, TTarget> InternalParameter_3053) where TEvent : struct, IEvent where TTarget : class, InternalType_273 => InternalProperty_24.InternalMethod_1623(InternalParameter_3053);

        internal void InternalMethod_89(InternalType_523 InternalParameter_72) => InternalProperty_24.InternalMethod_2075(InternalParameter_72);
        internal void InternalMethod_90(InternalType_523 InternalParameter_73) => InternalProperty_24.InternalMethod_2076(InternalParameter_73);

        internal void InternalMethod_91<TEvent>(TEvent InternalParameter_74, Type InternalParameter_75 = null) where TEvent : struct, IEvent => InternalType_522.InternalMethod_2077(this, InternalParameter_74, InternalParameter_75);
        #endregion
    }
}

