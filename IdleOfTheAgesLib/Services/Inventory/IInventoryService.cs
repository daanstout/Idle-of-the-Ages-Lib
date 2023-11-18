using System.Collections.Generic;

namespace IdleOfTheAgesLib.Inventory {
    /// <summary>
    /// Represents the player's inventory.
    /// </summary>
    public interface IInventoryService {
        /// <summary>
        /// Adds an item to the player's inventory.
        /// </summary>
        /// <param name="item">The item to add to the player's inventory.</param>
        Result AddItem(IItemStack item);

        /// <summary>
        /// Gets all the items in the player's inventory.
        /// </summary>
        /// <returns>An enumerable with all the items.</returns>
        IEnumerable<IItemStack> GetItems();
    }
}
