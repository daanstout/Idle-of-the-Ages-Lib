﻿// <copyright file="IDependencyInjector.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.DependencyInjection;

/// <summary>
/// A service that can inject objects with dependencies.
/// </summary>
public interface IDependencyInjector {
    /// <summary>
    /// Injects an object with its dependencies through a function called: <code>InjectDependencies(...).</code>
    /// </summary>
    /// <param name="target">The object to inject.</param>
    /// <returns>Whether there were any issues with the injection.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="target"/> does not contain a function called `InjectDependencies`.</exception>
    Result InjectDependencies(object target);
}
