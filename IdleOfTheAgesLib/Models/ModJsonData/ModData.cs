using Newtonsoft.Json;

using System;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// The data class is used for defining mod gameplay data.
    /// </summary>
    public class ModData {
        /// <summary>
        /// The namespace the data sits in.
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; } = string.Empty;

        /// <summary>
        /// The ages that the mod adds.
        /// </summary>
        [JsonProperty("ages")]
        public AgeData[] Ages { get; set; } = Array.Empty<AgeData>();

        /// <summary>
        /// The skill categories that the mod adds.
        /// </summary>
        [JsonProperty("skill_categories")]
        public SkillCategoryData[] SkillCategories { get; set; } = Array.Empty<SkillCategoryData>();

        /// <summary>
        /// The skills that the mod adds.
        /// </summary>
        [JsonProperty("skills")]
        public SkillData[] Skills { get; set; } = Array.Empty<SkillData>();
    }
}
