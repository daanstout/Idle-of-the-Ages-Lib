// <copyright file="WoodcuttingManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesGame.Skills;
using IdleOfTheAgesGame.UI.Elements;
using IdleOfTheAgesGame.UI.Models;

using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;

namespace IdleOfTheAgesGame.UI.Managers {
    /// <summary>
    /// The manager for the woodcutting skill.
    /// </summary>
    [UIManager(typeof(IWoodcuttingManager))]
    public class WoodcuttingManager : IWoodcuttingManager {
        private readonly IElementLibrary elementLibrary;
        private readonly ITranslationService translationService;
        private IWoodcuttingElement woodcuttingElement = null!;
        private Woodcutting skill = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="WoodcuttingManager"/> class.
        /// </summary>
        /// <param name="elementLibrary">The element library to get elements from.</param>
        /// <param name="translationService">The translation service to translate text with.</param>
        public WoodcuttingManager(IElementLibrary elementLibrary, ITranslationService translationService) {
            this.elementLibrary = elementLibrary;
            this.translationService = translationService;
        }

        /// <inheritdoc/>
        public void InjectSkillData(Woodcutting skill) {
            this.skill = skill;
        }

        /// <inheritdoc/>
        IElement IUIManager.GetElement() => GetElement();

        /// <inheritdoc/>
        public IWoodcuttingElement GetElement() {
            woodcuttingElement ??= elementLibrary.GetElement<IWoodcuttingElement>().Value;

            woodcuttingElement.InjectData(new WoodcuttingModel(translationService.GetLanguageString(skill.SkillData.TranslationKey)));

            return woodcuttingElement;
        }
    }
}
