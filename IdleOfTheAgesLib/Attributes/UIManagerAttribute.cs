using IdleOfTheAgesLib.UI;

using System;

namespace IdleOfTheAgesLib {
    /// <summary>
    /// Indicates that a class is an UI <see cref="Element"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UIManagerAttribute : Attribute {
        /// <summary>
        /// The type of the element this manager manages.
        /// </summary>
        public Type ManagerInterfaceType { get; }

        /// <summary>
        /// The identifier of the UI attribute.
        /// </summary>
        public string? Identifier { get; }

        /// <summary>
        /// Instantiates a new UI ELement Attribute.
        /// </summary>
        /// <param name="managerInterfaceType">The type of the manager interface this manager implements.</param>
        /// <param name="identifier">The identifier of the attribute.</param>
        public UIManagerAttribute(Type managerInterfaceType, string? identifier = null) {
            ManagerInterfaceType = managerInterfaceType;
            Identifier = identifier;
        }
    }
}
