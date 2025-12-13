// <copyright file="TemplateLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using HtmlAgilityPack;
using IdleOfTheAgesLib;
using IdleOfTheAgesLib.IO;
using IdleOfTheAgesLib.UI.Services;
using IdleOfTheAgesLib.UI.Templates;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.UI.Services;

/// <summary>
/// Keeps track of all the templates that are available.
/// </summary>
[Service<ITemplateLibrary>]
public class TemplateLibrary : ITemplateLibrary {
    private readonly IFileLoader fileLoader;

    private readonly Dictionary<string, Template> templates = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="TemplateLibrary"/> class.
    /// </summary>
    /// <param name="fileLoader">The file loader to use.</param>
    public TemplateLibrary(IFileLoader fileLoader) {
        this.fileLoader = fileLoader;
    }

    /// <inheritdoc/>
    public Result<Template> GetTemplate(string templateId) {
        if (templates.TryGetValue(templateId, out var template)) {
            return template;
        }

        var html = fileLoader.GetFileContents(FileCategories.FILE_TYPE_HTML, templateId);

        if (!html) {
            return (null, html.Errors);
        }

        HtmlDocument document = new();
        document.LoadHtml(html);

        template = new Template {
            HtmlDocument = document,
        };
        templates[templateId] = template;

        return template;
    }
}
