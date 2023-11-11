using System;

namespace IdleOfTheAgesLib {
    /// <summary>
    /// A result object that can be returned with information.
    /// </summary>
    public class Result : Result<bool> {
        /// <summary>
        /// Instantiates a new Result object.
        /// </summary>
        /// <param name="value">Whether or not the call was a success.</param>
        /// <param name="errorReason">The reason the call failed.</param>
        /// <param name="exception">The exception that was thrown.</param>
        public Result(bool value = true, string? errorReason = null, Exception? exception = null)
            : base(value, errorReason, exception) { }

        /// <summary>
        /// Implicitly casts a <see cref="Result"/> object to a <see cref="bool"/>.
        /// </summary>
        /// <param name="result">The result object to cast.</param>
        public static implicit operator bool(Result result) => result != null && result.Value;

        /// <summary>
        /// Implicitly casts a <see cref="bool"/> value to a <see cref="Result"/>.
        /// </summary>
        /// <param name="value">The bool value to cast.</param>
        public static implicit operator Result(bool value) => new Result(value);

        /// <summary>
        /// Implicitly casts a <see cref="Tuple{T1, T2}"/> of a <see cref="bool"/> value and a <see cref="string"/> value to a <see cref="Result"/> value.
        /// </summary>
        /// <param name="value">The tuple object to cast.</param>
        public static implicit operator Result((bool, string) value) => new Result(value.Item1, value.Item2);

        /// <summary>
        /// Implicitly casts a <see cref="Tuple{T1, T2, T3}"/> of a <see cref="bool"/> value, a <see cref="string"/> value, and an <see cref="Exception"/> object to a <see cref="Result{T}"/>.
        /// </summary>
        /// <param name="value">The tuple object to cast.</param>
        public static implicit operator Result((bool, string, Exception) value) => new Result(value.Item1, value.Item2, value.Item3);
    }

    /// <summary>
    /// A result object that can be returned with information.
    /// </summary>
    public class Result<T> {
        /// <summary>
        /// The target object.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// The reason a function call failed.
        /// </summary>
        public string? ErrorReason { get; }

        /// <summary>
        /// The Exception that was thrown.
        /// </summary>
        public Exception? Exception { get; }

        /// <summary>
        /// Instantiates a new Result object.
        /// </summary>
        /// <param name="value">The target object.</param>
        /// <param name="errorReason">The reason the call failed.</param>
        /// <param name="exception">The exception that was thrown.</param>
        public Result(T value, string? errorReason = null, Exception? exception = null) {
            Value = value;
            ErrorReason = errorReason;
            Exception = exception;
        }

        /// <summary>
        /// Implicitly casts a <see cref="Result"/> object to a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="result">The result object to cast.</param>
        public static implicit operator T(Result<T> result) => result == null ? default! : result.Value;

        /// <summary>
        /// Implicitly casts a <typeparamref name="T"/> value to a <see cref="Result"/>.
        /// </summary>
        /// <param name="value">The bool value to cast.</param>
        public static implicit operator Result<T>(T value) => new Result<T>(value);

        /// <summary>
        /// Implicitly casts a <see cref="Tuple{T1, T2}"/> of a <typeparamref name="T"/> value and a <see cref="string"/> value to a <see cref="Result"/> value to a <see cref="Result{T}"/>.
        /// </summary>
        /// <param name="value">The tuple object to cast.</param>
        public static implicit operator Result<T>((T, string) value) => new Result<T>(value.Item1, value.Item2);

        /// <summary>
        /// Implicitly casts a <see cref="Tuple{T1, T2, T3}"/> of a <typeparamref name="T"/> value, a <see cref="string"/> value, and an <see cref="Exception"/> object to a <see cref="Result{T}"/>.
        /// </summary>
        /// <param name="value">The tuple object to cast.</param>
        public static implicit operator Result<T>((T, string, Exception) value) => new Result<T>(value.Item1, value.Item2, value.Item3);
    }
}
