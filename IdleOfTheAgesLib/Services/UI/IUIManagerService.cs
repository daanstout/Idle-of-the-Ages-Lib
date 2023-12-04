// <copyright file="IUIManagerService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// A service to keep track of the <see cref="IUIManager"/> instances.
    /// </summary>
    public interface IUIManagerService {
        /// <summary>
        /// Registers a <see cref="IUIManager"/>.
        /// </summary>
        /// <typeparam name="TManagerInterface">The type of the UI manager interface.</typeparam>
        /// <typeparam name="TManagerImplementation">The type of the UI manager implementation.</typeparam>
        /// <param name="key">The key to get the specific manager.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterManager<TManagerInterface, TManagerImplementation>(string? key = null) where TManagerInterface : IUIManager where TManagerImplementation : TManagerInterface;

        /// <summary>
        /// Registers a <see cref="IUIManager"/>.
        /// </summary>
        /// <param name="managerInterfaceType">The type of the UI manager interface.</param>
        /// <param name="managerImplementationType">The type of the UI manager implementation.</param>
        /// <param name="key">The key to get the specific manager.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterManager(Type managerInterfaceType, Type managerImplementationType, string? key = null);

        /// <summary>
        /// Gets the UI manager for the specific UI element.
        /// </summary>
        /// <typeparam name="TManager">The type of the manager to get.</typeparam>
        /// <param name="instanceIdentifier">The identifier for the instance to get.</param>
        /// <param name="key">The key to the specific manager.</param>
        /// <returns>The requested UI Manager.</returns>
        Result<TManager> GetManager<TManager>(string instanceIdentifier, string? key = null) where TManager : IUIManager;

        /// <summary>
        /// Gets the UI manager for the specific UI element.
        /// </summary>
        /// <param name="managerType">The type of the manager to get.</param>
        /// <param name="instanceIdentifier">The identifier for the instance to get.</param>
        /// <param name="key">The key to the specific manager.</param>
        /// <returns>The requested UI Manager.</returns>
        Result<IUIManager> GetManager(Type managerType, string instanceIdentifier, string? key = null);
    }
}
