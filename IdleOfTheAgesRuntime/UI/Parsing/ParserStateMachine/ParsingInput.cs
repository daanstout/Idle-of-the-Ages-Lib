// <copyright file="ParsingInput.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Linq;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;

/// <summary>
/// Contains the input being parsed.
/// </summary>
public class ParsingInput {
    /// <summary>
    /// Gets the HTML to parse.
    /// </summary>
    public string Input { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the current character index that is being parsed.
    /// </summary>
    public int CurrentCharacterIndex { get; set; } = 0;

    /// <summary>
    /// Gets the current character that is being parsed.
    /// </summary>
    public char CurrentLineCharacter => Input[CurrentCharacterIndex];

    /// <summary>
    /// Gets a value indicating whether the current line has finished being parsed.
    /// </summary>
    public bool IsFinished => CurrentCharacterIndex >= Input.Length;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParsingInput"/> class.
    /// </summary>
    /// <param name="input">The input that is being parsed.</param>
    public ParsingInput(string input) {
        this.Input = input;
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
    public char GetCurrentChar() => Input[CurrentCharacterIndex];

    /// <summary>
    /// Reads the next word from the HTML, and moves towards the next character.
    /// </summary>
    /// <param name="charactersFlags">The character types that are allowed.</param>
    /// <param name="explicitlyAllowedCharacters">Explicitly allowed characters.</param>
    /// <returns>The next word from the HTML.</returns>
    public string ReadCurrentWord(CharactersFlags charactersFlags = CharactersFlags.AlphaNumerical, char[]? explicitlyAllowedCharacters = null) {
        string s = GetCurrentWord(charactersFlags, explicitlyAllowedCharacters);
        CurrentCharacterIndex += s.Length;
        return s;
    }

    /// <summary>
    /// Gets the next word from the HTML.
    /// </summary>
    /// <param name="charactersFlags">The character types that are allowed.</param>
    /// <param name="explicitlyAllowedCharacters">Explicitly allowed characters.</param>
    /// <returns>The next word from the HTML.</returns>
    public string GetCurrentWord(CharactersFlags charactersFlags = CharactersFlags.AlphaNumerical, char[]? explicitlyAllowedCharacters = null) {
        SkipWhiteSpace();

        int i = CurrentCharacterIndex;

        while (IsCharacterAllowed(Input[i], charactersFlags, explicitlyAllowedCharacters ?? [])) {
            i++;
        }

        return Input[CurrentCharacterIndex..i];
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
        return CurrentCharacterIndex <= Input.Length;
    }

    /// <summary>
    /// Advances to the next character if the current character is equal to <paramref name="character"/>.
    /// </summary>
    /// <param name="character">The character the current character needs to be to advance.</param>
    /// <returns>
    /// <see langword="true"/> if there are still more characters to process and the current character is equal to the <paramref name="character"/>,
    /// otherwise <see langword="false"/>.
    /// </returns>
    public bool Advance(char character) {
        if (Input[CurrentCharacterIndex] != character) {
            return false;
        }

        return Advance();
    }

    private static bool IsCharacterAllowed(char character, CharactersFlags charactersFlags, char[] explicitlyAllowedCharacters) {
        if (charactersFlags.HasFlag(CharactersFlags.Letters) && char.IsLetter(character)) {
            return true;
        } else if (charactersFlags.HasFlag(CharactersFlags.Letters) && char.IsDigit(character)) {
            return true;
        } else if (charactersFlags.HasFlag(CharactersFlags.Letters) && char.IsControl(character)) {
            return true;
        } else if (explicitlyAllowedCharacters.Contains(character)) {
            return true;
        }

        return false;
    }
}

/// <summary>
/// An enum that can be used to indicate character types.
/// </summary>
[Flags]
public enum CharactersFlags {
    /// <summary>
    /// No characters match the flag.
    /// </summary>
    None = 0 << 0,

    /// <summary>
    /// Letters match the flag.
    /// </summary>
    Letters = 1 << 0,

    /// <summary>
    /// Numbers match the flag.
    /// </summary>
    Numbers = 1 << 1,

    /// <summary>
    /// Control characters match the flag.
    /// </summary>
    Control = 1 << 2,

    /// <summary>
    /// Numbers and letters match the flag.
    /// </summary>
    AlphaNumerical = Letters | Numbers,
}
