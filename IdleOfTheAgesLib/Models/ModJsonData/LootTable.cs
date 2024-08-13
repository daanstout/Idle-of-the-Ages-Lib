// <copyright file="LootTable.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// Represents a loot table to get loot drops from.
/// </summary>
public class LootTable {
    /// <summary>
    /// Gets the type of thing this table is targeting.
    /// </summary>
    public TargetType TargetType { get; }

    /// <summary>
    /// Gets the ID of the thing this table is targeting.
    /// </summary>
    public string TargetID { get; }

    /// <summary>
    /// Gets the possible loot that can be obtained.
    /// </summary>
    public IReadOnlyList<LootEntry> LootEntries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootTable"/> class.
    /// </summary>
    /// <param name="targetType">The type of thing this table is targeting.</param>
    /// <param name="targetID">The ID of the thing to target.</param>
    /// <param name="lootEntries">The entires that can be obtained.</param>
    public LootTable(TargetType targetType, string targetID, IReadOnlyList<LootEntry> lootEntries) {
        TargetType = targetType;
        TargetID = targetID;
        LootEntries = lootEntries;
    }
}
