//#define VERBOSE
using Nova;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NovaSamples.UIControls
{
    public class TextField : MonoBehaviour
    {
        /// <summary>
        /// Fires whenever the cursor position changes.
        /// </summary>
        public event Action OnCursorPositionChanged;
        /// <summary>
        /// Fires whenever the highlighted text changes
        /// </summary>
        public event Action OnTextSelectionChanged;
        /// <summary>
        /// Fires whenever the text has changed
        /// </summary>
        public event Action OnTextChanged;

        [SerializeField]
        [Tooltip("The TextBlock used to render the text")]
        private TextBlock textBlock = null;
        [SerializeField]
        [Tooltip("Optional placeholder text to display when the input text is empty")]
        private TextBlock placeHolderText = null;

        [Header("Cursor")]
        [SerializeField]
        [Tooltip("The prefab instantiated to represent the current input position")]
        private UIBlock2D cursorPrefab = null;
        [SerializeField]
        [Tooltip("The frequency with which the cursor will be enabled/disabled")]
        private float cursorBlinkRate = .4f;

        [Header("Scroller")]
        [SerializeField]
        [Tooltip("The Scroller responsible for automatically scrolling the text when the cursor moves out of view.\nCan be null if scrolling text is undesired.")]
        private Scroller scroller = null;

        [Header("Hightlight")]
        [SerializeField]
        [Tooltip("The prefab instantiated to represent selected/highlighted text")]
        private UIBlock2D highlightPrefab = null;

        /// <summary>
        /// The animation handle for blinking the cursor.
        /// </summary>
        private AnimationHandle cursorBlinkHandle = default;
        /// <summary>
        /// The current string position of the cursor.
        /// </summary>
        private TextPosition cursorPosition = default;
        /// <summary>
        /// The starting point of the current selection.
        /// </summary>
        private TextPosition selectionStartPosition = default;

        /// <summary>
        /// The visual for the cursor, instantiated from <see cref="cursorPrefab"/>.
        /// </summary>
        private UIBlock2D cursorVisual = null;

        /// <summary>
        /// The highlights that are currently disabled and can be reused
        /// </summary>
        private List<UIBlock2D> highlightPool = new List<UIBlock2D>();
        /// <summary>
        /// The currently active highlights
        /// </summary>
        private List<UIBlock2D> activeHighlights = new List<UIBlock2D>();

        private string _text = null;
        /// <summary>
        /// The <see cref="TextField"/>'s current text, which may not be the same as the string
        /// that is visible (i.e. <see cref="TextBlock">TextBlock</see>.<see cref="Text">Text</see>) due to 
        /// <see cref="TextField"/> needing to add a trailing empty space to ensure correct cursor position
        /// in certain sitations.
        /// </summary>
        /// <remarks>
        /// This should not be used internally (i.e. by <see cref="TextField"/> itself), 
        /// as <see cref="CursorPosition"/> does not correspond to a position in
        /// this string, but in <see cref="TextBlock">TextBlock</see>.<see cref="Text">Text</see>. In other words,
        /// <see cref="Text"/> should be considered the final string value, and can be fed into other components as
        /// the "real" value, while <see cref="TextBlock">TextBlock</see>.<see cref="Text">Text</see> is what the
        /// user is interacting with and sees.
        /// </remarks>
        /// <seealso cref="FromDisplayText(string)"/>
        /// <seealso cref="ToDisplayText(string)"/>
        public string Text
        {
            get
            {
                if (_text == null)
                {
                    // The text hasn't been initialized yet, so pull
                    // it from the text block, but convert it from a display string
                    _text = FromDisplayText(TextBlock.Text);
                }
                return _text;
            }
            set
            {
                // Make sure not null
                string newText = value ?? string.Empty;

                if (newText == _text)
                {
                    // Text already set to this, nothing to do
                    return;
                }

                // Save off the actual string value
                _text = newText;

                // Convert the string to a display string by inserting any
                // empty spaces if necessary
                string displayText = ToDisplayText(newText);

                if (placeHolderText != null)
                {
                    // If we have a placeholder, enable/disable it based on whether or not the
                    // display string is empty
                    placeHolderText.Visible = string.IsNullOrEmpty(displayText);
                }

                // Update the TextBlock and force a text mesh update so that any cursor/highlight
                // adjustments are valid immediately
                TextBlock.Text = displayText;
                TextBlock.TMP.ForceMeshUpdate();
            }
        }

        /// <summary>
        /// The TextBlock which is used to visualize the value for this input field.
        /// </summary>
        public TextBlock TextBlock
        {
            get
            {
                if (textBlock == null)
                {
                    textBlock = GetComponent<TextBlock>();
                }
                return textBlock;
            }
        }

        /// <summary>
        /// The current cursor position.<br/>
        /// </summary>
        /// <remarks>
        /// NOTE: This is <b>NOT</b> a position in <see cref="Text"/>, but in the <b>display string</b>
        /// (i.e., <see cref="TextBlock">TextBlock</see>.<see cref="Text">Text</see>). See <see cref="Text"/>
        /// for more details.
        /// </remarks>
        public TextPosition CursorPosition
        {
            get
            {
                if (!EnsureInitialized())
                {
                    throw new Exception("Failed to get CursorPosition");
                }
                return cursorPosition;
            }
        }

        /// <summary>
        /// Is there any text highlight/selected?
        /// </summary>
        public bool HasTextSelection => EnsureInitialized() && cursorPosition.IsValid && selectionStartPosition.IsValid && !cursorPosition.Equals(selectionStartPosition);

        /// <summary>
        /// The current position (in <see cref="TextBlock"/> space) of the cursor.
        /// </summary>
        public Vector2 CursorVisualPosition => EnsureInitialized() ? GetCenteredPosition(cursorVisual) : Vector2.zero;

        /// <summary>
        /// The height of the cursor (in <see cref="TextBlock"/> space).
        /// </summary>
        public Vector2 CursorSize => cursorVisual.CalculatedSize.XY.Value;

        private bool HasScrollbarVisual => scroller != null && scroller.ScrollbarVisual != null;

        #region Public API
        /// <summary>
        /// Sets the cursor position and, optionally, the selection/highlight start location.
        /// </summary>
        /// <remarks>
        /// This checks to make sure <paramref name="newPos"/> is valid, so it can be called with
        /// invalid cursor positions.
        /// </remarks>
        public void SetCursorPosition(TextPosition newCursorPosition, TextPosition newSelectionStart = default)
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            if (!newCursorPosition.IsValid)
            {
                if (newCursorPosition.TextMeshIsEmpty)
                {
                    // If the string is empty, move the cursor to the
                    // empty string position
                    HandleEmptyString();
                }

                // Not a valid position
                return;
            }

            if (newSelectionStart.TextBlock == null || !newSelectionStart.IsValid)
            {
                // Not initialized or invalid, so just use cursor position (no selection)
                newSelectionStart = newCursorPosition;
            }

            // Set the selection start and then move the cursor with highlight set to true
            // so that everything inbetween gets selected
            selectionStartPosition = newSelectionStart;
            MoveCursor(newCursorPosition, true);
        }

        /// <summary>
        /// Moves the cursor to <paramref name="newPos"/>. If <paramref name="highlight"/> is true,
        /// the highlight will be maintained (any text between the new cursor position and the old position 
        /// will be highlighted). If <paramref name="highlight"/> is false, the selection will be cleared.
        /// </summary>
        /// <remarks>
        /// This checks to make sure <paramref name="newPos"/> is valid, so it can be called with
        /// invalid cursor positions.
        /// </remarks>
        public void MoveCursor(TextPosition newPos, bool highlight)
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            textBlock.CalculateLayout();

            if (!newPos.IsValid)
            {
                if (newPos.TextMeshIsEmpty)
                {
                    // If the string is empty, move the cursor to the
                    // empty string position
                    HandleEmptyString();
                }

                // Early return if not valid position
                return;
            }

            // Set the cursor position
            cursorPosition = newPos;

#if VERBOSE
            Debug.Log($"Setting cursor to: {cursorPosition}");
#endif


            // Ensure the cursor height is correct
            cursorVisual.Size.Y.Value = cursorPosition.CharHeight;

            // Get the new cursor position
            // NOTE: We add half of the cursor width since cursorPosition.XPos describes the
            // location of the left edge of the cursor
            Vector2 cursorSize = cursorVisual.Size.XY.Value;

            // Reset the cursor animation to guarantee that it's initially solid
            ResetCursorAnimation();

            MatchTextAlignment(cursorVisual);

            // The same as position, but adding in half of the cursor width since 
            // cursorPosition.XPos describes the location of the left edge of the cursor
            Vector2 centeredPosition = new Vector2(cursorPosition.XPos + .5f * cursorSize.x, cursorPosition.YPos);

            Vector2 position = ConvertCenteredPositionToAlignedPosition(cursorVisual, centeredPosition, cursorVisual.Size.XY.Value);

            // Update cursor visual position
            cursorVisual.Position.XY.Value = position;

            // Scroll the text to ensure the cursor is in view 
            ScrollTextToCursorPosition();

            // Notify subscribers of cursor position change
            OnCursorPositionChanged?.Invoke();

            if (!highlight)
            {
                // If we don't want to highlight, just set the selection start to
                // the new cursor position
                selectionStartPosition = cursorPosition;
            }

            UpdateHighlightVisuals();
        }

        /// <summary>
        /// Gets the highlighted string if there is one, otherwise returns the empty string.
        /// </summary>
        public string GetSelectedString()
        {
            if (!HasTextSelection)
            {
                return string.Empty;
            }

            // Get the left and right boundaries of the selection
            GetSelectionLeftRight(out TextPosition left, out TextPosition right);

            // Get the string slice
            int start = left.StringIndex;
            int count = right.StringIndex - start;

            // Get the substring
            string subStr = TextBlock.TMP.text.Substring(start, count);

            // Since this is a display string, we need to convert it
            return FromDisplayText(subStr);
        }

        /// <summary>
        /// Get the left and right positions of the selection, since the cursor
        /// position may actually come before the selection start (for example, if
        /// the user drags their mouse to the left).
        /// </summary>
        public void GetSelectionLeftRight(out TextPosition left, out TextPosition right)
        {
            left = cursorPosition < selectionStartPosition ? cursorPosition : selectionStartPosition;
            right = cursorPosition > selectionStartPosition ? cursorPosition : selectionStartPosition;
        }

        /// <summary>
        /// Hides both the cursor and highlights (if any).
        /// </summary>
        public void HideAllVisuals()
        {
            HideCursorVisual();
            ClearTextSelection();
        }

        /// <summary>
        /// Hides the cursor visual.
        /// </summary>
        public void HideCursorVisual()
        {
#if VERBOSE
            Debug.Log("Hiding cursor visual");
#endif

            // Cancel the animation
            cursorBlinkHandle.Cancel();

            if (cursorVisual != null)
            {
                // Hide the cursor
                cursorVisual.BodyEnabled = false;
            }
        }

        /// <summary>
        /// Clears the current selection
        /// </summary>
        public void ClearTextSelection()
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            selectionStartPosition = cursorPosition;
            UpdateHighlightVisuals();
        }

        /// <summary>
        /// Converts a display string position to raw string index.
        /// </summary>
        public int StringIndexFromTextPosition(TextPosition textPosition)
        {
            if (!EnsureInitialized())
            {
                return -1;
            }

            string displayString = textPosition.TextBlock.Text;

            // Go through the display string and bump the string index for every
            // non empty character
            int displayStringStart = textPosition.StringIndex;
            int stringPosition = 0;
            for (int i = 0; i < displayStringStart; ++i)
            {
                if (!displayString[i].IsEmptySpace())
                {
                    stringPosition += 1;
                }
            }

            return stringPosition;
        }

        /// <summary>
        /// Converts a raw string index into <see cref="Text"/> to a 
        /// <see cref="TextPosition"/> in the display string.
        /// </summary>
        public TextPosition TextPositionFromStringIndex(int stringPosition)
        {
            if (!EnsureInitialized())
            {
                throw new Exception("Tried to get text position for TextField when not initialized");
            }

            if (stringPosition > Text.Length)
            {
                throw new Exception($"Tried to get text position {stringPosition} when string length was {Text.Length}");
            }

            if (stringPosition == Text.Length)
            {
                // It's the end of the string
                return cursorPosition.MoveToEnd();
            }

            // Go through the display string until we've reached stringPosition
            // non-empty characters
            string displayString = TextBlock.Text;
            int displayIndex = 0;
            while (stringPosition > 0 && displayIndex <= displayString.Length)
            {
                if (!displayString[displayIndex].IsEmptySpace())
                {
                    stringPosition -= 1;
                }

                displayIndex++;
            }

            return TextPosition.Create(TextBlock, displayIndex);
        }

        #region Text Modification
        /// <summary>
        /// Deletes one character to the left of <see cref="CursorPosition"/>, if
        /// possible.
        /// </summary>
        /// <remarks>
        /// This is valid to call at any point, even if the operation has no effect.
        /// </remarks>
        public void DeleteLeft()
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            if (HasTextSelection)
            {
                // If there is any text selected, just delete that
                DeleteSelection();
                return;
            }

            Delete(cursorPosition.MoveLeft(), cursorPosition);
        }

        /// <summary>
        /// Deletes one character to the right of <see cref="CursorPosition"/>, if possible.
        /// </summary>
        /// <remarks>
        /// This is valid to call at any point, even if the operation has no effect.
        /// </remarks>
        public void DeleteRight()
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            if (HasTextSelection)
            {
                // If there is any text selected, just delete that
                DeleteSelection();
                return;
            }

            Delete(cursorPosition, cursorPosition.MoveRight());
        }

        /// <summary>
        /// Deletes the currently highlighted/selected text.
        /// </summary>
        /// <remarks>
        /// This is valid to call at any point, even if the operation has no effect.
        /// </remarks>
        public void DeleteSelection()
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            GetSelectionLeftRight(out TextPosition left, out TextPosition right);
            Delete(left, right);
        }

        /// <summary>
        /// Inserts <paramref name="c"/> into the string at <see cref="CursorPosition"/>. 
        /// If there is currently any text selected (i.e. <see cref="HasTextSelection"/> is true), the
        /// selected text is also deleted.
        /// </summary>
        /// <remarks>
        /// This is valid to call at any point, even if the operation has no effect.
        /// </remarks>
        public void Insert(char c)
        {
            Insert(c.ToString());
        }

        /// <summary>
        /// Inserts <paramref name="toInsert"/> into the string at <see cref="CursorPosition"/>. 
        /// If there is currently any text selected (i.e. <see cref="HasTextSelection"/> is true), the
        /// selected text is also deleted.
        /// </summary>
        /// <remarks>
        /// This is valid to call at any point, even if the operation has no effect.
        /// </remarks>
        public void Insert(string toInsert)
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            // First delete the current selection if there is one
            DeleteSelection();

            if (cursorPosition.TextMeshIsEmpty)
            {
                // If the text is empty, just set the text to the inserted value
                Text = toInsert;
                MoveCursor(cursorPosition.MoveToEnd(), false);
            }
            else
            {
                if (!cursorPosition.IsValid)
                {
                    return;
                }

                // Get the new text
                string newText = TextBlock.Text.Insert(cursorPosition.StringIndex, toInsert);

                // Cache the current cursor position
                TextPosition newCursorPosition = cursorPosition;

                // Update the text
                Text = FromDisplayText(newText);

                // Move the cursor by the length of the inserted text
                newCursorPosition = newCursorPosition.MoveRight(toInsert.Length);

                // Set the new cursor position
                MoveCursor(newCursorPosition, false);
            }
        }
        #endregion
        #endregion

        [NonSerialized]
        private bool initialized = false;

        /// <summary>
        /// Returns true if already initialized or was able to successfully initialize,
        /// otherwise returns false.
        /// </summary>
        private bool EnsureInitialized()
        {
            if (initialized)
            {
                // Already initialized
                return true;
            }

            if (!isActiveAndEnabled)
            {
                // Don't do anything if disabled
                return false;
            }

            if (textBlock == null)
            {
                Debug.LogError("No TextBlock assigned to TextField", this);
                return false;
            }

            if (TextBlock.TMP.textInfo == null)
            {
                // TMP hasn't initialized yet
                return false;
            }

            if (cursorVisual == null)
            {
                // Instantiate the cursor visual if we haven't already
                if (cursorPrefab == null)
                {
                    Debug.LogError("No cursor visual assigned on TextField", this);
                    return false;
                }

                cursorVisual = Instantiate(cursorPrefab, textBlock.transform, false);
                cursorVisual.BodyEnabled = false;
            }

#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
            // On PC, we want drag scrolling to be disabled since that is how a user
            // highlights text. However, on mobile since the virtual keyboard has its own text field,
            // we want to enable drag scrolling
            if (scroller != null)
            {
                scroller.DragScrolling = true;
            }
#endif

            if (HasScrollbarVisual)
            {
                scroller.UIBlock.AddGestureHandler<Gesture.OnScroll>(HandleScroll);
            }

            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(HandleTextChanged);

            // Default the cursor and highlight to the beginning.
            cursorPosition = TextPosition.Create(TextBlock, 0);
            selectionStartPosition = cursorPosition;

            // Successfully initialized!
            initialized = true;
            return true;
        }

        /// <summary>
        /// Handle scroll so we can enable/disable scrollbar.
        /// </summary>
        /// <param name="evt"></param>
        private void HandleScroll(Gesture.OnScroll evt) => UpdateScrollbarState();

        private void OnDisable()
        {
            if (!initialized)
            {
                return;
            }

            HideAllVisuals();
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(HandleTextChanged);
            if (scroller != null)
            {
                scroller.UIBlock.RemoveGestureHandler<Gesture.OnScroll>(HandleScroll);
            }
            initialized = false;
        }

        /// <summary>
        /// Refreshes the scrollbar enable/disable state when scrolled or when the text is updated.
        /// </summary>
        private void UpdateScrollbarState()
        {
            if (!HasScrollbarVisual)
            {
                return;
            }

            if (textBlock.CalculatedSize.Y.Value > scroller.UIBlock.CalculatedSize.Y.Value)
            {
                scroller.ScrollbarVisual.gameObject.SetActive(true);
            }
            else
            {
                scroller.ScrollbarVisual.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// When the text mesh changes (e.g., due to the string itself changing, or the font size, alignment, etc)
        /// this ensures that the cursor and highlight visuals are in the correct locations.
        /// </summary>
        /// <param name="obj"></param>
        private void HandleTextChanged(UnityEngine.Object obj)
        {
            if (obj != TextBlock.TMP)
            {
                // Different TMP object, do nothing
                return;
            }

            if (cursorPosition.TextMeshIsEmpty)
            {
                // Empty string
                HandleEmptyString();
            }
            else if (cursorPosition.IsValid)
            {
                // Since the mesh may have changed, we set the cursor position to ensure
                // the cursor visual is in the correct spot
                MoveCursor(cursorPosition, true);
            }
            else
            {
                // Text updated and the cursor position is no longer valid,
                // which means the text where the cursor was positioned has been deleted,
                // so just move it to the end of the string.
                MoveCursor(CursorPosition.MoveToEnd(), false);
            }

            UpdateScrollbarState();

            OnTextChanged?.Invoke();
        }

        /// <summary>
        /// Deletes the text inbetween the two provided positions
        /// </summary>
        private void Delete(TextPosition left, TextPosition right)
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            if (left.Equals(right))
            {
                // Nothing to delete
                return;
            }

            // Get the start location and count
            int start = left.StringIndex;
            int count = right.StringIndex - start;

            // Get the new text with the character removed
            string newText = TextBlock.Text.Remove(start, count);

            // Since we are using the string directly from the text block,
            // we need to convert it from a display string
            newText = FromDisplayText(newText);

            // Update the text
            Text = newText;

            // Set the new cursor position
            MoveCursor(left, false);
        }

        /// <summary>
        /// When the string is empty, there is no mesh on which we can base the
        /// positioning of the cursor, so in order to get the cursor position to be correct
        /// we must manually adjust its alignment based on the alignment of the TMP component.
        /// </summary>
        private void HandleEmptyString()
        {
#if VERBOSE
            Debug.Log($"Setting cursor empty string pos from: {cursorPosition}");
#endif

            // Move the cursor to the "front" of the empty string
            cursorPosition = TextPosition.Create(TextBlock, 0);

            // Set the horizontal and vertical alignment of the cursor based
            // on the text alignment
            MatchTextAlignment(cursorVisual);

            // Reset the cursor animation to ensure it is initially solid
            ResetCursorAnimation();

            // Set the position to VisualOffset, as this will be (0, 0) if the text is
            // not being hugged, otherwise it will be whatever offset is required to to
            // get to (0, 0).
            cursorVisual.Position.XY.Value = TextBlock.VisualOffset;

            // Scroll the text to ensure the cursor is in view 
            ScrollTextToCursorPosition();

            OnCursorPositionChanged?.Invoke();

            // Hide highlights if there are any
            ClearTextSelection();
        }

        /// <summary>
        /// Returns the centered position of the UIBlock, adjusting for alignment as needed
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        private Vector2 GetCenteredPosition(UIBlock block)
        {
            Vector2 parentSize = block.Parent.CalculatedSize.XY.Value;
            Vector2 halfParentSize = .5f * parentSize;

            Vector2 blockSize = block.CalculatedSize.XY.Value;
            Vector2 halfBlockSize = .5f * blockSize;

            Vector2 position = cursorVisual.Position.XY.Value;

            Vector2 centeredPosition = default;
            switch (block.Alignment.X)
            {
                case HorizontalAlignment.Center:
                    centeredPosition.x = position.x;
                    break;
                case HorizontalAlignment.Left:
                    centeredPosition.x = position.x - halfParentSize.x + halfBlockSize.x;
                    break;
                case HorizontalAlignment.Right:
                    centeredPosition.x = halfParentSize.x - position.x - halfBlockSize.x;
                    break;
            }

            switch (block.Alignment.Y)
            {
                case VerticalAlignment.Center:
                    centeredPosition.y = position.y;
                    break;
                case VerticalAlignment.Top:
                    //position.y = halfParentSize.y - centeredPosition.y - .5f * blockSize.y;
                    centeredPosition.y = halfParentSize.y - position.y - halfBlockSize.y;
                    break;
                case VerticalAlignment.Bottom:
                    //position.y = halfParentSize.y + centeredPosition.y - .5f * blockSize.y;
                    centeredPosition.y = position.y - halfParentSize.y + halfBlockSize.y;
                    break;
            }

            return centeredPosition;
        }

        /// <summary>
        /// Converts the provided target center position of the UIBlock to the 
        /// matching position based on the alignment of the block
        /// </summary>
        /// <param name="block"></param>
        /// <param name="centeredPosition"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        private Vector2 ConvertCenteredPositionToAlignedPosition(UIBlock block, Vector2 centeredPosition, Vector2 blockSize)
        {
            Vector2 parentSize = block.Parent.CalculatedSize.XY.Value;
            Vector2 halfParentSize = .5f * parentSize;

            Vector2 position = default;
            switch (block.Alignment.X)
            {
                case HorizontalAlignment.Center:
                    position.x = centeredPosition.x;
                    break;
                case HorizontalAlignment.Left:
                    position.x = centeredPosition.x + halfParentSize.x - .5f * blockSize.x;
                    break;
                case HorizontalAlignment.Right:
                    position.x = halfParentSize.x - centeredPosition.x - .5f * blockSize.x;
                    break;
            }

            switch (block.Alignment.Y)
            {
                case VerticalAlignment.Center:
                    // Same as position
                    position.y = centeredPosition.y;
                    break;
                case VerticalAlignment.Top:
                    position.y = halfParentSize.y - centeredPosition.y - .5f * blockSize.y;
                    break;
                case VerticalAlignment.Bottom:
                    position.y = halfParentSize.y + centeredPosition.y - .5f * blockSize.y;
                    break;
            }

            return position;
        }

        /// <summary>
        /// Sets the alignment of the provided block to match the text alignment
        /// </summary>
        private void MatchTextAlignment(UIBlock block)
        {
            switch (TextBlock.TMP.horizontalAlignment)
            {
                case HorizontalAlignmentOptions.Left:
                    block.Alignment.X = HorizontalAlignment.Left;
                    break;
                case HorizontalAlignmentOptions.Right:
                    block.Alignment.X = HorizontalAlignment.Right;
                    break;
                default:
                    block.Alignment.X = HorizontalAlignment.Center;
                    break;
            }

            switch (TextBlock.TMP.verticalAlignment)
            {
                case VerticalAlignmentOptions.Top:
                    block.Alignment.Y = VerticalAlignment.Top;
                    break;
                case VerticalAlignmentOptions.Bottom:
                    block.Alignment.Y = VerticalAlignment.Bottom;
                    break;
                default:
                    block.Alignment.Y = VerticalAlignment.Center;
                    break;
            }
        }

        /// <summary>
        /// Hide all active highlights and return them to the pool.
        /// </summary>
        private void ReturnAllHighlightsToPool()
        {
            for (int i = 0; i < activeHighlights.Count; i++)
            {
                activeHighlights[i].BodyEnabled = false;
                highlightPool.Add(activeHighlights[i]);
            }

            activeHighlights.Clear();
        }

        /// <summary>
        /// Returns a new highlight visual, either retrieving one from the pool or 
        /// allocating a new one.
        /// </summary>
        private UIBlock2D GetFreeHighlightVisual()
        {
            if (highlightPool.Count > 0)
            {
                // Pop from pool
                UIBlock2D pooled = highlightPool[highlightPool.Count - 1];
                highlightPool.RemoveAt(highlightPool.Count - 1);
                pooled.BodyEnabled = true;
                return pooled;
            }
            else
            {
                // Need to create a new highlight
                return Instantiate(highlightPrefab, textBlock.transform, false);
            }
        }

        /// <summary>
        /// Updates the highlight visuals based on the new <see cref="cursorPosition"/>
        /// and <see cref="selectionStartPosition"/>.
        /// </summary>
        private void UpdateHighlightVisuals()
        {
            if (!EnsureInitialized())
            {
                // Don't do anything if not initialized.
                return;
            }

            // Free all active highlights
            ReturnAllHighlightsToPool();

            if (!selectionStartPosition.IsValid)
            {
                selectionStartPosition = cursorPosition;
            }

#if VERBOSE
            Debug.Log($"Updating selection bounds to: {selectionStartPosition} => {cursorPosition}");
#endif

            // If the selection is not empty, add the highlight visuals
            if (!cursorPosition.Equals(selectionStartPosition))
            {
                // Get the left and right bounds of the selection
                GetSelectionLeftRight(out TextPosition left, out TextPosition right);

                if (left.LineNumber == right.LineNumber)
                {
                    // Selection is only on a single line, so add one highlight
                    // that encapsulates the entire selection
                    AddHighlightVisual(left, right);
                }
                else
                {
                    // Multi line highlight

                    // Highlight the part on the first line
                    AddHighlightVisual(left, left.MoveToEndOfLine());

                    // Highlight all intermediate lines
                    for (int i = left.LineNumber + 1; i < right.LineNumber; ++i)
                    {
                        TextPosition lineStart = TextPosition.CreateAtBeginningOfLine(TextBlock, i);
                        AddHighlightVisual(lineStart, lineStart.MoveToEndOfLine());
                    }

                    // Highlight the part on the last line
                    AddHighlightVisual(right.MoveToStartOfLine(), right);
                }
            }

            // Notify subscribers
            OnTextSelectionChanged?.Invoke();
        }

        /// <summary>
        /// Adds a highlight visual for the provided bounds
        /// </summary>
        private void AddHighlightVisual(TextPosition left, TextPosition right)
        {
            UIBlock2D highlight = GetFreeHighlightVisual();

            MatchTextAlignment(highlight);

            Vector2 size = default;
            Vector2 centeredPosition = default;

            // Use the height of the line
            size.y = left.LineHeight;

            // Y position is the center of the line
            centeredPosition.y = left.LineYCenter;

            // X position is the center point between the left and right edges
            // of the selection
            centeredPosition.x = 0.5f * (left.XPos + right.XPos);

            // Width just goes from left to right edge
            size.x = Mathf.Abs(right.XPos - left.XPos);

            if (size.x == 0f)
            {
                // If selection doesn't contain any visible characters (which could
                // happen if the selection only contains the newline character),
                // we want to at least show something, so we set the width to be
                // a quarter of the height, which is arbitrary but looks reasonable.
                size.x = .25f * size.y;
                // And adjust the xposition based on the new width
                centeredPosition.x += .5f * size.x;
            }

            Vector2 position = ConvertCenteredPositionToAlignedPosition(highlight, centeredPosition, size);

            // Set the size and position of the visual
            highlight.Position.XY.Value = position;
            highlight.Size.XY.Value = size;

            // Track the visual
            activeHighlights.Add(highlight);
        }

        /// <summary>
        /// Whenever the cursor moves, we want it to be solid initially. This resets the 
        /// animation to guarantee that.
        /// </summary>
        private void ResetCursorAnimation()
        {
            // Stop the current animation if it's running
            HideCursorVisual();

            // Ensure enabled
            cursorVisual.BodyEnabled = true;

            // Kickoff the blink animation
            cursorBlinkHandle = new CursorBlinkAnimation(cursorVisual).Loop(cursorBlinkRate);
        }

        /// <summary>
        /// Try to scroll the text as needed each time the cursor position changes.
        /// </summary>
        private void ScrollTextToCursorPosition()
        {
            if (scroller == null)
            {
                // Assuming scrolling is undesired in 
                // this case, so nothing to do here.
                return;
            }

            // Ensure the TextBlock's layout is up to date
            textBlock.CalculateLayout();

            if (CursorPosition.TextMeshIsEmpty)
            {
                // Ensure it's not scrolling
                scroller.CancelScroll();

                // Calculate the scroller's UIBlock layout properties
                // Because its direct child bounds has changed
                scroller.UIBlock.CalculateLayout();

                // If the string is empty scroll to a 0 offset
                AutoLayout autoLayout = scroller.UIBlock.AutoLayout;

                // alignmentDirection is the direction in transform space
                // a positive AutoLayout.Offset will shift the AutoLayout content
                //
                // For the X axis, a positive Offset when Left and Center
                // aligned will shift Right, while Right aligned will shift Left. 
                //
                // For the Y axis, a positive Offset when Bottom and Center
                // aligned will shift Up, while Top aligned will shift Down. 
                float alignmentDirection = autoLayout.Alignment == 1 ? -1 : 1;
                scroller.Scroll(-alignmentDirection * autoLayout.Offset);
                return;
            }

            // The scroller's scrolling axis
            Axis scrollAxis = scroller.UIBlock.AutoLayout.Axis;

            if (scrollAxis == Axis.None || scrollAxis == Axis.Z)
            {
                // Only handle scrolling on X and Y
                return;
            }

            // Get the cursor position in world space, so we 
            // can convert it into scroller space.
            Vector3 cursorWorldPosition = textBlock.transform.TransformPoint(CursorVisualPosition);

            // Get the cursor position in scroller space
            Vector2 scrollSpacePosition = scroller.transform.InverseTransformPoint(cursorWorldPosition);

            // The extents of the scrollable region
            Vector2 halfScrollerSize = 0.5f * scroller.UIBlock.CalculatedSize.Value;

            // The extents of the cursor
            Vector2 cursorHalfSize = 0.5f * CursorSize;

            // Convert the axis into an index
            // so we can do the calculations
            // in an axis-agnostic manner
            int scrollAxisIndex = scrollAxis.Index();

            // Get the amount that the cursor is outside bounds of the scroller on either side of the scrollable axis

            // This is the amount beyond the bounds in the positive direction. For the X axis,
            // that would be to past the Right edge, and past the Top edge for the Y axis.  
            float afterBounds = (scrollSpacePosition[scrollAxisIndex] + cursorHalfSize[scrollAxisIndex]) - halfScrollerSize[scrollAxisIndex];

            // This is the amount beyond the bounds in the negative direction. For the X axis,
            // that would be to past the Left edge, and past the Bottom edge for the Y axis.
            float beforeBounds = (scrollSpacePosition[scrollAxisIndex] - cursorHalfSize[scrollAxisIndex]) + halfScrollerSize[scrollAxisIndex];

            float scrollAmount = 0;

            if (textBlock.CalculatedSize[scrollAxisIndex].Value > scroller.UIBlock.CalculatedSize[scrollAxisIndex].Value)
            {
                // The size of the text is larger than the scroller, so we are in a "scrollable" state
                if (afterBounds > 0)
                {
                    // Negate because we scroll in the direction
                    // opposite to edge the cursor surpasses,
                    // bringing the cursor into view.
                    scrollAmount = -afterBounds;
                }
                else if (beforeBounds < 0 ||
                    // If on the last line, we don't just want to keep the cursor in bounds but want to ensure
                    // that we haven't scrolled past the end (which can happen if the user deletes the last line)
                    (scrollAxis == Axis.Y && cursorPosition.LineNumber == cursorPosition.TextInfo.lineCount - 1))
                {
                    // Negate because we scroll in the direction
                    // opposite to edge the cursor surpasses,
                    // bringing the cursor into view.
                    scrollAmount = -beforeBounds;
                }
            }
            else
            {
                // alignmentDirection is the direction in transform space
                // a positive AutoLayout.Offset will shift the AutoLayout content
                //
                // For the X axis, a positive Offset when Left and Center
                // aligned will shift Right, while Right aligned will shift Left. 
                //
                // For the Y axis, a positive Offset when Bottom and Center
                // aligned will shift Up, while Top aligned will shift Down. 
                float alignmentDirection = scroller.UIBlock.AutoLayout.Alignment == 1 ? -1 : 1;

                // Scroll by the negative directed offset, so we move the scrolled
                // position to zero if we're not in a scrolling state
                scrollAmount = -alignmentDirection * scroller.UIBlock.AutoLayout.Offset;
            }

            scroller.CancelScroll();

            // Calculate the scroller's UIBlock layout properties
            // Because its direct child bounds has changed
            scroller.UIBlock.CalculateLayout();

            // The cursor is outside the bounds of the scroller, so scroll enough to bring it into view
            scroller.Scroll(scrollAmount);
        }

        #region Display Text Conversions
        /// <summary>
        /// In order to get correct cursor positioning, we need to add a zero-width space 
        /// at the end of the string if it ends with a newline.
        /// </summary>
        public static string ToDisplayText(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            if (s[s.Length - 1].IsNewline())
            {
                return $"{s}{CharExtensions.EmptyWidthSpace}";
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// Removes trailing empty space from <paramref name="s"/>.
        /// </summary>
        public static string FromDisplayText(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            if (s[s.Length - 1].IsEmptySpace())
            {
                return s.Substring(0, s.Length - 1);
            }
            else
            {
                return s;
            }
        }
        #endregion

        /// <summary>
        /// Blink animation for the cursor. Just toggles the cursor on and off.
        /// </summary>
        private struct CursorBlinkAnimation : IAnimation
        {
            public UIBlock2D Target;

            public void Update(float percentDone)
            {
                if (percentDone == 1f)
                {
                    Target.BodyEnabled = !Target.BodyEnabled;
                }
            }

            public CursorBlinkAnimation(UIBlock2D target)
            {
                Target = target;
            }
        }
    }
}