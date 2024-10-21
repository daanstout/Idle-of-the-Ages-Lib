// <copyright file="MetadataParserState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine.HtmlParsing;

/// <summary>
/// A state that parses metadata.
/// </summary>
public class MetadataParserState : State<ParserData<HtmlNode>>
{
    /// <summary>
    ///  Gets a static instance to use.
    /// </summary>
    public static MetadataParserState Instance { get; } = new();

    private MetadataParserState() { }

    /// <inheritdoc/>
    public override Result<State<ParserData<HtmlNode>>> Tick(ParserData<HtmlNode> input)
    {
        string metadataKey = input.ParsingInput.ReadCurrentWord();

        if (!input.ParsingInput.Advance('='))
            return (null, $"Metadata tags should be followed by an equals sign!");

        if (!input.ParsingInput.Advance('"'))
            return (null, $"Metadata tags should be started with a '\"' character!");

        string metadataValue = input.ParsingInput.ReadCurrentWord(explicitlyAllowedCharacters: ['@', '(', ')']);

        if (!input.ParsingInput.Advance('"'))
            return (null, $"Metadata tags should end with a '\"' character!");

        input.CurrentNode.AddMetadata(metadataKey, metadataValue);

        return PostElementParserState.Instance;
    }
}
