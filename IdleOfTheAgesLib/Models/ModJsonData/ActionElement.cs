// <copyright file="ActionElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// Represents an action that can be done in a skill.
/// </summary>
public class ActionElement : ThumbnailDataElement {
    /// <summary>
    /// Gets the base duration it takes to complete the action once.
    /// </summary>
    public float BaseDuration { get; }

    /// <summary>
    /// Gets the base xp amount that should be given to the player per completion.
    /// </summary>
    public float BaseXP { get; }

    /// <summary>
    /// Gets the base expertise amount that should be given to the player per completion.
    /// </summary>
    public float BaseExpertise { get; }

    /// <summary>
    /// Gets the base expertise pool amount that should be given to the player per completion.
    /// </summary>
    public float BaseExpertisePool { get; }

    /// <summary>
    /// Gets the required level to do the action.
    /// </summary>
    public int RequiredLevel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ActionElement"/> class.
    /// </summary>
    /// <param name="namespace">The namespace of the element.</param>
    /// <param name="id">The ID of the element.</param>
    /// <param name="name">The name of the element.</param>
    /// <param name="translationKey">The translation key of the element.</param>
    /// <param name="sortingOrder">The sorting order of the element.</param>
    /// <param name="thumbnail">The thumbnail for the element.</param>
    /// <param name="baseDuration">The base duration to complete the action once.</param>
    /// <param name="baseXP">The base xp obtained per completion.</param>
    /// <param name="baseExpertise">The base expertise obtained per completion.</param>
    /// <param name="baseExpertisePool">The base expertise pool obtained per completion.</param>
    /// <param name="requiredLevel">The required level to do the action.</param>
    public ActionElement(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder, string thumbnail, float baseDuration, float baseXP, float baseExpertise, float baseExpertisePool, int requiredLevel) : base(@namespace, id, name, translationKey, sortingOrder, thumbnail) {
        BaseDuration = baseDuration;
        BaseXP = baseXP;
        BaseExpertise = baseExpertise;
        BaseExpertisePool = baseExpertisePool;
        RequiredLevel = requiredLevel;
    }
}
