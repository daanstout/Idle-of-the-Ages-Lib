// <copyright file="TargetType.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// Represents a type something can target.
/// </summary>
public enum TargetType {
    /// <summary>
    /// Indicates a <see cref="SkillData"/> is being targeted.
    /// </summary>
    Skill,

    /// <summary>
    /// Indicates an <see cref="ActionData"/> is being targeted.
    /// </summary>
    Action,
}
