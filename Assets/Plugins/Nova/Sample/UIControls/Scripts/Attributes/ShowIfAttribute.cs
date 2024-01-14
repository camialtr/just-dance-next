using System;
using UnityEngine;

namespace NovaSamples
{
    /// <summary>
    /// Hides the field/property unless the the compared property is equal to the designated visible value.
    /// </summary>
    /// <remarks>
    /// Only compares string, bool, float, int, and enum types.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class ShowIfAttribute : PropertyAttribute
    {
        public string compareToFieldName { get; private set; }
        public object visibleValue { get; private set; }

        /// <summary>
        /// Draws the field only if a compared field is equal to a designated value.
        /// </summary>
        /// <param name="compareToFieldName">The name of the property that is being compared (case sensitive).</param>
        /// <param name="visibleValue">The value the compared to field should equal in order for the decorated field to be visible.</param>
        public ShowIfAttribute(string compareToFieldName, object visibleValue)
        {
            this.compareToFieldName = compareToFieldName;
            this.visibleValue = visibleValue;
        }
    }
}
