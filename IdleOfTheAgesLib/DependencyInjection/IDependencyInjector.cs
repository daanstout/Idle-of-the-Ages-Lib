// <copyright file="IDependencyInjector.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using UnityEngine;

namespace IdleOfTheAgesLib.DependencyInjection {
    /// <summary>
    /// A service that can inject objects with dependencies.
    /// </summary>
    public interface IDependencyInjector {
        /// <summary>
        /// Injects an object with its dependencies through a function called: <code>InjectDependencies(...).</code>
        /// </summary>
        /// <param name="target">The object to inject.</param>
        void InjectDependencies(object target);

        /// <summary>
        /// Injects <see cref="MonoBehaviour"/>s on a <see cref="GameObject"/> with dependencies through a function called: <code>InjectDependencies(...).</code>
        /// </summary>
        /// <param name="gameObject">The gameobject to inject.</param>
        void InjectDependencies(GameObject gameObject);
    }
}
