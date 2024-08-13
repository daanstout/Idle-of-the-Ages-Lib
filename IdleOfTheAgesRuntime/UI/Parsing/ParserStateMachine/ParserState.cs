// <copyright file="ParserState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;

/// <summary>
/// Contains the state of the parser.
/// </summary>
public class ParserState {
    /// <summary>
    /// Gets the HTML to parse.
    /// </summary>
    public string Html { get; init; } = string.Empty;

    /// <summary>
    /// Gets the root node of the parsed HTML.
    /// </summary>
    public Node RootNode { get; }

    /// <summary>
    /// Gets or sets the current node that is being parsed.
    /// </summary>
    public Node CurrentNode { get; set; }

    /// <summary>
    /// Gets or sets the current character index that is being parsed.
    /// </summary>
    public int CurrentCharacterIndex { get; set; } = 0;

    /// <summary>
    /// Gets the current character that is being parsed.
    /// </summary>
    public char CurrentLineCharacter => Html[CurrentCharacterIndex];

    /// <summary>
    /// Gets a value indicating whether the current line has finished being parsed.
    /// </summary>
    public bool IsFinished => CurrentCharacterIndex >= Html.Length;

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="CurrentNode"/> should be closed when the current tag is finished parsing.
    /// </summary>
    public bool CloseNodeWhenFinished { get; set; } = false;

    /// <summary>
    /// Gets or sets the state to return to when finishing certain tasks.
    /// </summary>
    public State<ParserState>? StateToReturnTo { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ParserState"/> class.
    /// </summary>
    /// <param name="html">The html to parse.</param>
    public ParserState(string html) {
        RootNode = new("root");
        CurrentNode = RootNode;
        Html = html;
    }

    /// <summary>
    /// Reads the current character, and moving towards the next character.
    /// </summary>
    /// <returns>The character currently being processed.</returns>
    public char ReadCurrentChar() {
        char c = GetCurrentChar();
        CurrentCharacterIndex++;
        return c;
    }

    /// <summary>
    /// Gets the current character.
    /// </summary>
    /// <returns>The character currently being processed.</returns>
    public char GetCurrentChar() => Html[CurrentCharacterIndex];

    /// <summary>
    /// Reads the next word from the HTML, and moves towards the next character.
    /// </summary>
    /// <returns>The next word from the HTML.</returns>
    public string ReadCurrentWord() {
        string s = GetCurrentWord();
        CurrentCharacterIndex += s.Length;
        return s;
    }

    /// <summary>
    /// Gets the next word from the HTML.
    /// </summary>
    /// <returns>The next word from the HTML.</returns>
    public string GetCurrentWord() {
        SkipWhiteSpace();

        int i = CurrentCharacterIndex;

        while (char.IsLetterOrDigit(Html[i])) {
            i++;
        }

        return Html[CurrentCharacterIndex..i];
    }

    /// <summary>
    /// Skips characters until a non-whitespace character is encountered.
    /// </summary>
    public void SkipWhiteSpace() {
        while (char.IsWhiteSpace(GetCurrentChar())) {
            CurrentCharacterIndex++;
        }
    }

    /// <summary>
    /// Advances to the next character.
    /// </summary>
    /// <returns><see langword="true"/> if there are still more characters to process, otherwise <see langword="false"/>.</returns>
    public bool Advance() {
        CurrentCharacterIndex++;
        return CurrentCharacterIndex <= Html.Length;
    }
}
