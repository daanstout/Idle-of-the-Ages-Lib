// <copyright file="ISkillService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Skills {
    /// <summary>
    /// A service that keeps track of all available skills.
    /// </summary>
    public interface ISkillService {
        /// <summary>
        /// Gets the skill that should be shown.
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
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterSkillData(SkillData skillData);

        /// <summary>
        /// Registers the implementation for a skill to the game.
        /// </summary>
        /// <typeparam name="TSkill">The type of the skill to register.</typeparam>
        /// <param name="skillID">The ID of the skill.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterSkillImplementation<TSkill>(string skillID) where TSkill : SkillImplementation;

        /// <summary>
        /// Registers the implementation for a skill to the game.
        /// </summary>
        /// <param name="skillType">The type of the skill to register.</param>
        /// <param name="skillID">The ID of the skill.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterSkillImplementation(Type skillType, string skillID);

        /// <summary>
        /// Gets a skill implementation.
        /// </summary>
        /// <typeparam name="TSkill">The type of the skill to get.</typeparam>
        /// <param name="skillID">The ID of the skill to get.</param>
        /// <returns>The requested skill.</returns>
        Result<TSkill> GetSkill<TSkill>(string skillID) where TSkill : SkillImplementation;

        /// <summary>
        /// Gets all skills currently registered in the game.
        /// </summary>
        /// <returns>The skills currently registered in the game.</returns>
        Result<IReadOnlyCollection<SkillImplementation>> GetSkills();

        /// <summary>
        /// Changes the skill that is being shown.
        /// </summary>
        /// <param name="skillID">The ID of the skill that should be shown.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result ChangeShowingSkill(string skillID);
    }
}
