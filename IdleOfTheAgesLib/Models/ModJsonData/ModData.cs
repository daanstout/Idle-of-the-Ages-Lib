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
        public Age[] Ages { get; set; } = Array.Empty<Age>();

        /// <summary>
        /// The skill categories that the mod adds.
        /// </summary>
        [JsonProperty("skill_categories")]
        public SkillCategory[] SkillCategories { get; set; } = Array.Empty<SkillCategory>();

        /// <summary>
        /// The skills that the mod adds.
        /// </summary>
        [JsonProperty("skills")]
        public Skill[] Skills { get; set; } = Array.Empty<Skill>();
    }
}
