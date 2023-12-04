// <copyright file="IModObject.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.DependencyInjection;

namespace IdleOfTheAgesLib {
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
        /// Gets the service library containing this mod's services.
        /// </summary>
        IServiceLibrary ServiceLibrary { get; }
    }
}