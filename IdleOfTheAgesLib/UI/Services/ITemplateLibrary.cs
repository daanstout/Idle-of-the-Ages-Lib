// <copyright file="ITemplateLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Templates;

namespace IdleOfTheAgesLib.UI.Services;

/// <summary>
/// Keeps track of all the templates that are available.
/// </summary>
public interface ITemplateLibrary {
    /// <summary>
    /// Gets a template.
    /// </summary>
    /// <param name="templateId">The template to obtain.</param>
    /// <returns>The requested template.</returns>
    Result<Template> GetTemplate(string templateId);
}
