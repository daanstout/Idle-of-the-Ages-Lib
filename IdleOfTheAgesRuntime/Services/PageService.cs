// <copyright file="PageService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Services;
using System.Collections.Generic;
using System.Linq;

namespace IdleOfTheAgesRuntime.Services;

/// <summary>
/// A service for containing all the pages the game can show.
/// </summary>
[Service<IPageService>]
public class PageService : IPageService {
    private readonly record struct PageInformation(PageGroupData PageGroup, Dictionary<string, PageData> Pages);

    private readonly Dictionary<string, PageInformation> pages = [];

    /// <inheritdoc/>
    public Result AddPage(string pageGroup, PageData page) {
        if (!pages.TryGetValue(pageGroup, out var pageInformation)) {
            return (false, $"No page group with the ID {pageGroup} has been registered.");
        }

        if (pageInformation.Pages.ContainsKey(page.NamespacedID)) {
            return (false, $"The page with the ID {page.NamespacedID} has already been registered.");
        }

        pageInformation.Pages.Add(page.NamespacedID, page);

        return true;
    }

    /// <inheritdoc/>
    public Result AddPageGroup(PageGroupData pageGroup) {
        if (pages.ContainsKey(pageGroup.NamespacedID)) {
            return (false, $"A page group with the ID {pageGroup.NamespacedID} has already been registered.");
        }

        pages[pageGroup.NamespacedID] = new PageInformation(pageGroup, []);

        return true;
    }

    /// <inheritdoc/>
    public IEnumerable<PageGroupData> GetAllPageGroups() {
        return pages.Values.Select(pageInformation => pageInformation.PageGroup);
    }

    /// <inheritdoc/>
    public Result<PageData> GetPage(string pageGroup, string page) {
        if (!pages.TryGetValue(pageGroup, out var pageInformation)) {
            return (null, $"No page group with the ID {pageGroup} has been registered");
        }

        if (!pageInformation.Pages.TryGetValue(page, out var pageData)) {
            return (null, $"No page with the ID {page} has been registered to the page group {pageGroup}");
        }

        return pageData;
    }

    /// <inheritdoc/>
    public Result<PageGroupData> GetPageGroup(string pageGroup) {
        if (!pages.TryGetValue(pageGroup, out var pageInformation)) {
            return (null, $"No page group with the ID {pageGroup} has been registered");
        }

        return pageInformation.PageGroup;
    }

    /// <inheritdoc/>
    public IEnumerable<PageData> GetPagesInGroup(string pageGroup) {
        if (!pages.TryGetValue(pageGroup, out var pageInformation)) {
            return [];
        }

        return [.. pageInformation.Pages.Values];
    }
}
