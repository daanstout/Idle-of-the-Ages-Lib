// <copyright file="CssLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using ExCSS;
using IdleOfTheAgesLib;
using IdleOfTheAgesLib.IO;
using IdleOfTheAgesLib.UI.Services;
using System;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.UI.Services;

/// <summary>
/// Holds all loaded css rules.
/// </summary>
public class CssLibrary : ICssLibrary {
    private class StyleData {
        public required string Selector { get; init; }

        public List<StyleDeclaration> Stylesheets { get; } = [];
    }

    private readonly IFileLoader fileLoader;
    private readonly StylesheetParser stylesheetParser;

    private readonly Dictionary<string, StyleData> stylesheets = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="CssLibrary"/> class.
    /// </summary>
    /// <param name="fileLoader">The file loader to use to load files.</param>
    public CssLibrary(IFileLoader fileLoader) {
        this.fileLoader = fileLoader;
        stylesheetParser = new StylesheetParser();
    }

    /// <inheritdoc/>
    public Result RegisterCSS(string path) {
        var rawCss = fileLoader.ReadFile(path);

        if (!rawCss) {
            return (false, rawCss.Errors);
        }

        var stylesheet = stylesheetParser.Parse(rawCss);

        foreach (var rule in stylesheet.StyleRules) {
            if (!stylesheets.TryGetValue(rule.SelectorText, out var styleData)) {
                styleData = new StyleData {
                    Selector = rule.SelectorText,
                };
                stylesheets[rule.SelectorText] = styleData;
            }

            styleData.Stylesheets.Add(rule.Style);
        }

        return true;
    }

    /// <inheritdoc/>
    public IReadOnlyList<StyleDeclaration> GetStyleSheets(string selector) {
        if (!stylesheets.TryGetValue(selector, out var styleData)) {
            return [];
        }

        return styleData.Stylesheets;
    }
}
