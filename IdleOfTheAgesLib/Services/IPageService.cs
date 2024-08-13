// <copyright file="IPageService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Services;

/// <summary>
/// A service for containing all the pages the game can show.
/// </summary>
public interface IPageService {
    /// <summary>
    /// Adds a page group.
    /// </summary>
    /// <param name="pageGroup">The page group to add.</param>
    /// <returns><see langword="true"/> if the page group was succesfully added. <see langword="false"/> if not.</returns>
    Result AddPageGroup(PageGroupData pageGroup);

    /// <summary>
    /// Adds a page to a page group.
    /// </summary>
    /// <param name="pageGroup">The page group to add the page to.</param>
    /// <param name="page">The page to add.</param>
    /// <returns><see langword="true"/> if the page group was succesfully added. <see langword="false"/> if not.</returns>
    Result AddPage(string pageGroup, PageData page);

    /// <summary>
    /// Gets the data for a page group.
    /// </summary>
    /// <param name="pageGroup">The page group to get the data for.</param>
    /// <returns>The page group data.</returns>
    Result<PageGroupData> GetPageGroup(string pageGroup);

    /// <summary>
    /// Gets all page groups that have been registered.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> with all page groups.</returns>
    IEnumerable<PageGroupData> GetAllPageGroups();

    /// <summary>
    /// Gets the data for a page.
    /// </summary>
    /// <param name="pageGroup">The page group the page is in.</param>
    /// <param name="page">The page to get the data for.</param>
    /// <returns>The page data.</returns>
    Result<PageData> GetPage(string pageGroup, string page);

    /// <summary>
    /// Gets all pages that have been registered in a page group.
    /// </summary>
    /// <param name="pageGroup">The page group to get the pages for.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with all pages in the page group.</returns>
    IEnumerable<PageData> GetPagesInGroup(string pageGroup);
}
