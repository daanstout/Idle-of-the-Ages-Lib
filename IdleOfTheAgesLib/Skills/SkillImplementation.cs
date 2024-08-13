// <copyright file="SkillImplementation.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Models.ModJsonData;

namespace IdleOfTheAgesLib.Skills;

/// <summary>
/// A skill that can be practiced by the player.
/// </summary>
public abstract class SkillImplementation {
    /// <summary>
    /// Gets the namespace the skill exists in.
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// Gets the data for the skill.
    /// </summary>
    public SkillData SkillData { get; }

    /// <summary>
    /// Gets or sets the current level of the skill.
    /// </summary>
    public int CurrentSkillLevel { get; set; }

    /// <summary>
    /// Gets the maximum level of this skill.
    /// </summary>
    public int MaxSkillLevel { get; }

    /// <summary>
    /// Gets the skill's namespaced ID.
    /// </summary>
    public string NamespacedID => $"{Namespace}:{SkillData.ID}";

    /// <summary>
    /// Initializes a new instance of the <see cref="SkillImplementation"/> class.
    /// </summary>
    /// <param name="skillData">The json data for the skill.</param>
    public SkillImplementation(SkillData skillData) {
        Namespace = skillData.Namespace;
        SkillData = skillData;
    }

    /// <summary>
    /// Initializes the skill.
    /// </summary>
    /// <param name="serviceLibrary">The service library to obtain services from.</param>
    public virtual void Initialize(IServiceLibrary serviceLibrary) { }
}
