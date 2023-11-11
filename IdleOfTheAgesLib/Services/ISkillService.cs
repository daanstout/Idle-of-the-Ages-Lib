using IdleOfTheAgesLib.Data;

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Services {
    /// <summary>
    /// A service that keeps track of all available skills.
    /// </summary>
    public interface ISkillService {
        /// <summary>
        /// The skill that should be shown.
        /// </summary>
        Skill CurrentlyShowingSkill { get; }

        /// <summary>
        /// An event that is fired when the currently showing skill changes.
        /// </summary>
        event Action<Skill> CurrentlyShowingSkillChangedEvent;

        /// <summary>
        /// Registers a skill to the game.
        /// </summary>
        /// <typeparam name="TSkill">The type of the skill to register.</typeparam>
        Result RegisterSkill<TSkill>() where TSkill : Skill, new();

        /// <summary>
        /// Gets all skills currently registered in the game.
        /// </summary>
        /// <returns>The skills currently registered in the game.</returns>
        Result<IReadOnlyCollection<Skill>> GetSkills();

        /// <summary>
        /// Changes the skill that is being shown.
        /// </summary>
        /// <param name="skillID">The ID of the skill that should be shown.</param>
        Result ChangeShowingSkill(string skillID);
    }
}
