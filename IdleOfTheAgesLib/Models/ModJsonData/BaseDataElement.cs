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

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataElement"/> class.
        /// </summary>
        protected BaseDataElement() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataElement"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        protected BaseDataElement(string @namespace, string id, string name) {
            Namespace = @namespace;
            ID = id;
            Name = name;
        }
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

        /// <summary>
        /// Initializes a new instance of the <see cref="VisisbleDataElement"/> class.
        /// </summary>
        protected VisisbleDataElement() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisisbleDataElement"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        protected VisisbleDataElement(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder) : base(@namespace, id, name) {
            TranslationKey = translationKey;
            SortingOrder = sortingOrder;
        }
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailDataElement"/> class.
        /// </summary>
        protected ThumbnailDataElement() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailDataElement"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the element.</param>
        /// <param name="id">The ID of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="translationKey">The translation key of the element.</param>
        /// <param name="sortingOrder">The sorting order of the element.</param>
        /// <param name="thumbnail">The thumbnail for the element.</param>
        protected ThumbnailDataElement(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder, string thumbnail) : base(@namespace, id, name, translationKey, sortingOrder) {
            Thumbnail = thumbnail;
        }
    }
}
