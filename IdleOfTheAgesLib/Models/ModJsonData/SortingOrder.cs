namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// Allows for sorting elements in different ways.
    /// <para>Elements that use <see cref="After"/> are considered as having the same <see cref="Order"/> as the element they are referring.</para>
    /// </summary>
    public class SortingOrder {
        /// <summary>
        /// The element that should precede this element.
        /// </summary>
        public string After { get; private set; } = string.Empty;

        /// <summary>
        /// A numeric value of where this element should be sorted.
        /// </summary>
        public int Order { get; private set; }
    }
}
