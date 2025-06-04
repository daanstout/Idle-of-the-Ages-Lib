// <copyright file="IUIManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Models;

namespace IdleOfTheAgesLib.UI.Services;

/// <summary>
/// Manages the game's UI.
/// </summary>
public interface IUIManager {
    /// <summary>
    /// Gets the root UI element.
    /// </summary>
    public IUIElement Root { get; }

    /// <summary>
    /// Adds a UI screen to the game.
    /// </summary>
    /// <param name="parentID">The ID of the parent element to add the UI to.</param>
    /// <param name="templateID">The ID of the template to add.</param>
    /// <returns>The newly created UI element.</returns>
    public Result<IUIElement> AddUI(string parentID, string templateID);

    /// <summary>
    /// Gets a UI element based on its ID.
    /// </summary>
    /// <param name="id">The ID of the element to get.</param>
    /// <returns>The requested UI element.</returns>
    public Result<IUIElement> GetUI(string id);
}
