using Nova;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// An <see cref="ItemVisuals"/> for a simple button control with an image.
    /// </summary>
    [System.Serializable]
    [MovedFrom(false, null, "Assembly-CSharp")]
    public class ImageButtonVisuals : ButtonVisuals
    {
        [Tooltip("The button's image field.")]
        public UIBlock2D Image = null;
    }
}
