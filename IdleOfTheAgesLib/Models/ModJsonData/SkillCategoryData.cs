// <copyright file="SkillCategoryData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// A category a skill can be a part of.
    /// </summary>
    public class SkillCategoryData : ThumbnailDataElement {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkillCategoryData"/> class.
        /// </summary>
        public SkillCategoryData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillCategoryData"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        /// <param name="thumbnail">The thumbnail for the element.</param>
        public SkillCategoryData(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder, string thumbnail) : base(@namespace, id, name, translationKey, sortingOrder, thumbnail) { }
    }
}
