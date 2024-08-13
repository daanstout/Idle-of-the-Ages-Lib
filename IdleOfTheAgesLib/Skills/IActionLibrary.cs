// <copyright file="IActionLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models.ModJsonData;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Skills;

/// <summary>
/// A library to hold the actions available.
/// </summary>
public interface IActionLibrary {
    /// <summary>
    /// Gets all the action elements for a specific skill.
    /// <para>The action elements are sorted based on their <see cref="ActionElement.RequiredLevel"/> value, going from low to high.</para>
    /// </summary>
    /// <param name="skillID">The skill to get the action elements for.</param>
    /// <returns>The action elements that have been registered for the specific skill.</returns>
    IEnumerable<ActionElement> GetAllActionsForSkill(string skillID);

    /// <summary>
    /// Registers actions to the library.
    /// </summary>
    /// <param name="action">The action to register.</param>
    /// <returns>Returns whether the action was successfully added.</returns>
    Result RegisterAction(ActionData action);
}
