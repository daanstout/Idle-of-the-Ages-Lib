// <copyright file="PageItemModel.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;

using UnityEngine;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains data to render a <see cref="IPageItemElement"/>.
    /// </summary>
    public class PageItemModel {
        /// <summary>
        /// Gets the text to display for the page.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the thumbnail to display for the page.
        /// </summary>
        public Texture2D Thumbnail { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageItemModel"/> class.
        /// </summary>
        /// <param name="text">The text to display for the page.</param>
        /// <param name="thumbnail">The thumbnail to display for the page.</param>
        public PageItemModel(string text, Texture2D thumbnail) {
            Text = text;
            Thumbnail = thumbnail;
        }
    }
}
