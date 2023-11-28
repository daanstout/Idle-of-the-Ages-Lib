using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI;

using UnityEngine.UIElements;

namespace IdleOfTheAgesGame.UI {
    public class WoodcuttingSkillUI : Element<Box, object> {
        private readonly ITranslationService translationService;

        public WoodcuttingSkillUI(ITranslationService translationService) {
            this.translationService = translationService;
        }

        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            target.Add(new Label(translationService.GetLanguageString(Constants.Skill.WOODCUTTING.TranslationKey)));

            return target;
        }
    }
}
