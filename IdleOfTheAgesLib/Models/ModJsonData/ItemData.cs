using Newtonsoft.Json;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// An item that can be obtained in the game.
    /// </summary>
    public class ItemData : ThumbnailDataElement {
        /// <summary>
        /// The key to the description of the item.
        /// </summary>
        [JsonProperty]
        public string DescriptionKey { get; private set; } = string.Empty;

        /// <summary>
        /// The sell price of this item.
        /// </summary>
        [JsonProperty]
        public int SellPrice { get; private set; }

        /// <summary>
        /// Metadata for this item.
        /// </summary>
        [JsonProperty]
        public Dictionary<string, object> Metadata { get; private set; } = new Dictionary<string, object>();

        /// <summary>
        /// The category of this item.
        /// <para>This is used for searching.</para>
        /// </summary>
        [JsonProperty]
        public string Category { get; private set; } = string.Empty;

        /// <summary>
        /// The type of item this is.
        /// <para>This is used for searching.</para>
        /// </summary>
        [JsonProperty]
        public string Type { get; private set; } = string.Empty;

        /// <summary>
        /// Whether this item is required for completing the game.
        /// </summary>
        [JsonProperty]
        public bool RequiredForCompletion { get; private set; }

        /// <summary>
        /// The item's tag. This indicates what type of item it is and is used for things such as storage and equipping.
        /// </summary>
        [JsonProperty]
        public string Tag { get; private set; } = string.Empty;
    }
}
