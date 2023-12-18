// <copyright file="PageItemManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;
using IdleOfTheAgesLib.UI.Models;

using System;

namespace IdleOfTheAgesRuntime.UI.Managers {
    /// <summary>
    /// Manages the <see cref="IPageItemElement"/>.
    /// </summary>
    [UIManager(typeof(IPageItemManager))]
    public class PageItemManager : IPageItemManager {
        /// <inheritdoc/>
        public event Action<PageData> PageItemClickedEvent = null!;

        private readonly IElementLibrary elementLibrary;
        private readonly ITranslationService translationService;
        private readonly ITextureLibrary textureLibrary;

        private IPageItemElement pageItemElement = null!;
        private PageData pageData = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageItemManager"/> class.
        /// </summary>
        /// <param name="elementLibrary">The element library to get the elements from.</param>
        /// <param name="translationService">The translation service to translate text.</param>
        /// <param name="textureLibrary">The texture library to obtain textures from.</param>
        public PageItemManager(IElementLibrary elementLibrary, ITranslationService translationService, ITextureLibrary textureLibrary) {
            this.elementLibrary = elementLibrary;
            this.translationService = translationService;
            this.textureLibrary = textureLibrary;
        }

        /// <inheritdoc/>
        public void InjectPageData(PageData page) => pageData = page;

        /// <inheritdoc/>
        IElement IUIManager.GetElement() => GetElement();

        /// <inheritdoc/>
        public IPageItemElement GetElement() {
            if (pageItemElement == null) {
                pageItemElement = elementLibrary.GetElement<IPageItemElement>().Value;
                pageItemElement.PageItemClickedEvent += OnPageItemClicked;
            }

            var model = new PageItemModel(translationService.GetLanguageString(pageData.TranslationKey), textureLibrary.GetTexture(pageData.Thumbnail!) !);

            pageItemElement.InjectData(model);

            return pageItemElement;
        }

        private void OnPageItemClicked() => PageItemClickedEvent?.Invoke(pageData);
    }
}
