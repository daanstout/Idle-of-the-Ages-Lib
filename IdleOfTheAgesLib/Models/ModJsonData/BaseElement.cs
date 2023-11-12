using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// A base class for data elements.
    /// </summary>
    public abstract class BaseElement {
        /// <summary>
        /// The namespace of the object.
        /// </summary>
        public string Namespace { get; private set; } = string.Empty;
        
        /// <summary>
        /// The name of the object.
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// The ID of the object.
        /// </summary>
        [JsonProperty]
        public string ID { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the object's namespaced ID.
        /// </summary>
        public string NamespacedID => $"{Namespace}:{ID}";
    }

    /// <summary>
    /// A base class for data elements that are visible to the user.
    /// </summary>
    public abstract class VisisbleElement : BaseElement {
        /// <summary>
        /// The translation key of the element.
        /// </summary>
        [JsonProperty]
        public string TranslationKey { get; private set; } = string.Empty;

        /// <summary>
        /// The Age that this age should be after.
        /// </summary>
        [JsonProperty]
        public SortingOrder SortingOrder { get; set; } = new SortingOrder();
    }

    /// <summary>
    /// A base class for data elements that are visible to the user and have a thumbnail.
    /// </summary>
    public abstract class ThumbnailElement : VisisbleElement {
        /// <summary>
        /// The thumbnail ID of the object.
        /// </summary>
        [JsonProperty]
        public string? Thumbnail { get; private set; } = string.Empty;
    }
}
