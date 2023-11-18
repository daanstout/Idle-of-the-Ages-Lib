using IdleOfTheAgesLib.Models.ModJsonData;

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Skills {
    /// <summary>
    /// A service that keeps track of all available skills.
    /// </summary>
    public interface ISkillService {
        /// <summary>
        /// The skill that should be shown.
        /// </summary>
        SkillImplementation CurrentlyShowingSkill { get; }

        /// <summary>
        /// An event that is fired when the currently showing skill changes.
        /// </summary>
        event Action<SkillImplementation> CurrentlyShowingSkillChangedEvent;

        /// <summary>
        /// Registers the skill data for a skill to the game.
        /// </summary>
        /// <param name="skillData">The skill data to register.</param>
        Result RegisterSkillData(SkillData skillData);

        /// <summary>
        /// Registers the implementation for a skill to the game.
        /// </summary>
        /// <typeparam name="TSkill">The type of the skill to register.</typeparam>
        /// <param name="skillID">The ID of the skill.</param>
        Result RegisterSkillImplementation<TSkill>(string skillID) where TSkill : SkillImplementation;

        /// <summary>
        /// Registers the implementation for a skill to the game.
        /// </summary>
        /// <param name="skillType">The type of the skill to register.</param>
        /// <param name="skillID">The ID of the skill.</param>
        Result RegisterSkillImplementation(Type skillType, string skillID);

        /// <summary>
        /// Gets all skills currently registered in the game.
        /// </summary>
        /// <returns>The skills currently registered in the game.</returns>
        Result<IReadOnlyCollection<SkillImplementation>> GetSkills();

        /// <summary>
        /// Changes the skill that is being shown.
        /// </summary>
        /// <param name="skillID">The ID of the skill that should be shown.</param>
        Result ChangeShowingSkill(string skillID);
    }
}
