using Nova;
using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// The <see cref="ItemVisuals"/> type used to display a <see cref="Dropdown"/> control and its list of selectable options.
    /// </summary>
    [Serializable]
    [MovedFrom(false, null, "Assembly-CSharp")]
    public class DropdownVisuals : UIControlVisuals
    {
        [Header("Collapsed Visuals")]
        [Tooltip("The TextBlock to display the label of currently selected option.")]
        public TextBlock SelectionLabel = null;
        [Tooltip("The background visual element to change as the dropdown is pressed and released.")]
        public UIBlock2D Background = null;
        [Tooltip("The visual to rotate as the dropdown is expanded or collapsed.")]
        public UIBlock2D DropdownArrow = null;

        [Header("Expanded Visuals")]
        [Tooltip("The visual root of the content to display when the dropdown is expanded.")]
        public UIBlock ExpandedViewRoot = null;
        [Tooltip("The ListView used to display the different options in the dropdown.")]
        public ListView OptionsView = null;
        [Tooltip("If false, the dropdown will expand upwards.")]
        public bool ExpandDown = true;

        [Header("Options View Row Colors")]
        [Tooltip("The default background color of the dropdown list items. Every even-row item will be this color.")]
        public Color DefaultRowColor;
        [Tooltip("The alternative background color of the dropdown list items. Every odd-row item will be this color.")]
        public Color AlternatingRowColor;

        protected override UIBlock TransitionTargetFallback => Background;

        /// <summary>
        /// Is the dropdown list open?
        /// </summary>
        public bool IsExpanded => ExpandedViewRoot.gameObject.activeSelf;

        [NonSerialized, HideInInspector]
        private bool eventHandlersRegistered = false;

        public event Action<string> OnValueChanged = null;

        /// <summary>
        /// The datasource used to populate this dropdown control and its list of options.
        /// </summary>
        public DropdownData DataSource { get; private set; }

        /// <summary>
        /// Expand this dropdown control and populate its expanded 
        /// <see cref="OptionsView"/> with the options in the datasource.
        /// </summary>
        /// <param name="dataSource">The datasource to populate this dropdown's list of options.</param>
        public void Expand(DropdownData dataSource)
        {
            // Ensure the dropdown expands in the desired direction
            ExpandedViewRoot.Alignment.Y = ExpandDown ? VerticalAlignment.Top : VerticalAlignment.Bottom;

            // Cache the current datasource, so we can update it in 
            // the event a new option is selected from the dropdown.
            DataSource = dataSource;

            // Verify the bind/interaction handlers
            // are registered for when we populate
            // the options view
            EnsureEventHandlersRegistered();

            // Enable the OptionsView and other visuals
            ExpandedViewRoot.gameObject.SetActive(true);

            // Set the datasource if it has changed
            if (OptionsView.GetDataSource<string>() != dataSource.Options)
            {
                OptionsView.SetDataSource(dataSource.Options);
            }

            // Update the dropdown arrow rotation
            DropdownArrow.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        /// <summary>
        /// Collapse the dropdown list of options.
        /// </summary>
        public void Collapse()
        {
            // Disable the list of selectable options
            ExpandedViewRoot.gameObject.SetActive(false);

            // Update the dropdown arrow rotation
            DropdownArrow.transform.localRotation = Quaternion.identity;
        }

        /// <summary>
        /// Register the desired databind/interaction event handlers if not already subscribed.
        /// </summary>
        private void EnsureEventHandlersRegistered()
        {
            if (eventHandlersRegistered)
            {
                return;
            }

            // Register data binder
            OptionsView.AddDataBinder<string, ToggleVisuals>(BindOption);

            // Register gesture handlers
            OptionsView.AddGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleOptionSelected);
            OptionsView.AddGestureHandler<Gesture.OnHover, ToggleVisuals>(ToggleVisuals.HandleHovered);
            OptionsView.AddGestureHandler<Gesture.OnUnhover, ToggleVisuals>(ToggleVisuals.HandleUnhovered);
            OptionsView.AddGestureHandler<Gesture.OnPress, ToggleVisuals>(ToggleVisuals.HandlePressed);
            OptionsView.AddGestureHandler<Gesture.OnRelease, ToggleVisuals>(ToggleVisuals.HandleReleased);
            OptionsView.AddGestureHandler<Gesture.OnCancel, ToggleVisuals>(ToggleVisuals.HandlePressCanceled);

            eventHandlersRegistered = true;
        }

        /// <summary>
        /// Event handler to react to a list item in the dropdown (bound to one of the options in <see cref="DropdownSetting.Options"/>) being selected.
        /// </summary>
        /// <param name="evt">The click event.</param>
        /// <param name="option">The <see cref="ItemVisuals"/> object that was selected.</param>
        /// <param name="index">The index into <see cref="DropdownData.Options"/> of the object represented by <paramref name="option"/>.</param>
        public void HandleOptionSelected(Gesture.OnClick evt, ToggleVisuals option, int index)
        {
            // If a new option was selected, update the datasource. 
            if (index != DataSource.SelectedIndex)
            {
                // Get the currently selected list item if it's in view.
                if (OptionsView.TryGetItemView(DataSource.SelectedIndex, out ItemView selectedListItem))
                {
                    // Get the list item's visuals as a ToggleVisuals.
                    ToggleVisuals selectedVisuals = selectedListItem.Visuals as ToggleVisuals;

                    // Disable the IsOnIndicator on the list item to indicate it's no longer selected.
                    selectedVisuals.IsOnIndicator.gameObject.SetActive(false);
                }

                // Set the selected index in the data source.
                DataSource.SelectedIndex = index;

                // Update this controls SelectionLabel to reflect the newly selected option.
                SelectionLabel.Text = DataSource.CurrentSelection;

                // Enable the IsOnon the list item to indicate its selected state.
                option.IsOnIndicator.gameObject.SetActive(true);

                OnValueChanged?.Invoke(DataSource.CurrentSelection);
            }

            // Collapse the expanded OptionsView
            Collapse();
        }

        /// <summary>
        /// Sets the selection label to the provided value
        /// </summary>
        public void InitSelectionLabel(string label)
        {
            SelectionLabel.Text = label;
        }

        /// <summary>
        /// Bind the <paramref name="option"/> visual to its corresponding data object.
        /// </summary>
        /// <param name="evt">The bind event data.</param>
        /// <param name="option">The <see cref="ToggleVisuals"/> object representing the data being bound into view.</param>
        /// <param name="index">The index into <see cref="DataSource"/> of the data object being bound into view.</param>
        private void BindOption(Data.OnBind<string> evt, ToggleVisuals option, int index)
        {
            // The UserData on this bind event is the same value stored
            // at the given `index` into the list of options.
            //
            // I.e.
            // evt.UserData == DataSource.Options[index]
            option.Label.Text = evt.UserData;

            // Highlight the selected row to differentiate it from the rest
            option.IsOnIndicator.gameObject.SetActive(index == DataSource.SelectedIndex);

            // For aesthetics and legibility we want to alternate the background color of rows
            // in the options view. Even numbered rows will use the default color, and odd numbered
            // rows will use the alternating color.
            Color defaultColor = index % 2 == 0 ? DefaultRowColor : AlternatingRowColor;
            option.Background.Color = defaultColor;

            option.DefaultColor = defaultColor;
            option.PressedColor = PressedColor;
            option.HoveredColor = HoveredColor;
        }

        /// <summary>
        /// A utility method to restore the visual state of <see cref="DropdownVisuals"/> 
        /// object when it's unhovered.
        /// </summary>
        /// <param name="evt">The release event.</param>
        /// <param name="visuals">The <see cref="ItemVisuals"/> receiving the release event.</param>
        public static void HandleUnhovered(Gesture.OnUnhover evt, DropdownVisuals visuals)
        {
            if (evt.Receiver.transform.IsChildOf(visuals.ExpandedViewRoot.transform))
            {
                // The hierarchy is hovered, which will happen if one of the objects in visuals.OptionsView
                // is hovered, but we don't want to highlight the background
                // element in that context.
                return;
            }

            ButtonVisuals.HandleUnhovered(evt, visuals);
        }

        /// <summary>
        /// A utility method to indicate a hovered visual state of <see cref="DropdownVisuals"/> object.
        /// </summary>
        /// <param name="evt">The press event.</param>
        /// <param name="visuals">The <see cref="ItemVisuals"/> receiving the press event.</param>
        public static void HandleHovered(Gesture.OnHover evt, DropdownVisuals visuals)
        {
            if (evt.Receiver.transform.IsChildOf(visuals.ExpandedViewRoot.transform))
            {
                // The hierarchy is hovered, which will happen if one of the objects in visuals.OptionsView
                // is hovered, but we don't want to highlight the background
                // element in that context.
                return;
            }

            ButtonVisuals.HandleHovered(evt, visuals);
        }

        /// <summary>
        /// A utility method to restore the visual state of <see cref="DropdownVisuals"/> 
        /// object when its active gesture (likely a press) is canceled.
        /// </summary>
        /// <param name="evt">The cancel event.</param>
        /// <param name="visuals">The <see cref="ItemVisuals"/> receiving the cancel event.</param>
        public static void HandlePressCanceled(Gesture.OnCancel evt, DropdownVisuals visuals)
        {
            if (evt.Receiver.transform.IsChildOf(visuals.ExpandedViewRoot.transform))
            {
                // The hierarchy is hovered, which will happen if one of the objects in visuals.OptionsView
                // is hovered, but we don't want to highlight the background
                // element in that context.
                return;
            }

            ButtonVisuals.HandlePressCanceled(evt, visuals);
        }

        /// <summary>
        /// A utility method to restore the visual state of <see cref="DropdownVisuals"/> 
        /// object when its active gesture (likely a press) is released.
        /// </summary>
        /// <param name="evt">The release event.</param>
        /// <param name="visuals">The <see cref="ItemVisuals"/> receiving the release event.</param>
        public static void HandleReleased(Gesture.OnRelease evt, DropdownVisuals visuals)
        {
            if (evt.Receiver.transform.IsChildOf(visuals.ExpandedViewRoot.transform))
            {
                // The hierarchy is released, which will happen if one of the objects in visuals.OptionsView
                // is released, but we don't want to highlight the background
                // element in that context.
                return;
            }

            ButtonVisuals.HandleReleased(evt, visuals);
        }

        /// <summary>
        /// A utility method to indicate a pressed visual state of <see cref="DropdownVisuals"/> object.
        /// </summary>
        /// <param name="evt">The press event.</param>
        /// <param name="visuals">The <see cref="ItemVisuals"/> receiving the press event.</param>
        public static void HandlePressed(Gesture.OnPress evt, DropdownVisuals visuals)
        {
            if (evt.Receiver.transform.IsChildOf(visuals.ExpandedViewRoot.transform))
            {
                // The hierarchy is pressed, which will happen if one of the objects in visuals.OptionsView
                // is pressed, but we don't want to highlight the background element in that context.
                return;
            }

            ButtonVisuals.HandlePressed(evt, visuals);
        }
    }
}
