﻿// <copyright file="PageListElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

using UnityEngine.UIElements;

namespace IdleOfTheAgesRuntime.UI.Elements {
    /// <summary>
    /// An element that represents a page list in the sidebar with <see cref="IPageGroupElement"/>s.
    /// </summary>
    [UIElement(typeof(IPageListElement))]
    public class PageListElement : Element<Box, PageListModel>, IPageListElement {
    }
}
