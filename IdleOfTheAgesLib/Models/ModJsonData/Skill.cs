using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// Represents the data for a skill that is being added.
    /// </summary>
    public class Skill : BaseDataObject {
        /// <inheritdoc/>
        [JsonProperty("skill_category")]
        public string SkillCategory { get; set; } = string.Empty;

        /// <inheritdoc/>
        [JsonProperty("unlock_age")]
        public string UnlockAge { get; set; } = string.Empty;
    }
}
