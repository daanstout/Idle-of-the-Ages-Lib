// <copyright file="MetadataParserState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;

/// <summary>
/// A state that parses metadata.
/// </summary>
public class MetadataParserState : State<ParserState> {
    /// <summary>
    ///  Gets a static instance to use.
    /// </summary>
    public static MetadataParserState Instance { get; } = new();

    private MetadataParserState() { }

    /// <inheritdoc/>
    public override Result<State<ParserState>> Tick(ParserState input) {
        string metadataKey = input.ReadCurrentWord();

        if (input.GetCurrentChar() != '=') {
            return (null, "Metadata tags should be followed by an equals sign!");
        }

        if (!input.Advance()) {
            return (null, $"Encountered no value for metadata tag at {input.CurrentCharacterIndex - 1}");
        }

        string metadataValue = input.ReadCurrentWord();

        input.CurrentNode.AddMetadata(metadataKey, metadataValue);

        return PostElementParserState.Instance;
    }
}
