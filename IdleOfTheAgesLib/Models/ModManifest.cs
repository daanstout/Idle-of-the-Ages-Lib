// <copyright file="ModManifest.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using Newtonsoft.Json;

using System;

namespace IdleOfTheAgesLib.Data {
    /// <summary>
    /// The data object of a mod's manifest.json.
    /// </summary>
    public class ModManifest {
        /// <summary>
        /// Gets or sets the namespace of a mod.
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the path to the mod's thumbnail.
        /// </summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the mod class.
        /// </summary>
        [JsonProperty("mod_class")]
        public string ModClass { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the dependencies of this mod.
        /// </summary>
        [JsonProperty("dependencies")]
        public string[] Dependencies { get; set; } = Array.Empty<string>();
    }
}
