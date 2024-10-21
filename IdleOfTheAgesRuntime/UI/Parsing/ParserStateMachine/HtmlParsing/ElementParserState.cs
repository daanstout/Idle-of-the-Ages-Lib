// <copyright file="ElementParserState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine.HtmlParsing;

/// <summary>
/// A state that parses elements.
/// </summary>
public class ElementParserState : State<ParserData<HtmlNode>> {
    /// <summary>
    /// Gets a static instance to use.
    /// </summary>
    public static ElementParserState Instance { get; } = new();

    private ElementParserState() { }

    /// <inheritdoc/>
    public override Result<State<ParserData<HtmlNode>>> Tick(ParserData<HtmlNode> input) {
        if (input.ParsingInput.GetCurrentChar() == '/') {
            input.CloseNodeWhenFinished = true;
            input.ParsingInput.CurrentCharacterIndex++;
        }

        string htmlTag = input.ParsingInput.ReadCurrentWord(CharactersFlags.AlphaNumerical);

        if (input.CloseNodeWhenFinished) {
            if (input.CurrentNode.Identifier != htmlTag)
                return (null, $"An incorrect tag-pair has been found! Tag {htmlTag} is trying to close {input.CurrentNode.Identifier} at {input.ParsingInput.CurrentCharacterIndex}");
        } else {
            HtmlNode newNode = new() {
                Identifier = htmlTag,
            };
            input.CurrentNode.AddChildNode(newNode);
            input.CurrentNode = newNode;
        }

        return PostElementParserState.Instance;
    }
}
