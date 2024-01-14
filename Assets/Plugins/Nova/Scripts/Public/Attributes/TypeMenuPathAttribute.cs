// Copyright (c) Supernova Technologies LLC
using System;

namespace Nova
{
    /// <summary>
    /// Organize the <see cref="ItemVisuals"/> dropdown by categories and subcategories.
    /// </summary>
    ///
    /// 
    /// <example>
    /// <code>
    /// [TypeMenuPath("My Project/Main Menu")]
    /// public class MainMenuButtonVisuals : ItemVisuals
    /// {
    ///    // ...
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TypeMenuPathAttribute : Attribute
    {
        /// <summary>
        /// The path to use, where each subpath is separated by \ or /.
        /// </summary>
        public readonly string Path;

        /// <summary>
        /// Constructs a new <see cref="TypeMenuPathAttribute">TypeMenuPath</see>.
        /// </summary>
        /// <param name="path">The string to assign to <see cref="Path"/></param>
        public TypeMenuPathAttribute(string path)
        {
            Path = path;
        }
    }
}
