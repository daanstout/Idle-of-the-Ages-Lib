using IdleOfTheAgesGame.UI;

using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using System;

namespace IdleOfTheAgesGame.Skills {
    [Skill("IdleOfTheAgesGame:woodcutting")]
    public class Woodcutting : SkillImplementation {
        public override string Namespace { get; } = Constants.NAMESPACE;

        public override Type SkillUI { get; } = typeof(WoodcuttingSkillUI);

        public Woodcutting(SkillData skillData) : base(skillData) { }
    }
}
