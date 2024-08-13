// <copyright file="IActivity.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Activity;

/// <summary>
/// An activity the user can do.
/// </summary>
public interface IActivity {
    /// <summary>
    /// Ticks the activity.
    /// </summary>
    /// <param name="deltaTime">The time since the last tick.</param>
    void Tick(float deltaTime);
}
