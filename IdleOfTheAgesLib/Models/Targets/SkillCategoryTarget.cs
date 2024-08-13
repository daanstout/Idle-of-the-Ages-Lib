// <copyright file="SkillCategoryTarget.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.Targets;

/// <summary>
/// Indicates that something is targeting a <see cref="ModJsonData.SkillCategoryData"/>.
/// </summary>
public class SkillCategoryTarget : ITarget {
    /// <inheritdoc/>
    public ITarget? Parent { get; } = null;

    /// <inheritdoc/>
    public string ID { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkillCategoryTarget"/> class.
    /// </summary>
    /// <param name="id">The ID of the <see cref="ModJsonData.SkillCategoryData"/> that is being targeted.</param>
    public SkillCategoryTarget(string id) {
        ID = id;
    }
}
