// <copyright file="ParserService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.IO;
using IdleOfTheAgesLib.UI.Parsing;
using IdleOfTheAgesLib.UI.Parsing.Trees;
using IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;
using IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine.HtmlParsing;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.UI.Parsing;

/// <summary>
/// A service that parses HTML files into trees that can be used to create the UI.
/// </summary>
[Service<IParserService>(ServiceLevel = ServiceLevelEnum.Public)]
public class ParserService : IParserService {
    private readonly Dictionary<string, HtmlNode> parsedFiles = [];
    private readonly IFileLoader fileLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParserService"/> class.
    /// </summary>
    /// <param name="fileLoader">The file loader to load the files with.</param>
    public ParserService(IFileLoader fileLoader) {
        this.fileLoader = fileLoader;
    }

    /// <inheritdoc/>
    public Result<HtmlNode> GetUI(string uiName) {
        if (parsedFiles.TryGetValue(uiName, out HtmlNode? uiNode)) {
            return uiNode;
        }

        var fileContents = fileLoader.GetFileContents(FileCategories.FILE_TYPE_HTML, uiName);

        if (!fileContents) {
            return (null, $"No ui with the name {uiName} has been registered!");
        }

        string html = fileContents;
        html = html.Replace("\r\n", string.Empty).Replace("\n", string.Empty);

        ParserData<HtmlNode> state = new(html);

        StateMachine<ParserData<HtmlNode>> stateMachine = new(HtmlStarterState.Instance);

        var result = stateMachine.RunToCompletion(state);

        if (!result) {
            return (null, $"An error occured while parsing the html", result.Errors);
        }

        parsedFiles[uiName] = result.Value!.RootNode;

        return result.Value!.RootNode;
    }
}
