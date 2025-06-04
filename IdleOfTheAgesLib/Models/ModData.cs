// <copyright file="ModData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Models;

/// <summary>
/// The data class is used for defining mod gameplay data.
/// </summary>
public class ModData {
    /// <summary>
    /// Gets the namespace the data sits in.
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// Gets the skill categories that the mod adds.
    /// </summary>
    public IReadOnlyList<SkillCategoryData> SkillCategories { get; }

    /// <summary>
    /// Gets the skills that the mod adds.
    /// </summary>
    public IReadOnlyList<SkillData> Skills { get; }

    /// <summary>
    /// Gets the page groups that the mod adds.
    /// </summary>
    public IReadOnlyList<PageGroupData> PageGroups { get; }

    /// <summary>
    /// Gets the pages that the mod adds.
    /// </summary>
    public IReadOnlyList<PageData> Pages { get; }

    /// <summary>
    /// Gets the items that the mod adds.
    /// </summary>
    public IReadOnlyList<ItemData> Items { get; }

    /// <summary>
    /// Gets the actions that the mod adds.
    /// </summary>
    public IReadOnlyList<ActionData> Actions { get; }

    /// <summary>
    /// Gets the loot tables that the mod adds.
    /// </summary>
    public IReadOnlyList<LootTable> LootTables { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModData"/> class.
    /// </summary>
    /// <param name="namespace">The namespace of the mod.</param>
    /// <param name="skillCategories">The skill categories this mod adds.</param>
    /// <param name="skills">The skills this mod adds.</param>
    /// <param name="pageGroups">The page groups this mod adds.</param>
    /// <param name="pages">The pages this mod adds.</param>
    /// <param name="items">The items this mod adds.</param>
    /// <param name="actions">The actions this mod adds.</param>
    /// <param name="lootTables">The loot tables this mod adds.</param>
    public ModData(string @namespace, IReadOnlyList<SkillCategoryData>? skillCategories = null, IReadOnlyList<SkillData>? skills = null,
        IReadOnlyList<PageGroupData>? pageGroups = null, IReadOnlyList<PageData>? pages = null, IReadOnlyList<ItemData>? items = null,
        IReadOnlyList<ActionData>? actions = null, IReadOnlyList<LootTable>? lootTables = null) {
        Namespace = @namespace;
        SkillCategories = skillCategories ?? [];
        Skills = skills ?? [];
        PageGroups = pageGroups ?? [];
        Pages = pages ?? [];
        Items = items ?? [];
        Actions = actions ?? [];
        LootTables = lootTables ?? [];
    }
}
