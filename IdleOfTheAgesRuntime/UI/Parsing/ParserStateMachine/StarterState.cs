// <copyright file="StarterState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;

/// <summary>
/// The initial state to parse a line.
/// </summary>
public class StarterState : State<ParserState> {
    /// <summary>
    /// Gets a static instance to use.
    /// </summary>
    public static StarterState Instance { get; } = new();

    private StarterState() { }

    /// <inheritdoc/>
    public override Result<State<ParserState>> Tick(ParserState input) {
        if (input.IsFinished)
            return Finish();

        if (input.GetCurrentChar() == '<') {
            if (!input.Advance()) {
                return (null, $"Encountered an opening bracket at {input.CurrentCharacterIndex - 1}, but then the input ended!");
            }

            return ElementParserState.Instance;
        }

        return this;
    }
}
