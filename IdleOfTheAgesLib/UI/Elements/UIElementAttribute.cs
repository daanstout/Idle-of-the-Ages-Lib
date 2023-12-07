// <copyright file="UIElementAttribute.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.UI.Elements {
    /// <summary>
    /// Indicates that the class creates <see cref="Element"/>s.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UIElementAttribute : Attribute
    {
        /// <summary>
        /// Gets the type of the interface this element implements.
        /// </summary>
        public Type ElementInterface { get; }

        /// <summary>
        /// Gets the key to identify this class implementation.
        /// </summary>
        public string? Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIElementAttribute"/> class.
        /// </summary>
        /// <param name="elementInterface">The type of the interface this element implements.</param>
        /// <param name="key">The key to identify this class implementation.</param>
        public UIElementAttribute(Type elementInterface, string? key = null)
        {
            ElementInterface = elementInterface;
            Key = key;
        }
    }
}
