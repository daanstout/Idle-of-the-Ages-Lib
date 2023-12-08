// <copyright file="IPageGroupManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.UI.Elements;

namespace IdleOfTheAgesLib.UI.Managers {
    /// <summary>
    /// Manages the <see cref="IPageGroupElement"/>.
    /// </summary>
    public interface IPageGroupManager : IUIManager<IPageGroupElement> {
        /// <summary>
        /// Injects Page Group Data into the manager.
        /// </summary>
        /// <param name="pageGroupData">The page group data this manager should manage.</param>
        void InjectPageGroup(PageGroupData pageGroupData);
    }
}
