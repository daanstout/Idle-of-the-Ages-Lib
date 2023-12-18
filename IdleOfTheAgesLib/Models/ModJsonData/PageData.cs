// <copyright file="PageData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// Represents a page in the <see cref="PageGroupData"/>.
    /// </summary>
    public class PageData : ThumbnailDataElement {
        /// <summary>
        /// The type of pages available.
        /// </summary>
        public enum PageTypeValues {
            /// <summary>
            /// Default value.
            /// </summary>
            None = 0,

            /// <summary>
            /// The page goes to a skill.
            /// </summary>
            Skill,
        }

        /// <summary>
        /// Gets the type of page this is.
        /// </summary>
        [JsonProperty]
        public PageTypeValues PageType { get; private set; } = PageTypeValues.None;

        /// <summary>
        /// Gets the ID of the target behind the page.
        /// </summary>
        [JsonProperty]
        public string TargetID { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the ID of the page group this page belongs to.
        /// </summary>
        [JsonProperty]
        public string PageGroup { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageData"/> class.
        /// </summary>
        public PageData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageData"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        /// <param name="thumbnail">The thumbnail for the element.</param>
        /// <param name="pageType">The type of page this is.</param>
        /// <param name="targetID">The ID of the target behind the page.</param>
        /// <param name="pageGroup">The Id of the page group this page belongs to.</param>
        public PageData(
            string @namespace,
            string id,
            string name,
            string translationKey,
            SortingOrderData sortingOrder,
            string thumbnail,
            PageTypeValues pageType,
            string targetID,
            string pageGroup) : base(@namespace, id, name, translationKey, sortingOrder, thumbnail) {
            PageType = pageType;
            TargetID = targetID;
            PageGroup = pageGroup;
        }
    }
}
