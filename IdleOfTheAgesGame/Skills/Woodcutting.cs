using IdleOfTheAgesGame.UI;

using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.Data;

using System;

namespace IdleOfTheAgesGame.Skills {
    [Skill]
    public class Woodcutting : Skill {
        public override string Namespace { get; } = Constants.NAMESPACE;
        public override string ID { get; } = Constants.WOODCUTTING.ID;
        public override string Name { get; } = Constants.WOODCUTTING.Name;
        public override string TranslationKey { get; } = Constants.WOODCUTTING.TranslationKey;
        public override string SkillCategory { get; } = Constants.NON_COMBAT.NamespacedID;
        public override string UnlockAge { get; } = Constants.STONE_AGE.NamespacedID;
        public override string Thumbnail { get; } = Constants.TREE.NamespacedID;
        public override Type SkillUI { get; } = typeof(WoodcuttingSkillUI);
    }
}
