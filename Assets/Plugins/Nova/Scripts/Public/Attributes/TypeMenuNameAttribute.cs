// Copyright (c) Supernova Technologies LLC
using System;

namespace Nova
{
    /// <summary>
    /// Provide a display name to show in the the <see cref="ItemVisuals"/> dropdown inspector in place of the class name.
    /// </summary>
    /// 
    /// 
    /// <example><code>
    /// 
    /// [TypeMenuName("Button")]
    /// public class MainMenuButtonVisuals : ItemVisuals
    /// {
    ///    // ...
    /// }
    /// 
    /// </code></example>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TypeMenuNameAttribute : Attribute
    {
        /// <summary>
        /// The string to display in place of the custom ItemVisuals's class name.
        /// </summary>
        public readonly string DisplayName;

        /// <summary>
        /// Constructs a new <see cref="TypeMenuNameAttribute">TypeMenuName</see>.
        /// </summary>
        /// <param name="displayName">The string to assign to <see cref="DisplayName"/></param>
        public TypeMenuNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
