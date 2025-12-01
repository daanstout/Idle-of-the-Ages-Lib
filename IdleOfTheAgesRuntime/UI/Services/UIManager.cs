// <copyright file="UIManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI.Models;
using IdleOfTheAgesLib.UI.Services;
using IdleOfTheAgesRuntime.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleOfTheAgesRuntime.UI.Services;

/// <summary>
/// Manages the game's UI.
/// </summary>
[Service<IUIManager>]
public class UIManager : IUIManager {
    /// <inheritdoc/>
    public IUIElement Root { get; }

    private readonly Dictionary<string, IUIElement> elements = [];
    private readonly ITemplateLibrary templateLibrary;

    /// <summary>
    /// Initializes a new instance of the <see cref="UIManager"/> class.
    /// </summary>
    /// <param name="templateLibrary">The template library to get templates from.</param>
    public UIManager(ITemplateLibrary templateLibrary) {
        this.templateLibrary = templateLibrary;

        Root = new UIElement {
            ID = "ROOT",
            Classes = [],
        };

        elements.Add("ROOT", Root);
    }

    /// <inheritdoc/>
    public Result<IUIElement> AddUI(string parentID, string templateID) {
        if (string.IsNullOrWhiteSpace(parentID)) {
            return (null, "Provided parent ID is null or whitespace", new ArgumentNullException(nameof(parentID)));
        }

        if (!elements.TryGetValue(parentID, out IUIElement? element)) {
            return (null, $"No UI element with the ID {parentID} could be found", new ArgumentException($"No UI element with the ID {parentID} could be found", nameof(parentID)));
        }

        if (string.IsNullOrWhiteSpace(templateID)) {
            return (null, "Provided template ID is null or whitespace", new ArgumentNullException(nameof(templateID)));
        }

        var template = templateLibrary.GetTemplate(templateID);
        if (!template) {
            return (null, "Could not find the template", template.Errors);
        }

        return (null, string.Empty);
    }

    /// <inheritdoc/>
    public Result<IUIElement> GetUI(string id) => throw new NotImplementedException();
}
