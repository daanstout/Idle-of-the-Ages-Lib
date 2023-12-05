// <copyright file="TextureLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;

using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace IdleOfTheAgesRuntime.UI {
    /// <summary>
    /// A texture library where textures are loaded into.
    /// </summary>
    [Service(typeof(ITextureLibrary), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class TextureLibrary : ITextureLibrary {
        private readonly Dictionary<string, string> registeredTextures = new Dictionary<string, string>();
        private readonly Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();

        /// <inheritdoc/>
        public Result<Texture2D?> GetTexture(string textureID) {
            if (!loadedTextures.TryGetValue(textureID, out var result)) {
                if (!registeredTextures.TryGetValue(textureID, out var path)) {
                    return (null, $"No texture with ID {textureID} has been registered!");
                }

                result = LoadTexture(path);
                loadedTextures[textureID] = result;
            }

            return result;
        }

        /// <inheritdoc/>
        public Result RegisterTextures(string textureID, string path) {
            if (registeredTextures.ContainsKey(textureID))
                return (false, $"Texture with ID {textureID} has already been registered!");

            registeredTextures[textureID] = path;

            return true;
        }

        private static Texture2D LoadTexture(string path) {
            Texture2D texture = new Texture2D(2, 2);
            var imageBytes = File.ReadAllBytes(path);
            texture.LoadImage(imageBytes);
            return texture;
        }
    }
}
