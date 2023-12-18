// <copyright file="IPageItemElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Models;

using System;

namespace IdleOfTheAgesLib.UI.Elements {
    /// <summary>
    /// An element that represents a page item within a <see cref="IPageListElement"/>.
    /// </summary>
    public interface IPageItemElement : IElement<PageItemModel> {
        /// <summary>
        /// An event that gets fired when the page item is clicked on by the user.
        /// </summary>
        event Action PageItemClickedEvent;
    }
}
