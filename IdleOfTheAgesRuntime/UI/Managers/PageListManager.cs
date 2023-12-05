// <copyright file="PageListManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;

using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.UI.Managers {
    /// <summary>
    /// Manages the <see cref="IPageListElement"/>.
    /// </summary>
    [UIManager(typeof(IPageListManager))]
    public class PageListManager : IPageListManager {
        private readonly IElementLibrary elementLibrary;
        private readonly IPageGroupService pageGroupService;
        private readonly Dictionary<string, IPageItemElement> pageItemElements = new Dictionary<string, IPageItemElement>();
        private IPageListElement pageListElement = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageListManager"/> class.
        /// </summary>
        /// <param name="elementLibrary">The element library to get elements from.</param>
        /// <param name="pageGroupService">The page group service to get page group data from.</param>
        public PageListManager(IElementLibrary elementLibrary, IPageGroupService pageGroupService) {
            this.elementLibrary = elementLibrary;
            this.pageGroupService = pageGroupService;
        }

        /// <inheritdoc/>
        IElement IUIManager.GetElement() => GetElement();

        /// <inheritdoc/>
        public IPageListElement GetElement() {
            pageListElement ??= elementLibrary.GetElement<IPageListElement>().Value;

            foreach (var page in pageGroupService.GetAllPageGroups()) {
                if (pageItemElements.TryGetValue(page.NamespacedID, out var _)) {
                }
            }

            return pageListElement;
        }
    }
}
