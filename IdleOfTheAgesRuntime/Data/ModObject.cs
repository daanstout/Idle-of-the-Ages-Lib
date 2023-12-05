// <copyright file="ModObject.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;

using System.Reflection;

namespace IdleOfTheAgesRuntime.Data {
    /// <summary>
    /// Contains all relevant mod data.
    /// </summary>
    public class ModObject : IModObject {
        /// <inheritdoc/>
        public string Namespace { get; set; } = string.Empty;

        /// <inheritdoc/>
        public IMod Mod { get; set; } = null!;

        /// <inheritdoc/>
        public ILogger Logger { get; set; } = null!;

        /// <inheritdoc/>
        public IServiceLibrary ServiceLibrary { get; set; } = null!;

        /// <inheritdoc/>
        public IServiceRegistry ServiceRegistry { get; set; } = null!;

        /// <inheritdoc/>
        public Assembly ModAssembly { get; set; } = null!;

        /// <summary>
        /// Initializes the Mod Object.
        /// </summary>
        public void Init() {
            ServiceLibrary.Bind<IModObject>().ToInstance(this);
            ServiceLibrary.Bind<ILogger>().ToInstance(Logger);
        }
    }
}
