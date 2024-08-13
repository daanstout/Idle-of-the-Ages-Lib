// <copyright file="CyclicalDependencyException.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.DependencyInjection;

/// <summary>
/// An exception that is thrown when 2 dependencies have a cyclical dependency on each other.
/// </summary>
public class CyclicalDependencyException : Exception {
    /// <summary>
    /// Initializes a new instance of the <see cref="CyclicalDependencyException"/> class.
    /// </summary>
    public CyclicalDependencyException() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CyclicalDependencyException"/> class.
    /// with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CyclicalDependencyException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CyclicalDependencyException"/> class with a specified error.
    /// message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
    /// (Nothing in Visual Basic) if no inner exception is specified.</param>
    public CyclicalDependencyException(string message, Exception? innerException) : base(message, innerException) { }
}
