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
    private readonly string injectDependenciesMethodName;

    /// <summary>
    /// Initializes a new instance of the <see cref="DependencyInjector"/> class.
    /// </summary>
    /// <param name="serviceLibrary">The service library to get the dependencies from.</param>
    /// <param name="injectDependenciesMethodName">The method to call to inject dependencies in to an object.</param>
    public DependencyInjector(IServiceLibrary serviceLibrary, string injectDependenciesMethodName = "InjectDependencies") {
        this.serviceLibrary = serviceLibrary;
        this.injectDependenciesMethodName = injectDependenciesMethodName;
    }

    /// <inheritdoc/>
    public Result InjectDependencies(object target) {
        if (target == null) {
            return (false, "Target is null!", new ArgumentNullException(nameof(target)));
        }

        var type = target.GetType();

        var method = type.GetMethod(injectDependenciesMethodName);

        if (method == null) {
            return (false, $"No method found on object called '{injectDependenciesMethodName}'.", new ArgumentException(null, nameof(target)));
        }

        var parameters = serviceLibrary.GetInstances(method.GetParameters());

        try {
            method.Invoke(target, parameters);
        } catch (Exception e) {
            return (false, $"An error occured while trying to inject the object.", e);
        }

        return true;
    }
}
