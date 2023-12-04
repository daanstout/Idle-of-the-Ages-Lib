// <copyright file="PageListModel.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains data to render a <see cref="IPageListElement"/>.
    /// </summary>
    public class PageListModel {
        /// <summary>
        /// Gets the <see cref="IPageItemElement"/>s to display.
        /// </summary>
        public IReadOnlyCollection<IPageItemElement> Pages { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageListModel"/> class.
        /// </summary>
        /// <param name="pages">The <see cref="IPageItemElement"/>s to display.</param>
        public PageListModel(IReadOnlyCollection<IPageItemElement> pages) => Pages = pages;
    }
}
