namespace IdleOfTheAgesLib.Translation {
    /// <summary>
    /// Allows for translation of text.
    /// </summary>
    public interface ITranslationService {
        /// <summary>
        /// The currently selected language.
        /// </summary>
        public Language CurrentLanguage { get; }

        /// <summary>
        /// Changes the language of the game.
        /// </summary>
        /// <param name="language">The new game language.</param>
        public Result ChangeLanguage(Language language);

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
        public Result LoadLanguagePath(Language language, string path);
    }
}
