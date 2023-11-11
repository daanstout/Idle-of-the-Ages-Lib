namespace IdleOfTheAgesLib.Services {
    /// <summary>
    /// Allows for loading in <see cref="Models.ModJsonData.ModData"/> objects.
    /// </summary>
    public interface IDataLoader {
        /// <summary>
        /// Loads in a <see cref="Models.ModJsonData.ModData"/> object from the mod folder.
        /// </summary>
        /// <param name="path">The path to the json file.</param>
        Result LoadData(string path);

        /// <summary>
        /// Registers textures from this mod to the game.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="includeSubFolders">Whether or not to also include textures in sub-folders.</param>
        Result RegisterTextures(string rootPath, bool includeSubFolders = true);
    }
}
