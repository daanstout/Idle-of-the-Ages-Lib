// <copyright file="IModObject.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.DependencyInjection;
using System.Reflection;

namespace IdleOfTheAgesLib;

/// <summary>
/// Contains all relevant mod data.
/// </summary>
public interface IModObject {
    /// <summary>
    /// Gets a logger to log data to.
    /// </summary>
    ILogger Logger { get; }

    /// <summary>
    /// Gets the instance of the mod's initializer class.
    /// </summary>
    IMod Mod { get; }

    /// <summary>
    /// Gets the namespace of the mod.
    /// </summary>
    string Namespace { get; }

    /// <summary>
    /// Gets the mod's private service library.
    /// </summary>
    IServiceLibrary ServiceLibrary { get; }

    /// <summary>
    /// Gets the service registry from this mod to register services to.
    /// </summary>
    IServiceRegistry ServiceRegistry { get; }

    /// <summary>
    /// Gets the mod's assembly.
    /// </summary>
    Assembly ModAssembly { get; }
}
