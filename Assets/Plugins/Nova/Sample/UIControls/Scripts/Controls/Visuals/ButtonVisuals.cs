using Nova;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// An <see cref="ItemVisuals"/> for a simple button control.
    /// </summary>
    [System.Serializable]
    [MovedFrom(false, null, "Assembly-CSharp")]
    public class ButtonVisuals : UIControlVisuals
    {
        [Space]
        [Tooltip("The button's background UIBlock.")]
        public UIBlock2D Background = null;
        [Tooltip("The TextBlock to display the button's label.")]
        public TextBlock Label = null;

        protected override UIBlock TransitionTargetFallback => Background;
    }
}
