// <copyright file="ParseContext.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAgesLib.UI.Parsing.Models;

/// <summary>
/// Keeps track of data while parsing HTML.
/// </summary>
public class ParseContext {
    private readonly Dictionary<string, object> miscContext = [];

    /// <summary>
    /// Adds data to the parsing that can be used elsewhere.
    /// </summary>
    /// <param name="key">The key of the context.</param>
    /// <param name="data">The data to keep.</param>
    /// <param name="overwriteExisting">If <see langword="true"/>, if the <paramref name="key"/> already exists, the data is overwritten.</param>
    /// <returns><see langword=""/> if the data was succesfully added.</returns>
    public Result AddData(string key, object data, bool overwriteExisting = false) {
        if (miscContext.ContainsKey(key) && !overwriteExisting) {
            return (false, $"An entry with the key {key} already exists!");
        }

        miscContext[key] = data;

        return true;
    }

    /// <summary>
    /// Gets data stored in the context.
    /// </summary>
    /// <param name="key">The key of the data to get.</param>
    /// <returns>The requested data.</returns>
    public Result<object> GetData(string key) {
        if (miscContext.TryGetValue(key, out object? data)) {
            return data;
        }

        return (null, $"No data with the key {key} has been registered");
    }

    /// <summary>
    /// Gets data stored in the context.
    /// </summary>
    /// <typeparam name="T">The type of the data stored.</typeparam>
    /// <param name="key">The key of the data to get.</param>
    /// <returns>The requested data.</returns>
    public Result<T> GetData<T>(string key) {
        if (miscContext.TryGetValue(key, out object? data)) {
            if (data is T casted) {
                return casted;
            }

            return (default, $"The data stored at {key} has type {data.GetType().FullName} but is requested as {typeof(T).FullName}");
        }

        return (default, $"No data with the key {key} has been registered.");
    }
}
