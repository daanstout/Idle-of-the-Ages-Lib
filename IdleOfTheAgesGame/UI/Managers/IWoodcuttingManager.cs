// <copyright file="IWoodcuttingManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesGame.Skills;
using IdleOfTheAgesGame.UI.Elements;

using IdleOfTheAgesLib.UI.Managers;

namespace IdleOfTheAgesGame.UI.Managers {
    /// <summary>
    /// The manager for the woodcutting skill.
    /// </summary>
    public interface IWoodcuttingManager : IUIManager<IWoodcuttingElement> {
        /// <summary>
        /// Injects the manager with the woodcutting skill data.
        /// </summary>
        /// <param name="skill">The woodcutting skill this manager is managing.</param>
        void InjectSkillData(Woodcutting skill);
    }
}
