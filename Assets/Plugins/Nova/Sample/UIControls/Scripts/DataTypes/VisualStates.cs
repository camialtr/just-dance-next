using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// The set of available visual states for a UIControl
    /// </summary>
    public enum VisualState
    {
        Default,
        Hovered,
        Pressed
    }

    /// <summary>
    /// Various visual state transition types
    /// </summary>
    public enum TransitionType
    {
        /// <summary>
        /// No Transition.
        /// </summary>
        None,

        /// <summary>
        /// Use a color change transition.
        /// </summary>
        ColorChange,

        /// <summary>
        /// Use a sprite swap transition.
        /// </summary>
        SpriteSwap,

        /// <summary>
        /// Use an animation transition.
        /// </summary>
        Animation
    }

    /// <summary>
    /// The set of sprites to use for different visual states.
    /// </summary>
    [System.Serializable]
    public struct SpriteStates
    {
        [Tooltip("The sprite to use when the control is in its default visual state.")]
        public Sprite DefaultSprite;
        [Tooltip("The sprite to use when the control is in its hovered visual state.")]
        public Sprite HoveredSprite;
        [Tooltip("The sprite to use when the control is in its pressed visual state.")]
        public Sprite PressedSprite;
    }

    /// <summary>
    /// The set of animation triggers to use for different visual states.
    /// </summary>
    [System.Serializable]
    public struct AnimationStates
    {
        [Tooltip("The animation to run when the control is in its default visual state.")]
        public string DefaultAnimation;
        [Tooltip("The animation to run when the control is in its hovered visual state.")]
        public string HoveredAnimation;
        [Tooltip("The animation to run when the control is in its pressed visual state.")]
        public string PressedAnimation;

        public static readonly AnimationStates DefaultStates = new AnimationStates() { DefaultAnimation = "Normal", HoveredAnimation = "Highlighted", PressedAnimation = "Pressed" };
    }
}
