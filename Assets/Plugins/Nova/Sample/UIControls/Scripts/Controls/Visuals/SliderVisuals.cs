using Nova;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// The <see cref="ItemVisuals"/> type used to display a draggable <see cref="SliderSetting"/> control.
    /// </summary>
    [System.Serializable]
    [MovedFrom(false, null, "Assembly-CSharp")]
    public class SliderVisuals : UIControlVisuals
    {
        [Header("Slider Fields")]
        [Tooltip("The draggable bounds of the slider control.")]
        public UIBlock2D DraggableRange = null;
        [Tooltip("The UIBlock2D within the SliderBounds to indicate the selected slider value.")]
        public UIBlock2D FillBar = null;
        [Tooltip("The UIBlock2D positioned at moving edge of a fill bar.")]
        public UIBlock2D Knob = null;
        [Tooltip("The Textblock used to display the numerical value and units of the slider's selected value.")]
        public TextBlock Units = null;

        protected override UIBlock TransitionTargetFallback => Knob;
    }
}
