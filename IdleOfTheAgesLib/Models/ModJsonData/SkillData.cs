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

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillData"/> class.
        /// </summary>
        public SkillData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillData"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        /// <param name="thumbnail">The thumbnail for the element.</param>
        /// <param name="skillCategory">The skill category this skill falls under.</param>
        /// <param name="unlockAge">The age in which this skill is unlocked.</param>
        /// <param name="skillUI">The ID of the skill's UI class.</param>
        /// <param name="pageGroup">The page group this skill should be filed under.</param>
        public SkillData(
            string @namespace,
            string id,
            string name,
            string translationKey,
            SortingOrderData sortingOrder,
            string thumbnail,
            string skillCategory,
            string unlockAge,
            string skillUI,
            string pageGroup) : base(@namespace, id, name, translationKey, sortingOrder, thumbnail) {
            SkillCategory = skillCategory;
            UnlockAge = unlockAge;
            SkillUI = skillUI;
            PageGroup = pageGroup;
        }
    }
}
