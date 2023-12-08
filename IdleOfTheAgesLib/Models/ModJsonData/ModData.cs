// <copyright file="ModData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;

using Newtonsoft.Json;

using System;

namespace IdleOfTheAgesLib.Models {
    /// <summary>
    /// The data class is used for defining mod gameplay data.
    /// </summary>
    public class ModData {
        /// <summary>
        /// Gets the namespace the data sits in.
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the ages that the mod adds.
        /// </summary>
        [JsonProperty("ages")]
        public AgeData[] Ages { get; private set; } = Array.Empty<AgeData>();

        /// <summary>
        /// Gets the skill categories that the mod adds.
        /// </summary>
        [JsonProperty("skill_categories")]
        public SkillCategoryData[] SkillCategories { get; private set; } = Array.Empty<SkillCategoryData>();

        /// <summary>
        /// Gets the skills that the mod adds.
        /// </summary>
        [JsonProperty("skills")]
        public SkillData[] Skills { get; private set; } = Array.Empty<SkillData>();

        /// <summary>
        /// Gets the page groups that the mod adds.
        /// </summary>
        [JsonProperty("page_groups")]
        public PageGroupData[] PageGroups { get; private set; } = Array.Empty<PageGroupData>();

        /// <summary>
        /// Gets the pages that the mod adds.
        /// </summary>
        [JsonProperty("pages")]
        public PageData[] Pages { get; private set; } = Array.Empty<PageData>();
    }
}
