// <copyright file="ParserData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;

/// <summary>
/// Contains the state of the parser.
/// </summary>
/// <typeparam name="T">The type of node being parsed.</typeparam>
public class ParserData<T> where T : Node<T>, new() {
    /// <summary>
    /// Gets the root node of the parsed HTML.
    /// </summary>
    public T RootNode { get; }

    /// <summary>
    /// Gets or sets the current node that is being parsed.
    /// </summary>
    public T CurrentNode { get; set; }

    /// <summary>
    /// Gets the parsing input to the parser.
    /// </summary>
    public ParsingInput ParsingInput { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="CurrentNode"/> should be closed when the current tag is finished parsing.
    /// </summary>
    public bool CloseNodeWhenFinished { get; set; } = false;

    /// <summary>
    /// Gets or sets the state to return to when finishing certain tasks.
    /// </summary>
    public State<ParserData<T>>? StateToReturnTo { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ParserData{T}"/> class.
    /// </summary>
    /// <param name="input">The input to parse.</param>
    public ParserData(string input) {
        RootNode = new T() {
            Identifier = "root",
        };
        CurrentNode = RootNode;
        ParsingInput = new ParsingInput(input);
    }
}
