using IdleOfTheAgesGame.UI;

using IdleOfTheAgesLib.Data;

using System;
using System.Collections.Generic;
using System.Text;

namespace IdleOfTheAgesGame.Skills {
    public class Mining : Skill {
        public override string Namespace { get; } = Constants.NAMESPACE;
        public override string ID { get; } = Constants.MINING.ID;
        public override string Name { get; } = Constants.MINING.Name;
        public override string TranslationKey { get; } = Constants.MINING.TranslationKey;
        public override string SkillCategory { get; } = Constants.NON_COMBAT.NamespacedID;
        public override string UnlockAge { get; } = Constants.STONE_AGE.NamespacedID;
        public override string Thumbnail { get; } = Constants.TREE.NamespacedID;
        public override Type SkillUI { get; } = typeof(MiningSkillUI);
    }
}
