// <copyright file="ResultBuilder.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;

namespace IdleOfTheAgesLib.Models;

/// <summary>
/// A helper class to build a <see cref="Result"/> or <see cref="Result{T}"/> object.
/// </summary>
public class ResultBuilder {
    private readonly List<Error> errors = [];

    /// <summary>
    /// Adds an error to the builder.
    /// </summary>
    /// <param name="error">The error to add.</param>
    public void AddError(Error error) => errors.Add(error);

    /// <summary>
    /// Adds the errors of a <see cref="Result"/> object to this result.
    /// </summary>
    /// <param name="result">The result to incorporate.</param>
    public void AddResult(Result result) {
        if (!result.Errors.Any()) {
            return;
        }

        errors.AddRange(result.Errors);
    }

    /// <summary>
    /// Adds the errors of a <see cref="Result{T}"/> object to this result.
    /// </summary>
    /// <typeparam name="T">The type the result object stores.</typeparam>
    /// <param name="result">The <see cref="Result{T}"/> to incorporate.</param>
    public void AddResult<T>(Result<T> result) {
        if (!result.Errors.Any()) {
            return;
        }

        errors.AddRange(result.Errors);
    }

    /// <summary>
    /// Builds the result object.
    /// </summary>
    /// <returns>The created Result object.</returns>
    public Result Build() {
        return new Result(errors.Count == 0, errors);
    }

    /// <summary>
    /// Builds the result object.
    /// </summary>
    /// <typeparam name="T">The type of the object returned by the function.</typeparam>
    /// <param name="result">The result of the operation.</param>
    /// <returns>The created Result object.</returns>
    public Result<T> Build<T>(T result) {
        return new Result<T>(result, errors);
    }
}
