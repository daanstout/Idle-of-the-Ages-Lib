// <copyright file="IUIManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// A UI Factory that creates and manages.
    /// </summary>
    public interface IUIManager {
        /// <summary>
        /// Gets the UI Element this manager is managing.
        /// </summary>
        /// <returns>The UI Element this manager is managing.</returns>
        IElement GetElement();
    }

    /// <summary>
    /// A UI Factory that creates and manages.
    /// </summary>
    /// <typeparam name="TElement">The type of the element the manager is managing.</typeparam>
    public interface IUIManager<TElement> : IUIManager where TElement : IElement {
        /// <summary>
        /// Gets the UI Element this manager is managing.
        /// </summary>
        /// <returns>The UI Element this manager is managing.</returns>
        new TElement GetElement();
    }
}
