// <copyright file="TranslationService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Translation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IdleOfTheAgesRuntime.Translation {
    /// <summary>
    /// Allows for translation of text.
    /// </summary>
    [Service(typeof(ITranslationService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class TranslationService : ITranslationService {
        /// <inheritdoc/>
        public Language CurrentLanguage { get; private set; }

        /// <inheritdoc/>
        public event Action<Language>? LanguageChangedEvent;

        private readonly Dictionary<Language, HashSet<string>> languagePaths = new Dictionary<Language, HashSet<string>>();
        private readonly Dictionary<string, string> translations = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationService"/> class.
        /// </summary>
        public TranslationService() {
            foreach (var language in Enum.GetValues(typeof(Language)).Cast<Language>()) {
                languagePaths[language] = new HashSet<string>();
            }
        }

        /// <inheritdoc/>
        public Result ChangeLanguage(Language language) {
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
        public Result LoadLanguagePath(Language language, string path) {
            languagePaths[language].Add(path);

            if (language == CurrentLanguage) {
                LoadFile(path);
            }

            return true;
        }

        private void LoadLanguage(Language language) {
            translations.Clear();

            foreach (var file in languagePaths[language]) {
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
}
