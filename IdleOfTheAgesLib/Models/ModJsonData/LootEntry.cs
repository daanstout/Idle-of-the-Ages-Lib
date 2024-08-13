// <copyright file="LootEntry.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// Represents a loot entry within a loot table.
/// </summary>
public class LootEntry {
    /// <summary>
    /// Gets the item this entry is representing.
    /// </summary>
    public string ItemID { get; }

    /// <summary>
    /// Gets a value indicating whether this entry is a guaranteed drop when checking this loot table.
    /// <para>If this is <see langword="true"/>, <see cref="Weight"/> and <see cref="Percentage"/> are ignored and this entry doesn't impact the other entries.</para>
    /// </summary>
    public bool Guaranteed { get; }

    /// <summary>
    /// Gets the base amount of items to drop when rolling this entry.
    /// </summary>
    public int BaseAmount { get; }

    /// <summary>
    /// Gets the weight for this entry.
    /// <para>Only 1 entry within a <see cref="LootTable"/> that have weights can drop.</para>
    /// <para>If this entry can drop regardless of other drops, use <see cref="Percentage"/> instead.</para>
    /// </summary>
    public float? Weight { get; }

    /// <summary>
    /// Gets the percentage chance for this entry to drop.
    /// <para>All entries with a set percentage within a <see cref="LootTable"/> can potentially drop independently from eachother and entries that have a <see cref="Weight"/>.</para>
    /// <para>If this entry is part of a set of which only 1 can drop, use <see cref="Weight"/> instead.</para>
    /// </summary>
    public float? Percentage { get; }

    /// <summary>
    /// Gets the action that should be performed on the loot entry. This value defaults to "add".
    /// <list type="bullet">
    /// <item>add: Adds the entry to the loot table</item>
    /// <item>remove: Removes the entry from the loot table</item>
    /// <item>update: Updates the entry within the loot table</item>
    /// </list>
    /// </summary>
    public string Action { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootEntry"/> class.
    /// </summary>
    /// <param name="itemID">The ID of the item this entry should drop.</param>
    /// <param name="guaranteed">Whether the item is a guaranteed drop.</param>
    /// <param name="baseAmount">The base amount of the item to drop.</param>
    /// <param name="weight">The weigth of the drop.</param>
    /// <param name="percentage">The percentage chance this item drops.</param>
    /// <param name="action">The action that should be applied.</param>
    public LootEntry(string itemID, bool guaranteed, int baseAmount, float? weight, float? percentage, string action) {
        ItemID = itemID;
        Guaranteed = guaranteed;
        BaseAmount = baseAmount;
        Weight = weight;
        Percentage = percentage;
        Action = action;
    }
}
