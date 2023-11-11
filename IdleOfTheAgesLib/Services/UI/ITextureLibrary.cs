using UnityEngine;

namespace IdleOfTheAgesLib.Services.UI {
    /// <summary>
    /// A texture library where textures are loaded into.
    /// </summary>
    public interface ITextureLibrary {
        /// <summary>
        /// Registers textures within a root folder.
        /// </summary>
        /// <param name="textureID">The namespaced ID of the texture.</param>
        /// <param name="path">The path to the texture.</param>
        Result RegisterTextures(string textureID, string path);

        /// <summary>
        /// Gets a registered texture, loading it in if it's the first time it is requested.
        /// </summary>
        /// <param name="textureID">The texture to obtain.</param>
        /// <returns>The requested texture.</returns>
        Result<Texture2D?> GetTexture(string textureID);
    }
}
