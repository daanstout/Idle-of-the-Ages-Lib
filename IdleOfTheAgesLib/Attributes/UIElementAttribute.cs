using IdleOfTheAgesLib.UI;

using System;
using System.Collections.Generic;
using System.Text;

namespace IdleOfTheAgesLib.Attributes {
    /// <summary>
    /// Indicates that the class creates <see cref="Element"/>s.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UIElementAttribute : Attribute{
        /// <summary>
        /// The type of the interface this element implements.
        /// </summary>
        public Type ElementInterface { get; }

        /// <summary>
        /// The key to identify this class implementation.
        /// </summary>
        public string? Key { get; }

        /// <summary>
        /// Instantiates a new <see cref="UIElementAttribute"/>.
        /// </summary>
        /// <param name="elementInterface">The type of the interface this element implements.</param>
        /// <param name="key">The key to identify this class implementation.</param>
        public UIElementAttribute(Type elementInterface, string? key = null) {
            ElementInterface = elementInterface;
            Key = key;
        }
    }
}
