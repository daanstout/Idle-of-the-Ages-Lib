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
        /// The ID of the item this stack represents.
        /// </summary>
        public string ItemID { get; }

        /// <summary>
        /// The data for this item.
        /// </summary>
        public ItemData ItemData { get; }

        /// <summary>
        /// The metadata for this item.
        /// </summary>
        public Dictionary<string, string> Metadata { get; }

        /// <summary>
        /// The amount of items that are in this stack.
        /// </summary>
        public int StackSize { get; set; }
    }
}
