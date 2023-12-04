// <copyright file="IItemStack.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.Inventory
{
    /// <summary>
    /// Represents a stack of items in the inventory.
    /// </summary>
    public interface IItemStack
    {
        /// <summary>
        /// Gets the ID of the item this stack represents.
        /// </summary>
        public string ItemID { get; }

        /// <summary>
        /// Gets the data for this item.
        /// </summary>
        public ItemData ItemData { get; }

        /// <summary>
        /// Gets the metadata for this item.
        /// </summary>
        public Dictionary<string, string> Metadata { get; }

        /// <summary>
        /// Gets or sets the amount of items that are in this stack.
        /// </summary>
        public int StackSize { get; set; }
    }
}
