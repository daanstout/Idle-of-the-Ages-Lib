// <copyright file="ItemStack.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Inventory;
using IdleOfTheAgesLib.Models.ModJsonData;

using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.Inventory {
    /// <summary>
    /// Represents a stack of items in the inventory.
    /// </summary>
    public class ItemStack : IItemStack {
        /// <inheritdoc/>
        public string ItemID { get; }

        /// <inheritdoc/>
        public ItemData ItemData { get; }

        /// <inheritdoc/>
        public Dictionary<string, string> Metadata { get; } = new Dictionary<string, string>();

        /// <inheritdoc/>
        public int StackSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemStack"/> class.
        /// </summary>
        /// <param name="itemID">The ID of the item this item stack represents.</param>
        /// <param name="itemData">The item data for this item stack.</param>
        public ItemStack(string itemID, ItemData itemData) {
            ItemID = itemID;
            ItemData = itemData;
        }
    }
}
