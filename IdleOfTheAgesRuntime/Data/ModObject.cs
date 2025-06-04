// <copyright file="ModObject.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using System.Reflection;

namespace IdleOfTheAgesRuntime.Data;

/// <summary>
/// Contains all relevant mod data.
/// </summary>
public class ModObject : IModObject {
    /// <inheritdoc/>
    public required string Namespace { get; init; }

    /// <inheritdoc/>
    public required IMod Mod { get; set; }

    /// <inheritdoc/>
    public required IServiceLibrary ServiceLibrary { get; set; } = null!;

    /// <inheritdoc/>
    public required IServiceRegistry ServiceRegistry { get; set; } = null!;

    /// <inheritdoc/>
    public required Assembly ModAssembly { get; set; } = null!;

    /// <summary>
    /// Initializes the Mod Object.
    /// </summary>
    public void Init() {
        ServiceLibrary.Bind<IModObject>().Value!.ToInstance(this);
    }
}
