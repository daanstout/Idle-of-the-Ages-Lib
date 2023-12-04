// <copyright file="ServiceLibraryExtensions.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IdleOfTheAgesLib.Extensions.ServiceLibrary {
    /// <summary>
    /// Contains extensions for the <see cref="IServiceLibrary"/> interface.
    /// </summary>
    public static class ServiceLibraryExtensions {
        /// <summary>
        /// Obtains instances for the provided <paramref name="types"/>.
        /// </summary>
        /// <param name="serviceLibrary">The service library to get the instances from.</param>
        /// <param name="types">The parameters to obtain instances for.</param>
        /// <returns>An <see cref="Array"/> containing the instances in order.</returns>
        public static object[] GetInstances(this IServiceLibrary serviceLibrary, IEnumerable<ParameterInfo> types) {
            if (serviceLibrary == null) {
                throw new ArgumentNullException(nameof(serviceLibrary));
            }

            var typesArray = types.ToArray();

            object[] result = new object[typesArray.Length];

            for (int i = 0; i < typesArray.Length; i++) {
                var param = typesArray[i];

                var attrib = param.GetCustomAttribute<DependencyIdentifierAttribute>();

                result[i] = serviceLibrary.Get(param.ParameterType, attrib?.Key);
            }

            return result;
        }
    }
}
