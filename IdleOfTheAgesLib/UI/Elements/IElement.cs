// <copyright file="IElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using UnityEngine.UIElements;

namespace IdleOfTheAgesLib.UI.Elements {
    /// <summary>
    /// Base class for building a visual element container.
    /// </summary>
    public interface IElement {
        /// <summary>
        /// Rebuilds the element and its child elements.
        /// <para>This function breaks down and rebuilds from the ground up when called.</para>
        /// </summary>
        /// <returns>Returns its <see cref="VisualElement"/> to show.</returns>
        VisualElement GetVisualElement();

        /// <summary>
        /// Rebuilds the visual element.
        /// </summary>
        void RebuildVisualElement();
    }

    /// <summary>
    /// Base class for building a visual element container that requires initialization.
    /// </summary>
    /// <typeparam name="TDataModel">The type of the data model.</typeparam>
    public interface IElement<TDataModel> : IElement {
        /// <summary>
        /// Injects the element with its data model.
        /// </summary>
        /// <param name="data">The data the model needs to build itself.</param>
        void InjectData(TDataModel data);
    }
}