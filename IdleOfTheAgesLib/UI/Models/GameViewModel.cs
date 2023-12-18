// <copyright file="GameViewModel.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains data for the game view model.
    /// </summary>
    public class GameViewModel {
        /// <summary>
        /// Gets the sidebar element.
        /// </summary>
        public IPageListElement SidebarElement { get; } = null!;

        /// <summary>
        /// Gets the page to render to the user.
        /// </summary>
        public IElement PageElement { get; } = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// </summary>
        /// <param name="sidebarElement">The page list to render in the sidebar.</param>
        /// <param name="pageElement">The page to render.</param>
        public GameViewModel(IPageListElement sidebarElement, IElement pageElement) {
            SidebarElement = sidebarElement;
            PageElement = pageElement;
        }
    }
}
