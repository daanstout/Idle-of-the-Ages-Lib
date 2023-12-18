// <copyright file="SkillService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.Skills {
    /// <summary>
    /// A service that keeps track of all available skills.
    /// </summary>
    [Service(typeof(ISkillService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class SkillService : ISkillService {
        /// <inheritdoc/>
        public SkillImplementation CurrentlyShowingSkill { get; private set; } = null!;

        /// <inheritdoc/>
        public event Action<SkillImplementation>? CurrentlyShowingSkillChangedEvent;

        private readonly Dictionary<string, SkillImplementation> skills = new Dictionary<string, SkillImplementation>();
        private readonly Dictionary<string, SkillData> skillDatas = new Dictionary<string, SkillData>();

        private readonly IModLibrary modLibrary;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillService"/> class.
        /// </summary>
        /// <param name="modLibrary">The mod library.</param>
        public SkillService(IModLibrary modLibrary) {
            this.modLibrary = modLibrary;
        }

        /// <inheritdoc/>
        public Result RegisterSkillImplementation<TSkill>(string skillID) where TSkill : SkillImplementation {
            return RegisterSkillImplementation(typeof(TSkill), skillID);
        }

        /// <inheritdoc/>
        public Result RegisterSkillImplementation(Type skillType, string skillID) {
            if (!skillDatas.TryGetValue(skillID, out var skillData)) {
                return (false, $"No skill data has been registered for skill {skillID}", new ArgumentException(null, nameof(skillID)));
            }

            var skill = (SkillImplementation)Activator.CreateInstance(skillType, skillData);

            skill.Initialize(modLibrary.GetModObject(skill.Namespace).Value.ServiceLibrary);

            skills.Add(skill.NamespacedID, skill);

            if (skills.Count == 1) {
                ChangeShowingSkill(skill.NamespacedID);
            }

            return true;
        }

        /// <inheritdoc/>
        public Result<TSkill> GetSkill<TSkill>(string skillID) where TSkill : SkillImplementation {
            if (string.IsNullOrWhiteSpace(skillID)) {
                return (null!, "skillID cannot be empty!", new ArgumentNullException(nameof(skillID)));
            }

            if (!skills.TryGetValue(skillID, out var skill)) {
                return (null!, $"No skill with skill ID: {skillID} has been registered!", new ArgumentException(null, nameof(skillID)));
            }

            return (TSkill)skill;
        }

        /// <inheritdoc/>
        public Result<IReadOnlyCollection<SkillImplementation>> GetSkills() {
            return skills.Values;
        }

        /// <inheritdoc/>
        public Result ChangeShowingSkill(string skillID) {
            if (!skills.TryGetValue(skillID, out var skill))
                return (false, $"No skill with ID {skillID} has been registered!");

            CurrentlyShowingSkill = skill;

            CurrentlyShowingSkillChangedEvent?.Invoke(skill);

            return true;
        }

        /// <inheritdoc/>
        public Result RegisterSkillData(SkillData skillData) {
            skillDatas[skillData.NamespacedID] = skillData;

            return true;
        }
    }
}
