// <copyright file="ServiceAttribute.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.DependencyInjection;
using System;

namespace IdleOfTheAgesLib;

/// <summary>
/// Can be used to indicate whether the service is only for private use, or also for public use.
/// </summary>
public enum ServiceLevelEnum {
    /// <summary>
    /// Default value.
    /// </summary>
    None,

    /// <summary>
    /// The service can also be requested by other mods.
    /// </summary>
    Public,

    /// <summary>
    /// The service is only for the mod itself.
    /// </summary>
    Private,
}

/// <summary>
/// An attribute that can be put on services to indicate they are a service.
/// <para>Using this attribute makes it so you don't have to register services in a <see cref="IServiceRegistry"/>.</para>
/// </summary>
/// <typeparam name="TInterface">The type of the interface that the service is implementing.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ServiceAttribute<TInterface>() : Attribute {
    /// <summary>
    /// Gets the type of the interface this service is implementing.
    /// </summary>
    public Type InterfaceType { get; } = typeof(TInterface);

    /// <summary>
    /// Gets the key for identifying this service.
    /// </summary>
    public string? Key { get; init; }

    /// <summary>
    /// Gets whether this service should be public or private.
    /// </summary>
    public ServiceLevelEnum ServiceLevel { get; init; } = ServiceLevelEnum.Public;
}
