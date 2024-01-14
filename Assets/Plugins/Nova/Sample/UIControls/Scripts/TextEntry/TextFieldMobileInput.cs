using System;
using System.Collections;
using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// Provides text input on mobile using the <see cref="TouchScreenKeyboard"/> apis.
    /// </summary>
    public class TextFieldMobileInput : TextFieldInputProvider
    {
        [SerializeField]
        [Tooltip("The type of virtual keyboard to bring up when the reference Text Field is focused.")]
        private TouchScreenKeyboardType keyboardType = TouchScreenKeyboardType.Default;
        [SerializeField]
        [Tooltip("Enable the system keyboard's auto correct functionality?")]
        private bool autoCorrect = true;
        [SerializeField]
        [Tooltip("Should the text be masked (e.g. for passwords)?")]
        private bool secure = false;

        /// <summary>
        /// The touch screen keyboard controller shared by all text fields.
        /// </summary>
        private static readonly TouchScreenKeyboardController touchScreenKeyboardController = new TextFieldMobileInput.TouchScreenKeyboardController();

        /// <summary>
        /// The coroutine tracking tracking the keyboard visibility and listening for input events.
        /// </summary>
        private Coroutine inputRoutine = null;


        /// <summary>
        /// Tracks if we are currently updating the <see cref="TextField"/> from the touch screen keyboard.
        /// Used for ignoring the <see cref="TextField.OnTextSelectionChanged"/> event.
        /// </summary>
        private bool updatingText = false;

        protected override void OnEnable()
        {
            if (!TouchScreenKeyboard.isSupported)
            {
                // If touchscreen keyboard not supported on this device, do nothing
                return;
            }

            base.OnEnable();

            // Subscribe to selection changed so we can update the touch screen
            // keyboard whenever the input field selection changes
            inputField.OnTextSelectionChanged += UpdateTouchScreenKeyboardSelection;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            inputField.OnTextSelectionChanged -= UpdateTouchScreenKeyboardSelection;
        }

        /// <summary>
        /// Kickoff the input update loop.
        /// </summary>
        protected override void HandleFocused()
        {
            inputRoutine = StartCoroutine(InputLoop());
        }

        /// <summary>
        /// Stop the input update loop and hide the touch screen
        /// keyboard.
        /// </summary>
        protected override void HandleFocusLost()
        {
            if (inputRoutine != null)
            {
                StopCoroutine(inputRoutine);
                inputRoutine = null;
            }

            touchScreenKeyboardController.RequestHide(this);
        }

        /// <summary>
        /// Updates the touch screen keyboard's selection from the text input field.
        /// </summary>
        private void UpdateTouchScreenKeyboardSelection()
        {
            if (touchScreenKeyboardController.Status != TouchScreenKeyboard.Status.Visible ||
                !touchScreenKeyboardController.IsCurrentController(this))
            {
                return;
            }

            if (updatingText)
            {
                // We are in the process of updating the input field,
                // so ignore this event
                return;
            }

            // Get the display string selection positions
            inputField.GetSelectionLeftRight(out TextPosition left, out TextPosition right);

            // Convert the display string positions to raw string positions
            int start = inputField.StringIndexFromTextPosition(left);
            int count = inputField.StringIndexFromTextPosition(right) - start;

            // Update the keyboard selection
            touchScreenKeyboardController.Selection = new RangeInt(start, count);
        }

        /// <summary>
        /// Coroutine to listen for keyboard visibility and input events.
        /// </summary>
        /// <returns></returns>
        private IEnumerator InputLoop()
        {
            // Open the touch screen keyboard
            touchScreenKeyboardController.RequestShow(this, inputField.Text, new TouchScreenConfig()
            {
                KeyboardType = keyboardType,
                Autocorrection = autoCorrect,
                Multiline = allowNewlines,
                Secure = secure,
                Alert = false
            });

            // Update the touch screen keyboard selection
            UpdateTouchScreenKeyboardSelection();

            // Loop indefinitely, the loop will stop when the coroutine is stopped.
            while (true)
            {
                if (touchScreenKeyboardController.Status != TouchScreenKeyboard.Status.Visible)
                {
                    // The touch screen keyboard was hidden (for example, if the user clicks somewhere else
                    // on the screen), so unfocus the text input field (our unfocus event handler will 
                    // stop this coroutine and do other cleanup).
                    selector.RemoveFocus();
                    yield break;
                }

                if (touchScreenKeyboardController.Text != inputField.Text)
                {
                    // The keyboard text and input field text don't match, so update the input field
                    updatingText = true;
                    inputField.Text = touchScreenKeyboardController.Text;
                    updatingText = false;
                }

                // Convert the touch screen keyboard positions to display string positions
                TextPosition left = inputField.TextPositionFromStringIndex(touchScreenKeyboardController.Selection.start);
                TextPosition right = inputField.TextPositionFromStringIndex(touchScreenKeyboardController.Selection.end);

                if (left.IsValid && right.IsValid)
                {
                    // Update the input field cursor positions
                    inputField.SetCursorPosition(right, left);
                }

                yield return null;
            }
        }

        /// <summary>
        /// Configuration describing the touch screen keyboard.
        /// </summary>
        private struct TouchScreenConfig : IEquatable<TouchScreenConfig>
        {
            public TouchScreenKeyboardType KeyboardType;
            public bool Autocorrection;
            public bool Multiline;
            public bool Secure;
            public bool Alert;

            public bool Equals(TouchScreenConfig other)
            {
                return
                    this.KeyboardType == other.KeyboardType &&
                    this.Autocorrection == other.Autocorrection &&
                    this.Multiline == other.Multiline &&
                    this.Secure == other.Secure &&
                    this.Alert == other.Alert;
            }
        }

        /// <summary>
        /// Handles control of the touch screen keyboard. Since transferring control from
        /// one text field to another shouldn't hide the keyboard, we need a single controller that handles
        /// accessing "Show" and "Hide" requests
        /// </summary>
        private class TouchScreenKeyboardController
        {
            /// <summary>
            /// The active touchscreen keyboard
            /// </summary>
            private TouchScreenKeyboard keyboard = null;

            /// <summary>
            /// The current controller of the virtual keyboard
            /// </summary>
            private TextFieldMobileInput currentKeyboardController = null;

            /// <summary>
            /// The current configuration of the keyboard
            /// </summary>
            private TouchScreenConfig currentConfig;

            public TouchScreenKeyboard.Status Status => keyboard != null ? keyboard.status : TouchScreenKeyboard.Status.LostFocus;
            public string Text => keyboard != null ? keyboard.text : null;

            public bool IsCurrentController(TextFieldMobileInput toCheck) => currentKeyboardController == toCheck;

            public RangeInt Selection
            {
                get => keyboard != null ? keyboard.selection : default;
                set
                {
                    if (keyboard != null)
                    {
                        keyboard.selection = value;
                    }
                }
            }

            public void RequestShow(TextFieldMobileInput requestor, string text, TouchScreenConfig config)
            {
                if (currentKeyboardController == requestor)
                {
                    Debug.LogWarning("TextFieldMobileInput requested to show virtual keyboard when already controller", requestor);
                    return;
                }

                currentKeyboardController = requestor;

                if (keyboard != null && currentConfig.Equals(config))
                {
                    // The config is the same, so just update the text
                    keyboard.text = text;
                }
                else
                {
                    // It's a different type of keyboard, so open a new one
                    currentConfig = config;
                    // Different keyboard type, so re-open
                    keyboard = TouchScreenKeyboard.Open(text, config.KeyboardType, config.Autocorrection, config.Multiline, config.Secure, config.Alert);
                }
            }

            public void RequestHide(TextFieldMobileInput requestor)
            {
                if (requestor != currentKeyboardController)
                {
                    // The requestor is not the current controller, nothing to do
                    return;
                }

                currentKeyboardController = null;
                keyboard.active = false;
                keyboard = null;
                currentConfig = default;
            }
        }
    }
}
