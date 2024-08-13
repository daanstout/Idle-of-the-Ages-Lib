// <copyright file="ParserLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Parsing;
using IdleOfTheAgesRuntime.DependencyInjection;
using System;

namespace IdleOfTheAgesRuntime.UI.Parsing;

/// <summary>
/// A library that stores all the parsers available.
/// </summary>
[Service<IParserLibrary>]
public class ParserLibrary : IParserLibrary {
    private readonly ServiceLibrary serviceLibrary;
    private readonly IParserLibrary? parent;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParserLibrary"/> class.
    /// </summary>
    /// <param name="serviceLibrary">The service library that contains the services.</param>
    /// <param name="parent">The parent parser library.</param>
    public ParserLibrary(IServiceLibrary serviceLibrary, IParserLibrary? parent) {
        this.serviceLibrary = new ServiceLibrary(serviceLibrary);
        this.parent = parent;
    }

    /// <inheritdoc/>
    public Result<ElementManager> GetElementManager(string tag) {
        if (serviceLibrary.TryGet<ElementManager>(out var result, tag)) {
            return result;
        }

        var parentParser = parent?.GetElementManager(tag);

        if (parentParser) {
            return parentParser;
        }

        return (null, $"No parser for the tag \"{tag}\" has been registered!");
    }

    /// <inheritdoc/>
    public Result<ElementManager<T>> GetElementManager<T>(string tag) where T : new() {
        if (serviceLibrary.TryGet<ElementManager<T>>(out var result, tag)) {
            return result;
        }

        var parentParser = parent?.GetElementManager<T>(tag);

        if (parentParser) {
            return parentParser;
        }

        return (null, $"No parser for the tag \"{tag}\" has been registered!");
    }

    /// <inheritdoc/>
    public Result RegisterElementManager<T>(string tag) => RegisterElementManager(typeof(T), tag);

    /// <inheritdoc/>
    public Result RegisterElementManager(Type parserType, string tag) {
        var result = serviceLibrary.RegisterService(parserType, (Type)null!, tag);

        if (!result) {
            return (false, $"Unable to register parser of type {parserType.FullName}");
        }

        result.Value!.IsSingleton = false;

        return true;
    }

    /// <inheritdoc/>
    public Result RegisterUIModel<T>(string modelName) => RegisterUIModel(typeof(T), modelName);

    /// <inheritdoc/>
    public Result RegisterUIModel(Type modelType, string modelName) {
        var result = serviceLibrary.Bind<ModelBase>(modelName);

        if (!result) {
            return (false, $"Unable to register model type of type {modelType.FullName}");
        }

        result.Value!.SetInstanceType(modelType);
        result.Value.IsSingleton = false;

        return true;
    }

    /// <inheritdoc/>
    public Result<object> GetUIModel(string modelName) {
        if (!serviceLibrary.TryGet<ModelBase>(out var model, modelName)) {
            return (null, $"No model with the model name {modelName} has been registered!");
        }

        return model;
    }
}
