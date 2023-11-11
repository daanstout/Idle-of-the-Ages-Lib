using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Data {
    /// <summary>
    /// The data object of a mod's manifest.json.
    /// </summary>
    public class ModManifest {
        /// <summary>
        /// The namespace of a mod.
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; } = string.Empty;

        /// <summary>
        /// The path to the mod's thumbnail.
        /// </summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; } = string.Empty;

        /// <summary>
        /// The name of the mod class.
        /// </summary>
        [JsonProperty("mod_class")]
        public string ModClass { get; set; } = string.Empty;
    }
}
