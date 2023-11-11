using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// An age that the player can be in.
    /// </summary>
    public class Age : BaseDataObject {
        /// <inheritdoc/>
        [JsonProperty("after")]
        public string After { get; set; } = string.Empty;
    }
}
