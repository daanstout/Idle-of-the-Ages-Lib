// <copyright file="IResolver.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.DependencyInjection;

/// <summary>
/// A resolver to resolve a dependency to an instance.
/// </summary>
public interface IResolver {
    /// <summary>
    /// Gets or sets a factory that can be used to resolve the instance.
    /// </summary>
    Func<IServiceLibrary, object>? Factory { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a boolean that indicates whether or not the target is a singleton.
    /// </summary>
    bool IsSingleton { get; set; }

    /// <summary>
    /// Resolves the dependency to the instance, creating a new one if one doesn't exist yet.
    /// </summary>
    /// <param name="serviceLibrary">The <see cref="IServiceLibrary"/> to obtain the dependencies from.</param>
    /// <returns>An instance of the dependency.</returns>
    object Resolve(IServiceLibrary serviceLibrary);

    /// <summary>
    /// Sets the instance this resolver should use.
    /// </summary>
    /// <param name="instance">The instance to use.</param>
    void ToInstance(object? instance);

    /// <summary>
    /// Sets the type created instances should be.
    /// </summary>
    /// <param name="instanceType">The type created instances should be.</param>
    void SetInstanceType(Type instanceType);
}

/// <summary>
/// A resolver to resolve a dependency to an instance.
/// </summary>
/// <typeparam name="TType">The type the resolver resolves for.</typeparam>
public interface IResolver<TType> : IResolver
    where TType : class {
    /// <summary>
    /// Resolves the dependency to the instance, creating a new one if one doesn't exist yet.
    /// </summary>
    /// <param name="serviceLibrary">The <see cref="IServiceLibrary"/> to obtain the dependencies from.</param>
    /// <returns>An instance of the dependency.</returns>
    new TType Resolve(IServiceLibrary serviceLibrary);
}
