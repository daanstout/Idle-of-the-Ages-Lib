namespace IdleOfTheAgesLib {
    /// <summary>
    /// A logger to log information to.
    /// </summary>
    public interface ILogger {
        /// <summary>
        /// The namespace the logger logs to.
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
        void Warn(string message, params object[] objects);

        /// <summary>
        /// Logs an error to the logger.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="objects">Parameters to add to the message.</param>
        void Error(string message, params object[] objects);
    }
}
