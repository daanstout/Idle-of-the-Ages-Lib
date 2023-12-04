// <copyright file="PageGroupModel.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains data needed to render a <see cref="IPageGroupElement"/>.
    /// </summary>
    public class PageGroupModel {
        /// <summary>
        /// Gets the pages that are in this group.
        /// </summary>
        public IReadOnlyCollection<IPageListElement> Pages { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageGroupModel"/> class.
        /// </summary>
        /// <param name="pages">The pages to instantiate.</param>
        public PageGroupModel(IReadOnlyCollection<IPageListElement> pages) => Pages = pages;
    }
}
