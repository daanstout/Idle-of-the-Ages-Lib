// <copyright file="ElementParserState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;

/// <summary>
/// A state that parses elements.
/// </summary>
public class ElementParserState : State<ParserState> {
    /// <summary>
    /// Gets a static instance to use.
    /// </summary>
    public static ElementParserState Instance { get; } = new();

    private ElementParserState() { }

    /// <inheritdoc/>
    public override Result<State<ParserState>> Tick(ParserState input) {
        if (input.GetCurrentChar() == '/') {
            input.CloseNodeWhenFinished = true;
            input.CurrentCharacterIndex++;
        }

        string htmlTag = input.ReadCurrentWord();

        if (input.CloseNodeWhenFinished) {
            if (input.CurrentNode.HtmlTag != htmlTag) {
                return (null, $"An incorrect tag-pair has been found! Tag {htmlTag} is trying to close {input.CurrentNode.HtmlTag} at {input.CurrentCharacterIndex}");
            }
        } else {
            Node newNode = new(htmlTag);
            input.CurrentNode.AddChildNode(newNode);
            input.CurrentNode = newNode;
        }

        return PostElementParserState.Instance;
    }
}
