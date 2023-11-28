using IdleOfTheAgesLib.UI.Elements;

using UnityEngine;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains the data required to render the <see cref="ISkillSidebarElement"/>.
    /// </summary>
    public class SkillSidebarModel {
        /// <summary>
        /// The translated display text of the skill.
        /// </summary>
        public string SkillDisplayText { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the skill.
        /// </summary>
        public string SkillID { get; set; } = string.Empty;

        /// <summary>
        /// The thumbnail for the skill.
        /// </summary>
        public Texture2D SkillThumbnail { get; set; } = null!;

        /// <summary>
        /// The current level of the skill.
        /// </summary>
        public int SkillLevel { get; set; }

        /// <summary>
        /// The maximum level of the skill.
        /// </summary>
        public int SkillMaxLevel { get; set; }
    }
}
