// <copyright file="Error.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.Models;

/// <summary>
/// Represents an error that has occured.
/// </summary>
public class Error {
    /// <summary>
    /// Gets the error message that occured.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the exception that would be thrown.
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class.
    /// </summary>
    /// <param name="message">The error that occured.</param>
    /// <param name="exception">The exception to throw.</param>
    public Error(string message, Exception? exception = null) {
        Message = message;
        Exception = exception;
    }

    /// <summary>
    /// Implicitly casts a <see cref="Tuple{T1, T2}"/> of a <see cref="string"/> and a <see cref="Exception"/> to an <see cref="Error"/>.
    /// </summary>
    /// <param name="tuple">The tuple to cast.</param>
    public static implicit operator Error((string Error, Exception? Exception) tuple) => new(tuple.Error, tuple.Exception);

    /// <summary>
    /// Implicitly casts a <see cref="string"/> to an <see cref="Error"/>.
    /// </summary>
    /// <param name="message">the string to cast.</param>
    public static implicit operator Error(string message) => new(message);

    /// <summary>
    /// Implicitly casts an <see cref="Error"/> to a <see cref="string"/>.
    /// </summary>
    /// <param name="error">The error to cast.</param>
    public static implicit operator string(Error error) => error.Message;
}
