// <copyright file="Result.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IdleOfTheAgesLib;

/// <summary>
/// A result object that can be returned with information.
/// </summary>
public class Result : Result<bool> {
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="value">Whether or not the call was a success.</param>
    public Result(bool value) : base(value) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="value">Whether or not the call was a success.</param>
    /// <param name="errors">The errors that occured.</param>
    public Result(bool value, IEnumerable<Error> errors)
        : base(value, errors) { }

    /// <summary>
    /// Implicitly casts a <see cref="Result"/> object to a <see cref="bool"/>.
    /// </summary>
    /// <param name="result">The result object to cast.</param>
    /// <exception cref="InvalidOperationException">Thrown if the <paramref name="result"/> object is <see langword="null"/>.</exception>
    public static implicit operator bool([NotNullWhen(true)] Result? result) {
        if (result == null) {
            return false;
        }

        return result.Value && !result.Errors.Any();
    }

    /// <summary>
    /// Implicitly casts a <see cref="bool"/> value to a <see cref="Result"/>.
    /// </summary>
    /// <param name="value">The bool value to cast.</param>
    public static implicit operator Result(bool value) => new(value);

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2}"/> of a <see cref="bool"/> value and a <see cref="string"/> value to a <see cref="Result"/> value.
    /// </summary>
    /// <param name="value">The tuple object to cast.</param>
    public static implicit operator Result((bool Result, string Error) value) => new(value.Result, [value.Error]);

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2}"/> of a <see cref="bool"/> value and a <see cref="IEnumerable{T}"/> or <see cref="Error"/> value to a <see cref="Result"/> value.
    /// </summary>
    /// <param name="value">The tuple object to cast.</param>
    public static implicit operator Result((bool Result, IEnumerable<Error> Errors) value) => new(value.Result, value.Errors);

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2, T3}"/> of a <see cref="bool"/> value, a <see cref="string"/> value, and an <see cref="Exception"/> object to a <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="value">The tuple object to cast.</param>
    public static implicit operator Result((bool Result, string Error, Exception Exception) value) => new(value.Result, [(value.Error, value.Exception)]);
}

/// <summary>
/// A result object that can be returned with information.
/// </summary>
/// <typeparam name="T">The type of the object that is encased in this object.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="Result{T}"/> class.
/// </remarks>
public class Result<T> {
    /// <summary>
    /// Gets the target object.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Gets the errors that occured (if any).
    /// </summary>
    public IEnumerable<Error> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class.
    /// </summary>
    /// <param name="value">The target object.</param>
    public Result(T? value) : this(value, []) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class.
    /// </summary>
    /// <param name="value">The target object.</param>
    /// <param name="errors">The errors that occured.</param>
    public Result(T? value, IEnumerable<Error> errors) {
        Value = value;
        Errors = errors;
    }

    /// <summary>
    /// Throws an exception if the <see cref="Result{T}"/> object is in an invalid state.
    /// </summary>
    /// <exception cref="System.Exception">Thrown if the object is not in a valid state and no exception was provided.</exception>
    public void ThrowIfInvalid() {
        if (!this) {
            if (!Errors.Any()) {
                return;
            }

            foreach (var error in Errors) {
                if (error.Exception != null) {
                    throw error.Exception;
                }
            }
        }
    }

    /// <summary>
    /// Prints the resulting object to a target.
    /// </summary>
    /// <param name="logger">The logger to print to.</param>
    public void Print(ILogger logger) {
        StringBuilder builder = new();

        builder.AppendFormat("Result: {0}\n", Value);

        if (Errors.Any()) {
            builder.AppendFormat("{0} Errors occured while processing:\n", Errors.Count());

            for (int i = 0; i < Errors.Count(); i++) {
                var error = Errors.ElementAt(i);

                builder.AppendFormat("{0}:\tMessage: {1} - Exception: {2}\n", i, error.Message, error.Exception);
            }

            logger.Error(builder.ToString());
        } else {
            logger.Info(builder.ToString());
        }
    }

    /// <summary>
    /// Casts a result's value to a different type.
    /// </summary>
    /// <typeparam name="TOther">The type to cast to.</typeparam>
    /// <returns>A result object for the casted type.</returns>
    public Result<TOther> Cast<TOther>() where TOther : T {
        if (!this) {
            return new Result<TOther>(default, Errors);
        }

        if (Value is TOther casted) {
            return new Result<TOther>(casted);
        }

        return (default, $"Could not cast from {typeof(T).FullName} to {typeof(TOther).FullName}");
    }

    /// <summary>
    /// Casts a result to a result of a different type, while retaining any errors.
    /// </summary>
    /// <typeparam name="TOther">The type of the object to change to.</typeparam>
    /// <param name="obj">The object to return with the result object.</param>
    /// <returns>The casted result object.</returns>
    public Result<TOther> To<TOther>(TOther? obj = default) {
        return new Result<TOther>(obj, Errors);
    }

    /// <summary>
    /// Implicitly casts a <see cref="Result{T}"/> object to a bool.
    /// <para>This returns <see langword="true"/> if the call was successful, and <see langword="false"/> if something went wrong.</para>
    /// </summary>
    /// <param name="result">The result object to cast.</param>
    /// <exception cref="InvalidOperationException">Thrown if the <paramref name="result"/> object is <see langword="null"/>.</exception>
    [MemberNotNullWhen(true, nameof(Value))]
    public static implicit operator bool([NotNullWhen(true)] Result<T>? result) {
        if (result == null) {
            return false;
        }

        if (result.Value == null) {
            return false;
        }

        return !result.Errors.Any();
    }

    /// <summary>
    /// Implicitly casts a <see cref="Result{T}"/> object to a <typeparamref name="T"/>.
    /// </summary>
    /// <param name="result">The result object to cast.</param>
    /// <exception cref="InvalidOperationException">Thrown if the <paramref name="result"/> object is <see langword="null"/>.</exception>
    /// <exception cref="Exception">Thrown if the <see cref="Exception"/> is not <see langword="null"/>.</exception>
    [return: NotNull]
    public static implicit operator T(Result<T>? result) {
        if (result == null) {
            throw new InvalidOperationException("Result is null. Always return an instance of the Result class and pass `null` as the value!");
        }

        if (result.Errors.Any()) {
            foreach (var error in result.Errors) {
                if (error.Exception != null) {
                    throw error.Exception;
                }
            }

            throw new ArgumentException($"An error occured while processing for the result of type {typeof(T).FullName}"!);
        }

        if (result.Value == null) {
            throw new InvalidOperationException("The value in the Result is null, but no errors have been provided. Always provide errors when passing null as the value!");
        }

        return result.Value;
    }

    /// <summary>
    /// Implicitly casts a <typeparamref name="T"/> value to a <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="value">The bool value to cast.</param>
    public static implicit operator Result<T>(T value) => new(value);

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2}"/> of a <typeparamref name="T"/> value and a <see cref="string"/> value to a <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="value">The tuple object to cast.</param>
    public static implicit operator Result<T>((T? Value, string Error) value) => new(value.Value, [value.Error]);

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2}"/> of a <typeparamref name="T"/> value and a <see cref="IEnumerable{T}"/> of type <see cref="Error"/> value to a <see cref="Result{T}"/> value.
    /// </summary>
    /// <param name="value">The tuple to cast.</param>
    public static implicit operator Result<T>((T? Value, IEnumerable<Error> Errors) value) => new(value.Value, value.Errors);

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2, T3}"/> of a <typeparamref name="T"/> value, a <see cref="string"/> value, and a <see cref="IEnumerable{T}"/> of type <see cref="Error"/> value to a <see cref="Result{T}"/> value.
    /// </summary>
    /// <param name="value">The tuple to cast.</param>
    public static implicit operator Result<T>((T? Value, string Error, IEnumerable<Error> Errors) value) => new(value.Value, new List<Error>() { value.Error }.Append(value.Error));

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2, T3}"/> of a <typeparamref name="T"/> value, a <see cref="string"/> value, and an <see cref="Exception"/> object to a <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="value">The tuple object to cast.</param>
    public static implicit operator Result<T>((T? Value, string Error, Exception Exception) value) => new(value.Value, [(value.Error, value.Exception)]);
}
