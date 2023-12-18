// <copyright file="GameViewManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;
using IdleOfTheAgesLib.UI.Models;

using UnityEngine;

namespace IdleOfTheAgesRuntime.UI.Managers {
    /// <summary>
    /// Represents a manager for the <see cref="IGameViewElement"/>.
    /// </summary>
    [UIManager(typeof(IGameViewManager))]
    public class GameViewManager : IGameViewManager {
        private readonly IElementLibrary elementLibrary;
        private readonly IUIManagerService uiManagerService;
        private readonly IPageService pageService;
        private readonly IModLibrary modLibrary;
        private IGameViewElement gameView = null!;
        private IPageListManager pageListManager = null!;
        private IGamePageManager gamePage = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewManager"/> class.
        /// </summary>
        /// <param name="elementLibrary">The element library to get elements from.</param>
        /// <param name="uiManagerService">The ui manager to get other managers from.</param>
        /// <param name="pageService">The page service that keeps track of the active page.</param>
        /// <param name="modLibrary">The mod library to get other mod data from.</param>
        public GameViewManager(IElementLibrary elementLibrary, IUIManagerService uiManagerService, IPageService pageService, IModLibrary modLibrary) {
            this.elementLibrary = elementLibrary;
            this.uiManagerService = uiManagerService;
            this.pageService = pageService;
            this.modLibrary = modLibrary;

            pageService.OnPageChangedEvent += OnActivePageChangedEvent;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="GameViewManager"/> class.
        /// </summary>
        ~GameViewManager() {
            pageService.OnPageChangedEvent -= OnActivePageChangedEvent;
        }

        /// <inheritdoc/>
        public IGameViewElement GetElement() {
            gameView ??= elementLibrary.GetElement<IGameViewElement>().Value;
            pageListManager ??= uiManagerService.GetManager<IPageListManager>("Sidebar").Value;
            gamePage = GetManager("IdleOfTheAgesGame:woodcutting");

            gameView.InjectData(new GameViewModel(pageListManager.GetElement(), gamePage.GetElement()));

            return gameView;
        }

        /// <inheritdoc/>
        IElement IUIManager.GetElement() => GetElement();

        private void OnActivePageChangedEvent(string pageId) {
            gamePage = GetManager(pageId);

            gameView.InjectData(new GameViewModel(pageListManager.GetElement(), gamePage.GetElement()));
            gameView.RebuildVisualElement();
        }

        private IGamePageManager GetManager(string id) {
            string @namespace = id.Split(':')[0];

            var modData = modLibrary.GetModObject(@namespace).Value;
            var manager = modData.ServiceLibrary.Get<IUIManagerService>().GetManager<IGamePageManager>(id, id).Value;
            return manager;
        }
    }
}
