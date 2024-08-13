// <copyright file="ParserService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing;
using IdleOfTheAgesLib.UI.Parsing.Trees;
using IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;
using System.Collections.Generic;
using System.IO;

namespace IdleOfTheAgesRuntime.UI.Parsing;

/// <summary>
/// A service that parses HTML files into trees that can be used to create the UI.
/// </summary>
[Service<IParserService>(ServiceLevel = ServiceLevelEnum.Public)]
public class ParserService : IParserService {
    private readonly Dictionary<string, Node> parsedFiles = [];
    private readonly Dictionary<string, string> fileLocations = [];

    /// <inheritdoc/>
    public Result<Node> GetUI(string uiName) {
        if (parsedFiles.TryGetValue(uiName, out Node? uiNode)) {
            return uiNode;
        }

        if (!fileLocations.TryGetValue(uiName, out string? filePath)) {
            return (null, $"No ui with the name {uiName} has been registered!");
        }

        string html = File.ReadAllText(filePath);

        ParserState state = new(html);

        StateMachine<ParserState> stateMachine = new(StarterState.Instance);

        var result = stateMachine.RunToCompletion(state);

        if (!result) {
            return (null, $"An error occured while parsing the html", result.Errors);
        }

        parsedFiles[uiName] = result.Value!.RootNode;

        return result.Value!.RootNode;
    }

    /// <inheritdoc/>
    public Result RegisterFile(string uiName, string file) {
        if (fileLocations.ContainsKey(uiName)) {
            return (false, "A ui element with the provided name already exists!");
        }

        fileLocations[uiName] = file;

        return true;
    }
}
