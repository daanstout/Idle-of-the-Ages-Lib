// <copyright file="ActionData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// Contains data about all the actions available within a skill.
/// </summary>
public class ActionData {
    /// <summary>
    /// Gets the skill the actions apply to.
    /// </summary>
    public string SkillID { get; private set; }

    /// <summary>
    /// Gets the actions that should be added to the skill.
    /// </summary>
    public IReadOnlyCollection<ActionElement> Actions { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ActionData"/> class.
    /// </summary>
    /// <param name="skillID">The ID of the skill this action is meant to work on.</param>
    /// <param name="actions">The actions to add to the skill.</param>
    public ActionData(string skillID, IReadOnlyCollection<ActionElement> actions) {
        SkillID = skillID;
        Actions = actions;
    }
}
