// <copyright file="CssStarterState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine.CssParsing;

/// <summary>
/// The initial state to parse a CSS file.
/// </summary>
public class CssStarterState : State<ParserData<CssNode>> {
    /// <summary>
    /// Gets a static instance to use.
    /// </summary>
    public static CssStarterState Instance { get; } = new();

    private CssStarterState() { }

    /// <inheritdoc/>
    public override Result<State<ParserData<CssNode>>> Tick(ParserData<CssNode> input) {
        if (input.ParsingInput.IsFinished)
            return Finish();

        return this;
    }
}
