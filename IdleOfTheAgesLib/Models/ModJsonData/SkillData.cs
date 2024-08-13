// <copyright file="SkillData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// Represents the data for a skill that is being added.
/// </summary>
public class SkillData : ThumbnailDataElement {
    /// <summary>
    /// Gets the skill category this Skill falls under.
    /// </summary>
    public string SkillCategory { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkillData"/> class.
    /// </summary>
    /// <param name="namespace">The namespace of the element.</param>
    /// <param name="id">The ID of the element.</param>
    /// <param name="name">The name of the element.</param>
    /// <param name="translationKey">The translation key of the element.</param>
    /// <param name="sortingOrder">The sorting order of the element.</param>
    /// <param name="thumbnail">The thumbnail for the element.</param>
    /// <param name="skillCategory">The skill category this skill falls under.</param>
    public SkillData(
        string @namespace,
        string id,
        string name,
        string translationKey,
        SortingOrderData sortingOrder,
        string thumbnail,
        string skillCategory) : base(@namespace, id, name, translationKey, sortingOrder, thumbnail) {
        SkillCategory = skillCategory;
    }
}
