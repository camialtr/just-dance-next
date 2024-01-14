using Nova;
using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// An abstract base class used to share common functionality of various UI controls (e.g. Button, Toggle, Slider, Dropdown, etc.) 
    /// </summary>
    /// <typeparam name="T">The type of <see cref="ItemVisuals"/> used to represent this UI control.</typeparam>

    [RequireComponent(typeof(ItemView))]
    public abstract class UIControl<T> : MonoBehaviour where T : ItemVisuals
    {
        /// <summary>
        /// The view holding the visuals representing this control
        /// </summary>
        private ItemView view = null;

        /// <summary>
        /// The view holding the visuals representing this control
        /// </summary>
        protected ItemView View
        {
            get
            {
                if (view == null)
                {
                    // ItemView is a required component, so it's safe to assume it's there.
                    view = GetComponent<ItemView>();

                    if (!(view.Visuals is T))
                    {
                        Debug.LogError($"Attached {nameof(ItemView)} expected to have a Visuals of Type {typeof(T).Name}", this);
                    }
                }

                return view;
            }
        }
    }
}
