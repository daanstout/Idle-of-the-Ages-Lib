// <copyright file="WoodcuttingElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesGame.UI.Models;

using IdleOfTheAgesLib.UI.Elements;

using UnityEngine.UIElements;

namespace IdleOfTheAgesGame.UI.Elements {
    /// <summary>
    /// The UI element for the Woodcutting page.
    /// </summary>
    [UIElement(typeof(IWoodcuttingElement))]
    public class WoodcuttingElement : Element<Box, WoodcuttingModel>, IWoodcuttingElement {
        /// <inheritdoc/>
        protected override void BuildElement(Box targetElement) {
            targetElement.Add(new Label(Data.Name));
        }
    }
}
