namespace IdleOfTheAgesLib {
    /// <summary>
    /// Allows for loading in <see cref="Models.ModJsonData.ModData"/> objects.
    /// </summary>
    public interface IDataLoader {
        /// <summary>
        /// Loads in a <see cref="Models.ModJsonData.ModData"/> object from the mod folder.
        /// </summary>
        /// <param name="pathSegments">The path to the json file.</param>
        Result LoadData(params string[] pathSegments);

        /// <summary>
        /// Registers textures from this mod to the game.
        /// </summary>
        /// <param name="pathSegments">The root path.</param>
        Result RegisterTextures(params string[] pathSegments);

        /// <summary>
        /// Loads the language files in the given path.
        /// </summary>
        /// <param name="pathSegments">The path the language files are located at.</param>
        Result LoadLanguages(params string[] pathSegments);
    }
}
