// <copyright file="ILootLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;

namespace IdleOfTheAgesLib;

/// <summary>
/// A library containing all <see cref="LootTable"/>s.
/// </summary>
public interface ILootLibrary {
    /// <summary>
    /// Registers a <see cref="LootTable"/>.
    /// </summary>
    /// <param name="lootTable">The <see cref="LootTable"/> to register.</param>
    /// <returns>Whether the table was successfully added.</returns>
    Result RegisterLootTable(LootTable lootTable);

    /// <summary>
    /// Gets a <see cref="LootTable"/> for a specific target.
    /// </summary>
    /// <param name="target">The target to get the <see cref="LootTable"/> for.</param>
    /// <returns>Returns the requested <see cref="LootTable"/>.</returns>
    Result<LootTable> GetLootTable(string target);
}
