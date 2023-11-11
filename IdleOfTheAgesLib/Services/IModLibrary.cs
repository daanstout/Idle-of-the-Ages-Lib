using IdleOfTheAgesLib.Data;

namespace IdleOfTheAgesLib {
    /// <summary>
    /// Contains all mods that have been loaded.
    /// </summary>
    public interface IModLibrary {
        /// <summary>
        /// Registers a mod to the mod library.
        /// </summary>
        /// <param name="namespace">The namespace of the mod.</param>
        /// <param name="modObject">The mod object.</param>
        Result RegisterMod(string @namespace, IModObject modObject);

        /// <summary>
        /// Checks whether a mod with the specified <paramref name="namespace"/> exists.
        /// </summary>
        /// <param name="namespace">The namespace to check for.</param>
        /// <returns><see langword="true"/> if the mod exists.</returns>
        Result ModExists(string @namespace);

        /// <summary>
        /// Gets the mod object of a mod.
        /// </summary>
        /// <param name="namespace">The namespace of the mod to get the mod object for.</param>
        /// <returns>The requested mod object.</returns>
        Result<IModObject> GetModObject(string @namespace);
    }
}
