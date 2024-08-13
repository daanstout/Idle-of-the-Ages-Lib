// <copyright file="ModifierOrder.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Skills;

/// <summary>
/// An enum that is used to indicate in what order the modifiers should be applied.
/// </summary>
public enum ModifierOrder {
    /// <summary>
    /// The <see cref="ModifierData.FlatModifier"/> should be applied first.
    /// </summary>
    FlatFirst,

    /// <summary>
    /// The <see cref="ModifierData.PercentModifier"/> should be applied first.
    /// </summary>
    PercentageFirst,
}
