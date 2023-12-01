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
            Skill
        }

        /// <summary>
        /// The type of page this is.
        /// </summary>
        [JsonProperty]
        public PageTypeValues PageType { get; private set; } = PageTypeValues.None;

        /// <summary>
        /// The ID of the target behind the page.
        /// </summary>
        [JsonProperty]
        public string TargetID { get; private set; } = string.Empty;

        /// <summary>
        /// The ID of the page group this page belongs to.
        /// </summary>
        [JsonProperty]
        public string PageGroup { get; private set; } = string.Empty;
    }
}
