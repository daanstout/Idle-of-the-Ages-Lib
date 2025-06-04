// <copyright file="StyleData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using ExCSS;
using IdleOfTheAgesLib.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAgesLib.UI.Models;

/// <summary>
/// Contains all the relevant styles as well as helper functions to get the required style information.
/// </summary>
public class StyleData {
    private readonly ICssLibrary cssLibrary;

    /// <summary>
    /// Initializes a new instance of the <see cref="StyleData"/> class.
    /// </summary>
    /// <param name="cssLibrary">The css library that contains all the css data.</param>
    public StyleData(ICssLibrary cssLibrary) {
        this.cssLibrary = cssLibrary;
    }

    /// <summary>
    /// Gets all styles for the specified class.
    /// </summary>
    /// <param name="className">The name of the class.</param>
    /// <returns>The requested styles information.</returns>
    public IReadOnlyList<StyleDeclaration> GetStyles(string className) {
        return cssLibrary.GetStyleSheets(className);
    }
}
