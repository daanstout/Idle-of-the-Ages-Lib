// <copyright file="PageGroupService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Services;

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.UI {
    /// <summary>
    /// A service to keep track of the <see cref="PageGroupData"/>s and <see cref="PageData"/>s in the sidebar.
    /// </summary>
    [Service(typeof(IPageGroupService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class PageGroupService : IPageGroupService {
        private class PageGroupInfo {
            public PageGroupData? PageGroup { get; set; }

            public Dictionary<string, PageData> Pages { get; } = new Dictionary<string, PageData>();
        }

        private readonly Dictionary<string, PageGroupInfo> pageGroups = new Dictionary<string, PageGroupInfo>();
        private readonly Dictionary<string, string> pageToPageGroup = new Dictionary<string, string>();

        /// <inheritdoc/>
        public IEnumerable<PageGroupData> GetAllPageGroups() {
            foreach (var item in pageGroups.Values)
                if (item.PageGroup != null)
                    yield return item.PageGroup;
        }

        /// <inheritdoc/>
        public Result<PageData> GetPage(string pageID) {
            if (string.IsNullOrWhiteSpace(pageID)) {
                return (null!, "Empty page ID has been provided!", new ArgumentNullException(nameof(pageID)));
            }

            if (!pageToPageGroup.TryGetValue(pageID, out var pageGroup)) {
                return (null!, $"No page has been registered with the ID {pageID}", new ArgumentException(null, nameof(pageID)));
            }

            if (!pageGroups.TryGetValue(pageGroup, out var pageGroupInfo)) {
                return (null!, $"Could not find the page group the page is in!", new ArgumentException(null, nameof(pageID)));
            }

            if (!pageGroupInfo.Pages.TryGetValue(pageID, out var pageData)) {
                return (null!, $"Could not find the page within the page group!", new ArgumentException(null, nameof(pageID)));
            }

            return pageData;
        }

        /// <inheritdoc/>
        public Result<PageGroupData> GetPageGroup(string pageGroupID) {
            if (string.IsNullOrWhiteSpace(pageGroupID)) {
                return (null!, "Empty page group ID has been provided!", new ArgumentNullException(nameof(pageGroupID)));
            }

            if (!pageGroups.TryGetValue(pageGroupID, out var pageGroupInfo)) {
                return (null!, $"No page group has been registered with the ID {pageGroupID}", new ArgumentException(null, nameof(pageGroupID)));
            }

            if (pageGroupInfo.PageGroup == null) {
                return (null!, $"No page group has been registered with the ID {pageGroupID}, but pages have been registered to it. Please make sure to create a page group when adding pages to a new group!", new ArgumentException(null, nameof(pageGroupID)));
            }

            return pageGroupInfo.PageGroup;
        }

        /// <inheritdoc/>
        public IEnumerable<PageData> GetPagesInPageGroup(string pageGroupID) {
            if (string.IsNullOrWhiteSpace(pageGroupID)) {
                yield break;
            }

            if (!pageGroups.TryGetValue(pageGroupID, out var pageGroupInfo)) {
                yield break;
            }

            if (pageGroupInfo.PageGroup == null) {
                yield break;
            }

            foreach (var page in pageGroupInfo.Pages.Values) {
                yield return page;
            }
        }

        /// <inheritdoc/>
        public Result RegisterPage(PageData page) {
            if (!pageGroups.TryGetValue(page.PageGroup, out var pageGroupInfo)) {
                pageGroupInfo = new PageGroupInfo();
                pageGroups[page.PageGroup] = pageGroupInfo;
            }

            pageGroupInfo.Pages[page.NamespacedID] = page;
            pageToPageGroup[page.NamespacedID] = page.PageGroup;

            return true;
        }

        /// <inheritdoc/>
        public Result RegisterPageGroup(PageGroupData pageGroup) {
            if (!pageGroups.TryGetValue(pageGroup.NamespacedID, out var pageGroupInfo)) {
                pageGroupInfo = new PageGroupInfo();
                pageGroups[pageGroup.NamespacedID] = pageGroupInfo;
            }

            pageGroupInfo.PageGroup = pageGroup;

            return true;
        }
    }
}
