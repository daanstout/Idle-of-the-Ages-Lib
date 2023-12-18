// <copyright file="AgeData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// An age that the player can be in.
    /// </summary>
    public class AgeData : ThumbnailDataElement {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgeData"/> class.
        /// </summary>
        public AgeData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgeData"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        /// <param name="thumbnail">The thumbnail for the element.</param>
        public AgeData(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder, string thumbnail) : base(@namespace, id, name, translationKey, sortingOrder, thumbnail) { }
    }
}
