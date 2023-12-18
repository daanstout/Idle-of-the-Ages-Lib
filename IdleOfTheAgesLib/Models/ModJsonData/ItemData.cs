// <copyright file="ItemData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using Newtonsoft.Json;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// An item that can be obtained in the game.
    /// </summary>
    public class ItemData : ThumbnailDataElement {
        /// <summary>
        /// Gets the key to the description of the item.
        /// </summary>
        [JsonProperty]
        public string DescriptionKey { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the sell price of this item.
        /// </summary>
        [JsonProperty]
        public int SellPrice { get; private set; }

        /// <summary>
        /// Gets metadata for this item.
        /// </summary>
        [JsonProperty]
        public Dictionary<string, object> Metadata { get; private set; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets the category of this item.
        /// <para>This is used for searching.</para>
        /// </summary>
        [JsonProperty]
        public string Category { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the type of item this is.
        /// <para>This is used for searching.</para>
        /// </summary>
        [JsonProperty]
        public string Type { get; private set; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether whether this item is required for completing the game.
        /// </summary>
        [JsonProperty]
        public bool RequiredForCompletion { get; private set; }

        /// <summary>
        /// Gets the item's tag. This indicates what type of item it is and is used for things such as storage and equipping.
        /// </summary>
        [JsonProperty]
        public string Tag { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemData"/> class.
        /// </summary>
        public ItemData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemData"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        /// <param name="thumbnail">The thumbnail for the element.</param>
        /// <param name="descriptionKey">The description key of the item.</param>
        /// <param name="sellPrice">The sell price of the item.</param>
        /// <param name="metadata">The metadata of the item.</param>
        /// <param name="category">The category of the item.</param>
        /// <param name="type">The type of the item.</param>
        /// <param name="requiredForCompletion">Whether or not the item is required to consider the game "completed".</param>
        /// <param name="tag">The tags of the item.</param>
        public ItemData(
            string @namespace,
            string id,
            string name,
            string translationKey,
            SortingOrderData sortingOrder,
            string thumbnail,
            string descriptionKey,
            int sellPrice,
            Dictionary<string, object> metadata,
            string category,
            string type,
            bool requiredForCompletion,
            string tag) : base(@namespace, id, name, translationKey, sortingOrder, thumbnail) {
            DescriptionKey = descriptionKey;
            SellPrice = sellPrice;
            Metadata = metadata;
            Category = category;
            Type = type;
            RequiredForCompletion = requiredForCompletion;
            Tag = tag;
        }
    }
}
