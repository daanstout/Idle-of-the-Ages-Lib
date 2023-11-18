using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.UI;

using System;

namespace IdleOfTheAgesLib.Skills {
    /// <summary>
    /// A skill that can be practiced by the player.
    /// </summary>
    public abstract class SkillImplementation {
        /// <summary>
        /// The namespace the skill exists in.
        /// </summary>
        public abstract string Namespace { get; }

        /// <summary>
        /// The data for the skill.
        /// </summary>
        public SkillData SkillData { get; }

        /// <summary>
        /// The current level of the skill.
        /// </summary>
        public int CurrentSkillLevel { get; set; }

        /// <summary>
        /// The maximum level of this skill.
        /// </summary>
        public int MaxSkillLevel { get; }

        /// <summary>
        /// The skill's namespaced ID.
        /// </summary>
        public string NamespacedID => $"{Namespace}:{SkillData.ID}";

        /// <summary>
        /// The type of this class's skill UI <see cref="Element"/>.
        /// </summary>
        public abstract Type SkillUI { get; }

        /// <summary>
        /// Instantiates a new Skill instance.
        /// </summary>
        /// <param name="skillData">The json data for the skill.</param>
        protected SkillImplementation(SkillData skillData) {
            SkillData = skillData;
        }

        /// <summary>
        /// Initializes the skill.
        /// </summary>
        /// <param name="serviceLibrary">The service library to obtain services from.</param>
        public virtual void Initialize(IServiceLibrary serviceLibrary) { }
    }
}
