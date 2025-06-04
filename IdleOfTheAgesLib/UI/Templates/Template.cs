// <copyright file="Template.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using HtmlAgilityPack;

namespace IdleOfTheAgesLib.UI.Templates;

/// <summary>
/// Holds data for a given template.
/// </summary>
public class Template {
    /// <summary>
    /// Gets the HTML of the template.
    /// </summary>
    public required HtmlDocument HtmlDocument { get; init; }
}
