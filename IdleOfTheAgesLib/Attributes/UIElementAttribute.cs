using IdleOfTheAgesLib.UI;

using System;

namespace IdleOfTheAgesLib.Attributes {
    /// <summary>
    /// Indicates that a class is an UI <see cref="Element"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UIElementAttribute : Attribute {
        /// <summary>
        /// The identifier of the UI attribute.
        /// </summary>
        public string? Identifier { get; }

        /// <summary>
        /// Instantiates a new UI ELement Attribute.
        /// </summary>
        /// <param name="identifier">The identifier of the attribute.</param>
        public UIElementAttribute(string? identifier = null) {
            Identifier = identifier;
        }
    }
}
