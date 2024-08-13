// <copyright file="Resolver.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Extensions.ServiceLibrary;
using System;
using System.Linq;

namespace IdleOfTheAgesRuntime.DependencyInjection;

/// <summary>
/// A resolver to resolve a dependency to an instance.
/// </summary>
/// <typeparam name="TType">The type the resolver resolves for.</typeparam>
public class Resolver<TType> : IResolver<TType>
    where TType : class {
    /// <inheritdoc/>
    public Func<IServiceLibrary, object>? Factory { get; set; }

    /// <inheritdoc/>
    public bool IsSingleton { get; set; } = true;

    private Type instanceType;
    private TType? instance;
    private bool isResolved;
    private bool isResolving;

    /// <summary>
    /// Initializes a new instance of the <see cref="Resolver{TType}"/> class.
    /// </summary>
    /// <param name="instanceType">The type this resolver should resolve to.</param>
    public Resolver(Type instanceType) {
        this.instanceType = instanceType;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Resolver{TType}"/> class.
    /// </summary>
    public Resolver() : this(typeof(TType)) { }

    /// <inheritdoc/>
    object IResolver.Resolve(IServiceLibrary serviceLibrary) => Resolve(serviceLibrary);

    /// <inheritdoc/>
    public TType Resolve(IServiceLibrary serviceLibrary) {
        if (isResolved && this.instance != null) {
            return this.instance;
        }

        if (isResolving) {
            throw new CyclicalDependencyException($"Cyclical dependency found when resolving for {GetType().FullName}");
        }

        isResolving = true;
        TType instance;

        if (Factory != null) {
            instance = (TType)Factory(serviceLibrary);
        } else if (instanceType != null) {
            if (instanceType.IsAbstract || instanceType.IsInterface) {
                throw new InvalidOperationException($"Cannot create an instance of an abstract or interface type: {instanceType.FullName}.");
            }

            var constructor = instanceType.GetConstructors()[0];

            var objects = serviceLibrary.GetInstances(constructor.GetParameters());

            instance = (TType)constructor.Invoke(objects);
        } else if (!typeof(TType).IsInterface && !typeof(TType).IsAbstract) {
            var constructor = typeof(TType).GetConstructors()[0];

            var objects = serviceLibrary.GetInstances(constructor.GetParameters());

            instance = (TType)constructor.Invoke(objects);
        } else {
            throw new InvalidOperationException($"Cannot create instance for type {typeof(TType).FullName}! No factory or instance type has been provided.");
        }

        if (IsSingleton) {
            isResolved = true;
            this.instance = instance;
        }

        isResolving = false;
        return instance;
    }

    /// <inheritdoc/>
    public void ToInstance(object? instance) {
        isResolved = true;
        isResolving = false;
        IsSingleton = true;
        this.instance = instance as TType;
    }

    /// <inheritdoc/>
    public void SetInstanceType(Type instanceType) {
        this.instanceType = instanceType;
    }
}
