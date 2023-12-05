// <copyright file="ModLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime {
    /// <summary>
    /// A library that contains all the mods that have been laoded.
    /// </summary>
    [Service(typeof(IModLibrary), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class ModLibrary : IModLibrary {
        private readonly Dictionary<string, IModObject> loadedMods = new Dictionary<string, IModObject>();

        /// <inheritdoc/>
        public Result<IModObject> GetModObject(string @namespace) {
            if (string.IsNullOrWhiteSpace(@namespace)) {
                return (null!, "Namespace is empty!", new ArgumentNullException(nameof(@namespace)));
            }

            if (loadedMods.TryGetValue(@namespace, out var result)) {
                return new Result<IModObject>(result);
            }

            return (null!, $"No mod registered with namespace {@namespace}", new ArgumentException(null, nameof(@namespace)));
        }

        /// <inheritdoc/>
        public Result ModExists(string @namespace) => loadedMods.ContainsKey(@namespace);

        /// <inheritdoc/>
        public Result RegisterMod(string @namespace, IModObject modObject) {
            loadedMods.Add(@namespace, modObject);
            return true;
        }

        /// <inheritdoc/>
        public IEnumerable<IModObject> GetAllMods() {
            return loadedMods.Values;
        }
    }
}
