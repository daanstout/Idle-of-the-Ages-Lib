using IdleOfTheAgesLib.UI;

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// A service to interact with the UI elements that exist.
    /// </summary>
    public interface IUIService {
        /// <summary>
        /// Gets the root <see cref="Element"/>.
        /// </summary>
        /// <returns>The root UI element of the game.</returns>
        Result<Element> GetRoot();

        /// <summary>
        /// Adds an element to the UI Service that has been spawned to the screen.
        /// </summary>
        /// <param name="element">The element that was added.</param>
        /// <param name="identifier">The unique identifier of the element.</param>
        Result AddElement(Element element, string identifier);

        /// <summary>
        /// Gets an element that has been spawned.
        /// </summary>
        /// <typeparam name="TElement">The type of the element to obtain.</typeparam>
        /// <param name="identifier">The unique identifier of the element.</param>
        /// <returns>The requested element.</returns>
        Result<TElement> GetElement<TElement>(string identifier) where TElement : Element;

        /// <summary>
        /// Gets an element that has been spawned.
        /// </summary>
        /// <param name="identifier">The unique identifier of the element.</param>
        /// <returns>The requested element.</returns>
        Result<Element> GetElement(string identifier);
    }
}
