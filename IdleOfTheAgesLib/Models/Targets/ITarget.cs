// <copyright file="ITarget.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Models.Targets;

/// <summary>
/// Represents an interface that can be used to target a certain thing, such as actions, skills, or skill categories.
/// </summary>
public interface ITarget {
    /// <summary>
    /// Gets the parent target type that this falls under.
    /// </summary>
    ITarget? Parent { get; }

    /// <summary>
    /// Gets the ID of what is being targeted.
    /// </summary>
    string ID { get; }
}
