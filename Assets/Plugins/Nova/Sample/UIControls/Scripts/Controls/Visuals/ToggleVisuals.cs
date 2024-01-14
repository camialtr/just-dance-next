using Nova;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// An <see cref="ItemVisuals"/> for a simple toggle control. Inherits from <see cref="ButtonVisuals"/>.
    /// </summary>
    [System.Serializable]
    [MovedFrom(false, null, "Assembly-CSharp")]
    public class ToggleVisuals : ButtonVisuals
    {
        [Header("Toggle Fields")]
        [Tooltip("The UIBlock used to indicate the underlying \"Toggled On\" or \"Toggled Off\" state.")]
        public UIBlock IsOnIndicator;
    }
}