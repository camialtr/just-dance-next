// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_16;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_11.InternalNamespace_15;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using Unity.Mathematics;
using UnityEngine;

namespace Nova
{
    internal interface InternalType_489 : InternalType_493, InternalType_506 { }

    /// <summary>
    /// Scrolls the attached <see cref="UIBlock"/>'s content along its <see cref="AutoLayout"/>.<see cref="Axis">Axis</see> with an iOS-like inertia and bounce effect
    /// </summary>
    /// <remarks>
    /// If there's a <see cref="ListView"/> on the same <see cref="GameObject"/>, this component will also handle scrolling the virtualized <see cref="ListView"/>
    /// </remarks>
    /// <see cref="Interaction.Scroll(Interaction.Update, Vector3, float, int, InputAccuracy)"/>
    /// <seealso cref="Gesture.OnClick"/>
    /// <seealso cref="Gesture.OnPress"/>
    /// <seealso cref="Gesture.OnRelease"/>
    /// <seealso cref="Gesture.OnHover"/>
    /// <seealso cref="Gesture.OnUnhover"/>
    /// <seealso cref="Gesture.OnMove"/>
    /// <seealso cref="Gesture.OnScroll"/>
    /// <seealso cref="Gesture.OnCancel"/>
    [AddComponentMenu("Nova/Scroller")]
    [HelpURL("https://novaui.io/manual/Scroller.html")]
    public sealed class Scroller : GestureRecognizer, InternalType_489
    {
        #region Public
        /// <summary>
        /// The animation applied to content once it's scrolled past the edges of its viewport
        /// </summary>
        [SerializeField]
        public OverscrollEffect OverscrollEffect = OverscrollEffect.Bounce;

        /// <summary>
        /// The scroll speed multiplier for vector (e.g. mouse wheel) scrolling
        /// </summary>
        [SerializeField]
        public float VectorScrollMultiplier = 1;

        /// <summary>
        /// Allow pointer drag events to trigger a scroll
        /// </summary>
        /// <remarks>
        /// <see cref="Interaction.Point(Interaction.Update, bool, bool, float, int, InputAccuracy)"/><br/>
        /// <see cref="Interaction.Point(Sphere, uint, object, int, InputAccuracy)"/>
        /// </remarks>
        /// <see cref="GestureRecognizer.DragThreshold"/>
        /// <see cref="GestureRecognizer.LowAccuracyDragThreshold"/>
        public bool DragScrolling
        {
            get
            {
                return dragScrolling;
            }
            set
            {
                if (value == dragScrolling)
                {
                    return;
                }

                dragScrolling = value;

                if (!InternalProperty_911)
                {
                    return;
                }

                if (dragScrolling)
                {
                    if (!VectorScrolling)
                    {
                        InternalMethod_2074();
                    }

                    UIBlock.InternalProperty_23.InternalEvent_2 += InternalProperty_766;
                }
                else
                {
                    UIBlock.InternalProperty_23.InternalEvent_2 -= InternalProperty_766;

                    if (!VectorScrolling)
                    {
                        InternalMethod_2073();
                    }
                }
            }
        }

        /// <summary>
        /// Allow mouse wheel or joystick vector events to trigger a scroll via <see cref="Interaction.Scroll(Interaction.Update, Vector3, float, int, InputAccuracy)"/>
        /// </summary>
        public bool VectorScrolling
        {
            get
            {
                return vectorScrolling;
            }
            set
            {
                if (value == vectorScrolling)
                {
                    return;
                }

                vectorScrolling = value;

                if (!InternalProperty_911)
                {
                    return;
                }

                if (vectorScrolling)
                {
                    if (!DragScrolling)
                    {
                        InternalMethod_2074();
                    }

                    UIBlock.InternalProperty_23.InternalEvent_3 += InternalProperty_765;
                }
                else
                {
                    UIBlock.InternalProperty_23.InternalEvent_3 -= InternalProperty_765;

                    if (!DragScrolling)
                    {
                        InternalMethod_2073();
                    }
                }
            }
        }

        /// <summary>
        /// The <see cref="Nova.UIBlock"/> scrollbar root
        /// </summary>
        public UIBlock ScrollbarVisual => scrollbarVisual;

        /// <summary>
        /// Indicates whether or not the <see cref="Scroller"/> should handle drag events on the <see cref="ScrollbarVisual"/>.
        /// </summary>
        /// <remarks>
        /// Proper configuration requires the <see cref= "ScrollbarVisual"/> to have an <see cref="Interactable"/> attached to it which must have <see cref="Interactable.Draggable"/> set to <see langword="true"/> along the scrolling axis.
        /// </remarks>
        /// <seealso cref="Interactable"/>
        /// <seealso cref="Interactable.Draggable"/>
        public bool DraggableScrollbar
        {
            get
            {
                return draggableScrollbar;
            }
            set
            {
                if (value == draggableScrollbar)
                {
                    return;
                }

                draggableScrollbar = value;

                if (scrollbarVisual == null || !InternalProperty_911)
                {
                    return;
                }

                if (draggableScrollbar)
                {
                    scrollbarVisual.InternalMethod_3272(InternalProperty_749, InternalParameter_3056: true);
                    scrollbarVisual.InternalMethod_3272(InternalProperty_750, InternalParameter_3056: true);
                }
                else
                {
                    scrollbarVisual.InternalMethod_3271(InternalProperty_749);
                    scrollbarVisual.InternalMethod_3271(InternalProperty_750);
                }
            }
        }

        /// <summary>
        /// The number of child UIBlocks this scroller is capable of scrolling to.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>
        /// Value can be larger than <see cref="UIBlock.ChildCount"/> if this <see cref="GameObject"/> has an attached <see cref="ListView"/> component.
        /// </description></item>
        /// <item><description>
        /// This is the upper limit (exclusive) for the index that can be passed to <see cref="ScrollToIndex(int, bool)"/>.
        /// </description></item>
        /// </list>
        /// </remarks>
        public int ScrollableChildCount => InternalProperty_912 ? InternalField_2802.InternalProperty_0 : UIBlock.ChildCount;

        /// <summary>
        /// Abruptly stop the active scroll 
        /// </summary>
        /// <remarks>If <c>this.ActiveAndEnabled == <see langword="false"/></c>, this call won't do anything.</remarks>
        public void CancelScroll()
        {
            if (!InternalProperty_911)
            {
                return;
            }

            if (InternalField_2259.InternalProperty_167)
            {
                UIBlock.InternalProperty_23.InternalMethod_467(InternalField_2259);
            }
            else
            {
                InternalMethod_2662(ref InternalField_2259);
            }
        }

        /// <summary>
        /// Scrolls to the child item at the provided index <paramref name="index"/> and applies a brief "after scroll" animation.
        /// </summary>
        /// <remarks>If <c>this.ActiveAndEnabled == <see langword="false"/></c>, this call won't do anything.</remarks>
        /// <param name="index">The index of the child in the range [0, <see cref="ScrollableChildCount"/>) to scroll to</param>
        /// <exception cref="System.IndexOutOfRangeException">if <c><paramref name="index"/> &lt; 0 || <paramref name="index"/> &gt;= <see cref="ScrollableChildCount"/></c></exception>
        /// <exception cref="System.InvalidOperationException">if <c><see cref="UIBlock">UIBlock</see>.<see cref="UIBlock.AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> == <see cref="Axis"/>.<see cref="Axis.None">None</see></c></exception>
        public void ScrollToIndex(int index) => ScrollToIndex(index, animate: true);

        /// <summary>
        /// Scrolls to the child item at the provided index <paramref name="index"/> and optionally applies a brief "after scroll" animation.
        /// </summary>
        /// <remarks>If <c>this.ActiveAndEnabled == <see langword="false"/></c>, this call won't do anything.</remarks>
        /// <param name="index">The index of the child in the range [0, <see cref="ScrollableChildCount"/>) to scroll to</param>
        ///<param name="animate">Applies an "after scroll" animation when <c>true</c>. Jumps to the position without animating when <c>false</c>.</param>
        /// <exception cref="System.IndexOutOfRangeException">if <c><paramref name="index"/> &lt; 0 || <paramref name="index"/> &gt;= <see cref="ScrollableChildCount"/></c></exception>
        /// <exception cref="System.InvalidOperationException">if <c><see cref="UIBlock">UIBlock</see>.<see cref="UIBlock.AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> == <see cref="Axis"/>.<see cref="Axis.None">None</see></c></exception>
        public void ScrollToIndex(int index, bool animate)
        {
            if (!InternalProperty_911)
            {
                return;
            }

            float InternalVar_1 = 0;

            if (!InternalProperty_912)
            {
                ref AutoLayout InternalVar_2 = ref UIBlock.AutoLayout;

                if (!InternalVar_2.Axis.TryGetIndex(out int InternalVar_3))
                {
                    throw new System.InvalidOperationException($"{UIBlock.name}'s Auto Layout axis is unassigned.");
                }

                if (index < 0 || index >= UIBlock.ChildCount)
                {
                    throw new System.IndexOutOfRangeException($"Expected: [0, {UIBlock.ChildCount}). Actual: {index}.");
                }

                UIBlock InternalVar_4 = UIBlock.GetChild(index);

                InternalVar_1 = InternalType_182.InternalMethod_3654(InternalVar_4, InternalVar_3, InternalVar_2.Alignment);

                if (!animate)
                {
                    InternalVar_2.Offset += InternalVar_1 * InternalVar_2.InternalProperty_14;
                    InternalVar_1 = 0;
                }
            }
            else
            {
                if (animate)
                {
                    InternalVar_1 = InternalField_2802.JumpToIndexPage(index);
                }
                else
                {
                    InternalField_2802.JumpToIndex(index);
                }
            }

            InternalMethod_2403();

            InternalField_2793 = false;

            InternalProperty_547.InternalMethod_717(InternalField_2262 - InternalField_2263, 0);

            float InternalVar_5 = InternalVar_1 * -InternalType_508.InternalField_2233;

            InternalMethod_1991(InternalVar_5, InternalType_508.InternalField_2234);
        }

        /// <summary>
        /// Scrolls content by the provided <paramref name="delta"/> along the <see cref="UIBlock"/>'s <see cref="AutoLayout"/>.<see cref="AutoLayout.Axis">Axis</see>
        /// </summary>
        /// <remarks>
        /// If <c>this.ActiveAndEnabled == <see langword="false"/></c>, this call won't do anything. 
        /// May require a call to <see cref="UIBlock.CalculateLayout"/> if attempting to scroll immediately 
        /// after child content has been modified.
        /// </remarks>
        /// <param name="delta">Value is in <c><see cref="UIBlock"/>.transform</c> local space</param>
        /// <exception cref="System.InvalidOperationException">if <c><see cref="UIBlock">UIBlock</see>.<see cref="UIBlock.AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> == <see cref="Axis"/>.<see cref="Axis.None">None</see></c></exception>
        public void Scroll(float delta)
        {
            if (!InternalProperty_911)
            {
                return;
            }

            if (!UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_1))
            {
                throw new System.InvalidOperationException($"{UIBlock.name}'s Auto Layout axis is unassigned.");
            }

            Vector3 InternalVar_2 = Vector3.zero;
            InternalVar_2[InternalVar_1] = delta;

            InternalNamespace_0.InternalType_78 InternalVar_3 = InternalNamespace_0.InternalType_78.InternalField_260;

            InternalMethod_1994(InternalVar_2, ref InternalVar_3);
        }

        /// <summary>
        /// Moves the scrollbar to the <paramref name="newScrollbarWorldPosition"/> and scrolls the content accordingly
        /// </summary>
        /// <remarks>
        /// If <c><see cref="DraggableScrollbar"/> == <see langword="true"/></c>, this will be called automatically whenever the <see cref="ScrollbarVisual"/> fires <see cref="Gesture.OnDrag"/> events.<br/>
        /// If <c>this.ActiveAndEnabled == <see langword="false"/></c>, this call won't do anything.
        /// </remarks>
        /// <param name="newScrollbarWorldPosition">The position to move the scrollbar to in world space. This will clamp everything to move along the scrolling axis.</param>
        public void DragScrollbarToPosition(Vector3 newScrollbarWorldPosition)
        {
            if (!InternalProperty_911 || scrollbarVisual == null || scrollbarVisual.Parent == null)
            {
                return;
            }

            InternalField_2793 = false;

            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return;
            }

            Vector3 InternalVar_3 = scrollbarVisual.transform.parent.InverseTransformPoint(newScrollbarWorldPosition);
            float InternalVar_4 = scrollbarVisual.Parent.PaddedSize[InternalVar_2];
            float InternalVar_5 = InternalVar_3[InternalVar_2] - scrollbarVisual.transform.localPosition[InternalVar_2];

            Length.Calculated InternalVar_6 = scrollbarVisual.CalculatedSize[InternalVar_2] + scrollbarVisual.CalculatedMargin[InternalVar_2].Sum();

            float InternalVar_7 = math.max(0, 0.5f - (InternalVar_6.Percent * 0.5f));

            if (InternalType_187.InternalMethod_914(InternalVar_7))
            {
                return;
            }

            float InternalVar_8 = InternalVar_5 / InternalVar_4;
            float InternalVar_9 = InternalProperty_912 ? InternalField_2802.InternalProperty_1 : UIBlock.InternalProperty_18[InternalVar_2];

            float InternalVar_10 = -InternalVar_8 * InternalVar_9;

            Scroll(InternalVar_10);
        }
        #endregion

        #region Internal
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                        private const int InternalField_815 = 2;

        [SerializeField, InternalType_22, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool dragScrolling = true;
        [SerializeField, InternalType_22, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool vectorScrolling = true;
        [SerializeField, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock scrollbarVisual;
        [SerializeField, InternalType_22, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool draggableScrollbar = false;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_726 InternalField_2808 = new InternalType_726();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal float InternalProperty_920 => InternalField_2393.InternalProperty_242;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_1 InternalField_2802 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalProperty_912 => (InternalField_2802 as MonoBehaviour) != null && InternalField_2802.InternalProperty_0 > 0;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2793 = true;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2792 = 0;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2773 = false;
        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_3392 = 0;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_14.InternalType_23 InternalField_2405 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_14.InternalType_23 InternalProperty_765
        {
            get
            {
                if (InternalField_2405 == null)
                {
                    InternalField_2405 = InternalMethod_311;
                }

                return InternalField_2405;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIEventHandler<Gesture.OnDrag> InternalField_2397 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIEventHandler<Gesture.OnDrag> InternalProperty_750
        {
            get
            {
                if (InternalField_2397 == null)
                {
                    InternalField_2397 = InternalMethod_2070;
                }

                return InternalField_2397;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIEventHandler<Gesture.OnRelease> InternalField_2394 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIEventHandler<Gesture.OnRelease> InternalProperty_749
        {
            get
            {
                if (InternalField_2394 == null)
                {
                    InternalField_2394 = InternalMethod_2033;
                }

                return InternalField_2394;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        System.Type InternalType_523.InternalProperty_439 => typeof(UIBlock);
        bool InternalType_523.InternalMethod_1635(InternalType_273 receiver, System.Type _, out InternalType_273 target)
        {
            target = UIBlock;
            return true;
        }

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_190 InternalField_2393 = default;
        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_190 InternalField_2392 = default;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2263 = 0;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2262 = 0;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2261 = 0;

        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_505 InternalField_2260 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_505 InternalProperty_547
        {
            get
            {
                if (InternalField_2260 == null)
                {
                    InternalField_2260 = new InternalType_505(this);
                }

                return InternalField_2260;
            }
        }


        [System.NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalNamespace_0.InternalType_78 InternalField_2259 = InternalNamespace_0.InternalType_78.InternalField_260;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal float InternalProperty_748
        {
            get
            {
                if (!InternalProperty_911)
                {
                    return 0f;
                }

                if (!InternalProperty_912)
                {
                    if (!UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_1))
                    {
                        return 0;
                    }

                    return UIBlock.InternalProperty_19[InternalVar_1];
                }

                return InternalField_2802.InternalProperty_3;
            }
        }

        private void InternalMethod_2403()
        {
            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();
            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return;
            }

            if (InternalVar_1.Alignment == 1)
            {
                InternalField_2261 = InternalVar_1.Offset;
                return;
            }

            float InternalVar_3 = UIBlock.PaddedSize[InternalVar_2];
            float InternalVar_4 = UIBlock.InternalProperty_18[InternalVar_2];
            float InternalVar_5 = InternalVar_1.Offset;
            float InternalVar_6 = UIBlock.CalculatedPadding.Offset[InternalVar_2];

            float InternalVar_7 = InternalType_182.InternalMethod_857(InternalVar_5, InternalVar_4, InternalVar_3, InternalVar_6, InternalVar_1.Alignment);

            InternalField_2261 = InternalType_182.InternalMethod_858(InternalVar_7, InternalVar_4, InternalVar_3, InternalVar_6, 1);
        }

        internal void InternalMethod_2078(float InternalParameter_2153)
        {
            Scroll(InternalParameter_2153 - InternalProperty_748);
        }

        private protected override void InternalMethod_2750()
        {
            InternalProperty_547.InternalMethod_500();

            if (InternalField_2802 == null)
            {
                InternalField_2802 = GetComponent<InternalType_1>();
            }

            InternalField_2393 = new InternalType_190(0);
            InternalField_2392 = new InternalType_190(0);

            InternalField_2792 = 0;

            if (DragScrolling || VectorScrolling)
            {
                InternalMethod_2074();
            }

            if (VectorScrolling)
            {
                UIBlock.InternalProperty_23.InternalEvent_3 += InternalProperty_765;
            }

            if (DragScrolling)
            {
                UIBlock.InternalProperty_23.InternalEvent_2 += InternalProperty_766;
            }

            UIBlock.InternalProperty_23.InternalMethod_3551(this);

            if (DraggableScrollbar && scrollbarVisual != null)
            {
                scrollbarVisual.InternalMethod_3272(InternalProperty_749, InternalParameter_3056: true);
                scrollbarVisual.InternalMethod_3272(InternalProperty_750, InternalParameter_3056: true);
            }

            InternalField_2808.InternalMethod_2963(UIBlock, InternalField_2802, scrollbarVisual);
        }

        private bool InternalMethod_2027(InternalType_5 InternalParameter_2351, int InternalParameter_2350)
        {
            Bounds InternalVar_1 = new Bounds(InternalParameter_2351.InternalMethod_1035(), InternalParameter_2351.InternalProperty_144.InternalProperty_124);
            Vector3 InternalVar_2 = UIBlock.CalculatedSize.Value * 0.5f;

            return InternalVar_1.min[InternalParameter_2350] >= -InternalVar_2[InternalParameter_2350] && InternalVar_1.max[InternalParameter_2350] <= InternalVar_2[InternalParameter_2350];
        }

        private bool InternalMethod_1034(InternalType_5 InternalParameter_1043, int InternalParameter_378)
        {
            Bounds InternalVar_1 = new Bounds(InternalParameter_1043.InternalMethod_1035(), InternalParameter_1043.InternalProperty_144.InternalProperty_124);
            Vector3 InternalVar_2 = UIBlock.CalculatedSize.Value * 0.5f;

            return InternalVar_1.max[InternalParameter_378] < -InternalVar_2[InternalParameter_378] || InternalVar_1.min[InternalParameter_378] > InternalVar_2[InternalParameter_378];
        }

        private protected override void InternalMethod_2664()
        {
            if (DragScrolling || VectorScrolling)
            {
                InternalMethod_2073();
            }

            if (VectorScrolling)
            {
                UIBlock.InternalProperty_23.InternalEvent_3 -= InternalProperty_765;
            }

            if (DragScrolling)
            {
                UIBlock.InternalProperty_23.InternalEvent_2 -= InternalProperty_766;
            }

            UIBlock.InternalProperty_23.InternalMethod_3552();

            if (DraggableScrollbar && scrollbarVisual != null)
            {
                scrollbarVisual.InternalMethod_3271(InternalProperty_749);
                scrollbarVisual.InternalMethod_3271(InternalProperty_750);
            }

            InternalField_2259 = default;
            InternalMethod_2403();
        }

        private void InternalMethod_2074()
        {
            UIBlock.InternalMethod_89(this);
            UIBlock.InternalProperty_23.InternalMethod_3548(this);
            UIBlock.InternalProperty_23.InternalEvent_4 += InternalProperty_770;
        }

        private void InternalMethod_2073()
        {
            UIBlock.InternalMethod_90(this);
            UIBlock.InternalProperty_23.InternalMethod_3549();
            UIBlock.InternalProperty_23.InternalEvent_4 -= InternalProperty_770;
        }

        private void LateUpdate()
        {
            if (InternalField_2792 != 0)
            {
                InternalField_3392 = 0;
            }

            if (InternalField_2773 && InternalField_2792 == 0 && ++InternalField_3392 >= InternalField_815)
            {
                InternalField_3392 = 0;
                InternalField_2773 = false;

                if (InternalMethod_1990()) 
                {
                    InternalType_492 InternalVar_1 = default;
                    Gesture.OnRelease InternalVar_2 = Gesture.InternalMethod_3227(InternalField_2259.InternalMethod_2179(), UIBlock, InternalParameter_3041: true, InternalParameter_3040: false);
                    InternalMethod_2661(ref InternalVar_1, ref InternalVar_2);
                }
                else 
                {
                    InternalMethod_2662(ref InternalField_2259);
                }
            }

            InternalProperty_547.InternalField_2276 = OverscrollEffect == OverscrollEffect.Clamp;

            if (InternalField_2793)
            {
                InternalMethod_1988(InternalProperty_547.InternalMethod_960(InternalField_2262));

            }
            else if (UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_3))
            {
                float InternalVar_4 = InternalField_2792;
                float InternalVar_5 = UIBlock.PaddedSize[InternalVar_3] * 0.5f;

                InternalField_2392.InternalMethod_957(InternalType_187.InternalMethod_884(InternalVar_4, -InternalVar_5, InternalVar_5));

                float InternalVar_6 = InternalField_2773 ? InternalVar_4 : InternalField_2392.InternalProperty_242;
                InternalField_2393.InternalMethod_957(InternalVar_6 / Time.unscaledDeltaTime);

                InternalMethod_1988(InternalProperty_547.InternalMethod_959(InternalVar_6, InternalField_2262));

            }

            if (UIBlock.InternalProperty_22 || InternalField_2808.InternalProperty_938)
            {
                InternalField_2808.InternalMethod_2960();
            }

            InternalField_2262 += Time.unscaledDeltaTime;
            InternalField_2792 = 0;
        }

        private void InternalMethod_2070(Gesture.OnDrag InternalParameter_2151)
        {
            DragScrollbarToPosition(scrollbarVisual.transform.position + InternalParameter_2151.DragDeltaWorldSpace);
            InternalField_2773 = false;
        }

        private void InternalMethod_2033(Gesture.OnRelease InternalParameter_2150)
        {
            InternalNamespace_0.InternalType_78 InternalVar_1 = InternalParameter_2150.Interaction.InternalMethod_2204();
            InternalMethod_2662(ref InternalVar_1);
        }

        private void InternalMethod_311(ref InternalType_14.InternalType_16<InternalType_755<Vector3>> InternalParameter_96)
        {
            if (!InternalParameter_96.InternalField_67.HasValue)
            {
                return;
            }

            InternalType_76<InternalType_755<Vector3>> InternalVar_1 = InternalParameter_96.InternalField_67.Value;

            if (!InternalVar_1.InternalField_246 || InternalVar_1.InternalField_247.InternalField_3546 == Vector3.zero)
            {
                return;
            }

            InternalMethod_1994(InternalVar_1.InternalField_247.InternalField_3546 * VectorScrollMultiplier, ref InternalParameter_96.InternalField_3029);
        }

        private void InternalMethod_1994(Vector3 InternalParameter_2148, ref InternalNamespace_0.InternalType_78 InternalParameter_2147)
        {
            InternalField_2773 = true;
            InternalMethod_1989(InternalParameter_2148, ref InternalParameter_2147);
        }

        private protected override void InternalMethod_339(ref InternalType_14.InternalType_16<bool> InternalParameter_330, ref InternalType_492 InternalParameter_714, ref Vector3 InternalParameter_713, ref Matrix4x4 InternalParameter_712)
        {
            if (InternalField_2259.InternalProperty_167 && InternalParameter_330.InternalField_3029.InternalField_257 != InternalField_2259.InternalField_257 && InternalProperty_921.TryGetValue(InternalField_2259.InternalField_257, out InternalType_492 InternalVar_1) && InternalVar_1.InternalField_2809)
            {
                return;
            }

            InternalType_76<bool> InternalVar_2 = InternalParameter_330.InternalField_70.GetValueOrDefault();
            InternalType_76<bool> InternalVar_3 = InternalParameter_330.InternalField_67.GetValueOrDefault();

            bool InternalVar_4 = InternalVar_2.InternalField_247;
            bool InternalVar_5 = InternalVar_3.InternalField_247;

            bool InternalVar_6 = InternalVar_3.InternalProperty_166 && !InternalVar_2.InternalProperty_166;
            bool InternalVar_7 = InternalVar_3.InternalProperty_166 || InternalVar_2.InternalProperty_166;
            bool InternalVar_8 = InternalVar_2.InternalProperty_166 && !InternalVar_5;

            if (!InternalVar_4 && InternalVar_5)
            {
                InternalMethod_2662(ref InternalParameter_330.InternalField_3029);
            }

            if (!InternalVar_7)
            {
                return;
            }

            InternalParameter_714.InternalField_2809 = true;

            InternalField_2773 = false;

            Vector3 InternalVar_9 = Vector3.zero;

            float InternalVar_10 = math.abs(math.sin(math.radians(InternalMethod_1985(ref InternalVar_3)))) * Vector3.Distance(InternalParameter_330.InternalField_3029.InternalField_258.origin, InternalVar_3.InternalField_248);

            Vector3 InternalVar_11 = InternalParameter_330.InternalField_70.HasValue ? InternalParameter_712.MultiplyPoint(InternalParameter_714.InternalField_2933) : InternalVar_3.InternalField_248;

            if (InternalVar_6)
            {
                InternalMethod_2403();
                InternalProperty_547.InternalMethod_717(InternalField_2262 - InternalField_2263, InternalVar_10);
                InternalField_2392.InternalProperty_242 = 0;

                if (InternalVar_4)
                {
                    InternalVar_9 = InternalParameter_330.InternalMethod_3808(InternalVar_11);
                }
            }
            else
            {
                InternalVar_9 = InternalParameter_330.InternalMethod_3808(InternalVar_11);

            }

            if (!InternalVar_5)
            {
                return;
            }

            InternalMethod_1989(InternalVar_9, ref InternalParameter_330.InternalField_3029);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected override bool InternalProperty_937 => InternalMethod_2389();

        private protected override void InternalMethod_2662(ref InternalNamespace_0.InternalType_78 InternalParameter_1327)
        {
            InternalField_2793 = true;
            InternalField_2263 = InternalField_2262;

            InternalMethod_2403();

            InternalProperty_547.InternalMethod_533(InternalField_2263);

            InternalField_2773 = false;
            InternalField_2792 = 0;

            if (InternalField_2393.InternalProperty_242 == 0)
            {
                return;
            }

            InternalField_2393.InternalProperty_242 = 0;

        }

        private protected override void InternalMethod_2661(ref InternalType_492 InternalParameter_906, ref Gesture.OnRelease InternalParameter_951)
        {
            if (InternalField_2793)
            {
                return;
            }

            InternalMethod_1991(InternalField_2393.InternalProperty_242);

            InternalField_2259 = InternalParameter_951.Interaction.InternalMethod_2204();
        }

        private void InternalMethod_1991(float InternalParameter_1794, double InternalParameter_1793 = InternalType_508.InternalField_2235)
        {
            if (InternalField_2793)
            {
                return;
            }

            InternalField_2793 = true;
            InternalField_2263 = InternalField_2262;
            InternalProperty_547.InternalMethod_1648(InternalParameter_1794, InternalField_2263, InternalParameter_1793);

        }

        InternalType_513 InternalType_506.InternalMethod_965()
        {
            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return default;
            }

            float InternalVar_3 = UIBlock.PaddedSize[InternalVar_2];
            float InternalVar_4 = UIBlock.InternalProperty_18[InternalVar_2];
            float InternalVar_5 = UIBlock.CalculatedPadding.Offset[InternalVar_2];
            float InternalVar_6 = InternalVar_3 - InternalVar_4;
            float InternalVar_7 = UIBlock.InternalProperty_19[InternalVar_2];

            bool InternalVar_8 = InternalProperty_912;

            bool InternalVar_9 = InternalVar_8 && InternalField_2802.InternalMethod_45(-1);
            bool InternalVar_10 = InternalVar_8 && InternalField_2802.InternalMethod_45(1);

            if (InternalVar_6 < 0 || InternalVar_10 || InternalVar_9)
            {
                float InternalVar_11 = InternalType_182.InternalMethod_858(InternalVar_7, InternalVar_4, InternalVar_3, InternalVar_5, 1);
                float InternalVar_12 = InternalField_2261 - InternalVar_11;

                float InternalVar_13 = InternalVar_8 ? InternalField_2802.InternalProperty_1 : InternalVar_4;

                double2 InternalVar_14 = default;
                InternalVar_14.x = InternalVar_9 ? double.NegativeInfinity : math.max(InternalVar_6 + InternalVar_12, -InternalVar_13);
                InternalVar_14.y = InternalVar_10 ? double.PositiveInfinity : math.min(InternalVar_12, InternalVar_13);

                if (InternalVar_14.x > InternalVar_14.y)
                {
                    InternalVar_14 = InternalVar_14.yx;
                }

                return new InternalType_513(InternalVar_14, InternalField_2261, InternalVar_3);
            }

            float InternalVar_15 = (InternalVar_1.Alignment - 1) * -0.5f;
            float InternalVar_16 = InternalVar_6 * InternalVar_15;

            return new InternalType_513(InternalVar_16, InternalField_2261, InternalVar_3);
        }

        private bool InternalMethod_1990()
        {
            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (InternalVar_1.Axis.TryGetIndex(out int InternalVar_2) || InternalVar_1.Offset == 0)
            {
                return false;
            }

            bool InternalVar_3 = !InternalMethod_1987(1, out _);
            bool InternalVar_4 = !InternalMethod_1987(-1, out _);

            if (!InternalVar_3 && !InternalVar_4)
            {
                return false;
            }

            float InternalVar_5 = UIBlock.InternalProperty_19[InternalVar_2];
            float InternalVar_6 = UIBlock.InternalProperty_18[InternalVar_2];
            float InternalVar_7 = UIBlock.PaddedSize[InternalVar_2];

            float InternalVar_8 = InternalVar_6 * 0.5f;
            float InternalVar_9 = InternalVar_5 - InternalVar_8;
            float InternalVar_10 = InternalVar_5 + InternalVar_8;
            float InternalVar_11 = InternalVar_7 * 0.5f;

            return (InternalVar_3 && InternalVar_10 < InternalVar_11) ||
                   (InternalVar_4 && InternalVar_9 > -InternalVar_11);
        }

        private void InternalMethod_1989(Vector3 InternalParameter_1792, ref InternalNamespace_0.InternalType_78 InternalParameter_1791)
        {


            InternalField_2793 = false;

            if (UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_1))
            {
                InternalField_2792 += InternalParameter_1792[InternalVar_1];
            }

            InternalField_2259 = InternalParameter_1791;
        }

        private void InternalMethod_1988(float InternalParameter_1790)
        {
            float InternalVar_1 = (float)InternalField_2261 - InternalParameter_1790;

            if (InternalField_2793)
            {
                InternalField_2393.InternalProperty_242 = InternalProperty_547.InternalMethod_961(InternalField_2262);
            }

            if (InternalType_187.InternalMethod_914(InternalVar_1))
            {
                return;
            }

            ref AutoLayout InternalVar_2 = ref UIBlock.AutoLayout;

            if (!InternalVar_2.Axis.TryGetIndex(out int InternalVar_3))
            {
                return;
            }

            float InternalVar_4 = UIBlock.PaddedSize[InternalVar_3];

            InternalVar_1 = InternalType_187.InternalMethod_869(InternalVar_1, 2 * InternalVar_4 * InternalType_187.InternalMethod_892(InternalVar_1));

            if (InternalProperty_912)
            {
                InternalField_2802.Scroll(InternalVar_1);
                InternalField_2261 = InternalParameter_1790;
            }
            else
            {
                InternalVar_2.Offset += InternalVar_1 * InternalVar_2.InternalProperty_14;
                InternalMethod_2403();
            }

            Vector3 InternalVar_5 = Vector3.zero;
            InternalVar_5[InternalVar_3] = InternalVar_1;

            ScrollType InternalVar_6 = InternalField_2793 ? ScrollType.Inertial : ScrollType.Manual;

            UIBlock.InternalMethod_91(Gesture.InternalMethod_3225(InternalField_2259.InternalMethod_2179(), UIBlock, InternalVar_6, InternalVar_5));
        }

        InternalType_77 InternalType_75.InternalMethod_3340<T>(Ray InternalParameter_329, InternalType_76<T> InternalParameter_328, InternalType_76<T> InternalParameter_2232, Transform InternalParameter_2233)
        {
            int InternalVar_1 = UIBlock.InternalMethod_79().Axis.Index();

            Vector3 InternalVar_2 = Vector3.zero;

            InternalType_77 InternalVar_3 = InternalType_77.InternalField_251;

            if (InternalVar_1 >= 0)
            {
                InternalVar_2[InternalVar_1] = 1;
            }
            else
            {
                return InternalVar_3;
            }

            System.Type InternalVar_4 = typeof(T);

            if (InternalMethod_2389() && InternalParameter_2233.IsChildOf(transform))
            {
                return InternalType_77.InternalField_253;
            }

            InternalVar_3 = InternalType_77.InternalField_252;

            if (InternalVar_4 == typeof(bool))
            {
                Vector3 InternalVar_5 = UIBlock.transform.TransformDirection(InternalVar_2);
                Vector3 InternalVar_6 = InternalParameter_329.direction;
                Vector3 InternalVar_7 = InternalParameter_329.origin;
                Vector3 InternalVar_8 = Vector3.Cross(InternalVar_6, InternalVar_5);

                if (InternalVar_8 == Vector3.zero)
                {
                    InternalVar_2 = InternalVar_1 != 0 ? Vector3.right : InternalVar_1 != 1 ? Vector3.up : Vector3.forward;
                    InternalVar_6 = UIBlock.transform.TransformDirection(InternalVar_2);
                    InternalVar_7 = InternalParameter_328.InternalField_248;
                    InternalVar_8 = Vector3.Cross(InternalVar_6, InternalVar_5);
                }

                Vector3 InternalVar_9 = InternalType_187.InternalMethod_3642(InternalParameter_2232.InternalField_248 - InternalVar_7);

                float InternalVar_10 = InternalType_187.InternalMethod_907(InternalVar_6, InternalVar_9, InternalVar_8);
                InternalVar_10 = math.min(InternalVar_10, 180 - InternalVar_10);

                InternalVar_3 = InternalVar_10 >= InternalMethod_1985(ref InternalParameter_2232) ? InternalMethod_1986(ref InternalParameter_328, ref InternalParameter_2232, InternalVar_1) : InternalVar_3;
            }
            else if (InternalVar_4 == typeof(InternalType_755<Vector3>))
            {
                _ = InternalParameter_2232.InternalMethod_474(out InternalType_76<InternalType_755<Vector3>>? InternalVar_5);
                Vector3 InternalVar_6 = InternalVar_5.Value.InternalField_247.InternalField_3546;

                InternalVar_3 = InternalVar_6[InternalVar_1] != 0 ? InternalMethod_3649(Vector3.zero, InternalVar_6, InternalVar_1) : InternalVar_3;
            }

            return InternalVar_3;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_754.InternalProperty_1153 => InternalProperty_164;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_754.InternalProperty_1154 => OnSelect == SelectBehavior.FireEvents;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_754.InternalProperty_1155 => OnSelect == SelectBehavior.ScopeNavigation;

        bool InternalType_754.InternalMethod_3559(Vector3 InternalParameter_3234)
        {
            if (InternalType_182.InternalMethod_3638(UIBlock, InternalParameter_3234, out int _, out int InternalVar_1))
            {
                return !InternalMethod_1987(InternalVar_1, out _);
            }

            return true;
        }

        bool InternalType_754.InternalMethod_3561(Vector3 InternalParameter_3238, out InternalType_5 InternalParameter_3239)
        {
            InternalParameter_3239 = null;

            if (!InternalProperty_164)
            {
                return false;
            }

            return Navigation.InternalMethod_2715(InternalParameter_3238, out InternalParameter_3239);
        }

        bool InternalType_754.InternalMethod_3576(InternalType_5 InternalParameter_3264, InternalType_5 InternalParameter_3263, Vector3 InternalParameter_3262)
        {
            if (!InternalProperty_164)
            {
                return false;
            }

            if (!InternalType_182.InternalMethod_3638(UIBlock, InternalParameter_3262, out int InternalVar_1, out int InternalVar_2))
            {
                return false;
            }

            if (InternalParameter_3264 == null)
            {
                if (InternalMethod_1987(InternalVar_2, out float InternalVar_3))
                {
                    float InternalVar_4 = InternalType_187.InternalMethod_869(UIBlock.InternalMethod_3595(0).InternalProperty_150[InternalVar_1] + UIBlock.CalculatedSpacing.Value, InternalVar_3);
                    Scroll(InternalVar_4 * -InternalVar_2);

                    return true;
                }

                return false;
            }

            if (InternalParameter_3263 == null)
            {
                if (InternalMethod_1987(InternalVar_2, out float InternalVar_3))
                {
                    float InternalVar_4 = InternalType_187.InternalMethod_869(InternalParameter_3264.InternalProperty_150[InternalVar_1] + UIBlock.CalculatedSpacing.Value, InternalVar_3);
                    Scroll(InternalVar_4 * InternalVar_2);

                    return true;
                }

                return false;
            }

            if (InternalMethod_1034(InternalParameter_3263, InternalVar_1))
            {
                float InternalVar_3 = InternalType_182.InternalMethod_3654(InternalParameter_3263, InternalVar_1, UIBlock.InternalMethod_79().Alignment);
                float InternalVar_4 = (InternalParameter_3263.InternalProperty_150[InternalVar_1] + UIBlock.CalculatedSpacing.Value) * InternalVar_2;

                if (!InternalType_187.InternalMethod_3644(InternalType_187.InternalMethod_871(InternalVar_3), InternalType_187.InternalMethod_871(InternalVar_4)))
                {
                    Scroll(InternalVar_4);

                    return true;
                }
            }

            if (!InternalMethod_2027(InternalParameter_3263, InternalVar_1))
            {
                int InternalVar_3 = 0;

                if (InternalProperty_912)
                {
                    InternalType_5 InternalVar_4 = InternalParameter_3263.InternalProperty_203 ? InternalParameter_3263.InternalMethod_3595(0) : InternalParameter_3263;
                    if (!InternalField_2802.InternalMethod_868(InternalVar_4, out InternalVar_3))
                    {
                        return false;
                    }
                }
                else
                {
                    InternalVar_3 = UIBlock.InternalMethod_3594(InternalParameter_3263);
                }

                ScrollToIndex(InternalVar_3, animate: false);
            }

            return true;
        }

        void InternalType_754.InternalMethod_3585(InternalType_5 InternalParameter_3313)
        {
            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();
            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return;
            }

            if (InternalParameter_3313 == null)
            {
                return;
            }

            Vector3 InternalVar_3 = InternalType_457.InternalProperty_190.InternalMethod_682(InternalParameter_3313).c3.xyz;
            Vector3 InternalVar_4 = UIBlock.transform.InverseTransformPoint(InternalVar_3);

            float InternalVar_5 = InternalParameter_3313.InternalProperty_147.InternalProperty_139[InternalVar_2];
            float InternalVar_6 = InternalVar_5 + UIBlock.CalculatedPadding.Offset[InternalVar_2];
            float InternalVar_7 = InternalVar_4[InternalVar_2];
            float InternalVar_8 = InternalParameter_3313.InternalProperty_144[InternalVar_2].InternalField_153;

            float InternalVar_9 = InternalType_182.InternalMethod_858(InternalVar_7, InternalVar_8, UIBlock.PaddedSize[InternalVar_2], InternalVar_6, InternalVar_1.Alignment);

            float InternalVar_10 = InternalType_182.InternalMethod_3696(InternalVar_8, InternalVar_9, InternalVar_5, UIBlock, InternalVar_2, InternalVar_1.Alignment);
            int InternalVar_11 = -(int)InternalType_187.InternalMethod_892(InternalVar_10);

            if (!InternalType_187.InternalMethod_914(InternalVar_10) && InternalMethod_1987(InternalVar_11, out _))
            {
                Scroll(InternalVar_10);
                LateUpdate();
            }
        }

        private bool InternalMethod_2389()
        {
            if (!UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_1))
            {
                return !InternalType_187.InternalMethod_914(InternalField_2393.InternalProperty_242);
            }

            double InternalVar_2 = 0.1f * math.pow(10, math.round(math.log10(UIBlock.CalculatedSize[InternalVar_1].Value)));

            return !InternalType_187.InternalMethod_915(InternalField_2393.InternalProperty_242, InternalParameter_851: InternalVar_2);
        }

        private bool InternalMethod_1987(int InternalParameter_1789, out float InternalParameter_2143)
        {
            if (InternalProperty_912 && InternalField_2802.InternalMethod_45(InternalParameter_1789))
            {
                InternalParameter_2143 = InternalParameter_1789 < 0 ? float.MinValue : float.MaxValue;

                return true;
            }

            if (!UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_1))
            {
                InternalParameter_2143 = 0;
                return false;
            }

            float InternalVar_2 = UIBlock.CalculatedPadding.Offset[InternalVar_1] + 0.5f * InternalParameter_1789 * UIBlock.PaddedSize[InternalVar_1];
            float InternalVar_3 = UIBlock.InternalProperty_19[InternalVar_1] + 0.5f * InternalParameter_1789 * UIBlock.InternalProperty_18[InternalVar_1];

            InternalParameter_2143 = InternalParameter_1789 * (InternalVar_3 - InternalVar_2);

            float InternalVar_4 = InternalType_187.InternalMethod_871(InternalVar_3);
            float InternalVar_5 = InternalType_187.InternalMethod_871(InternalVar_2);

            return InternalType_187.InternalMethod_922(InternalVar_4, InternalVar_5) ? false : InternalVar_5 < InternalVar_4;
        }

        private InternalType_77 InternalMethod_1986<T>(ref InternalType_76<T> InternalParameter_1788, ref InternalType_76<T> InternalParameter_1787, int InternalParameter_1786) where T : unmanaged, System.IEquatable<T>
        {
            Vector3 InternalVar_1 = UIBlock.transform.InverseTransformPoint(InternalParameter_1788.InternalField_248);
            Vector3 InternalVar_2 = UIBlock.transform.InverseTransformPoint(InternalParameter_1787.InternalField_248);
            return InternalMethod_3649(InternalVar_1, InternalVar_2, InternalParameter_1786);
        }

        private InternalType_77 InternalMethod_3649(Vector3 InternalParameter_2144, Vector3 InternalParameter_3266, int InternalParameter_3265)
        {
            int InternalVar_1 = (int)InternalType_187.InternalMethod_892((InternalParameter_2144 - InternalParameter_3266)[InternalParameter_3265]);

            return InternalMethod_1987(InternalVar_1, out _) ? InternalType_77.InternalField_255 : InternalType_77.InternalField_254;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_75.InternalProperty_741 => ObstructDrags;

        private float InternalMethod_1985<T>(ref InternalType_76<T> InternalParameter_1767) where T : unmanaged, System.IEquatable<T> => InternalParameter_1767.InternalField_250 ? LowAccuracyDragThreshold : DragThreshold;

        private Scroller() : base()
        {
            ClickBehavior = ClickBehavior.None;
            onSelect = SelectBehavior.ScopeNavigation;
        }
        #endregion
    }
}
