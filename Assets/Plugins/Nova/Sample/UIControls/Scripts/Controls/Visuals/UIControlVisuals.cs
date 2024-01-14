using Nova;
using System;
using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// An abstract base class for different UI Control <see cref="ItemVisuals"/> types.
    /// Provides a base implementation for various visual state transitions.
    /// </summary>
    [Serializable]
    [TypeMenuPath("Nova")]
    public abstract class UIControlVisuals : ItemVisuals
    {
        [Header("Visual States")]
        public TransitionType TransitionType = TransitionType.ColorChange;
        [Tooltip("The UIBlock whose properties will change as the visual state transitions.")]
        [SerializeField]
        private UIBlock transitionTarget = null;
        
        [Tooltip("The default Background color.")]
        public Color DefaultColor = Color.HSVToRGB(0, 0, 1); // white
        [Tooltip("The color to apply to the Background when this control is hovered.")]
        public Color HoveredColor = Color.HSVToRGB(0, 0, 0.75f); // light grey
        [Tooltip("The color to apply to the Background when this control is pressed.")]
        public Color PressedColor = Color.HSVToRGB(0, 0, 0.5f); // darker grey

        private AnimationHandle colorAnimationHandle = default;

        [Min(0), Tooltip("The duration of the transition animation. Only applicable when \"Transition Type\" is set to \"Color Change\".")]
        public float TransitionDuration = 0.1f;

        /// <summary>
        /// The set of sprites to use when <see cref="TransitionType"/> is set to <see cref="TransitionType.SpriteSwap"/>.
        /// </summary>
        public SpriteStates Sprites = default;

        /// <summary>
        /// The set of animations names to use when <see cref="TransitionType"/> is set to <see cref="TransitionType.Animation"/>.
        /// </summary>
        public AnimationStates Animations = AnimationStates.DefaultStates;

        /// <summary>
        /// The UIBlock whose properties will change as the visual state transitions.
        /// </summary>
        public UIBlock TransitionTarget
        {
            get => transitionTarget == null ? TransitionTargetFallback : transitionTarget;
            set => transitionTarget = value;
        }

        /// <summary>
        /// The UIBlock to fall back to when the <see cref="transitionTarget"/> is null.
        /// </summary>
        /// <remarks>
        /// Derived classes can override this Property. Primarily here to allow refactoring
        /// without causing breaking changes due to null-serialized fields.
        /// </remarks>
        protected virtual UIBlock TransitionTargetFallback => null;

#if PACKAGE_ANIMATION
        private Animator GetAnimator() => View == null ? null : View.GetComponent<Animator>();
#endif

        /// <summary>
        /// Update the visual state based on the given <paramref name="newState"/> and configured <see cref="TransitionType"/>.
        /// </summary>
        /// <param name="newState">The new visual state.</param>
        public void UpdateVisualState(VisualState newState)
        {
            Color newColor;
            Sprite newSprite;
            string newAnimation;

            switch (newState)
            {
                case VisualState.Hovered:
                    newColor = HoveredColor;
                    newSprite = Sprites.HoveredSprite;
                    newAnimation = Animations.HoveredAnimation;
                    break;
                case VisualState.Pressed:
                    newColor = PressedColor;
                    newSprite = Sprites.PressedSprite;
                    newAnimation = Animations.PressedAnimation;
                    break;
                default:
                    newColor = DefaultColor;
                    newSprite = Sprites.DefaultSprite;
                    newAnimation = Animations.DefaultAnimation;
                    break;
            }

            switch (TransitionType)
            {
                case TransitionType.ColorChange:
                    ChangeColor(newColor);
                    break;
                case TransitionType.SpriteSwap:
                    SwapSprite(newSprite);
                    break;
                case TransitionType.Animation:
                    PlayAnimation(newAnimation);
                    break;
            }
        }

        /// <summary>
        /// Apply the new color to the <see cref="TransitionTarget"/>.
        /// </summary>
        /// <param name="targetColor">The color to assign to the <see cref="TransitionTarget"/>'s body.</param>
        private void ChangeColor(Color targetColor)
        {
            if (TransitionTarget == null)
            {
                return;
            }

            colorAnimationHandle.Cancel();
            colorAnimationHandle = new ControlColorAnimation()
            {
                Target = TransitionTarget,
                TargetColor = targetColor,
            }.Run(TransitionDuration);
        }

        /// <summary>
        /// Apply the new sprite to the <see cref="TransitionTarget"/>.
        /// </summary>
        /// <param name="newSprite">The sprite to assign to the <see cref="TransitionTarget"/>'s body.</param>
        private void SwapSprite(Sprite newSprite)
        {
            if (!(TransitionTarget is UIBlock2D uiBlock2D))
            {
                return;
            }

            uiBlock2D.SetImage(newSprite);
        }

        /// <summary>
        /// Play the new visual state animation.
        /// </summary>
        /// <param name="newAnimation">The animation to play for the current visual state.</param>
        private void PlayAnimation(string newAnimation)
        {
#if PACKAGE_ANIMATION
            Animator animator = GetAnimator();

            if (animator == null || !animator.isActiveAndEnabled || !animator.hasBoundPlayables || string.IsNullOrEmpty(newAnimation))
            {
                return;
            }

            animator.ResetTrigger(Animations.DefaultAnimation);
            animator.ResetTrigger(Animations.HoveredAnimation);
            animator.ResetTrigger(Animations.PressedAnimation);

            animator.SetTrigger(newAnimation);
#endif
        }

        /// <summary>
        /// A utility method to indicate a hovered visual state of <see cref="UIControlVisuals"/> object.
        /// </summary>
        /// <param name="evt">The hover event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the press event.</param>
        /// <param name="index">Unused here, but this is the index into the data source of list view invoking this event.</param>
        public static void HandleHovered(Gesture.OnHover evt, UIControlVisuals control, int index) => HandleHovered(evt, control);

        /// <summary>
        /// A utility method to indicate a hovered visual state of <see cref="UIControlVisuals"/> object.
        /// </summary>
        /// <param name="evt">The hover event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the press event.</param>
        public static void HandleHovered(Gesture.OnHover evt, UIControlVisuals control) => control.UpdateVisualState(VisualState.Hovered);

        /// <summary>
        /// A utility method to restore the visual state of <see cref="UIControlVisuals"/> object when it's unhovered.
        /// </summary>
        /// <param name="evt">The unhover event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the press event.</param>
        /// <param name="index">Unused here, but this is the index into the data source of list view invoking this event.</param>
        public static void HandleUnhovered(Gesture.OnUnhover evt, UIControlVisuals control, int index) => HandleUnhovered(evt, control);

        /// <summary>
        /// A utility method to restore the visual state of <see cref="UIControlVisuals"/> object when it's unhovered.
        /// </summary>
        /// <param name="evt">The unhover event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the press event.</param>
        public static void HandleUnhovered(Gesture.OnUnhover evt, UIControlVisuals control) => control.UpdateVisualState(VisualState.Default);

        /// <summary>
        /// A utility method to indicate a pressed visual state of <see cref="UIControlVisuals"/> object.
        /// </summary>
        /// <param name="evt">The press event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the press event.</param>
        /// <param name="index">Unused here, but this is the index into the data source of list view invoking this event.</param>
        public static void HandlePressed(Gesture.OnPress evt, UIControlVisuals control, int index) => HandlePressed(evt, control);

        /// <summary>
        /// A utility method to indicate a pressed visual state of <see cref="UIControlVisuals"/> object.
        /// </summary>
        /// <param name="evt">The press event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the press event.</param>
        public static void HandlePressed(Gesture.OnPress evt, UIControlVisuals control) => control.UpdateVisualState(VisualState.Pressed);

        /// <summary>
        /// A utility method to restore the visual state of <see cref="UIControlVisuals"/> object when its active gesture is released.
        /// </summary>
        /// <param name="evt">The release event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the release event.</param>
        /// <param name="index">Unused here, but this is the index into the data source of list view invoking this event.</param>
        public static void HandleReleased(Gesture.OnRelease evt, UIControlVisuals control, int index) => HandleReleased(evt, control);

        /// <summary>
        /// A utility method to restore the visual state of <see cref="UIControlVisuals"/> object when its active gesture is released.
        /// </summary>
        /// <param name="evt">The release event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the release event.</param>
        public static void HandleReleased(Gesture.OnRelease evt, UIControlVisuals control) => control.UpdateVisualState(evt.Hovering ? VisualState.Hovered : VisualState.Default);

        /// <summary>
        /// A utility method to restore the visual state of <see cref="UIControlVisuals"/> object when its active gesture is canceled.
        /// </summary>
        /// <param name="evt">The cancel event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the cancel gesture event.</param>
        /// <param name="index">Unused here, but this is the index into the data source of list view invoking this event.</param>
        public static void HandlePressCanceled(Gesture.OnCancel evt, UIControlVisuals control, int index) => HandlePressCanceled(evt, control);

        /// <summary>
        /// A utility method to restore the visual state of <see cref="UIControlVisuals"/> object when its active gesture is canceled.
        /// </summary>
        /// <param name="evt">The cancel event.</param>
        /// <param name="control">The <see cref="ItemVisuals"/> receiving the cancel gesture event.</param>
        public static void HandlePressCanceled(Gesture.OnCancel evt, UIControlVisuals control) => control.UpdateVisualState(VisualState.Default);
    }

    internal struct ControlColorAnimation : IAnimation
    {
        public UIBlock Target;
        public Color TargetColor;
        private Color startColor;

        public void Update(float percentDone)
        {
            if (Target == null)
            {
                return;
            }

            if (percentDone == 0)
            {
                startColor = Target.Color;
            }

            Target.Color = Color.Lerp(startColor, TargetColor, percentDone);
        }
    }
}
