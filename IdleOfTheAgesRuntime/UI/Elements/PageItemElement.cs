// <copyright file="PageItemElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

using System;

using UnityEngine.UIElements;

namespace IdleOfTheAgesRuntime.UI.Elements {
    /// <summary>
    /// An element that represents a page item within a <see cref="IPageListElement"/>.
    /// </summary>
    [UIElement(typeof(IPageItemElement))]
    public class PageItemElement : Element<Box, PageItemModel>, IPageItemElement {
        /// <inheritdoc/>
        public event Action PageItemClickedEvent = null!;

        private readonly Image image;
        private readonly Label label;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageItemElement"/> class.
        /// </summary>
        public PageItemElement() {
            image = new Image();
            label = new Label();

            RegisterCallback<ClickEvent>(OnElementClicked);
        }

        /// <inheritdoc/>
        protected override void BuildElement(Box targetElement) {
            image.image = Data.Thumbnail;
            label.text = Data.Text;

            targetElement.Add(image);
            targetElement.Add(label);
        }

        private void OnElementClicked(ClickEvent args) {
            PageItemClickedEvent?.Invoke();
        }
    }
}
