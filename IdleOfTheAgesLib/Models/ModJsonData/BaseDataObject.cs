using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// A base class for data objects.
    /// </summary>
    public class BaseDataObject {
        /// <inheritdoc/>
        public string Namespace { get; private set; } = string.Empty;

        /// <inheritdoc/>
        [JsonProperty]
        public string Name { get; private set; } = string.Empty;

        /// <inheritdoc/>
        [JsonProperty]
        public string ID { get; private set; } = string.Empty;

        /// <inheritdoc/>
        [JsonProperty]
        public string TranslationKey { get; private set; } = string.Empty;

        /// <inheritdoc/>
        [JsonProperty]
        public string? Thumbnail { get; private set; } = string.Empty;

        /// <inheritdoc/>
        public string ObjectIdentifier => $"{Namespace}:{ID}";
    }
}
