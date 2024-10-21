// <copyright file="IParserService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesLib.UI.Parsing;

/// <summary>
/// A service that parses HTML files into trees that can be used to create the UI.
/// </summary>
public interface IParserService {
    /// <summary>
    /// Gets the root <see cref="HtmlNode"/> for building the UI for the provided ui element.
    /// </summary>
    /// <param name="uiName">The name of the UI to get.</param>
    /// <returns>The root <see cref="HtmlNode"/> for the UI.</returns>
    Result<HtmlNode> GetUI(string uiName);
}
