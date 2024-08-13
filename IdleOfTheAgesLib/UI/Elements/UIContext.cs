// <copyright file="UIContext.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Elements;

/// <summary>
/// Contains the UI context for creating UI elements from the parsed HTML.
/// </summary>
public class UIContext {
    private readonly Dictionary<string, object> contexts = [];
    private object? uiModel;

    /// <summary>
    /// Adds a context.
    /// </summary>
    /// <param name="key">The key of the context.</param>
    /// <param name="context">The context to add.</param>
    /// <param name="overwriteIfExists">If <see langword="true"/>, overwrites existing contexts with the same key.</param>
    /// <returns>Whether the context was succesfully added.</returns>
    public Result AddContext(string key, object context, bool overwriteIfExists = true) {
        if (contexts.ContainsKey(key) && !overwriteIfExists) {
            return (false, $"A context with the key \"{key}\" already exists!");
        }

        contexts[key] = context;

        return true;
    }

    /// <summary>
    /// Gets the context stored at the provided key.
    /// </summary>
    /// <param name="key">The key of the context to get.</param>
    /// <returns>The requested context.</returns>
    public Result<object> GetContext(string key) {
        if (contexts.TryGetValue(key, out object? value)) {
            return value;
        }

        return (null, $"No context with the key \"{key}\" exists");
    }

    /// <summary>
    /// Gets the context stored at the provided key.
    /// </summary>
    /// <typeparam name="T">The type of the context to get.</typeparam>
    /// <param name="key">The key of the context to get.</param>
    /// <returns>The requested context.</returns>
    public Result<T> GetContext<T>(string key) {
        if (contexts.TryGetValue(key, out object? value)) {
            if (value is T casted) {
                return casted;
            }

            return (default, $"The context stored at key \"{key}\" is not of type \"{typeof(T).FullName}\", but instead of type \"{value.GetType().FullName}\"");
        }

        return (default, $"No context with the key \"{key}\" exists");
    }

    /// <summary>
    /// Sets the UI model to use.
    /// </summary>
    /// <param name="model">The ui model to use.</param>
    /// <param name="overwriteIfExists">Whether or not to overwrite an existing ui model if one is already present.</param>
    /// <returns><see langword="true"/> if the model has been updated, <see langword="false"/> if not.</returns>
    public Result SetUIModel(object model, bool overwriteIfExists = false) {
        if (uiModel != null && !overwriteIfExists) {
            return (false, "A UI model has already been provided!");
        }

        uiModel = model;

        return true;
    }

    /// <summary>
    /// Calls the provided method on the model.
    /// </summary>
    /// <param name="methodName">The name of the method to call.</param>
    /// <returns>The result of the method call.</returns>
    public Result<object> CallModelMethod(string methodName) {
        if (uiModel == null) {
            return (null, "No UI model has been provided!");
        }

        var method = uiModel.GetType().GetMethod(methodName);

        if (method == null) {
            return (null, $"The method \"{methodName}\" does not exist on the model of type {uiModel.GetType().FullName}");
        }

        return method.Invoke(uiModel, null)!;
    }
}
