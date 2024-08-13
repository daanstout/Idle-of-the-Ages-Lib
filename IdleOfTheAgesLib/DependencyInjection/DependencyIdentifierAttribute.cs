// <copyright file="DependencyIdentifierAttribute.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib;

/// <summary>
/// An attribute that can be applied to parameters to provide a key to the required dependency.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public class DependencyIdentifierAttribute : Attribute {
    /// <summary>
    /// Gets key of the dependency instance to obtain.
    /// </summary>
    public string Key { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DependencyIdentifierAttribute"/> class.
    /// </summary>
    /// <param name="key">The key of the dependency instance to obtain.</param>
    public DependencyIdentifierAttribute(string key) {
        Key = key;
    }
}
