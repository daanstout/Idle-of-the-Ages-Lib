// <copyright file="Woodcutting.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesGame.UI;

using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using System;

namespace IdleOfTheAgesGame.Skills {
    /// <summary>
    /// Implements the Woodcutting skill.
    /// </summary>
    [Skill("IdleOfTheAgesGame:woodcutting")]
    public class Woodcutting : SkillImplementation {
        /// <inheritdoc/>
        public override string Namespace { get; } = Constants.NAMESPACE;

        /// <inheritdoc/>
        public override Type SkillUI { get; } = typeof(WoodcuttingSkillUI);

        /// <summary>
        /// Initializes a new instance of the <see cref="Woodcutting"/> class.
        /// </summary>
        /// <param name="skillData">The Skill Data for the skill.</param>
        public Woodcutting(SkillData skillData) : base(skillData) { }
    }
}
