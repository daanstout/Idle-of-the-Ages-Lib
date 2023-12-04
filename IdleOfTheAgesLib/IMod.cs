// <copyright file="IMod.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.DependencyInjection;

namespace IdleOfTheAgesLib
{
    /// <summary>
    /// The entry class for a Mod.
    /// <para>Mod initialization happens in steps:
    /// <list type="number">
    /// <item>The <see cref="IModObject"/> is created with the relevant objects for the mod.</item>
    /// <item>Services with a <see cref="ServiceAttribute"/> are registered with the <see cref="IServiceRegistry"/>.</item>
    /// <item><see cref="RegisterPublicServices(IServiceRegistry)"/> is called, allowing for public services to be registered.</item>
    /// <item><see cref="RegisterServices(IServiceRegistry)"/> is called, allowing for private services to be registered.</item>
    /// <item><see cref="ModLoaded(IServiceLibrary)"/> is called. Other mods are still to be loaded, so only do things that need to happen early.</item>
    /// <item><see cref="AppLoaded(IServiceLibrary)"/> is called once the game and all mods have been loaded, but before the main menu is shown. This is where menu modifications and game modes should be loaded.</item>
    /// <item><see cref="GameLoaded(IServiceLibrary)"/> is called once the player has selected a game. This is where most game modifications should go.</item>
    /// </list>
    /// </para>
    /// </summary>
    public interface IMod {
        /// <summary>
        /// This function can be used to register the services used by the mod.
        /// <para>The services registered are registered within the mod's namespace.</para>
        /// </summary>
        /// <param name="serviceRegistry">The service registry to register services to.</param>
        void RegisterServices(IServiceRegistry serviceRegistry);

        /// <summary>
        /// This function can be used to register services from this mod that should be accessible to other mods.
        /// <para>Keep in mind that services registered here can only use other public services, or services provided by the base game.
        /// services registered with <see cref="RegisterServices(IServiceRegistry)"/> can not be used within public services.</para>
        /// </summary>
        /// <param name="serviceRegistry">The service registry to register services to.</param>
        void RegisterPublicServices(IServiceRegistry serviceRegistry);

        /// <summary>
        /// This function is called when the app has loaded, before the main menu is shown.
        /// </summary>
        /// <param name="serviceLibrary">The service library for this mod.</param>
        void AppLoaded(IServiceLibrary serviceLibrary);

        /// <summary>
        /// This function is called when the game has loaded, when the player has selected a save.
        /// </summary>
        /// <param name="serviceLibrary">The service library for this mod.</param>
        void GameLoaded(IServiceLibrary serviceLibrary);

        /// <summary>
        /// This function is called directly after the mod has been loaded.
        /// <para>Keep in mind that mod loading in general is still in progress.</para>
        /// </summary>
        /// <param name="serviceLibrary">The service library for this mod.</param>
        void ModLoaded(IServiceLibrary serviceLibrary);
    }
}
