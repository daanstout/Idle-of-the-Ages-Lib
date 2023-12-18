// <copyright file="WoodcuttingPageManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesGame.Skills;

using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;

namespace IdleOfTheAgesGame.UI.Managers {
    /// <summary>
    /// The UI manager for the Woodcutting Page.
    /// </summary>
    [UIManager(typeof(IGamePageManager), "IdleOfTheAgesGame:woodcutting")]
    public class WoodcuttingPageManager : IGamePageManager {
        private readonly IUIManagerService uiManagerService;
        private readonly ISkillService skillService;
        private IWoodcuttingManager woodcuttingManager = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="WoodcuttingPageManager"/> class.
        /// </summary>
        /// <param name="uiManagerService">The ui manager to get other managers from.</param>
        /// <param name="skillService">The skill service to get skill information from.</param>
        public WoodcuttingPageManager(IUIManagerService uiManagerService, ISkillService skillService) {
            this.uiManagerService = uiManagerService;
            this.skillService = skillService;
        }

        /// <inheritdoc/>
        IElement IUIManager.GetElement() {
            woodcuttingManager ??= uiManagerService.GetManager<IWoodcuttingManager>("woodcutting_instance").Value;

            woodcuttingManager.InjectSkillData(skillService.GetSkill<Woodcutting>(Constants.Skill.WOODCUTTING.NamespacedID));

            return woodcuttingManager.GetElement();
        }
    }
}
