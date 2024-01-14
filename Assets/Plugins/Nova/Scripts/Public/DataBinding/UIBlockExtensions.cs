// Copyright (c) Supernova Technologies LLC
using System;
using Nova;

namespace Nova
{
    public static class UIBlockExtensions
    {
        /// <summary>
        /// Subscribe to a gesture event on this <see cref="UIBlock"/>'s descendant hierarchy (inclusive of this <see cref="UIBlock"/>), filtered to the given <see cref="ItemVisuals"/> type, <typeparamref name="TVisuals"/>.
        /// </summary>
        /// <remarks>
        /// The subscription only "lives" on this UIBlock, but the event will propagate up from descendents triggering gesture events with an <paramref name="gestureHandler"/> type-matched signature.
        /// </remarks>
        /// <typeparam name="TGesture">The type of gesture event to handle.</typeparam>
        /// <typeparam name="TVisuals">The <see cref="ItemVisuals"/> type to target as the event propagates. If no object of this type is in the event propogation path, the <paramref name="gestureHandler"/> won't be invoked.</typeparam>
        /// <param name="gestureHandler">The callback invoked when the event fires.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="uiBlock"/> or <paramref name="gestureHandler"/> is <c>null</c>.</exception>
        /// <seealso cref="Gesture.OnClick"/>
        /// <seealso cref="Gesture.OnPress"/>
        /// <seealso cref="Gesture.OnRelease"/>
        /// <seealso cref="Gesture.OnHover"/>
        /// <seealso cref="Gesture.OnUnhover"/>
        /// <seealso cref="Gesture.OnScroll"/>
        /// <seealso cref="Gesture.OnMove"/>
        /// <seealso cref="Gesture.OnDrag"/>
        /// <seealso cref="Gesture.OnCancel"/>
        /// <seealso cref="UIBlock.FireGestureEvent{TGesture}(TGesture)"/>
        public static void AddGestureHandler<TGesture, TVisuals>(this UIBlock uiBlock, UIEventHandler<TGesture, TVisuals> gestureHandler) where TGesture : struct, IGestureEvent where TVisuals : ItemVisuals
        {
            if (uiBlock == null)
            {
                throw new ArgumentNullException(nameof(uiBlock));
            }

            if (gestureHandler == null)
            {
                throw new ArgumentNullException(nameof(gestureHandler));
            }

            uiBlock.InternalMethod_3270(gestureHandler);
        }

        /// <summary>
        /// Unsubscribe from a gesture event previously subscribed to via <see cref="AddGestureHandler{TInteractionEvent, TVisuals}(UIBlock, UIEventHandler{TInteractionEvent, TVisuals})"/>.
        /// </summary>
        /// <typeparam name="TGesture">The type of gesture event to handle.</typeparam>
        /// <typeparam name="TVisuals">The type to target as the event propagates. If no object of this type is in the event propogation path, the <paramref name="gestureHandler"/> won't be invoked.</typeparam>
        /// <param name="gestureHandler">The callback to remove from the subscription list.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="uiBlock"/> or <paramref name="gestureHandler"/> is <c>null</c>.</exception>
        /// <seealso cref="Gesture.OnClick"/>
        /// <seealso cref="Gesture.OnPress"/>
        /// <seealso cref="Gesture.OnRelease"/>
        /// <seealso cref="Gesture.OnHover"/>
        /// <seealso cref="Gesture.OnUnhover"/>
        /// <seealso cref="Gesture.OnScroll"/>
        /// <seealso cref="Gesture.OnMove"/>
        /// <seealso cref="Gesture.OnDrag"/>
        /// <seealso cref="Gesture.OnCancel"/>
        /// <seealso cref="UIBlock.FireGestureEvent{TGesture}(TGesture)"/>
        public static void RemoveGestureHandler<TGesture, TVisuals>(this UIBlock uiBlock, UIEventHandler<TGesture, TVisuals> gestureHandler) where TGesture : struct, IGestureEvent where TVisuals : ItemVisuals
        {
            if (uiBlock == null)
            {
                throw new ArgumentNullException(nameof(uiBlock));
            }

            if (gestureHandler == null)
            {
                throw new ArgumentNullException(nameof(gestureHandler));
            }

            uiBlock.InternalMethod_3269(gestureHandler);
        }
    }
}
