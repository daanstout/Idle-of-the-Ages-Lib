// <copyright file="MiningSkillUI.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI.Elements;

using UnityEngine.UIElements;

namespace IdleOfTheAgesGame.UI {
    /// <summary>
    /// The UI for the Mining Skill.
    /// </summary>
    public class MiningSkillUI : Element<Box, object> {
        private readonly ITranslationService translationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiningSkillUI"/> class.
        /// </summary>
        /// <param name="translationService">The translation service to translate text with.</param>
        public MiningSkillUI(ITranslationService translationService) {
            this.translationService = translationService;
        }

        /// <inheritdoc/>
        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            target.Add(new Label(translationService.GetLanguageString(Constants.Skill.MINING.TranslationKey)));

            return target;
        }
    }
}
