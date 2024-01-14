using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// Base class for classes that provide input to <see cref="TextField"/>.
    /// </summary>
    public abstract class TextFieldInputProvider : MonoBehaviour
    {
        [Tooltip("The input field to which this class provides input.")]
        [SerializeField]
        protected TextField inputField = null;
        [Tooltip("The focuser, used to determine when this class should start providing input.")]
        [SerializeField]
        protected TextFieldSelector selector = null;
        [SerializeField]
        [Tooltip("If true, the user can input newlines into the field.")]
        protected bool allowNewlines = true;

        protected abstract void HandleFocused();
        protected abstract void HandleFocusLost();

        protected virtual void OnEnable()
        {
            // Subscribe to focus change events
            selector.OnFocused += HandleFocused;
            selector.OnFocusLost += HandleFocusLost;
        }

        protected virtual void OnDisable()
        {
            // Unsubscribe from focus change events
            selector.OnFocused -= HandleFocused;
            selector.OnFocusLost -= HandleFocusLost;
        }

        /// <summary>
        /// Stub function for text/character validation. Can be extended to 
        /// support different scenarios, e.g. numbers only, alphanumerics only, etc.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected bool IsValidChar(char c)
        {
            // Don't allow return chars or tabulator key to be entered into single line fields.
            if (!allowNewlines && (c == '\t' || c == '\r' || c == 10))
            {
                return false;
            }

            // Null character
            if (c == 0)
            {
                return false;
            }

            // Delete key on mac
            if (c == 127)
            {
                return false;
            }

            return true;
        }
    }
}

