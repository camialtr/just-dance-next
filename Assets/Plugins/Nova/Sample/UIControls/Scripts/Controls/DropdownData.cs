using System;
using System.Collections.Generic;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// A data structure used to store the state of a dropdown UI control.
    /// </summary>
    [Serializable]
    public class DropdownData
    {
        public const string NothingSelected = "None";

        /// <summary>
        /// The index into the list of <see cref="Options"/> of the selected value.
        /// </summary>
        public int SelectedIndex;

        /// <summary>
        /// The list of selectable options the end-user can choose from for this given dropdown.
        /// </summary>
        public List<string> Options = new List<string>();

        /// <summary>
        /// The currently selected item, if one is selected, otherwise <see cref="NothingSelected"/>.
        /// </summary>
        public string CurrentSelection
        {
            get
            {
                if (Options == null || SelectedIndex < 0 || SelectedIndex >= Options.Count)
                {
                    // If the dropdown doesn't have any options or the
                    // SelectedIndex is out of range, indicate nothing selected.
                    return NothingSelected;
                }

                // Return the selected option
                return Options[SelectedIndex];
            }
        }
    }
}

