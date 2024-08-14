// <copyright file="IUIManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.UI;

/// <summary>
/// The UI manager that manages the UI of the application and is responsible for adding new UI.
/// <para>
/// This interface should be implemented by the UI framework.
/// </para>
/// </summary>
public interface IUIManager {
    /// <summary>
    /// Adds a piece of UI to the screen.
    /// </summary>
    /// <param name="uiID">The ID of the UI to add.</param>
    /// <param name="parentID">The ID of the parent node.</param>
    /// <returns>Returns whether the UI was succesfully added.</returns>
    Result AddUI(string uiID, string parentID);
}
