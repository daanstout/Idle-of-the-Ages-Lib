// <copyright file="ILogger.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib;

/// <summary>
/// A logger to log information to.
/// </summary>
public interface ILogger {
    /// <summary>
    /// Gets the namespace the logger logs to.
    /// </summary>
    string Namespace { get; }

    /// <summary>
    /// Logs a message to the logger.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="objects">Parameters to add to the message.</param>
    void Info(string message, params object[] objects);

    /// <summary>
    /// Logs a warning to the logger.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="objects">Parameters to add to the message.</param>
    void Warning(string message, params object[] objects);

    /// <summary>
    /// Logs an error to the logger.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="objects">Parameters to add to the message.</param>
    void Error(string message, params object[] objects);

    /// <summary>
    /// Logs a <see cref="Result"/> object to the logger.
    /// </summary>
    /// <param name="result">The <see cref="Result"/> object to log.</param>
    void LogResult(Result result);

    /// <summary>
    /// Logs a <see cref="Result{T}"/> object to the logger.
    /// </summary>
    /// <typeparam name="T">The type of the object that the <see cref="Result{T}"/> contains.</typeparam>
    /// <param name="result">The <see cref="Result{T}"/> object to log.</param>
    void LogResult<T>(Result<T> result);
}
