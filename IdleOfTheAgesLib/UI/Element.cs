// <copyright file="Element.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// Base class for building a visual element container.
    /// </summary>
    public abstract class Element : IElement {
        /// <summary>
        /// Gets the child elements of this element.
        /// </summary>
        protected List<Element> ChildElements => childElements;

        private readonly List<Element> childElements = new List<Element>();

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
        [Obsolete("Initialization happens with Initialize method that requires a data model to be passed into.")]
        public virtual void Initialize() { }

        /// <summary>
        /// Rebuilds the element and its child elements.
        /// <para>This function breaks down and rebuilds from the ground up when called.</para>
        /// </summary>
        /// <returns>Returns its <see cref="VisualElement"/> to show.</returns>
        public abstract VisualElement GetVisualElement();

        /// <summary>
        /// Applies a <see cref="IManipulator"/> on the <see cref="VisualElement"/>.
        /// </summary>
        /// <param name="manipulator">The <see cref="IManipulator"/> to apply.</param>
        public abstract void ApplyManipulator(IManipulator manipulator);
    }

    /// <summary>
    /// Base class for building a visual element container.
    /// </summary>
    /// <typeparam name="TElement">The type of the <see cref="VisualElement"/> this element should create.</typeparam>
    /// <typeparam name="TDataModel">The type of the data model this element needs to render correctly.</typeparam>
    public abstract class Element<TElement, TDataModel> : Element, IElement<TDataModel>
        where TElement : VisualElement, new() {
        /// <summary>
        /// Gets the data for the visual element.
        /// </summary>
        protected TDataModel Data => data;

        private readonly TElement targetElement;
        private TDataModel data;
        private bool dirty = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Element{TElement, TDataModel}"/> class.
        /// </summary>
        protected Element() : base() {
            targetElement = new TElement {
                name = GetType().Name,
            };
            data = default!;
        }

        /// <summary>
        /// Should not be used. Throws an exception. Instead, call <see cref="Initialize(TDataModel)"/>.
        /// </summary>
        [Obsolete("Use initialize(TDataModel)")]
        public override void Initialize() => throw new NotImplementedException();

        /// <inheritdoc/>
        public void Initialize(TDataModel data) {
            this.data = data;
            dirty = true;
        }

        /// <inheritdoc/>
        public sealed override VisualElement GetVisualElement() {
            if (dirty) {
                dirty = false;
                return RebuildInternal();
            } else {
                return targetElement;
            }
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
        /// Internal rebuild function that returns the target visual element generically.
        /// </summary>
        /// <returns>The target element.</returns>
        protected virtual TElement RebuildInternal() {
            targetElement.Clear();

            return targetElement;
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
