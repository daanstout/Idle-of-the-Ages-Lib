// <copyright file="DependencyInjector.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Extensions.ServiceLibrary;

using UnityEngine;

namespace IdleOfTheAgesRuntime.DependencyInjection {
    /// <summary>
    /// A service that can inject objects with dependencies.
    /// </summary>
    [Service(typeof(IDependencyInjector), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class DependencyInjector : IDependencyInjector {
        private readonly IServiceLibrary serviceLibrary;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyInjector"/> class.
        /// </summary>
        /// <param name="serviceLibrary">The service library to get the dependencies from.</param>
        public DependencyInjector(IServiceLibrary serviceLibrary) {
            this.serviceLibrary = serviceLibrary;
        }

        /// <inheritdoc/>
        public void InjectDependencies(object target) {
            var type = target.GetType();

            var method = type.GetMethod("InjectDependencies");

            if (method == null) {
                return;
            }

            var parameters = serviceLibrary.GetInstances(method.GetParameters());

            method.Invoke(target, parameters);
        }

        /// <inheritdoc/>
        public void InjectDependencies(GameObject gameObject) {
            foreach (var behaviour in gameObject.GetComponentsInChildren<MonoBehaviour>()) {
                InjectDependencies(behaviour);
            }
        }
    }
}
