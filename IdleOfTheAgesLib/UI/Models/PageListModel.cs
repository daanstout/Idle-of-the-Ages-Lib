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
        /// Gets the <see cref="IPageGroupElement"/>s to display.
        /// </summary>
        public IReadOnlyList<IPageGroupElement> PageGroups { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageListModel"/> class.
        /// </summary>
        /// <param name="pageGroups">The <see cref="IPageGroupElement"/>s to display.</param>
        public PageListModel(IReadOnlyList<IPageGroupElement> pageGroups) => PageGroups = pageGroups;
    }
}
