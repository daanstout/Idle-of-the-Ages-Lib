using IdleOfTheAgesGame.UI;

using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;

using System;

namespace IdleOfTheAgesGame.Skills {
    [Skill("IdleOfTheAgesGame:mining")]
    public class Mining : SkillImplementation {
        public override string Namespace { get; } = Constants.NAMESPACE;

        public override Type SkillUI { get; } = typeof(MiningSkillUI);

        public Mining(SkillData skillData) : base(skillData) { }
    }
}
