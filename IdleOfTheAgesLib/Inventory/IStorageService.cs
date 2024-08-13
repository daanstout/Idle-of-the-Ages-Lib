// <copyright file="IStorageService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.Inventory;

/// <summary>
/// Keeps track of all the items in the storage.
/// </summary>
public interface IStorageService {
    /// <summary>
    /// Adds an item to the player's storage.
    /// </summary>
    /// <typeparam name="TGroup">The storage group to add the item to.</typeparam>
    /// <param name="itemID">The item to add to the player's storage.</param>
    /// <param name="count">How many items to add.</param>
    /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
    Result AddItem<TGroup>(string itemID, int count = 1) where TGroup : IStorageGroup;

    /// <summary>
    /// Gets an item from the storage.
    /// </summary>
    /// <typeparam name="TGroup">The storage group to look in.</typeparam>
    /// <param name="itemID">The ID of the item to obtain.</param>
    /// <returns>The requested items.</returns>
    Result<IItemStack> GetItem<TGroup>(string itemID) where TGroup : IStorageGroup;

    /// <summary>
    /// Checks to see if an item with the provided ID exists within the storage.
    /// </summary>
    /// <typeparam name="TGroup">The storage group to look in.</typeparam>
    /// <param name="itemID">The ID of the item to obtain.</param>
    /// <returns><see langword="true"/> if the item exists, and <see langword="false"/> if not.</returns>
    Result ContainsItem<TGroup>(string itemID) where TGroup : IStorageGroup;

    /// <summary>
    /// Gets all the items in the player's storage.
    /// </summary>
    /// <returns>An enumerable with all the items.</returns>
    IEnumerable<IItemStack> GetItems();

    /// <summary>
    /// Gets all the items in the player's storage that are stored in the given storage group.
    /// </summary>
    /// <typeparam name="TGroup">The storage group to get the items from.</typeparam>
    /// <returns>An enumerable with all the items.</returns>
    IEnumerable<IItemStack> GetItems<TGroup>() where TGroup : IStorageGroup;
}
