// <copyright file="SkillTarget.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.Targets;

/// <summary>
/// Indicates that something is targeting a <see cref="ModJsonData.SkillData"/>.
/// </summary>
public class SkillTarget : ITarget {
    /// <inheritdoc/>
    public ITarget? Parent { get; }

    /// <inheritdoc/>
    public string ID { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkillTarget"/> class.
    /// </summary>
    /// <param name="parent">The skill category this skill is a part of.</param>
    /// <param name="id">The ID of the <see cref="ModJsonData.SkillData"/> that is being targeted.</param>
    public SkillTarget(SkillCategoryTarget parent, string id) {
        Parent = parent;
        ID = id;
    }
}
