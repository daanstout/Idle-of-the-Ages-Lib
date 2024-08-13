// <copyright file="LootLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;

namespace IdleOfTheAgesRuntime;

/// <summary>
/// A library containing all <see cref="LootTable"/>s.
/// </summary>
[Service<ILootLibrary>(ServiceLevel = ServiceLevelEnum.Public)]
public class LootLibrary : ILootLibrary {
    /// <inheritdoc/>
    public Result<LootTable> GetLootTable(string target) => throw new System.NotImplementedException();

    /// <inheritdoc/>
    public Result RegisterLootTable(LootTable lootTable) => throw new System.NotImplementedException();
}
