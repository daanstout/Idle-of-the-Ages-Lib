// <copyright file="IDataLoader.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models;

namespace IdleOfTheAgesLib {
    /// <summary>
    /// Allows for loading in <see cref="ModData"/> objects.
    /// </summary>
    public interface IDataLoader {
        /// <summary>
        /// Loads in a <see cref="ModData"/> object from the mod folder.
        /// </summary>
        /// <param name="pathSegments">The path to the json file.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result LoadData(params string[] pathSegments);

        /// <summary>
        /// Registers textures from this mod to the game.
        /// </summary>
        /// <param name="pathSegments">The root path.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterTextures(params string[] pathSegments);

        /// <summary>
        /// Loads the language files in the given path.
        /// </summary>
        /// <param name="pathSegments">The path the language files are located at.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result LoadLanguages(params string[] pathSegments);
    }
}
