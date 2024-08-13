// <copyright file="Languages.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IdleOfTheAgesLib.Translation;

/// <summary>
/// Contains the different languages that the game supports.
/// </summary>
public static class Languages {
    /// <summary>
    /// English American.
    /// </summary>
    public static readonly string EN_US = "en_US";

    /// <summary>
    /// Dutch.
    /// </summary>
    public static readonly string NL_NL = "nl_NL";

    /// <summary>
    /// Checks whether a language is supported by the game.
    /// </summary>
    /// <param name="language">The language to check for.</param>
    /// <returns><see langword="true"/> if the language is supported, otherwise <see langword="false"/>.</returns>
    public static bool IsLanguageSupported(string language) {
        return GetAllSupportedLanguages().Contains(language);
    }

    /// <summary>
    /// Gets all languages supported by the game.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> with all languages the game supports.</returns>
    public static IEnumerable<string> GetAllSupportedLanguages() {
        foreach (var field in typeof(Languages).GetFields(BindingFlags.Static | BindingFlags.Public)) {
            if (field.FieldType == typeof(string)) {
                yield return (string)field.GetValue(null)!;
            }
        }
    }
}
