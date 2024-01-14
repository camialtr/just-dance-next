using Nova;
using UnityEngine;
using UnityEngine.Events;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// A UI control which reacts to user input and displays a list of selectable options.
    /// </summary>
    public class Dropdown : UIControl<DropdownVisuals>
    {
        [Tooltip("The event fired when a new item is selected from the dropdown list.")]
        public UnityEvent<string> OnValueChanged = null;

        [SerializeField]
        [Tooltip("The data used to populate the list of selectable items in the dropdown.")]
        private DropdownData DropdownOptions = new DropdownData();

        /// <summary>
        /// The visuals associated with this dropdown control
        /// </summary>
        private DropdownVisuals Visuals => View.Visuals as DropdownVisuals;

        public void Expand()
        {
            // Tell the dropdown to expand, showing a list of
            // selectable options.
            Visuals.Expand(DropdownOptions);
        }

        public void Collapse()
        {
            // Collapse the dropdown and stop tracking it
            // as the expanded focused object.
            Visuals.Collapse();
        }

        private void OnEnable()
        {
            if (View.TryGetVisuals(out DropdownVisuals visuals))
            {
                // Set default state
                visuals.UpdateVisualState(VisualState.Default);
            }

            // Subscribe to desired events
            View.UIBlock.AddGestureHandler<Gesture.OnHover, DropdownVisuals>(DropdownVisuals.HandleHovered);
            View.UIBlock.AddGestureHandler<Gesture.OnUnhover, DropdownVisuals>(DropdownVisuals.HandleUnhovered);
            View.UIBlock.AddGestureHandler<Gesture.OnPress, DropdownVisuals>(DropdownVisuals.HandlePressed);
            View.UIBlock.AddGestureHandler<Gesture.OnRelease, DropdownVisuals>(DropdownVisuals.HandleReleased);
            View.UIBlock.AddGestureHandler<Gesture.OnCancel, DropdownVisuals>(DropdownVisuals.HandlePressCanceled);
            View.UIBlock.AddGestureHandler<Gesture.OnClick, DropdownVisuals>(HandleDropdownClicked);

            Visuals.OnValueChanged += HandleValueChanged;
            InputManager.OnPostClick += HandlePostClick;

            // Ensure label is initialized
            Visuals.InitSelectionLabel(DropdownOptions.CurrentSelection);
        }

        private void OnDisable()
        {
            // Unsubscribe from events
            View.UIBlock.RemoveGestureHandler<Gesture.OnHover, DropdownVisuals>(DropdownVisuals.HandleHovered);
            View.UIBlock.RemoveGestureHandler<Gesture.OnUnhover, DropdownVisuals>(DropdownVisuals.HandleUnhovered);
            View.UIBlock.RemoveGestureHandler<Gesture.OnPress, DropdownVisuals>(DropdownVisuals.HandlePressed);
            View.UIBlock.RemoveGestureHandler<Gesture.OnRelease, DropdownVisuals>(DropdownVisuals.HandleReleased);
            View.UIBlock.RemoveGestureHandler<Gesture.OnCancel, DropdownVisuals>(DropdownVisuals.HandlePressCanceled);
            View.UIBlock.RemoveGestureHandler<Gesture.OnClick, DropdownVisuals>(HandleDropdownClicked);

            Visuals.OnValueChanged -= HandleValueChanged;
            InputManager.OnPostClick -= HandlePostClick;
        }

        /// <summary>
        /// Fire the Unity event when the selected value changes.
        /// </summary>
        /// <param name="value">The string in the list of selectable options.</param>
        private void HandleValueChanged(string value)
        {
            OnValueChanged?.Invoke(value);
        }

        /// <summary>
        /// Handle a <see cref="DropdownVisuals"/> object in the <see cref="ListView">
        /// being clicked, and either expand or collapse it accordingly.
        /// </summary>
        /// <param name="evt">The click event data.</param>
        /// <param name="dropdownControl">The <see cref="ItemVisuals"/> object which was clicked.</param>
        private void HandleDropdownClicked(Gesture.OnClick evt, DropdownVisuals dropdownControl)
        {
            if (evt.Receiver.transform.IsChildOf(dropdownControl.OptionsView.transform))
            {
                // The clicked object was not the dropdown itself but rather a list item within the dropdown.
                // The dropdownControl itself will handle this event, so we don't need to do anything here.
                return;
            }

            // Toggle the expanded state of the dropdown on click

            if (dropdownControl.IsExpanded)
            {
                Collapse();
            }
            else
            {
                Expand();
            }
        }

        /// <summary>
        /// Handles unfocusing the <see cref="Dropdown"/> if the user clicks somewhere else.
        /// </summary>
        private void HandlePostClick(UIBlock clickedUIBlock)
        {
            if (!Visuals.IsExpanded)
            {
                return;
            }

            if (clickedUIBlock == null || !clickedUIBlock.transform.IsChildOf(transform))
            {
                // Clicked somewhere else, so remove focus.
                Collapse();
            }
        }
    }
}

