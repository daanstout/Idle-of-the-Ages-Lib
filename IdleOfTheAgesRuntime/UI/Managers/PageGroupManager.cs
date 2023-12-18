// <copyright file="PageGroupManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;
using IdleOfTheAgesLib.UI.Models;

using System.Collections.Generic;
using System.Linq;

namespace IdleOfTheAgesRuntime.UI.Managers {
    /// <summary>
    /// Manages the <see cref="IPageGroupElement"/>.
    /// </summary>
    [UIManager(typeof(IPageGroupManager))]
    public class PageGroupManager : IPageGroupManager {
        private readonly IElementLibrary elementLibrary;
        private readonly IPageService pageGroupService;
        private readonly IUIManagerService uiManagerService;
        private readonly Dictionary<string, IPageItemManager> pageItems = new Dictionary<string, IPageItemManager>();
        private IPageGroupElement pageGroupElement = null!;
        private PageGroupData pageGroupData = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageGroupManager"/> class.
        /// </summary>
        /// <param name="elementLibrary">The element library to get elements from.</param>
        /// <param name="pageGroupService">The page group service to get page data from.</param>
        /// <param name="uiManagerService">The UI manager service to get other managers from.</param>
        public PageGroupManager(IElementLibrary elementLibrary, IPageService pageGroupService, IUIManagerService uiManagerService) {
            this.elementLibrary = elementLibrary;
            this.pageGroupService = pageGroupService;
            this.uiManagerService = uiManagerService;
        }

        /// <inheritdoc/>
        public void InjectPageGroup(PageGroupData pageGroupData) {
            this.pageGroupData = pageGroupData;
        }

        /// <inheritdoc/>
        IElement IUIManager.GetElement() => GetElement();

        /// <inheritdoc/>
        public IPageGroupElement GetElement() {
            pageGroupElement ??= elementLibrary.GetElement<IPageGroupElement>().Value;

            if (pageGroupData != null) {
                foreach (var page in pageGroupService.GetPagesInPageGroup(pageGroupData.NamespacedID)) {
                    if (!pageItems.TryGetValue(page.NamespacedID, out var pageItemManager)) {
                        pageItemManager = uiManagerService.GetManager<IPageItemManager>(page.NamespacedID).Value;
                        pageItemManager.InjectPageData(page);
                        pageItemManager.PageItemClickedEvent += OnPageItemClickedEvent;
                        pageItems[page.NamespacedID] = pageItemManager;
                    }
                }

                var model = new PageGroupModel(pageItems.Values.Select(manager => manager.GetElement()).ToList());

                pageGroupElement.InjectData(model);
            }

            return pageGroupElement;
        }

        private void OnPageItemClickedEvent(PageData pageData) => pageGroupService.ChangeActivePage(pageData.NamespacedID);
    }
}
