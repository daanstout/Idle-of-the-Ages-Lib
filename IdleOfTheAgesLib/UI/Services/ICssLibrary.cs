// <copyright file="ICssLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using ExCSS;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Services;

/// <summary>
/// Keeps track of all the CSS rules that are available.
/// </summary>
public interface ICssLibrary {
    /// <summary>
    /// Gets all style sheets for a specific selector.
    /// </summary>
    /// <param name="selector">The selector to get the style sheets for.</param>
    /// <returns>The requested style sheets.</returns>
    IReadOnlyList<StyleDeclaration> GetStyleSheets(string selector);

    /// <summary>
    /// Loads all CSS files registered to the application.
    /// </summary>
    /// <remarks>
    /// Errors while loading specific files doesn't prevent the loading of other files.
    /// </remarks>
    /// <returns>Whether the style sheets were succesfully loaded.</returns>
    Result LoadCSS();

    /// <summary>
    /// Registers a CSS file to the library.
    /// </summary>
    /// <param name="path">The path to the CSS file.</param>
    /// <returns>A <see cref="Result"/> object to see if the file was succesfully registered.</returns>
    Result RegisterCSS(string path);
}
