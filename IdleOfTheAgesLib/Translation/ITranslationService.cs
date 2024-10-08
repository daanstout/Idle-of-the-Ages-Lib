﻿// <copyright file="ITranslationService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.Translation;

/// <summary>
/// Allows for translation of text.
/// </summary>
public interface ITranslationService {
    /// <summary>
    /// Gets the currently selected language.
    /// </summary>
    public string CurrentLanguage { get; }

    /// <summary>
    /// An event that gets fired when the language is changed.
    /// </summary>
    event Action<string> LanguageChangedEvent;

    /// <summary>
    /// Changes the language of the game.
    /// </summary>
    /// <param name="language">The new game language.</param>
    /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
    public Result ChangeLanguage(string language);

    /// <summary>
    /// Gets the language string for the given key.
    /// </summary>
    /// <param name="key">The key to translate.</param>
    /// <returns>The requested language string.</returns>
    public Result<string> GetLanguageString(string key);

    /// <summary>
    /// Loads the path of the memory file for the language into memory so it can be read if the language is needed.
    /// </summary>
    /// <param name="language">The language the file is for.</param>
    /// <param name="path">The path to the file.</param>
    /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
    public Result LoadLanguagePath(string language, string path);
}
