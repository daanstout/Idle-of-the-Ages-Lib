// <copyright file="IPageGroupService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.Services {
    /// <summary>
    /// A service to keep track of the <see cref="PageGroupData"/>s and <see cref="PageData"/>s in the sidebar.
    /// </summary>
    public interface IPageGroupService {
        /// <summary>
        /// Registers a <see cref="PageGroupData"/>.
        /// </summary>
        /// <param name="pageGroup">The <see cref="PageGroupData"/> to register.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterPageGroup(PageGroupData pageGroup);

        /// <summary>
        /// Registers a <see cref="PageData"/>.
        /// </summary>
        /// <param name="page">The <see cref="PageData"/> to register.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result RegisterPage(PageData page);

        /// <summary>
        /// Gets all registered <see cref="PageGroupData"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> with all <see cref="PageGroupData"/>.</returns>
        IEnumerable<PageGroupData> GetAllPageGroups();

        /// <summary>
        /// Gets all registered <see cref="PageData"/> within a <see cref="PageGroupData"/>.
        /// </summary>
        /// <param name="pageGroupID">The ID of the page group to get the pages in.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> with all <see cref="PageData"/> in the <see cref="PageGroupData"/>.</returns>
        IEnumerable<PageData> GetPagesInPageGroup(string pageGroupID);

        /// <summary>
        /// Gets a <see cref="PageGroupData"/>.
        /// </summary>
        /// <param name="pageGroupID">The <see cref="PageGroupData"/> to obtain.</param>
        /// <returns>The requested <see cref="PageGroupData"/>.</returns>
        Result<PageGroupData> GetPageGroup(string pageGroupID);

        /// <summary>
        /// Gets a <see cref="PageData"/>.
        /// </summary>
        /// <param name="pageID">The <see cref="PageData"/> to obtain.</param>
        /// <returns>The requested <see cref="PageData"/>.</returns>
        Result<PageData> GetPage(string pageID);
    }
}
