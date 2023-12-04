// <copyright file="IItemService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;

namespace IdleOfTheAgesLib.Inventory
{
    /// <summary>
    /// A service that holds data about all the items registered in the game.
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// Registers an item to the service.
        /// </summary>
        /// <param name="item">The item to register.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        public Result RegisterItem(ItemData item);

        /// <summary>
        /// Obtains the item data for an item.
        /// </summary>
        /// <param name="itemID">The item ID to obtain the item data for.</param>
        /// <returns>The item data for the item.</returns>
        public Result<ItemData> GetItemData(string itemID);
    }
}
