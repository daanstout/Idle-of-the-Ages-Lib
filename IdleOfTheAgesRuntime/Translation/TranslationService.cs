// <copyright file="TranslationService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Translation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IdleOfTheAgesRuntime.Translation;

/// <summary>
/// Allows for translation of text.
/// </summary>
[Service<ITranslationService>(ServiceLevel = ServiceLevelEnum.Public)]
public class TranslationService : ITranslationService {
    /// <inheritdoc/>
    public string CurrentLanguage { get; private set; } = string.Empty;

    /// <inheritdoc/>
    public event Action<string>? LanguageChangedEvent;

    private readonly Dictionary<string, HashSet<string>> languagePaths = [];
    private readonly Dictionary<string, string> translations = [];

    /// <inheritdoc/>
    public Result ChangeLanguage(string language) {
        if (language == CurrentLanguage) {
            return true;
        }

        CurrentLanguage = language;

        LoadLanguage(CurrentLanguage);

        LanguageChangedEvent?.Invoke(language);

        return true;
    }

    /// <inheritdoc/>
    public Result<string> GetLanguageString(string key) {
        return translations[key];
    }

    /// <inheritdoc/>
    public Result LoadLanguagePath(string language, string path) {
        if (!languagePaths.TryGetValue(language, out var paths)) {
            paths = [];
            languagePaths[language] = paths;
        }

        paths.Add(path);

        if (language == CurrentLanguage) {
            LoadFile(path);
        }

        return true;
    }

    private void LoadLanguage(string language) {
        if (!languagePaths.TryGetValue(language, out var paths)) {
            return;
        }

        translations.Clear();

        foreach (var file in paths) {
            LoadFile(file);
        }
    }

    private void LoadFile(string path) {
        var contents = File.ReadAllLines(path);

        foreach (var line in contents) {
            var split = line.Split('=');
            if (!translations.ContainsKey(split[0])) {
                translations[split[0]] = split[1];
            }
        }
    }
}
