// <copyright file="PageListManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;
using IdleOfTheAgesLib.UI.Models;

using System.Collections.Generic;
using System.Linq;

namespace IdleOfTheAgesRuntime.UI.Managers {
    /// <summary>
    /// Manages the <see cref="IPageListElement"/>.
    /// </summary>
    [UIManager(typeof(IPageListManager))]
    public class PageListManager : IPageListManager {
        private readonly IElementLibrary elementLibrary;
        private readonly IPageGroupService pageGroupService;
        private readonly IUIManagerService uiManagerService;
        private readonly Dictionary<string, IPageGroupManager> pageGroups = new Dictionary<string, IPageGroupManager>();
        private IPageListElement pageListElement = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageListManager"/> class.
        /// </summary>
        /// <param name="elementLibrary">The element library to get elements from.</param>
        /// <param name="pageGroupService">The page group service to get page group data from.</param>
        /// <param name="uiManagerService">The UI Manager Service to get other managers from.</param>
        public PageListManager(IElementLibrary elementLibrary, IPageGroupService pageGroupService, IUIManagerService uiManagerService) {
            this.elementLibrary = elementLibrary;
            this.pageGroupService = pageGroupService;
            this.uiManagerService = uiManagerService;
        }

        /// <inheritdoc/>
        IElement IUIManager.GetElement() => GetElement();

        /// <inheritdoc/>
        public IPageListElement GetElement() {
            pageListElement ??= elementLibrary.GetElement<IPageListElement>().Value;

            foreach (var pageGroup in pageGroupService.GetAllPageGroups()) {
                if (!pageGroups.TryGetValue(pageGroup.NamespacedID, out var pageGroupManager)) {
                    pageGroupManager = uiManagerService.GetManager<IPageGroupManager>(pageGroup.NamespacedID).Value;
                    pageGroupManager.InjectPageGroup(pageGroup);
                    pageGroups[pageGroup.NamespacedID] = pageGroupManager;
                }
            }

            PageListModel model = new PageListModel(pageGroups.Values.Select(pageGroup => pageGroup.GetElement()).ToList());

            pageListElement.InjectData(model);

            return pageListElement;
        }
    }
}
