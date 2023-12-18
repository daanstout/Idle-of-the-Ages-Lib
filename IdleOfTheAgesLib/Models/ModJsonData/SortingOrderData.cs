// <copyright file="SortingOrderData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData {
    /// <summary>
    /// Allows for sorting elements in different ways.
    /// <para>Elements that use <see cref="After"/> are considered as having the same <see cref="Order"/> as the element they are referring.</para>
    /// </summary>
    public class SortingOrderData {
        /// <summary>
        /// Gets the element that should precede this element.
        /// </summary>
        public string After { get; private set; } = string.Empty;

        /// <summary>
        /// Gets a numeric value of where this element should be sorted.
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingOrderData"/> class.
        /// </summary>
        public SortingOrderData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingOrderData"/> class.
        /// </summary>
        /// <param name="after">The lement that should precede this element.</param>
        /// <param name="order">The numeric value of where this element should be stored.</param>
        public SortingOrderData(string after, int order) {
            After = after;
            Order = order;
        }
    }
}
