using System;

namespace IdleOfTheAgesLib
{
    /// <summary>
    /// An attribute that can be applied to parameters to provide a key to the required dependency.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class DependencyIdentifierAttribute : Attribute
    {
        /// <summary>
        /// The key of the dependency instance to obtain.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Instantiates a new instance of the <see cref="DependencyIdentifierAttribute"/>.
        /// </summary>
        /// <param name="key">The key of the dependency instance to obtain.</param>
        public DependencyIdentifierAttribute(string key) => Key = key;
    }
}
