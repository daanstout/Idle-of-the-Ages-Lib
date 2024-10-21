// <copyright file="HtmlStarterState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine.HtmlParsing;

/// <summary>
/// The initial state to parse a HTML file.
/// </summary>
public class HtmlStarterState : State<ParserData<HtmlNode>> {
    /// <summary>
    /// Gets a static instance to use.
    /// </summary>
    public static HtmlStarterState Instance { get; } = new();

    private HtmlStarterState() { }

    /// <inheritdoc/>
    public override Result<State<ParserData<HtmlNode>>> Tick(ParserData<HtmlNode> input) {
        if (input.ParsingInput.IsFinished)
            return Finish();

        if (input.ParsingInput.GetCurrentChar() == '<') {
            if (!input.ParsingInput.Advance())
                return (null, $"Encountered an opening bracket at {input.ParsingInput.CurrentCharacterIndex - 1}, but then the input ended!");

            return ElementParserState.Instance;
        }

        return this;
    }
}
