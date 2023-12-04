// <copyright file="SkillSidebarModel.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;

using UnityEngine;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains the data required to render the <see cref="ISkillSidebarElement"/>.
    /// </summary>
    public class SkillSidebarModel {
        /// <summary>
        /// Gets or sets the translated display text of the skill.
        /// </summary>
        public string SkillDisplayText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the skill.
        /// </summary>
        public string SkillID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the thumbnail for the skill.
        /// </summary>
        public Texture2D SkillThumbnail { get; set; } = null!;

        /// <summary>
        /// Gets or sets the current level of the skill.
        /// </summary>
        public int SkillLevel { get; set; }

        /// <summary>
        /// Gets or sets the maximum level of the skill.
        /// </summary>
        public int SkillMaxLevel { get; set; }
    }
}
