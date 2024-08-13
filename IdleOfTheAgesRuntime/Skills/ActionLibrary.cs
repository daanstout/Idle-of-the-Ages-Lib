// <copyright file="ActionLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;
using System;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.Skills;

/// <summary>
/// A library to hold the actions available.
/// </summary>
[Service<IActionLibrary>(ServiceLevel = ServiceLevelEnum.Public)]
public class ActionLibrary : IActionLibrary {
    private readonly Dictionary<string, List<ActionElement>> actions = [];

    /// <inheritdoc/>
    public Result RegisterAction(ActionData action) {
        if (action == null)
            return (false, "Cannot add \"NULL\" action!", new ArgumentNullException(nameof(action)));

        if (!actions.TryGetValue(action.SkillID, out var list)) {
            list = [];
            actions[action.SkillID] = list;
        }

        foreach (var actionElement in action.Actions) {
            var index = list.FindIndex(element => element.RequiredLevel > actionElement.RequiredLevel);
            list.Insert(index, actionElement);
        }

        return true;
    }

    /// <inheritdoc/>
    public IEnumerable<ActionElement> GetAllActionsForSkill(string skillID) {
        if (actions.TryGetValue(skillID, out var list))
            return list;

        return [];
    }
}
