// <copyright file="Logger.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using UnityEngine;

namespace IdleOfTheAgesRuntime {
    /// <summary>
    /// A logger to log information to.
    /// </summary>
    public class Logger : IdleOfTheAgesLib.ILogger {
        /// <inheritdoc/>
        public string Namespace { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="namespace">The namespace of the mod this logger is for.</param>
        public Logger(string @namespace) {
            Namespace = @namespace;
        }

        /// <inheritdoc/>
        public void Error(string message, params object[] objects) {
            Debug.LogErrorFormat("[{0}] {1}", Namespace, string.Format(message, objects));
        }

        /// <inheritdoc/>
        public void Info(string message, params object[] objects) {
            Debug.LogFormat("[{0}] {1}", Namespace, string.Format(message, objects));
        }

        /// <inheritdoc/>
        public void Warning(string message, params object[] objects) {
            Debug.LogWarningFormat("[{0}] {1}", Namespace, string.Format(message, objects));
        }
    }
}
