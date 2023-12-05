// <copyright file="GameViewManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;
using IdleOfTheAgesLib.UI.Models;

namespace IdleOfTheAgesRuntime.UI.Managers {
    /// <summary>
    /// Represents a manager for the <see cref="IGameViewElement"/>.
    /// </summary>
    [UIManager(typeof(IGameViewManager))]
    public class GameViewManager : IGameViewManager {
        private readonly IElementLibrary elementLibrary;
        private readonly IUIManagerService uiManagerService;
        private IGameViewElement gameView = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewManager"/> class.
        /// </summary>
        /// <param name="elementLibrary">The element library to get elements from.</param>
        /// <param name="uiManagerService">The ui manager to get other managers from.</param>
        public GameViewManager(IElementLibrary elementLibrary, IUIManagerService uiManagerService) {
            this.elementLibrary = elementLibrary;
            this.uiManagerService = uiManagerService;
        }

        /// <inheritdoc/>
        public IGameViewElement GetElement() {
            gameView ??= elementLibrary.GetElement<IGameViewElement>().Value;

            gameView.Initialize(new GameViewModel(uiManagerService.GetManager<IPageListManager>("Sidebar").Value.GetElement()));

            return gameView;
        }

        /// <inheritdoc/>
        IElement IUIManager.GetElement() => GetElement();
    }
}
