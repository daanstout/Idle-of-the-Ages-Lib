// <copyright file="PageGroupData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// Data for page groups in the sidebar.
    /// </summary>
    public class PageGroupData : VisisbleDataElement {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageGroupData"/> class.
        /// </summary>
        public PageGroupData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageGroupData"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        public PageGroupData(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder) : base(@namespace, id, name, translationKey, sortingOrder) { }
    }
}
