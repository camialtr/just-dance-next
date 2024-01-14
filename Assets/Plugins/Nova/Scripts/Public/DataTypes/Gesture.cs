// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_25;
using System.Collections.Generic;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A delegate for handling events.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    /// <param name="evt">The details of the event.</param>
    /// <seealso cref="UIBlock.AddGestureHandler{TEvent}(UIEventHandler{TEvent}, bool)"/>
    /// <seealso cref="UIBlock.RemoveGestureHandler{TEvent}(UIEventHandler{TEvent})"/>
    public delegate void UIEventHandler<in TEvent>(TEvent evt) where TEvent : struct, IEvent;

    /// <summary>
    /// A delegate for handling type-targeted events.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    /// <typeparam name="TTarget">The type of object relevant to the event.</typeparam>
    /// <param name="evt">The details of the event.</param>
    /// <param name="target">The targeted object relevant the event.</param>
    /// <seealso cref="UIBlockExtensions.AddGestureHandler{TEvent, TVisuals}(UIBlock, UIEventHandler{TEvent, TVisuals})"/>
    /// <seealso cref="UIBlockExtensions.RemoveGestureHandler{TEvent, TVisuals}(UIBlock, UIEventHandler{TEvent, TVisuals})"/>
    public delegate void UIEventHandler<in TEvent, in TTarget>(TEvent evt, TTarget target) where TEvent : struct, IEvent;

    /// <summary>
    /// A delegate for handling indexed type-targeted events.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    /// <typeparam name="TTarget">The type of object relevant to the event.</typeparam>
    /// <typeparam name="TIndex">The type of unique ID, likely used as an index into a relevant data source.</typeparam>
    /// <param name="evt">The details of the event.</param>
    /// <param name="target">The object relevant to the event.</param>
    /// <param name="index">The index into the data source relevant to <paramref name="evt"/>.</param>
    /// <seealso cref="ListView.AddGestureHandler{TEvent, TVisuals}(UIEventHandler{TEvent, TVisuals, int})"/>
    /// <seealso cref="ListView.RemoveGestureHandler{TEvent, TVisuals}(UIEventHandler{TEvent, TVisuals, int})"/>
    /// <seealso cref="ListView.AddDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/>
    /// <seealso cref="ListView.RemoveDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/>
    /// <seealso cref="ListView.AddDataUnbinder{TData, TVisuals}(UIEventHandler{Data.OnUnbind{TData}, TVisuals, int})"/>
    /// <seealso cref="ListView.RemoveDataUnbinder{TData, TVisuals}(UIEventHandler{Data.OnUnbind{TData}, TVisuals, int})"/>
    public delegate void UIEventHandler<in TEvent, in TTarget, in TIndex>(TEvent evt, TTarget target, TIndex index) where TEvent : struct, IEvent where TIndex : struct, System.IEquatable<TIndex>;

    /// <summary>
    /// A static class providing all UIBlock data event types.
    /// </summary>
    /// 
    /// <seealso cref="OnBind{TData}"/>
    /// <seealso cref="OnUnbind{TData}"/>
    /// <seealso cref="ItemView"/>
    /// <seealso cref="ItemVisuals"/>
    /// <seealso cref="ListView"/>
    /// <seealso cref="GridView"/>
    public static class Data
    {
        #region 
        internal static OnBind<TData> InternalMethod_159<TData>(ItemView InternalParameter_101, TData InternalParameter_102)
        {
            return new OnBind<TData>()
            {
                Target = InternalParameter_101.UIBlock,
                Receiver = InternalParameter_101.UIBlock,
                UserData = InternalParameter_102,
                View = InternalParameter_101,
            };
        }

        internal static OnUnbind<TData> InternalMethod_160<TData>(ItemView InternalParameter_103, TData InternalParameter_104)
        {
            return new OnUnbind<TData>()
            {
                Target = InternalParameter_103.UIBlock,
                Receiver = InternalParameter_103.UIBlock,
                UserData = InternalParameter_104,
                View = InternalParameter_103,
            };
        }
        #endregion

        /// <summary>
        /// Details of a data-model to view-model bind event.
        /// </summary>
        /// <typeparam name="TData">The type of data to bind to the attached <see cref="View">View</see>.<see cref="ItemView.Visuals">Visuals</see>.</typeparam>
        /// <seealso cref="ItemView"/>
        /// <seealso cref="ItemVisuals"/>
        /// <seealso cref="ListView"/>
        /// <seealso cref="GridView"/>
        public struct OnBind<TData> : IEvent, System.IEquatable<OnBind<TData>>
        {
            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// The <see cref="ItemView"/> containing the <see cref="ItemVisuals"/> for the given <see cref="UserData"/>.
            /// </summary>
            public ItemView View;

            /// <summary>
            /// The underlying data to bind to the attached <see cref="View">View</see>.<see cref="ItemView.Visuals">Visuals</see>.
            /// </summary>
            public TData UserData;

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnBind<TData> lhs, OnBind<TData> rhs)
            {
                return lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.View == rhs.View &&
                       EqualityComparer<TData>.Default.Equals(lhs.UserData, rhs.UserData) &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnBind<TData> lhs, OnBind<TData> rhs)
            {
                return lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.View != rhs.View ||
                       !EqualityComparer<TData>.Default.Equals(lhs.UserData, rhs.UserData) ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnBind{TData}"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + this.InternalMethod_2009();

                if (View != null)
                {
                    InternalVar_1 = (InternalVar_1 * 7) + View.GetHashCode();
                }

                if (typeof(TData).IsValueType || UserData != null)
                {
                    InternalVar_1 = (InternalVar_1 * 7) + View.GetHashCode();
                }

                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnBind{TData}"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnBind<TData> evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnBind{TData}"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnBind<TData> other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a data-model to view-model unbind event.
        /// </summary>
        /// <typeparam name="TData">The type of data being unbound from the attached <see cref="View">View</see>.<see cref="ItemView.Visuals">Visuals</see>.</typeparam>
        /// <seealso cref="ItemView"/>
        /// <seealso cref="ItemVisuals"/>
        /// <seealso cref="ListView"/>
        /// <seealso cref="GridView"/>
        public struct OnUnbind<TData> : IEvent, System.IEquatable<OnUnbind<TData>>
        {
            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// The <see cref="ItemView"/> containing the <see cref="ItemVisuals"/> for the given <see cref="UserData"/>.
            /// </summary>
            public ItemView View;

            /// <summary>
            /// The underlying data to unbind from the attached <see cref="View">View</see>.<see cref="ItemView.Visuals">Visuals</see>.
            /// </summary>
            public TData UserData;

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnUnbind<TData> lhs, OnUnbind<TData> rhs)
            {
                return lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.View == rhs.View &&
                       EqualityComparer<TData>.Default.Equals(lhs.UserData, rhs.UserData) &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnUnbind<TData> lhs, OnUnbind<TData> rhs)
            {
                return lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.View != rhs.View ||
                       !EqualityComparer<TData>.Default.Equals(lhs.UserData, rhs.UserData) ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnUnbind{TData}"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + this.InternalMethod_2009();

                if (View != null)
                {
                    InternalVar_1 = (InternalVar_1 * 7) + View.GetHashCode();
                }

                if (typeof(TData).IsValueType || UserData != null)
                {
                    InternalVar_1 = (InternalVar_1 * 7) + View.GetHashCode();
                }

                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnUnbind{TData}"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnUnbind<TData> evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnUnbind{TData}"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnUnbind<TData> other)
            {
                return this == other;
            }
        }
    }

    /// <summary>
    /// The source of the scroll delta.
    /// </summary>
    public enum ScrollType
    {
        /// <summary>
        /// User driven scroll event.<br/>
        /// A pointer was dragged or either a mouse wheel or joystick were used.
        /// </summary>
        Manual,
        /// <summary>
        /// Physics driven scroll event.<br/>
        /// After one or more <see cref="Manual"/> scroll events, the scrollable content will be moving at a non-zero velocity.<br/>
        /// This means, even after the gesture is released, the scrollable content may continue to animate until a new gesture is initiated or
        /// its velocity reaches zero.
        /// </summary>
        Inertial
    }

    /// <summary>
    /// A static class providing all available UIBlock interaction event types.
    /// </summary>
    /// <seealso cref="OnClick"/>
    /// <seealso cref="OnPress"/>
    /// <seealso cref="OnRelease"/>
    /// <seealso cref="OnHover"/>
    /// <seealso cref="OnUnhover"/>
    /// <seealso cref="OnScroll"/>
    /// <seealso cref="OnMove"/>
    /// <seealso cref="OnDrag"/>
    /// <seealso cref="OnCancel"/>
    /// <seealso cref="IGestureEvent"/>
    /// <seealso cref="Interactable"/>
    /// <seealso cref="Scroller"/>
    public static partial class Gesture
    {
        #region 
        internal static OnMove InternalMethod_3267(Interaction.Update InternalParameter_3052, UIBlock InternalParameter_3051, Vector3 InternalParameter_3050) => new OnMove() { Interaction = InternalParameter_3052, Target = InternalParameter_3051, Receiver = InternalParameter_3051, PointerWorldPosition = InternalParameter_3050 };
        internal static OnHover InternalMethod_3266(Interaction.Update InternalParameter_3049, UIBlock InternalParameter_3048, Vector3 InternalParameter_3045) => new OnHover() { Interaction = InternalParameter_3049, Target = InternalParameter_3048, Receiver = InternalParameter_3048, PointerWorldPosition = InternalParameter_3045 };
        internal static OnUnhover InternalMethod_3265(Interaction.Update InternalParameter_3047, UIBlock InternalParameter_3046) => new OnUnhover() { Interaction = InternalParameter_3047, Target = InternalParameter_3046, Receiver = InternalParameter_3046 };
        internal static OnPress InternalMethod_3264(Interaction.Update InternalParameter_3044, UIBlock InternalParameter_2566, Vector3 InternalParameter_2565) => new OnPress() { Interaction = InternalParameter_3044, Target = InternalParameter_2566, Receiver = InternalParameter_2566, PointerWorldPosition = InternalParameter_2565 };
        internal static OnRelease InternalMethod_3227(Interaction.Update InternalParameter_3043, UIBlock InternalParameter_3042, bool InternalParameter_3041, bool InternalParameter_3040) => new OnRelease() { Interaction = InternalParameter_3043, Target = InternalParameter_3042, Receiver = InternalParameter_3042, Hovering = InternalParameter_3041, WasDragged = InternalParameter_3040 };
        internal static OnClick InternalMethod_3226(Interaction.Update InternalParameter_3039, UIBlock InternalParameter_3038) => new OnClick() { Interaction = InternalParameter_3039, Target = InternalParameter_3038, Receiver = InternalParameter_3038 };
        internal static OnScroll InternalMethod_3225(Interaction.Update InternalParameter_3037, UIBlock InternalParameter_3036, ScrollType InternalParameter_3035, Vector3 InternalParameter_3034) => new OnScroll() { Interaction = InternalParameter_3037, Target = InternalParameter_3036, Receiver = InternalParameter_3036, ScrollDeltaLocalSpace = InternalParameter_3034, ScrollType = InternalParameter_3035 };
        internal static OnDrag InternalMethod_155(Interaction.Update InternalParameter_97, UIBlock InternalParameter_98, ref Positions InternalParameter_3030, ref Positions InternalParameter_3031, ThreeD<bool> InternalParameter_3032) => new OnDrag() { Interaction = InternalParameter_97, Target = InternalParameter_98, Receiver = InternalParameter_98, RawPointerPositions = InternalParameter_3030, PointerPositions = InternalParameter_3031, DraggableAxes = InternalParameter_3032 };
        internal static OnCancel InternalMethod_3197(Interaction.Update InternalParameter_3029, UIBlock InternalParameter_3028) => new OnCancel() { Interaction = InternalParameter_3029, Target = InternalParameter_3028, Receiver = InternalParameter_3028 };
        #endregion

        /// <summary>
        /// A set of sequential positions generated by a pointer interaction.
        /// </summary>
        public struct Positions : System.IEquatable<Positions>
        {
            /// <summary>
            /// The start position of the interaction.
            /// </summary>
            public Vector3 Start;
            /// <summary>
            /// The previous position of the interaction.
            /// </summary>
            public Vector3 Previous;
            /// <summary>
            /// The current position of the interaction.
            /// </summary>
            public Vector3 Current;

            /// <summary>
            /// The delta between <paramref name="from"/> and <paramref name="to"/> in the local space of the provided <paramref name="transform"/>.
            /// </summary>
            /// <param name="transform">Defines the local space.</param>
            /// <param name="from">The start position in world space.</param>
            /// <param name="to">The end position in world space.</param>
            /// <returns>The delta between <paramref name="from"/> and <paramref name="to"/> in <paramref name="transform"/> local space.</returns>
            public static Vector3 GetTranslationInLocalSpace(Transform transform, Vector3 from, Vector3 to)
            {
                if (transform == null)
                {
                    return Vector3.zero;
                }

                return transform.InverseTransformVector(to - from);
            }

            /// <summary>
            /// The delta between <paramref name="from"/> and <paramref name="to"/> in world space, constrained to the <paramref name="axisMask"/> local axes of the provided <paramref name="transform"/>.
            /// </summary>
            /// <param name="transform">Defines the local space.</param>
            /// <param name="from">The start position in world space.</param>
            /// <param name="to">The end position in world space.</param>
            /// <param name="axisMask">The local space axes.<br/>
            /// If <paramref name="axisMask"/>[axis] is <see langword="true"/>, the local translation along that axis is preserved.<br/>
            /// If <paramref name="axisMask"/>[axis] is <see langword="false"/>, the local translation along that axis is zeroed out.</param>
            /// <returns>The delta between <paramref name="from"/> and <paramref name="to"/> in <paramref name="transform"/> local space.</returns>
            public static Vector3 GetMaskedTranslationWorldSpace(Transform transform, Vector3 from, Vector3 to, ThreeD<bool> axisMask)
            {
                if (transform == null || !InternalType_728.InternalMethod_3278(axisMask))
                {
                    return Vector3.zero;
                }

                Vector3 InternalVar_1 = Vector3.Scale(GetTranslationInLocalSpace(transform, from, to), InternalType_728.InternalMethod_3283(axisMask));
                return transform.TransformVector(InternalVar_1);
            }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Start == <paramref name="rhs"/>.Start &amp;&amp; <paramref name="lhs"/>.Previous == <paramref name="rhs"/>.Previous &amp;&amp; <paramref name="lhs"/>.Current == <paramref name="rhs"/>.Current</c>.</returns>
            public static bool operator ==(Positions lhs, Positions rhs)
            {
                return lhs.Start == rhs.Start &&
                       lhs.Previous == rhs.Previous &&
                       lhs.Current == rhs.Current;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Start != <paramref name="rhs"/>.Start || <paramref name="lhs"/>.Previous != <paramref name="rhs"/>.Previous || <paramref name="lhs"/>.Current != <paramref name="rhs"/>.Current</c>.</returns>
            public static bool operator !=(Positions lhs, Positions rhs)
            {
                return lhs.Start != rhs.Start &&
                       lhs.Previous != rhs.Previous &&
                       lhs.Current != rhs.Current;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="Positions"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is Positions positions)
                {
                    return this == positions;
                }
                return false;
            }

            /// <summary>The hashcode for this <see cref="Positions"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + Start.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Previous.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Current.GetHashCode();
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="Positions"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(Positions other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a move event.
        /// </summary>
        /// <remarks>Corresponds to a <b>pointer move</b> event.</remarks>
        /// <seealso cref="Gesture"/>
        /// <seealso cref="Interactable"/>
        public struct OnMove : IGestureEvent, System.IEquatable<OnMove>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// The intersection point of the <see cref="Interaction"/> and the <see cref="Receiver"/>'s gesture plane in world space.
            /// </summary>
            public Vector3 PointerWorldPosition;

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnMove lhs, OnMove rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.PointerWorldPosition == rhs.PointerWorldPosition &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnMove lhs, OnMove rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.PointerWorldPosition != rhs.PointerWorldPosition ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnMove"/></summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                InternalVar_1 = (InternalVar_1 * 7) + PointerWorldPosition.GetHashCode();
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnMove"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnMove evt)
                {
                    return this == evt;
                }

                return false;
            }


            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnMove"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnMove other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a hover event.
        /// </summary>
        /// <remarks>Corresponds to a <b>pointer enter</b> event.</remarks>
        /// <seealso cref="Gesture"/>
        /// <seealso cref="Interactable"/>
        public struct OnHover : IGestureEvent, System.IEquatable<OnHover>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// The intersection point of the <see cref="Interaction"/> and the <see cref="Receiver"/>'s gesture plane in world space.
            /// </summary>
            public Vector3 PointerWorldPosition;

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnHover lhs, OnHover rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.PointerWorldPosition == rhs.PointerWorldPosition &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnHover lhs, OnHover rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.PointerWorldPosition != rhs.PointerWorldPosition ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnHover"/></summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnHover"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnHover evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnHover"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnHover other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of an unhover event.
        /// </summary>
        /// <remarks>Corresponds to a <b>pointer exit</b> event.</remarks>
        /// <seealso cref="Gesture"/>
        /// <seealso cref="Interactable"/>
        public struct OnUnhover : IGestureEvent, System.IEquatable<OnUnhover>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnUnhover lhs, OnUnhover rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnUnhover lhs, OnUnhover rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnUnhover"/></summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnUnhover"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnUnhover evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnUnhover"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnUnhover other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a press event.
        /// </summary>
        /// <remarks>Corresponds to a <b>pointer down</b> event.</remarks>
        /// <seealso cref="Gesture"/>
        /// <seealso cref="Interactable"/>
        public struct OnPress : IGestureEvent, System.IEquatable<OnPress>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// The intersection point of the <see cref="Interaction"/> and the <see cref="Receiver"/>'s gesture plane in world space.
            /// </summary>
            public Vector3 PointerWorldPosition;

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnPress lhs, OnPress rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.PointerWorldPosition == rhs.PointerWorldPosition &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnPress lhs, OnPress rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.PointerWorldPosition != rhs.PointerWorldPosition ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnPress"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnPress"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnPress evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnPress"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnPress other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a release event.
        /// </summary>
        /// <remarks>Corresponds to a <b>pointer up</b> event.</remarks>
        /// <seealso cref="Gesture"/>
        /// <seealso cref="Interactable"/>
        public struct OnRelease : IGestureEvent, System.IEquatable<OnRelease>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// A flag indicating whether or not the <see cref="Interaction"/> is still currently intersecting with the <see cref="Receiver"/>.
            /// </summary>
            public bool Hovering;

            /// <summary>
            /// A flag indicating whether or not a drag gesture was initiated between this <see cref="OnRelease"/> event and its corresponding <see cref="OnPress"/> event.
            /// </summary>
            public bool WasDragged;

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnRelease lhs, OnRelease rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.Hovering == rhs.Hovering &&
                       lhs.WasDragged == rhs.WasDragged &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnRelease lhs, OnRelease rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.Hovering != rhs.Hovering ||
                       lhs.WasDragged != rhs.WasDragged ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnRelease"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                InternalVar_1 = (InternalVar_1 * 7) + Hovering.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + WasDragged.GetHashCode();

                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnRelease"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnRelease evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnRelease"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnRelease other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a click event.
        /// </summary>
        /// <remarks>A click event will always fire <i>after</i> the <see cref="OnPress"/> or <see cref="OnRelease"/> event responsible for triggering the click.</remarks>
        /// <seealso cref="Gesture"/>
        /// <seealso cref="Interactable"/>
        /// <seealso cref="ClickBehavior"/>
        public struct OnClick : IGestureEvent, System.IEquatable<OnClick>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnClick lhs, OnClick rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnClick lhs, OnClick rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnClick"/></summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnClick"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnClick evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnClick"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnClick other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a scroll event.
        /// </summary>
        /// <seealso cref="Gesture"/>
        /// <seealso cref="Scroller"/>
        public struct OnScroll : IGestureEvent, System.IEquatable<OnScroll>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// The mechanism responsible for scrolling the content, <see cref="ScrollType.Manual"/> or <see cref="ScrollType.Inertial"/>.
            /// </summary>
            public ScrollType ScrollType;

            /// <summary>
            /// The amount the scrollable content was moved this frame in <see cref="Receiver"/> local space.
            /// </summary>
            public Vector3 ScrollDeltaLocalSpace;

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnScroll lhs, OnScroll rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ScrollType == rhs.ScrollType &&
                       lhs.ScrollDeltaLocalSpace == rhs.ScrollDeltaLocalSpace &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnScroll lhs, OnScroll rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ScrollType != rhs.ScrollType ||
                       lhs.ScrollDeltaLocalSpace != rhs.ScrollDeltaLocalSpace ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnScroll"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                InternalVar_1 = (InternalVar_1 * 7) + ((int)ScrollType).GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + ScrollDeltaLocalSpace.GetHashCode();
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnScroll"/> to compare</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnScroll evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnScroll"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnScroll other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a drag event.
        /// </summary>
        /// <remarks>
        /// <see cref="OnDrag"/> events will begin to fire when a drag distance threshold is surpassed while a pointer is pressed, <see cref="OnPress"/>.<br/>
        /// Once the drag interaction is initiated, a new <see cref="OnDrag"/> event will fire each time the <see cref="Interaction"/><br/>
        /// intersects a different position on the <see cref="Receiver"/>'s gesture plane. This process will continue to until either<br/>
        /// the interaction is canceled, <see cref="OnCancel"/>, or the pointer is released, <see cref="OnRelease"/>.
        /// </remarks>
        public struct OnDrag : IGestureEvent, System.IEquatable<OnDrag>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// The start, previous, and current positions of the pointer, in the world space position in which they actually occured, of this drag event. 
            /// </summary>
            /// <remarks>
            /// This will exactly match <see cref="PointerPositions"/> unless the entire UI is moving, rotating, or
            /// scaling while this drag gesture is occuring or if <c><see cref="Interactable.GestureSpace"/> == <see cref="GestureSpace.World"/></c>. 
            /// </remarks>
            public Positions RawPointerPositions;

            /// <summary>
            /// The start, previous, and current pointer positions, in world space, of this drag event. 
            /// </summary>
            /// <remarks>
            /// Positions are stored in <see cref="GestureSpace"/> between frames, so these values
            /// are the cached gesture space positions transformed into world space, which is why they
            /// can differ from <see cref="RawPointerPositions"/>.
            /// </remarks>
            /// <seealso cref="Interactable.GestureSpace"/>
            public Positions PointerPositions;

            /// <summary>
            /// The configured draggable axes of the <see cref="Receiver"/>.
            /// </summary>
            /// <seealso cref="Interactable.Draggable"/>
            public ThreeD<bool> DraggableAxes;

            /// <summary>
            /// The total translation from <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Start">Start</see></c> to <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Current">Current</see></c> in <see cref="Receiver"/> local space.
            /// </summary>
            /// <remarks>This value is not constrained to the <see cref="Receiver"/>'s local space draggable axes, <see cref="DraggableAxes"/>.</remarks>
            /// <seealso cref="Positions.GetTranslationInLocalSpace(Transform, Vector3, Vector3)"/>
            public readonly Vector3 RawTranslationLocalSpace => Positions.GetTranslationInLocalSpace(Receiver.transform, PointerPositions.Start, PointerPositions.Current);

            /// <summary>
            /// The delta between <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Previous">Previous</see></c> and <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Current">Current</see></c> in <see cref="Receiver"/> local space.
            /// </summary>
            /// <remarks>This value is not constrained to the <see cref="Receiver"/>'s local space draggable axes, <see cref="DraggableAxes"/>.</remarks>
            /// <seealso cref="Positions.GetTranslationInLocalSpace(Transform, Vector3, Vector3)"/>
            public readonly Vector3 RawDeltaLocalSpace => Positions.GetTranslationInLocalSpace(Receiver.transform, PointerPositions.Previous, PointerPositions.Current);

            /// <summary>
            /// The delta between <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Previous">Previous</see></c> and <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Current">Current</see></c> values in world space.
            /// </summary>
            /// <remarks>Constrained to the <see cref="Receiver"/>'s local space draggable axes, <see cref="DraggableAxes"/>.</remarks>
            /// <seealso cref="Positions.GetMaskedTranslationWorldSpace(Transform, Vector3, Vector3, ThreeD{bool})"/>
            public readonly Vector3 DragDeltaWorldSpace => Positions.GetMaskedTranslationWorldSpace(Receiver.transform, PointerPositions.Previous, PointerPositions.Current, DraggableAxes);

            /// <summary>
            /// The delta between <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Previous">Previous</see></c> and <c><see cref="PointerPositions">PointerPositions</see>.<see cref="Positions.Current">Current</see></c> values in local space.
            /// </summary>
            /// <remarks>Constrained to the <see cref="Receiver"/>'s local space draggable axes, <see cref="DraggableAxes"/>.</remarks>
            public readonly Vector3 DragDeltaLocalSpace => Vector3.Scale(RawDeltaLocalSpace, new Vector3(DraggableAxes.X ? 1 : 0, DraggableAxes.Y ? 1 : 0, DraggableAxes.Z ? 1 : 0));

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnDrag lhs, OnDrag rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.RawPointerPositions == rhs.RawPointerPositions &&
                       lhs.PointerPositions == rhs.PointerPositions &&
                       lhs.DraggableAxes.Equals(rhs.DraggableAxes) &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnDrag lhs, OnDrag rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.RawPointerPositions != rhs.RawPointerPositions ||
                       lhs.PointerPositions != rhs.PointerPositions ||
                       !lhs.DraggableAxes.Equals(rhs.DraggableAxes) ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnDrag"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                InternalVar_1 = (InternalVar_1 * 7) + RawPointerPositions.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + PointerPositions.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + DraggableAxes.GetHashCode();
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnDrag"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnDrag evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnDrag"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnDrag other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a interaction canceled event.
        /// </summary>
        /// <remarks>
        /// Interactions may be canceled manually by the user, <see cref="Interaction.Cancel(uint)"/>, or automatically either when a<br/>
        /// conflicting interaction is started or the current interaction <see cref="IEvent.Receiver"/> is disabled.
        /// </remarks>
        public struct OnCancel : IGestureEvent, System.IEquatable<OnCancel>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnCancel lhs, OnCancel rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnCancel lhs, OnCancel rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnCancel"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnCancel"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnCancel evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnCancel"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnCancel other)
            {
                return this == other;
            }
        }
    }

    /// <summary>
    /// A static class providing all available UIBlock navigation event types.
    /// </summary>
    /// <seealso cref="OnDirection"/>
    /// <seealso cref="OnMoveTo"/>
    /// <seealso cref="OnMoveFrom"/>
    /// <seealso cref="OnSelect"/>
    /// <seealso cref="OnDeselect"/>
    /// <seealso cref="IGestureEvent"/>
    /// <seealso cref="Interactable"/>
    /// <seealso cref="Scroller"/>
    public static class Navigate
    {
        internal static OnMoveTo InternalMethod_507(Interaction.Update InternalParameter_2084, UIBlock InternalParameter_2083, UIBlock InternalParameter_2082, Vector3 InternalParameter_2081) => new OnMoveTo() { Interaction = InternalParameter_2084, Target = InternalParameter_2083, Receiver = InternalParameter_2083, FromUIBlock = InternalParameter_2082, Direction = InternalParameter_2081 };
        internal static OnMoveFrom InternalMethod_1883(Interaction.Update InternalParameter_321, UIBlock InternalParameter_320, UIBlock InternalParameter_1215, Vector3 InternalParameter_1214) => new OnMoveFrom() { Interaction = InternalParameter_321, Target = InternalParameter_320, Receiver = InternalParameter_320, ToUIBlock = InternalParameter_1215, Direction = InternalParameter_1214 };
        internal static OnDirection InternalMethod_461(Interaction.Update InternalParameter_2378, UIBlock InternalParameter_2381, Vector3 InternalParameter_3023) => new OnDirection() { Interaction = InternalParameter_2378, Target = InternalParameter_2381, Receiver = InternalParameter_2381, Direction = InternalParameter_3023 };
        internal static OnSelect InternalMethod_460(Interaction.Update InternalParameter_3018, UIBlock InternalParameter_3017) => new OnSelect() { Interaction = InternalParameter_3018, Target = InternalParameter_3017, Receiver = InternalParameter_3017 };
        internal static OnDeselect InternalMethod_2058(Interaction.Update InternalParameter_3016, UIBlock InternalParameter_3019) => new OnDeselect() { Interaction = InternalParameter_3016, Target = InternalParameter_3019, Receiver = InternalParameter_3019 };

        /// <summary>
        /// Details of a navigation select event.
        /// </summary>
        /// <remarks>
        /// Not fired when <see cref="Receiver"/>'s <see cref="GestureRecognizer.OnSelect"/> is set
        /// to <see cref="SelectBehavior.Click"/>. In that case, <see cref="Gesture.OnClick"/> events 
        /// are fired instead.
        /// </remarks>
        /// <seealso cref="Navigate"/>
        /// <seealso cref="Interactable"/>
        /// <seealso cref="Scroller"/>
        /// <seealso cref="SelectBehavior"/>
        public struct OnSelect : IGestureEvent, System.IEquatable<OnSelect>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Created by a <see cref="Navigation"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnSelect lhs, OnSelect rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnSelect lhs, OnSelect rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnSelect"/></summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnSelect"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnSelect evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnSelect"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnSelect other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a navigation deselect event.
        /// </summary>
        /// <seealso cref="Navigate"/>
        /// <seealso cref="Interactable"/>
        /// <seealso cref="Scroller"/>
        /// <seealso cref="SelectBehavior"/>
        public struct OnDeselect : IGestureEvent, System.IEquatable<OnDeselect>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Created by a <see cref="Navigation"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnDeselect lhs, OnDeselect rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnDeselect lhs, OnDeselect rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID;
            }

            /// <summary>The hashcode for this <see cref="OnDeselect"/></summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnDeselect"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnDeselect evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnDeselect"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnDeselect other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a navigation event for when focus moves from <see cref="FromUIBlock"/> to <see cref="Receiver"/>.
        /// </summary>
        public struct OnMoveTo : IGestureEvent, System.IEquatable<OnMoveTo>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Created by a <see cref="Navigation"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// The direction in the <see cref="Receiver"/>'s local space
            /// </summary>
            public Vector3 Direction;

            /// <summary>
            /// The <see cref="UIBlock"/> navigation focus was moved from.
            /// </summary>
            /// <remarks>May be <c>null</c> if nothing previously had focus.</remarks>
            public UIBlock FromUIBlock;

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnMoveTo lhs, OnMoveTo rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID &&
                       lhs.Direction == rhs.Direction &&
                       lhs.FromUIBlock == rhs.FromUIBlock;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnMoveTo lhs, OnMoveTo rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID ||
                       lhs.Direction != rhs.Direction ||
                       lhs.FromUIBlock != rhs.FromUIBlock;
            }

            /// <summary>The hashcode for this <see cref="OnMoveTo"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                InternalVar_1 = (InternalVar_1 * 7) + Direction.GetHashCode();

                if (FromUIBlock != null)
                {
                    InternalVar_1 = (InternalVar_1 * 7) + FromUIBlock.GetHashCode();
                }

                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnMoveFrom"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                return other is OnMoveTo evt && this == evt;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnMoveFrom"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnMoveTo other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a navigation event for when focus moves from <see cref="Receiver"/> to <see cref="ToUIBlock"/>.
        /// </summary>
        public struct OnMoveFrom : IGestureEvent, System.IEquatable<OnMoveFrom>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Created by a <see cref="Navigation"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// The direction in the <see cref="Receiver"/>'s local space
            /// </summary>
            public Vector3 Direction;

            /// <summary>
            /// The <see cref="UIBlock"/> navigation focus was moved to.
            /// </summary>
            /// <remarks>May be <c>null</c> if focus moved off the <see cref="Receiver"/> but nothing received focus.</remarks>
            public UIBlock ToUIBlock;

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnMoveFrom lhs, OnMoveFrom rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID &&
                       lhs.Direction == rhs.Direction &&
                       lhs.ToUIBlock == rhs.ToUIBlock;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnMoveFrom lhs, OnMoveFrom rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID ||
                       lhs.Direction != rhs.Direction ||
                       lhs.ToUIBlock != rhs.ToUIBlock;
            }

            /// <summary>The hashcode for this <see cref="OnMoveFrom"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                InternalVar_1 = (InternalVar_1 * 7) + Direction.GetHashCode();

                if (ToUIBlock != null)
                {
                    InternalVar_1 = (InternalVar_1 * 7) + ToUIBlock.GetHashCode();
                }

                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnMoveFrom"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                return other is OnMoveFrom evt && this == evt;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnMoveFrom"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnMoveFrom other)
            {
                return this == other;
            }
        }

        /// <summary>
        /// Details of a navigation event for when focus is unchanged but received navigation input in <see cref="Direction"/>.
        /// </summary>
        public struct OnDirection : IGestureEvent, System.IEquatable<OnDirection>
        {
            /// <summary>
            /// The interaction update responsible for triggering the event. Created by a <see cref="Navigation"/> method.
            /// </summary>
            public Interaction.Update Interaction { get; set; }

            /// <summary>
            /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
            /// </summary>
            public UIBlock Target { get; set; }

            /// <summary>
            /// The <see cref="UIBlock"/> from which the event was invoked.
            /// </summary>
            public UIBlock Receiver { get; set; }

            /// <summary>
            /// The direction in the <see cref="Receiver"/>'s local space
            /// </summary>
            public Vector3 Direction;

            /// <summary>
            /// A unique identifier associated with the event.
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator ==(OnDirection lhs, OnDirection rhs)
            {
                return lhs.Interaction == rhs.Interaction &&
                       lhs.Target == rhs.Target &&
                       lhs.Receiver == rhs.Receiver &&
                       lhs.ID == rhs.ID &&
                       lhs.Direction == rhs.Direction;
            }

            /// <summary>
            /// Inequality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
            public static bool operator !=(OnDirection lhs, OnDirection rhs)
            {
                return lhs.Interaction != rhs.Interaction ||
                       lhs.Target != rhs.Target ||
                       lhs.Receiver != rhs.Receiver ||
                       lhs.ID != rhs.ID ||
                       lhs.Direction != rhs.Direction;
            }

            /// <summary>The hashcode for this <see cref="OnDirection"/>.</summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + InternalType_27.InternalMethod_193(this);
                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnDirection"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public override bool Equals(object other)
            {
                if (other is OnDirection evt)
                {
                    return this == evt;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The <see cref="OnDirection"/> to compare.</param>
            /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c>.</returns>
            public bool Equals(OnDirection other)
            {
                return this == other;
            }
        }

    }

    /// <summary>
    /// A common interface implemented by all UIBlock gesture event structs.
    /// </summary>
    /// <seealso cref="Interaction.Point(Interaction.Update, bool, bool, float, int, InputAccuracy)"/>
    /// <seealso cref="Interaction.Point(Sphere, uint, object, int, InputAccuracy)"/>
    /// <seealso cref="Interaction.Scroll(Interaction.Update, Vector3, float, int, InputAccuracy))"/>
    /// <seealso cref="Interaction.Cancel(Interaction.Update)"/>
    /// <seealso cref="Interaction.Cancel(uint)"/>
    /// <seealso cref="Gesture.OnClick"/>
    /// <seealso cref="Gesture.OnDrag"/>
    /// <seealso cref="Gesture.OnPress"/>
    /// <seealso cref="Gesture.OnRelease"/>
    /// <seealso cref="Gesture.OnHover"/>
    /// <seealso cref="Gesture.OnUnhover"/>
    /// <seealso cref="Gesture.OnMove"/>
    /// <seealso cref="Gesture.OnCancel"/>
    /// <seealso cref="Navigation.Focus(UIBlock, uint, object, int)"/>
    /// <seealso cref="Navigation.Move(Vector3, uint, object, int)"/>
    /// <seealso cref="Navigation.Select(uint, object, int)"/>
    /// <seealso cref="Navigation.Deselect(uint, object, int)"/>
    /// <seealso cref="Navigate.OnDirection"/>
    /// <seealso cref="Navigate.OnMoveTo"/>
    /// <seealso cref="Navigate.OnMoveFrom"/>
    /// <seealso cref="Navigate.OnSelect"/>
    /// <seealso cref="Navigate.OnDeselect"/>
    public interface IGestureEvent : IEvent
    {
        /// <summary>
        /// The interaction update responsible for triggering the event. Either passed into or created by an <see cref="Nova.Interaction"/> method.
        /// </summary>
        Interaction.Update Interaction { get; set; }
    }

    /// <summary>
    /// A common interface implemented by all UIBlock event structs.
    /// </summary>
    /// <seealso cref="Gesture.OnClick"/>
    /// <seealso cref="Gesture.OnPress"/>
    /// <seealso cref="Gesture.OnRelease"/>
    /// <seealso cref="Gesture.OnHover"/>
    /// <seealso cref="Gesture.OnUnhover"/>
    /// <seealso cref="Gesture.OnScroll"/>
    /// <seealso cref="Gesture.OnMove"/>
    /// <seealso cref="Gesture.OnDrag"/>
    /// <seealso cref="Gesture.OnCancel"/>
    /// <seealso cref="Navigate.OnDirection"/>
    /// <seealso cref="Navigate.OnMoveTo"/>
    /// <seealso cref="Navigate.OnMoveFrom"/>
    /// <seealso cref="Navigate.OnSelect"/>
    /// <seealso cref="Navigate.OnDeselect"/>
    /// <seealso cref="Data.OnBind{TData}"/>
    /// <seealso cref="Data.OnUnbind{TData}"/>
    public interface IEvent
    {
        /// <summary>
        /// An ancestor of the <see cref="Receiver"/> (or the  <see cref="Receiver"/> itself) holding information pertinent to the event handler.
        /// </summary>
        UIBlock Target { get; set; }

        /// <summary>
        /// The <see cref="UIBlock"/> from which the event was invoked.
        /// </summary>
        UIBlock Receiver { get; set; }

        /// <summary>
        /// A unique identifier associated with the event.
        /// </summary>
        /// <remarks>Assigned whenever an event is fired.</remarks>
        int ID { get; set; }
    }

    public static class IEventExtensions
    {
        /// <summary>
        /// Stops the event from propagating further up the <see cref="UIBlock"/> hierarchy.
        /// </summary>
        /// <remarks>
        /// Any remaining event handlers registered at the <b>current</b> propagation level which have yet to be called with the given <paramref name="evt"/> data, will <i>still</i> be called after an event has been consumed.
        /// </remarks>
        /// <typeparam name="T">The type of event being consumed.</typeparam>
        /// <param name="evt">The event instance being consumed, identified by its event <see cref="IEvent.ID">ID</see>.</param>
        public static void Consume<T>(this T evt) where T : struct, IEvent
        {
            InternalNamespace_16.InternalType_522.InternalMethod_2086(ref evt);
        }
    }

    #region Internal
    internal static class InternalType_17
    {
        public static int InternalMethod_2009<T>(this T InternalParameter_2149) where T : struct, IEvent
        {
            int InternalVar_1 = 13;

            InternalVar_1 = (InternalVar_1 * 7) + InternalParameter_2149.ID.GetHashCode();

            if (InternalParameter_2149.Target != null)
            {
                InternalVar_1 = (InternalVar_1 * 7) + InternalParameter_2149.Target.GetHashCode();
            }

            if (InternalParameter_2149.Receiver != null)
            {
                InternalVar_1 = (InternalVar_1 * 7) + InternalParameter_2149.Receiver.GetHashCode();
            }

            return InternalVar_1;
        }
    }

    internal static class InternalType_27
    {
        public static int InternalMethod_193<T>(this T InternalParameter_140) where T : struct, IGestureEvent
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + InternalType_17.InternalMethod_2009(InternalParameter_140);
            InternalVar_1 = (InternalVar_1 * 7) + InternalParameter_140.Interaction.GetHashCode();

            return InternalVar_1;
        }
    }
    #endregion
}
