﻿// <copyright file="PostElementParserState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;

/// <summary>
/// A state that decides what to do after parsing the tag's element.
/// </summary>
public class PostElementParserState : State<ParserState> {
    /// <summary>
    ///  Gets a static instance to use.
    /// </summary>
    public static PostElementParserState Instance { get; } = new();

    private PostElementParserState() { }

    /// <inheritdoc/>
    public override Result<State<ParserState>> Tick(ParserState input) {
        input.SkipWhiteSpace();

        if (input.GetCurrentChar() == '>') {
            if (!input.Advance()) {
                return (null, $"Encountered a closing bracket at {input.CurrentCharacterIndex - 1}, but then the input ended!");
            }

            if (input.CloseNodeWhenFinished) {
                input.CurrentNode = input.CurrentNode.Parent!;
                input.CloseNodeWhenFinished = false;
            }

            return StarterState.Instance;
        } else if (input.GetCurrentChar() == '/') {
            if (!input.Advance()) {
                return (null, $"Encountered a tag closing slash at {input.CurrentCharacterIndex - 1}, but then the input ended!");
            }

            if (input.GetCurrentChar() == '>') {
                if (!input.Advance()) {
                    return (null, $"Encountered a closing bracket at {input.CurrentCharacterIndex - 1}, but then the input ended!");
                }

                input.CurrentNode = input.CurrentNode.Parent!;

                return StarterState.Instance;
            } else {
                return (null, $"Encountered a tag closing slash at {input.CurrentCharacterIndex - 1}, but no closing bracket!");
            }
        } else {
            return MetadataParserState.Instance;
        }
    }
}