using Nova;
using UnityEngine;
using UnityEngine.Events;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// A UI control which reacts to user input and flips an underlying bool to track a <see cref="ToggledOn"/> state as it is clicked.
    /// </summary>
    public class Toggle : UIControl<ToggleVisuals>
    {
        [Tooltip("Event invoked when the toggle state changes. Provides the ToggledOn state.")]
        public UnityEvent<bool> OnToggled = null;

        [Tooltip("The toggle state of this toggle control")]
        [SerializeField]
        private bool toggledOn = false;

        /// <summary>
        /// The state of this toggle control
        /// </summary>
        public bool ToggledOn
        {
            get => toggledOn;
            set
            {
                if (value == toggledOn)
                {
                    return;
                }

                toggledOn = value;

                UpdateToggleIndicator();

                OnToggled?.Invoke(toggledOn);
            }
        }

        private void OnEnable()
        {
            if (View.TryGetVisuals(out ToggleVisuals visuals))
            {
                // Set default state
                visuals.UpdateVisualState(VisualState.Default);
            }

            // Subscribe to desired events
            View.UIBlock.AddGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleClicked);
            View.UIBlock.AddGestureHandler<Gesture.OnHover, ToggleVisuals>(ToggleVisuals.HandleHovered);
            View.UIBlock.AddGestureHandler<Gesture.OnUnhover, ToggleVisuals>(ToggleVisuals.HandleUnhovered);
            View.UIBlock.AddGestureHandler<Gesture.OnPress, ToggleVisuals>(ToggleVisuals.HandlePressed);
            View.UIBlock.AddGestureHandler<Gesture.OnRelease, ToggleVisuals>(ToggleVisuals.HandleReleased);
            View.UIBlock.AddGestureHandler<Gesture.OnCancel, ToggleVisuals>(ToggleVisuals.HandlePressCanceled);

            UpdateToggleIndicator();
        }

        private void OnDisable()
        {
            // Unsubscribe from events
            View.UIBlock.RemoveGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleClicked);
            View.UIBlock.RemoveGestureHandler<Gesture.OnHover, ToggleVisuals>(ToggleVisuals.HandleHovered);
            View.UIBlock.RemoveGestureHandler<Gesture.OnUnhover, ToggleVisuals>(ToggleVisuals.HandleUnhovered);
            View.UIBlock.RemoveGestureHandler<Gesture.OnPress, ToggleVisuals>(ToggleVisuals.HandlePressed);
            View.UIBlock.RemoveGestureHandler<Gesture.OnRelease, ToggleVisuals>(ToggleVisuals.HandleReleased);
            View.UIBlock.RemoveGestureHandler<Gesture.OnCancel, ToggleVisuals>(ToggleVisuals.HandlePressCanceled);
        }

        /// <summary>
        /// Flip the toggle state on click.
        /// </summary>
        /// <param name="evt">The click event data.</param>
        /// <param name="visuals">The toggle visuals associated with the click event.</param>
        private void HandleClicked(Gesture.OnClick evt, ToggleVisuals visuals) => ToggledOn = !ToggledOn;

        /// <summary>
        /// Update the visual toggle indicate to match the underlying <see cref="ToggledOn"/> state.
        /// </summary>
        private void UpdateToggleIndicator()
        {
            if (!(View.Visuals is ToggleVisuals visuals) || visuals.IsOnIndicator == null)
            {
                return;
            }

            visuals.IsOnIndicator.gameObject.SetActive(toggledOn);
        }
    }
}
