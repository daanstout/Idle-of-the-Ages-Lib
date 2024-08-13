// <copyright file="SkillCategoryData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// A category a skill can be a part of.
/// </summary>
public class SkillCategoryData : BaseDataElement {
    /// <summary>
    /// Initializes a new instance of the <see cref="SkillCategoryData"/> class.
    /// </summary>
    /// <param name="namespace">The namespace of the element.</param>
    /// <param name="id">The ID of the element.</param>
    /// <param name="name">The name of the element.</param>
    public SkillCategoryData(string @namespace, string id, string name) : base(@namespace, id, name) {
    }
}
