// <copyright file="Mod.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;

namespace IdleOfTheAgesGame;

/// <summary>
/// The entrance point of the mod.
/// </summary>
public class Mod : IMod {
    /// <inheritdoc/>
    public void AppLoaded(IServiceLibrary serviceLibrary) {
        serviceLibrary.Get<ILogger>().Info("App Loaded");
    }

    /// <inheritdoc/>
    public void GameLoaded(IServiceLibrary serviceLibrary) {
        serviceLibrary.Get<ILogger>().Info("Game Loaded");
    }

    /// <inheritdoc/>
    public void LoadData(IServiceLibrary serviceLibrary) {
        serviceLibrary.Get<IDataLoader>().LoadData(serviceLibrary.Get<IModObject>());
    }

    /// <inheritdoc/>
    public void ModLoaded(IServiceLibrary serviceLibrary) {
        serviceLibrary.Get<ILogger>().Info("Mod Loaded");
    }

    /// <inheritdoc/>
    public void RegisterPublicServices(IServiceRegistry serviceRegistry) { }

    /// <inheritdoc/>
    public void RegisterServices(IServiceRegistry serviceRegistry) { }
}
