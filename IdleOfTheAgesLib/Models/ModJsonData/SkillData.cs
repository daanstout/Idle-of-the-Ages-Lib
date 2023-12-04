// <copyright file="SkillData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// Represents the data for a skill that is being added.
    /// </summary>
    public class SkillData : ThumbnailDataElement {
        /// <summary>
        /// Gets the skill category this Skill falls under.
        /// </summary>
        [JsonProperty]
        public string SkillCategory { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the age in which this skill is unlocked.
        /// </summary>
        [JsonProperty]
        public string UnlockAge { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the ID of the skill's UI class.
        /// </summary>
        [JsonProperty]
        public string SkillUI { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the page group the skill should be filed under.
        /// </summary>
        [JsonProperty]
        public string PageGroup { get; private set; } = string.Empty;
    }
}
