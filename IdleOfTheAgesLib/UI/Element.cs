using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// Base class for building a visual element container.
    /// </summary>
    public abstract class Element {
        /// <summary>
        /// The child elements of this element.
        /// </summary>
        protected readonly List<Element> childElements = new List<Element>();

        /// <summary>
        /// Adds a child element to this element.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void AddElement(Element element) {
            childElements.Add(element);
        }

        /// <summary>
        /// Inserts a child element into this element.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <param name="index">Where to insert the element.</param>
        public void InsertElement(Element element, int index) {
            childElements.Insert(index, element);
        }

        /// <summary>
        /// Initializes the element.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Rebuilds the element and its child elements.
        /// <para>This function breaks down and rebuilds from the ground up when called.</para>
        /// </summary>
        /// <returns>Returns its <see cref="VisualElement"/> to show.</returns>
        public abstract VisualElement Rebuild();

        /// <summary>
        /// Applies a <see cref="IManipulator"/> on the <see cref="VisualElement"/>.
        /// </summary>
        /// <param name="manipulator">The <see cref="IManipulator"/> to apply.</param>
        public abstract void ApplyManipulator(IManipulator manipulator);
    }

    /// <summary>
    /// Base class for building a visual element container.
    /// </summary>
    public abstract class Element<T> : Element
        where T : VisualElement, new() {
        private readonly T targetElement;

        /// <summary>
        /// Instantiates a new <see cref="Element{T}"/> object.
        /// </summary>
        protected Element() : base() {
            targetElement = new T {
                name = GetType().Name
            };
        }

        /// <inheritdoc/>
        public sealed override VisualElement Rebuild() {
            return RebuildInternal();
        }

        /// <summary>
        /// Internal rebuild function that returns the target visual element generically.
        /// </summary>
        /// <returns>The target element.</returns>
        protected virtual T RebuildInternal() {
            targetElement.Clear();

            return targetElement;
        }

        /// <inheritdoc/>
        public sealed override void ApplyManipulator(IManipulator manipulator) {
            targetElement.AddManipulator(manipulator);
        }

        /// <summary>
        /// Translates the element based on its <see cref="VisualElement.transform"/>.
        /// </summary>
        /// <param name="translation">How much to move it.</param>
        public void TranslateElement(Vector3 translation) {
            targetElement.transform.position += translation;
        }

        /// <summary>
        /// Registers a callback to the target element.
        /// </summary>
        /// <typeparam name="TEventType">The type of event to register to.</typeparam>
        /// <param name="callback">The callback that should be fired.</param>
        protected void RegisterCallback<TEventType>(EventCallback<TEventType> callback) where TEventType : EventBase<TEventType>, new() {
            targetElement.RegisterCallback(callback);
        }

        /// <summary>
        /// Unregisters a callback from the target element.
        /// </summary>
        /// <typeparam name="TEventType">The type of event to unregister from.</typeparam>
        /// <param name="callback">The callback that should be removed.</param>
        protected void UnregisterCallback<TEventType>(EventCallback<TEventType> callback) where TEventType : EventBase<TEventType>, new() {
            targetElement.UnregisterCallback(callback);
        }
    }
}
