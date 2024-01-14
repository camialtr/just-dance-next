using Nova;
using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// <see cref="ItemVisuals"/> type to use to target drag events around the perimeter of the window.
    /// </summary>
    /// <remarks> 
    /// Also allows assignment of a cursor texture, so the cursor can be changed when the region
    /// is interacted with.
    /// </remarks>
    /// <seealso cref="Window"/>
    /// <seealso cref="WindowBar"/>
    [TypeMenuPath("Nova")]
    public class WindowResizeRegion : ItemVisuals
    {
        [Tooltip("The cursor texture to display when this region is hovered.")]
        public Texture2D Cursor = null;
    }
}
