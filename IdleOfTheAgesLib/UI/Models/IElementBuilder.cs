// <copyright file="IElementBuilder.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using HtmlAgilityPack;

namespace IdleOfTheAgesLib.UI.Models;

/// <summary>
/// Represents a class that can build elements.
/// </summary>
public interface IElementBuilder {
    /// <summary>
    /// Builds a UI element based on the provided html and styles.
    /// </summary>
    /// <param name="html">The html to build.</param>
    /// <param name="styleData">The style data to use.</param>
    /// <returns>The created UI element.</returns>
    Result<IUIElement> Build(HtmlNode html, StyleData styleData);
}
