// <copyright file="IUIBuilder.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Models;

namespace IdleOfTheAgesLib.UI.Services;

/// <summary>
/// Creates UI elements based on templates.
/// </summary>
public interface IUIBuilder {
    /// <summary>
    /// Builds a piece of UI based on the provided template.
    /// </summary>
    /// <param name="templateID">The template to use.</param>
    /// <returns>The created UI element.</returns>
    Result<IUIElement> BuildUI(string templateID);
}
