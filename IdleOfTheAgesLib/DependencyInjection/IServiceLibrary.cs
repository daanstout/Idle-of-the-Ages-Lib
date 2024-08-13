// <copyright file="IServiceLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IdleOfTheAgesLib.DependencyInjection;

/// <summary>
/// A library where services that are registered through a <see cref="IServiceRegistry"/> can be obtained from.
/// </summary>
public interface IServiceLibrary : IServiceRegistry {
    /// <summary>
    /// Gets the instance for the requested <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type to get the instance for.</typeparam>
    /// <param name="key">The key to the specific instance.</param>
    /// <returns>The requested instance.</returns>
    TType Get<TType>(string? key = null)
        where TType : class;

    /// <summary>
    /// Gets the instance for the requested <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to get the instance for.</param>
    /// <param name="key">The key to the specific instance.</param>
    /// <returns>The requested instance.</returns>
    object Get(Type type, string? key = null);

    /// <summary>
    /// Obtains a list of the names of all registered services that can be obtained.
    /// </summary>
    /// <returns>A list of names of all registered services.</returns>
    IEnumerable<string> GetAllServiceNames();

    /// <summary>
    /// Obtains a list of all services that are registered for a given type, regardless of the key they have been registered with.
    /// </summary>
    /// <param name="type">The type to search for.</param>
    /// <returns>A list of all interfaces for the provided type.</returns>
    IEnumerable<object> GetAllServices(Type type);

    /// <summary>
    /// Obtains a list of all services that are registered for a given type, regardless of the key they have been registered with.
    /// </summary>
    /// <typeparam name="TType">The type to search for.</typeparam>
    /// <returns>A list of all interfaces for the provided type.</returns>
    IEnumerable<TType> GetAllServices<TType>();

    /// <summary>
    /// Checks whether or not a service is registered with the given key.
    /// </summary>
    /// <typeparam name="TType">The service to check for.</typeparam>
    /// <param name="key">The key to check with.</param>
    /// <returns><see langword="true"/> if the service exists, <see langword="false"/> if not.</returns>
    bool ContainsService<TType>(string? key = null);

    /// <summary>
    /// Checks whether or not a service is registered with the given key.
    /// </summary>
    /// <param name="type">The service to check for.</param>
    /// <param name="key">The key to check with.</param>
    /// <returns><see langword="true"/> if the service exists, <see langword="false"/> if not.</returns>
    bool ContainsService(Type type, string? key = null);

    /// <summary>
    /// Tries to get the instance for the requested <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type to get the instance for.</typeparam>
    /// <param name="result">The instance.</param>
    /// <param name="key">The key to the specific instance.</param>
    /// <returns><see langword="true"/> if the instance was succesfully found. <see langword="false"/> if not.</returns>
    bool TryGet<TType>([NotNullWhen(true)] out TType? result, string? key = null);

    /// <summary>
    /// Tries to get the instance for the requested <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to get the instance for.</param>
    /// <param name="result">The instance.</param>
    /// <param name="key">The key to the specific instance.</param>
    /// <returns><see langword="true"/> if the instance was succesfully found. <see langword="false"/> if not.</returns>
    bool TryGet(Type type, [NotNullWhen(true)] out object? result, string? key = null);
}
