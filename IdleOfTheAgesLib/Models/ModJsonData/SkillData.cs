using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// Represents the data for a skill that is being added.
    /// </summary>
    public class SkillData : ThumbnailDataElement {
        /// <summary>
        /// The skill category this Skill falls under.
        /// </summary>
        [JsonProperty]
        public string SkillCategory { get; private set; } = string.Empty;
        
        /// <summary>
        /// The age in which this skill is unlocked.
        /// </summary>
        [JsonProperty]
        public string UnlockAge { get; private set; } = string.Empty;

        /// <summary>
        /// The ID of the skill's UI class.
        /// </summary>
        [JsonProperty]
        public string SkillUI { get; private set; } = string.Empty;
    }
}
