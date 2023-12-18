// <copyright file="GameView.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

using UnityEngine.UIElements;

namespace IdleOfTheAgesRuntime.UI.Elements {
    /// <summary>
    /// The element for the main game view.
    /// </summary>
    [UIElement(typeof(IGameViewElement))]
    public class GameView : Element<Box, GameViewModel>, IGameViewElement {
        private readonly TwoPaneSplitView splitView = new TwoPaneSplitView(0, 200, TwoPaneSplitViewOrientation.Horizontal);

        /// <inheritdoc/>
        protected override void BuildElement(Box targetElement) {
            targetElement.StretchToParentSize();

            splitView.Clear();
            splitView.Add(Data.SidebarElement.GetVisualElement());
            splitView.Add(Data.PageElement.GetVisualElement());

            targetElement.Add(splitView);

            splitView.StretchToParentSize();
        }
    }
}
