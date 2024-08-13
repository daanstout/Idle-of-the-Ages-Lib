// <copyright file="ServiceLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IdleOfTheAgesRuntime.DependencyInjection;

/// <summary>
/// A library where services that are registered through a <see cref="IServiceRegistry"/> can be obtained from.
/// </summary>
public sealed class ServiceLibrary : IServiceLibrary, IServiceRegistry {
    private readonly record struct ResolverKey(Type Type, string? Key) : IEquatable<ResolverKey> {
        public override readonly string ToString() => $"Type: {Type.FullName} - Key: {Key}";

        public static implicit operator ResolverKey((Type Type, string? Key) tuple) => new(tuple.Type, tuple.Key);
    }

    private readonly Dictionary<ResolverKey, IResolver> resolvers = [];
    private readonly IServiceLibrary? parent;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceLibrary"/> class.
    /// </summary>
    /// <param name="parent">The parent <see cref="IServiceLibrary"/>.</param>
    public ServiceLibrary(IServiceLibrary? parent) {
        this.parent = parent;

        Bind<IServiceLibrary>().Value!.ToInstance(this);

        if (parent != null) {
            Bind<IServiceLibrary>("Parent").Value!.ToInstance(parent);
        }
    }

    /// <inheritdoc/>
    public Result<IResolver> Bind(Type type, string? key = null) {
        if (type == null) {
            return (null, $"The passed type is null!", new ArgumentNullException(nameof(type)));
        }

        ResolverKey resolverKey = (type, key);

        if (!resolvers.TryGetValue(resolverKey, out var resolver)) {
            resolver = (IResolver)Activator.CreateInstance(typeof(Resolver<>).MakeGenericType(type))!;
            resolvers[resolverKey] = resolver;
        }

        return new Result<IResolver>(resolver);
    }

    /// <inheritdoc/>
    public Result<IResolver<TType>> Bind<TType>(string? key = null)
            where TType : class {
        return new Result<IResolver<TType>>((IResolver<TType>)Bind(typeof(TType), key));
    }

    /// <inheritdoc/>
    public TType Get<TType>(string? key = null)
        where TType : class {
        return (TType)Get(typeof(TType), key);
    }

    /// <inheritdoc/>
    public object Get(Type type, string? key = null) {
        ArgumentNullException.ThrowIfNull(type);

        if (!resolvers.TryGetValue((type, key), out var resolver)) {
            return parent?.Get(type, key) ?? throw new ArgumentException($"No resolver for type {type.FullName} with key {key} exists!");
        }

        return resolver.Resolve(this);
    }

    /// <inheritdoc/>
    public bool TryGet<TType>([NotNullWhen(true)] out TType? result, string? key = null) {
        if (TryGet(typeof(TType), out object? boxedResult, key)) {
            if (boxedResult is TType casted) {
                result = casted;
                return true;
            }
        }

        result = default;
        return false;
    }

    /// <inheritdoc/>
    public bool TryGet(Type type, [NotNullWhen(true)] out object? result, string? key = null) {
        ArgumentNullException.ThrowIfNull(type);

        if (!resolvers.TryGetValue((type, key), out var resolver)) {
            if (parent?.TryGet(type, out object? fromParent, key) ?? false) {
                result = fromParent;
                return true;
            }

            result = null;
            return false;
        }

        result = resolver.Resolve(this);
        return true;
    }

    /// <inheritdoc/>
    public IEnumerable<string> GetAllServiceNames() {
        foreach (var key in resolvers.Keys)
            yield return key.Type.FullName!;

        if (parent != null)
            foreach (var serviceName in parent.GetAllServiceNames())
                yield return serviceName;
    }

    /// <inheritdoc/>
    public IEnumerable<object> GetAllServices(Type type) {
        foreach (var entry in resolvers) {
            if (entry.Key.Type == type) {
                yield return entry.Value.Resolve(this);
            }
        }

        if (parent != null) {
            foreach (var service in parent.GetAllServices(type)) {
                yield return service;
            }
        }
    }

    /// <inheritdoc/>
    public IEnumerable<TType> GetAllServices<TType>() {
        foreach (var service in GetAllServices(typeof(TType))) {
            yield return (TType)service;
        }
    }

    /// <inheritdoc/>
    public Result<IResolver> RegisterService<TInterface, TImplementation>(string? key = null)
            where TInterface : class
            where TImplementation : class {
        return RegisterService(typeof(TInterface), typeof(TImplementation), key);
    }

    /// <inheritdoc/>
    public Result<IResolver> RegisterService<TInterface, TImplementation>(Func<IServiceLibrary, TInterface>? factory, string? key = null)
            where TInterface : class
            where TImplementation : class {
        return RegisterService(typeof(TInterface), typeof(TImplementation), factory, key);
    }

    /// <inheritdoc/>
    public Result<IResolver> RegisterService<TInterface>(Func<IServiceLibrary, TInterface> factory, string? key = null) where TInterface : class {
        return RegisterService(typeof(TInterface), factory, key);
    }

    /// <inheritdoc/>
    public Result<IResolver> RegisterService(Type interfaceType, Func<IServiceLibrary, object> factory, string? key = null) {
        return RegisterService(interfaceType, null, factory, key);
    }

    /// <inheritdoc/>
    public Result<IResolver> RegisterService(Type interfaceType, Type implementationType, string? key = null) {
        return RegisterService(interfaceType, implementationType, null, key);
    }

    /// <inheritdoc/>
    public Result<IResolver> RegisterService(Type interfaceType, Type? implementationType, Func<IServiceLibrary, object>? factory, string? key = null) {
        if (interfaceType is null) {
            return (null, "Interface type is null!", new ArgumentNullException(nameof(interfaceType)));
        }

        if (!interfaceType.IsInterface && !interfaceType.IsAbstract) {
            return (null, $"{interfaceType.FullName} is not an interface or abstract class!", new ArgumentException($"{nameof(interfaceType)} of {interfaceType.FullName} is not an interface or an abstract class!"));
        }

        if (implementationType != null && (implementationType.IsInterface || implementationType.IsAbstract)) {
            return (null, $"{implementationType.FullName} is not an instantiable class!", new ArgumentException($"{nameof(implementationType)} of {implementationType.FullName} is an interface or an abstract class!"));
        }

        ResolverKey resolverKey = (interfaceType, key);

        if (resolvers.ContainsKey(resolverKey)) {
            return (null, $"Service with key ({resolverKey}) already exists!");
        }

        var resolver = (implementationType == null) switch {
            true => (IResolver)Activator.CreateInstance(typeof(Resolver<>).MakeGenericType(interfaceType))!,
            false => (IResolver)Activator.CreateInstance(typeof(Resolver<>).MakeGenericType(interfaceType), implementationType)!,
        };

        resolver.Factory = factory;
        resolvers[resolverKey] = resolver;
        return new Result<IResolver>(resolver);
    }

    /// <inheritdoc/>
    public bool ContainsService<TType>(string? key = null) {
        return ContainsService(typeof(TType), key);
    }

    /// <inheritdoc/>
    public bool ContainsService(Type type, string? key = null) {
        return resolvers.ContainsKey((type, key)) || (parent?.ContainsService(type, key) ?? false);
    }
}
