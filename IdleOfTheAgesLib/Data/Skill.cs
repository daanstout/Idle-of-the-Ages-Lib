using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.UI;

using System;

namespace IdleOfTheAgesLib.Data {
    /// <summary>
    /// A skill that can be practiced by the player.
    /// </summary>
    public abstract class Skill {
        /// <summary>
        /// The namespace the skill exists in.
        /// </summary>
        public abstract string Namespace { get; }

        /// <summary>
        /// The ID of the skill.
        /// </summary>
        public abstract string ID { get; }

        /// <summary>
        /// The name of the skill.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The translation key of the skill.
        /// </summary>
        public abstract string TranslationKey { get; }

        /// <summary>
        /// The category this skill should fall under.
        /// </summary>
        public abstract string SkillCategory { get; }

        /// <summary>
        /// The age the user needs to be in to unlock this skill.
        /// </summary>
        public abstract string UnlockAge { get; }

        /// <summary>
        /// The thumbnail for the skill.
        /// </summary>
        public abstract string Thumbnail { get; }

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
        public string NamespacedID => $"{Namespace}:{ID}";

        /// <summary>
        /// The type of this class's skill UI <see cref="Element"/>.
        /// </summary>
        public abstract Type SkillUI { get; }

        /// <summary>
        /// Initializes the skill.
        /// </summary>
        /// <param name="serviceLibrary">The service library to obtain services from.</param>
        public virtual void Initialize(IServiceLibrary serviceLibrary) { }
    }
}
