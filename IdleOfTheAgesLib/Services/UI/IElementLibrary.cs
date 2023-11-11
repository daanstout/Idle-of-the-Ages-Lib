using IdleOfTheAgesLib.UI;

using System;

namespace IdleOfTheAgesLib.Services.UI {
    /// <summary>
    /// A library that contains the registered element pieces.
    /// <para>With <see cref="Create{TElement}(string, string)"/>, an instance can be created.
    /// Afterwards, this instance can also be obtained through the <see cref="IUIService"/>.</para>
    /// </summary>
    public interface IElementLibrary {
        /// <summary>
        /// Registers an element to the library.
        /// </summary>
        /// <typeparam name="TElement">The type of the element to register.</typeparam>
        /// <param name="identifier">The identifier of the element.</param>
        void RegisterElement<TElement>(string? identifier = null);

        /// <summary>
        /// Registers an element to the library.
        /// </summary>
        /// <param name="type">The type of the element to register.</param>
        /// <param name="identifier">The identifier of the element.</param>
        void RegisterElement(Type type, string? identifier = null);

        /// <summary>
        /// Creates a new instance of an element with the specified identifier.
        /// </summary>
        /// <typeparam name="TElement">The type of the element to create.</typeparam>
        /// <param name="instanceIdentifier">The identifier for the newly created element.</param>
        /// <param name="identifier">The identifier of the element to create.</param>
        /// <returns>The newly created element.</returns>
        Result<TElement> Create<TElement>(string instanceIdentifier, string? identifier = null) where TElement : Element;

        /// <summary>
        /// Creates a new instance of an element with the specified identifier.
        /// </summary>
        /// <param name="type">The type of the element to create.</param>
        /// <param name="instanceIdentifier">The identifier for the newly created element.</param>
        /// <param name="identifier">The identifier of the element to create.</param>
        /// <returns>The newly created element.</returns>
        Result<Element> Create(Type type, string instanceIdentifier, string? identifier = null);
    }
}
