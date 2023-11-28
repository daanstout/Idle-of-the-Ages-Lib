using System;

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// A library that registers UI Elements so they can be used by <see cref="IUIManager"/>s.
    /// </summary>
    public interface IElementLibrary {
        /// <summary>
        /// Registers an element to the library.
        /// </summary>
        /// <typeparam name="TInterface">The interface of the element to register.</typeparam>
        /// <typeparam name="TElement">The type of the element to register.</typeparam>
        /// <param name="key">The key of the element.</param>
        Result RegisterElement<TInterface, TElement>(string? key = null) where TInterface : IElement where TElement : Element;

        /// <summary>
        /// Registers an element to the library.
        /// </summary>
        /// <param name="interfaceType">The type of the interface of the element to register.</param>
        /// <param name="elementType">The type of the element to register.</param>
        /// <param name="key">The key of the element.</param>
        Result RegisterElement(Type interfaceType, Type elementType, string? key = null);

        /// <summary>
        /// Gets the element registered for the provided interface.
        /// </summary>
        /// <typeparam name="TElement">The interface to get the element for.</typeparam>
        /// <param name="key">The key the element is stored under.</param>
        /// <returns>The requested element.</returns>
        Result<TElement> GetElement<TElement>(string? key = null) where TElement : IElement;

        /// <summary>
        /// Gets the element registered for the provided interface.
        /// </summary>
        /// <param name="interfaceType">The interface to get the element for.</param>
        /// <param name="key">The key the element is stored under.</param>
        /// <returns>The requested element.</returns>
        Result<IElement> GetElement(Type interfaceType, string? key = null);
    }
}
