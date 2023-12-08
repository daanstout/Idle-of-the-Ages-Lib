// <copyright file="PageGroupElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

using UnityEngine.UIElements;

namespace IdleOfTheAgesRuntime.UI.Elements {
    /// <summary>
    /// An element that renders a group of <see cref="IPageItemElement"/>s.
    /// </summary>
    [UIElement(typeof(IPageGroupElement))]
    public class PageGroupElement : Element<Box, PageGroupModel>, IPageGroupElement {
        /// <inheritdoc/>
        protected override void BuildElement(Box targetElement) {
            foreach (var pageItem in Data.Pages) {
                targetElement.Add(pageItem.GetVisualElement());
            }
        }
    }
}
