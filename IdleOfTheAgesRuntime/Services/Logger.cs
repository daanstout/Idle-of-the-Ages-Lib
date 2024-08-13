// <copyright file="Logger.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace IdleOfTheAgesRuntime.Services;

/// <summary>
/// A logger that logs to all loggers that have been registered.
/// </summary>
public class Logger : ILogger {
    /// <inheritdoc/>
    public string Namespace { get; } = string.Empty;

    private readonly IReadOnlyList<ILogger> loggers;

    /// <summary>
    /// Initializes a new instance of the <see cref="Logger"/> class.
    /// </summary>
    /// <param name="serviceLibrary">The service library to get all the loggers from.</param>
    public Logger(IServiceLibrary serviceLibrary) {
        loggers = serviceLibrary.GetAllServices<ILogger>().ToList();
    }

    /// <inheritdoc/>
    public void Error(string message, params object[] objects) {
        foreach (var logger in loggers) {
            logger.Error(message, objects);
        }
    }

    /// <inheritdoc/>
    public void Info(string message, params object[] objects) {
        foreach (var logger in loggers) {
            logger.Info(message, objects);
        }
    }

    /// <inheritdoc/>
    public void Warning(string message, params object[] objects) {
        foreach (var logger in loggers) {
            logger.Warning(message, objects);
        }
    }

    /// <inheritdoc/>
    public void LogResult(Result result) {
        foreach (var logger in loggers) {
            logger.LogResult(result);
        }
    }

    /// <inheritdoc/>
    public void LogResult<T>(Result<T> result) {
        foreach (var logger in loggers) {
            logger.LogResult(result);
        }
    }
}
