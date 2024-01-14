using Nova;
using UnityEngine;
using UnityEngine.Events;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// A UI control which reacts to user input and fires click events
    /// </summary>
    public class Button : UIControl<ButtonVisuals>
    {
        [Tooltip("Event fired when the button is clicked.")]
        public UnityEvent OnClicked = null;

        private void OnEnable()
        {
            if (View.TryGetVisuals(out ButtonVisuals visuals))
            {
                // Set default state
                visuals.UpdateVisualState(VisualState.Default);
            }

            // Subscribe to desired events
            View.UIBlock.AddGestureHandler<Gesture.OnClick, ButtonVisuals>(HandleClicked);
            View.UIBlock.AddGestureHandler<Gesture.OnHover, ButtonVisuals>(ButtonVisuals.HandleHovered);
            View.UIBlock.AddGestureHandler<Gesture.OnUnhover, ButtonVisuals>(ButtonVisuals.HandleUnhovered);
            View.UIBlock.AddGestureHandler<Gesture.OnPress, ButtonVisuals>(ButtonVisuals.HandlePressed);
            View.UIBlock.AddGestureHandler<Gesture.OnRelease, ButtonVisuals>(ButtonVisuals.HandleReleased);
            View.UIBlock.AddGestureHandler<Gesture.OnCancel, ButtonVisuals>(ButtonVisuals.HandlePressCanceled);
        }

        private void OnDisable()
        {
            // Unsubscribe from events
            View.UIBlock.RemoveGestureHandler<Gesture.OnClick, ButtonVisuals>(HandleClicked);
            View.UIBlock.RemoveGestureHandler<Gesture.OnHover, ButtonVisuals>(ButtonVisuals.HandleHovered);
            View.UIBlock.RemoveGestureHandler<Gesture.OnUnhover, ButtonVisuals>(ButtonVisuals.HandleUnhovered);
            View.UIBlock.RemoveGestureHandler<Gesture.OnPress, ButtonVisuals>(ButtonVisuals.HandlePressed);
            View.UIBlock.RemoveGestureHandler<Gesture.OnRelease, ButtonVisuals>(ButtonVisuals.HandleReleased);
            View.UIBlock.RemoveGestureHandler<Gesture.OnCancel, ButtonVisuals>(ButtonVisuals.HandlePressCanceled);
        }

        /// <summary>
        /// Fire the Unity event on Click.
        /// </summary>
        /// <param name="evt">The click event data.</param>
        /// <param name="visuals">The buttons visuals which received the click.</param>
        private void HandleClicked(Gesture.OnClick evt, ButtonVisuals visuals) => OnClicked?.Invoke();
    }
}
