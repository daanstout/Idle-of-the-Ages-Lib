// <copyright file="Mining.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesGame.UI;

using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using System;

namespace IdleOfTheAgesGame.Skills {
    /// <summary>
    /// Implements the Mining skill.
    /// </summary>
    [Skill("IdleOfTheAgesGame:mining")]
    public class Mining : SkillImplementation {
        /// <inheritdoc/>
        public override string Namespace { get; } = Constants.NAMESPACE;

        /// <inheritdoc/>
        public override Type SkillUI { get; } = typeof(MiningSkillUI);

        /// <summary>
        /// Initializes a new instance of the <see cref="Mining"/> class.
        /// </summary>
        /// <param name="skillData">The skill data for the skill.</param>
        public Mining(SkillData skillData) : base(skillData) { }
    }
}
