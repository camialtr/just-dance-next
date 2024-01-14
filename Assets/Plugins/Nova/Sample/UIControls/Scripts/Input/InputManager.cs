using Nova;
using UnityEngine;
#if !ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
#endif

namespace NovaSamples.UIControls
{
    /// <summary>
    /// Simple input manager example for the UI Controls sample.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        /// <summary>
        /// Fired after mouse clicks. Can be used to determine when focus is lost.
        /// </summary>
        public static System.Action<UIBlock> OnPostClick;

        [SerializeField]
        [Tooltip("The camera to use for mouse and touch input.")]
        private Camera cam = null;

        [Header("Mouse")]
        [SerializeField]
        [Tooltip("Handle mouse input events.")]
        private bool mouseEnabled = true;
        [SerializeField]
        [Tooltip("Inverts the mouse wheel scroll direction.")]
        private bool invertScrolling = true;

        [Header("Touch")]
        [SerializeField]
        [Tooltip("Handle touch input events.")]
        private bool touchEnabled = true;

        [Header("Navigation")]
        [SerializeField]
        [Tooltip("Handle navigation input events.")]
        private bool navigationEnabled = false;
        [SerializeField]
        [Tooltip("The starting point for navigation focus.")]
        private GestureRecognizer startNavigationFrom = null;
        [Tooltip("The UIBlock to move around as navigation focus changes. Will be created if null.")]
        public UIBlock NavigationIndicator = null;
        [SerializeField]
        [Tooltip("Move navigation focus at this rate (in seconds) while its corresponding key is pressed.")]
        private float updateNavigationEveryXSeconds = 0.25f;

        [Header("Navigation Keys")]
        public KeyCode UpKey = KeyCode.UpArrow;
        public KeyCode DownKey = KeyCode.DownArrow;
        public KeyCode LeftKey = KeyCode.LeftArrow;
        public KeyCode RightKey = KeyCode.RightArrow;
        public KeyCode SelectKey = KeyCode.Return;
        public KeyCode DeselectKey = KeyCode.Escape;

        /// <summary>
        /// The camera to use for mouse and touch input.
        /// </summary>
        public Camera Cam
        {
            get => cam;
            set
            {
                if (value == null)
                {
                    Debug.LogError("Provided Camera is null. Please assign a valid Camera.", this);
                    return;
                }

                cam = value;
            }
        }

        /// <summary>
        /// Handle mouse input events.
        /// </summary>
        public bool MouseEnabled
        {
            get => mouseEnabled;
            set => mouseEnabled = value;
        }

        /// <summary>
        /// Handle touch input events.
        /// </summary>
        public bool TouchEnabled
        {
            get => touchEnabled;
            set => touchEnabled = value;
        }

        /// <summary>
        /// Handle navigation input events.
        /// </summary>
        public bool NavigationEnabled
        {
            get => navigationEnabled;
            set => navigationEnabled = value;
        }

        private void OnEnable()
        {
            if (cam == null)
            {
                cam = Camera.current;
            }

            if (cam == null)
            {
                cam = Camera.main;
            }

            Navigation.OnNavigationFocusChanged += HandleNavigationFocusChanged;

#if !ENABLE_LEGACY_INPUT_MANAGER
            EnhancedTouchSupport.Enable();
#endif
        }

        private void OnDisable()
        {
            Navigation.OnNavigationFocusChanged -= HandleNavigationFocusChanged;
        }

        private void Update()
        {
            UpdateMouse();
            UpdateTouch();
            UpdateNavigation();
        }

        #region Mouse
        private const uint MousePointerControlID = 1;
        private const uint ScrollWheelControlID = 2;

#if ENABLE_LEGACY_INPUT_MANAGER
        private bool MousePresent => Input.mousePresent;
        private Vector2 MousePosition => Input.mousePosition;
        private Vector2 MouseScrollDelta => Input.mouseScrollDelta;
        private bool LeftMouseButtonValue => Input.GetMouseButton(0);
        private bool LeftMouseButtonUp => Input.GetMouseButtonUp(0);
#else
        private bool MousePresent => Mouse.current != null;
        private Vector2 MousePosition => Mouse.current.position.ReadValue();
        private Vector2 MouseScrollDelta => Mouse.current.scroll.ReadValue().normalized;
        private bool LeftMouseButtonValue => Mouse.current.leftButton.isPressed;
        private bool LeftMouseButtonUp => Mouse.current.leftButton.wasReleasedThisFrame;
#endif

        private void UpdateMouse()
        {
            if (cam == null || !mouseEnabled || !MousePresent)
            {
                return;
            }

            // Get the current world-space ray of the mouse
            Ray mouseRay = cam.ScreenPointToRay(MousePosition);

            // Get the current scroll wheel delta
            Vector2 mouseScrollDelta = MouseScrollDelta;

            if (mouseScrollDelta != Vector2.zero)
            {
                // Invert scrolling for a mouse-type experience,
                // otherwise will scroll track-pad style.
                if (invertScrolling)
                {
                    mouseScrollDelta.y *= -1f;
                }

                // Create a new Interaction.Update from the mouse ray and scroll wheel control id
                Interaction.Update scrollInteraction = new Interaction.Update(mouseRay, ScrollWheelControlID);

                // Feed the scroll update and scroll delta into Nova's Interaction APIs
                Interaction.Scroll(scrollInteraction, mouseScrollDelta);
            }

            // Create a new Interaction.Update from the mouse ray and pointer control id
            Interaction.Update pointInteraction = new Interaction.Update(mouseRay, MousePointerControlID);

            // Feed the pointer update and pressed state to Nova's Interaction APIs
            Interaction.Point(pointInteraction, LeftMouseButtonValue);

            if (LeftMouseButtonUp)
            {
                // If the mouse button was released this frame, fire the OnPostClick
                // event with the hit UIBlock (or null if there wasn't one)
                Interaction.TryGetActiveReceiver(MousePointerControlID, out UIBlockHit hit);
                OnPostClick?.Invoke(hit.UIBlock);
            }
        }
        #endregion

        #region Touch

#if ENABLE_LEGACY_INPUT_MANAGER
        private bool TouchSupported => Input.touchSupported;
        private int TouchCount => Input.touchCount;
        private Touch GetTouch(int index) => Input.GetTouch(index);
        private Vector2 GetTouchPosition(Touch touch) => touch.position;
        private uint GetTouchID(Touch touch) => (uint)touch.fingerId;
#else
        private bool TouchSupported => Touchscreen.current != null;
        private int TouchCount => Touch.activeTouches.Count;
        private Touch GetTouch(int index) => Touch.activeTouches[index];
        private Vector2 GetTouchPosition(Touch touch) => touch.screenPosition;
        private uint GetTouchID(Touch touch) => (uint)touch.finger.index;
#endif

        private void UpdateTouch()
        {
            if (cam == null || !touchEnabled || !TouchSupported)
            {
                return;
            }

            for (int i = 0; i < TouchCount; i++)
            {
                Touch touch = GetTouch(i);

                // Convert the touch point to a world-space ray.
                Ray ray = cam.ScreenPointToRay(GetTouchPosition(touch));

                // Create a new Interaction from the ray and the finger's ID
                Interaction.Update update = new Interaction.Update(ray, GetTouchID(touch));

                // Get the current touch phase
                TouchPhase touchPhase = touch.phase;

                // If the touch phase hasn't ended and hasn't been canceled, then pointerDown == true.
                bool pointerDown = touchPhase != TouchPhase.Canceled && touchPhase != TouchPhase.Ended;

                // Feed the update and pressed state to Nova's Interaction APIs
                Interaction.Point(update, pointerDown);

                if (!pointerDown)
                {
                    // If the finger is off the screen, send a follow up hover that
                    // won't hit anything and cancel to indicate the interaction is over.
                    // This is to assist with cross platform compatibility for hover events,
                    // since touch events are driven by press/release and don't provide the same
                    // kind of "pointer exit" data as an unpressed mouse pointer
                    update.Ray = default;
                    Interaction.Point(update, false);
                    Interaction.Cancel(update);
                }
            }
        }
        #endregion

        #region Navigation
#if ENABLE_LEGACY_INPUT_MANAGER
        private bool KeyboardPresent => true;
        private bool NavigateUp => Input.GetKey(UpKey);
        private bool NavigateDown => Input.GetKey(DownKey);
        private bool NavigateLeft => Input.GetKey(LeftKey);
        private bool NavigateRight => Input.GetKey(RightKey);
        private bool Select => Input.GetKeyUp(SelectKey);
        private bool Deselect => Input.GetKeyUp(DeselectKey);
#else
        private bool KeyboardPresent => Keyboard.current != null;
        private bool NavigateUp => Keyboard.current[GetKey(UpKey)].isPressed;
        private bool NavigateDown => Keyboard.current[GetKey(DownKey)].isPressed;
        private bool NavigateLeft => Keyboard.current[GetKey(LeftKey)].isPressed;
        private bool NavigateRight => Keyboard.current[GetKey(RightKey)].isPressed;
        private bool Select => Keyboard.current[GetKey(SelectKey)].wasReleasedThisFrame;
        private bool Deselect => Keyboard.current[GetKey(DeselectKey)].wasReleasedThisFrame;
#endif
        private const uint NavigationID = 3;
        private float prevNavTime = 0;

        private void UpdateNavigation()
        {
            bool canNavigate = navigationEnabled && KeyboardPresent;
            bool navigating = Navigation.TryGetFocusedUIBlock(NavigationID, out UIBlock focused);

            if (canNavigate && !navigating)
            {
                // Initialize navigation
                EnsureNavigationIndicator();

                if (startNavigationFrom != null)
                {
                    Navigation.Focus(startNavigationFrom.UIBlock, NavigationID);
                }
            }

            if (NavigationIndicator != null)
            {
                // Ensure visibility matches navigable status
                NavigationIndicator.gameObject.SetActive(canNavigate && navigating);
            }

            if (!canNavigate || !navigating)
            {
                // Not navigable
                return;
            }

            Vector3 navDirection = Vector3.zero;

            float timeSinceNav = Time.unscaledTime - prevNavTime;

            if (NavigateDown)
            {
                navDirection += Vector3.down;
            }

            if (NavigateUp)
            {
                navDirection += Vector3.up;
            }

            if (NavigateRight)
            {
                navDirection += Vector3.right;
            }

            if (NavigateLeft)
            {
                navDirection += Vector3.left;
            }

            if (navDirection == Vector3.zero)
            {
                // if no navigation key is pressed,
                // "reset" prevNavTime.
                prevNavTime = Time.unscaledTime - updateNavigationEveryXSeconds;
            }

            if (navDirection != Vector3.zero)
            {
                if (timeSinceNav > updateNavigationEveryXSeconds)
                {
                    prevNavTime = Time.unscaledTime;
                    Navigation.Move(navDirection, NavigationID);
                }
            }
            else if (Deselect)
            {
                Navigation.Deselect(NavigationID);
            }
            else if (Select)
            {
                Navigation.Select(NavigationID);
            }

            if (focused == null)
            {
                // Nothing to update
                return;
            }

            // Match the world scale of the focused element
            Vector3 parentScale = NavigationIndicator.transform.parent == null ? Vector3.one : NavigationIndicator.transform.parent.lossyScale;
            Vector3 focusedScale = focused.transform.lossyScale;
            NavigationIndicator.transform.localScale = new Vector3(focusedScale.x / parentScale.x, focusedScale.y / parentScale.y, focusedScale.z / parentScale.z);

            // Update size and position to match whatever's focused
            NavigationIndicator.Size = focused.CalculatedSize.Value + NavigationIndicator.CalculatedPadding.Size;
            NavigationIndicator.TrySetWorldPosition(focused.transform.position);
            NavigationIndicator.transform.rotation = focused.transform.rotation;
        }

        private void HandleNavigationFocusChanged(uint controlID, UIBlock focused)
        {
            // When navigation focus changes, treat that
            // as though something new was clicked, since
            // we're no longer "hovering" on the previously
            // focused element.
            OnPostClick?.Invoke(focused);
        }

        private void EnsureNavigationIndicator()
        {
            if (NavigationIndicator != null)
            {
                return;
            }

            // Create a new game object to be our focus indicator
            UIBlock2D indicator = new GameObject("Navigation Indicator").AddComponent<UIBlock2D>();

            // Hide the body and enable the border
            indicator.BodyEnabled = false;
            indicator.Border = new Border()
            {
                Enabled = true,
                Width = 5,
                Direction = BorderDirection.Out,
                Color = Color.yellow,
            };

            // Round the cornes a bit
            indicator.CornerRadius = 2;

            // Add some padding
            indicator.Padding.XY = 5;

            // Make sure the indicator will render over the other content
            SortGroup sortGroup = indicator.gameObject.AddComponent<SortGroup>();
            sortGroup.RenderQueue = 4001;
            sortGroup.RenderOverOpaqueGeometry = true;

            // assign the focus indicator
            NavigationIndicator = indicator;
        }

        #region Convert KeyCode to Key
#if !ENABLE_LEGACY_INPUT_MANAGER
        /// <summary>
        /// Attempts to convert the legacy KeyCode value to its corresponding Key value
        /// 
        /// Code was taken from https://forum.unity.com/threads/convert-from-old-keycode-to-the-new-key-enum.938459/
        /// </summary>
        /// <param name="keyCode">The <see cref="KeyCode"/> to convert to an <see cref="UnityEngine.InputSystem.Key"/></param>
        /// <returns></returns>
        public static Key GetKey(KeyCode keyCode)
        {
            Key unknownKey = Key.None;
            Key mouseKey = Key.None;
            Key joystickKey = Key.None;

            switch (keyCode)
            {
                case KeyCode.None: return Key.None;
                case KeyCode.Backspace: return Key.Backspace;
                case KeyCode.Delete: return Key.Delete;
                case KeyCode.Tab: return Key.Tab;
                case KeyCode.Clear: return unknownKey; // Conversion unknown.
                case KeyCode.Return: return Key.Enter;
                case KeyCode.Pause: return Key.Pause;
                case KeyCode.Escape: return Key.Escape;
                case KeyCode.Space: return Key.Space;
                case KeyCode.Keypad0: return Key.Numpad0;
                case KeyCode.Keypad1: return Key.Numpad1;
                case KeyCode.Keypad2: return Key.Numpad2;
                case KeyCode.Keypad3: return Key.Numpad3;
                case KeyCode.Keypad4: return Key.Numpad4;
                case KeyCode.Keypad5: return Key.Numpad5;
                case KeyCode.Keypad6: return Key.Numpad6;
                case KeyCode.Keypad7: return Key.Numpad7;
                case KeyCode.Keypad8: return Key.Numpad8;
                case KeyCode.Keypad9: return Key.Numpad9;
                case KeyCode.KeypadPeriod: return Key.NumpadPeriod;
                case KeyCode.KeypadDivide: return Key.NumpadDivide;
                case KeyCode.KeypadMultiply: return Key.NumpadMultiply;
                case KeyCode.KeypadMinus: return Key.NumpadMinus;
                case KeyCode.KeypadPlus: return Key.NumpadPlus;
                case KeyCode.KeypadEnter: return Key.NumpadEnter;
                case KeyCode.KeypadEquals: return Key.NumpadEquals;
                case KeyCode.UpArrow: return Key.UpArrow;
                case KeyCode.DownArrow: return Key.DownArrow;
                case KeyCode.RightArrow: return Key.RightArrow;
                case KeyCode.LeftArrow: return Key.LeftArrow;
                case KeyCode.Insert: return Key.Insert;
                case KeyCode.Home: return Key.Home;
                case KeyCode.End: return Key.End;
                case KeyCode.PageUp: return Key.PageUp;
                case KeyCode.PageDown: return Key.PageDown;
                case KeyCode.F1: return Key.F1;
                case KeyCode.F2: return Key.F2;
                case KeyCode.F3: return Key.F3;
                case KeyCode.F4: return Key.F4;
                case KeyCode.F5: return Key.F5;
                case KeyCode.F6: return Key.F6;
                case KeyCode.F7: return Key.F7;
                case KeyCode.F8: return Key.F8;
                case KeyCode.F9: return Key.F9;
                case KeyCode.F10: return Key.F10;
                case KeyCode.F11: return Key.F11;
                case KeyCode.F12: return Key.F12;
                case KeyCode.F13: return unknownKey; // Conversion unknown.
                case KeyCode.F14: return unknownKey; // Conversion unknown.
                case KeyCode.F15: return unknownKey; // Conversion unknown.
                case KeyCode.Alpha0: return Key.Digit0;
                case KeyCode.Alpha1: return Key.Digit1;
                case KeyCode.Alpha2: return Key.Digit2;
                case KeyCode.Alpha3: return Key.Digit3;
                case KeyCode.Alpha4: return Key.Digit4;
                case KeyCode.Alpha5: return Key.Digit5;
                case KeyCode.Alpha6: return Key.Digit6;
                case KeyCode.Alpha7: return Key.Digit7;
                case KeyCode.Alpha8: return Key.Digit8;
                case KeyCode.Alpha9: return Key.Digit9;
                case KeyCode.Exclaim: return unknownKey; // Conversion unknown.
                case KeyCode.DoubleQuote: return unknownKey; // Conversion unknown.
                case KeyCode.Hash: return unknownKey; // Conversion unknown.
                case KeyCode.Dollar: return unknownKey; // Conversion unknown.
                case KeyCode.Percent: return unknownKey; // Conversion unknown.
                case KeyCode.Ampersand: return unknownKey; // Conversion unknown.
                case KeyCode.Quote: return Key.Quote;
                case KeyCode.LeftParen: return unknownKey; // Conversion unknown.
                case KeyCode.RightParen: return unknownKey; // Conversion unknown.
                case KeyCode.Asterisk: return unknownKey; // Conversion unknown.
                case KeyCode.Plus: return Key.None; // TODO
                case KeyCode.Comma: return Key.Comma;
                case KeyCode.Minus: return Key.Minus;
                case KeyCode.Period: return Key.Period;
                case KeyCode.Slash: return Key.Slash;
                case KeyCode.Colon: return unknownKey; // Conversion unknown.
                case KeyCode.Semicolon: return Key.Semicolon;
                case KeyCode.Less: return Key.None;
                case KeyCode.Equals: return Key.Equals;
                case KeyCode.Greater: return unknownKey; // Conversion unknown.
                case KeyCode.Question: return unknownKey; // Conversion unknown.
                case KeyCode.At: return unknownKey; // Conversion unknown.
                case KeyCode.LeftBracket: return Key.LeftBracket;
                case KeyCode.Backslash: return Key.Backslash;
                case KeyCode.RightBracket: return Key.RightBracket;
                case KeyCode.Caret: return Key.None; // TODO
                case KeyCode.Underscore: return unknownKey; // Conversion unknown.
                case KeyCode.BackQuote: return Key.Backquote;
                case KeyCode.A: return Key.A;
                case KeyCode.B: return Key.B;
                case KeyCode.C: return Key.C;
                case KeyCode.D: return Key.D;
                case KeyCode.E: return Key.E;
                case KeyCode.F: return Key.F;
                case KeyCode.G: return Key.G;
                case KeyCode.H: return Key.H;
                case KeyCode.I: return Key.I;
                case KeyCode.J: return Key.J;
                case KeyCode.K: return Key.K;
                case KeyCode.L: return Key.L;
                case KeyCode.M: return Key.M;
                case KeyCode.N: return Key.N;
                case KeyCode.O: return Key.O;
                case KeyCode.P: return Key.P;
                case KeyCode.Q: return Key.Q;
                case KeyCode.R: return Key.R;
                case KeyCode.S: return Key.S;
                case KeyCode.T: return Key.T;
                case KeyCode.U: return Key.U;
                case KeyCode.V: return Key.V;
                case KeyCode.W: return Key.W;
                case KeyCode.X: return Key.X;
                case KeyCode.Y: return Key.Y;
                case KeyCode.Z: return Key.Z;
                case KeyCode.LeftCurlyBracket: return unknownKey; // Conversion unknown.
                case KeyCode.Pipe: return unknownKey; // Conversion unknown.
                case KeyCode.RightCurlyBracket: return unknownKey; // Conversion unknown.
                case KeyCode.Tilde: return unknownKey; // Conversion unknown.
                case KeyCode.Numlock: return Key.NumLock;
                case KeyCode.CapsLock: return Key.CapsLock;
                case KeyCode.ScrollLock: return Key.ScrollLock;
                case KeyCode.RightShift: return Key.RightShift;
                case KeyCode.LeftShift: return Key.LeftShift;
                case KeyCode.RightControl: return Key.RightCtrl;
                case KeyCode.LeftControl: return Key.LeftCtrl;
                case KeyCode.RightAlt: return Key.RightAlt;
                case KeyCode.LeftAlt: return Key.LeftAlt;
                case KeyCode.LeftCommand: return Key.LeftCommand;
                // case KeyCode.LeftApple: (same as LeftCommand)
                case KeyCode.LeftWindows: return Key.LeftWindows;
                case KeyCode.RightCommand: return Key.RightCommand;
                // case KeyCode.RightApple: (same as RightCommand)
                case KeyCode.RightWindows: return Key.RightWindows;
                case KeyCode.AltGr: return Key.AltGr;
                case KeyCode.Help: return unknownKey; // Conversion unknown.
                case KeyCode.Print: return Key.PrintScreen;
                case KeyCode.SysReq: return unknownKey; // Conversion unknown.
                case KeyCode.Break: return unknownKey; // Conversion unknown.
                case KeyCode.Menu: return Key.ContextMenu;
                case KeyCode.Mouse0:
                case KeyCode.Mouse1:
                case KeyCode.Mouse2:
                case KeyCode.Mouse3:
                case KeyCode.Mouse4:
                case KeyCode.Mouse5:
                case KeyCode.Mouse6:
                    return mouseKey; // Not supported anymore.

                // All other keys are joystick keys which do not
                // exist anymore in the new input system.
                default:
                    return joystickKey; // Not supported anymore.
            }
        }
#endif
        #endregion

        #endregion
    }
}

