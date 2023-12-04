// <copyright file="BaseDataElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// A base class for data elements.
    /// </summary>
    public abstract class BaseDataElement {
        /// <summary>
        /// Gets or sets the namespace of the object.
        /// </summary>
        public string Namespace { get; set; } = string.Empty;

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        [JsonProperty]
        public string ID { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the object's namespaced ID.
        /// </summary>
        public string NamespacedID => $"{Namespace}:{ID}";
    }

    /// <summary>
    /// A base class for data elements that are visible to the user.
    /// </summary>
    public abstract class VisisbleDataElement : BaseDataElement {
        /// <summary>
        /// Gets the translation key of the element.
        /// </summary>
        [JsonProperty]
        public string TranslationKey { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Age that this age should be after.
        /// </summary>
        [JsonProperty]
        public SortingOrderData SortingOrder { get; set; } = new SortingOrderData();
    }

    /// <summary>
    /// A base class for data elements that are visible to the user and have a thumbnail.
    /// </summary>
    public abstract class ThumbnailDataElement : VisisbleDataElement {
        /// <summary>
        /// Gets the thumbnail ID of the object.
        /// </summary>
        [JsonProperty]
        public string? Thumbnail { get; private set; } = string.Empty;
    }
}
