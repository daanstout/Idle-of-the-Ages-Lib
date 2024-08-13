// <copyright file="DependencyInjector.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Extensions.ServiceLibrary;
using System;

namespace IdleOfTheAgesRuntime.DependencyInjection;

/// <summary>
/// A service that can inject objects with dependencies.
/// </summary>
[Service<IDependencyInjector>(ServiceLevel = ServiceLevelEnum.Public)]
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
    public Result InjectDependencies(object target) {
        if (target == null) {
            return (false, "Target is null!", new ArgumentNullException(nameof(target)));
        }

        var type = target.GetType();

        var method = type.GetMethod("InjectDependencies");

        if (method == null) {
            return (false, "No inject dependencies method found on object.", new ArgumentException(null, nameof(target)));
        }

        var parameters = serviceLibrary.GetInstances(method.GetParameters());

        method.Invoke(target, parameters);

        return true;
    }
}
