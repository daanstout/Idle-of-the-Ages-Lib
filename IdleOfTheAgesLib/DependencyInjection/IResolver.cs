using System;

namespace IdleOfTheAgesLib.DependencyInjection {
    /// <summary>
    /// A resolver to resolve a dependency to an instance.
    /// </summary>
    public interface IResolver {
        /// <summary>
        /// A factory that can be used to resolve the instance.
        /// </summary>
        Func<IServiceLibrary, object>? Factory { get; set; }

        /// <summary>
        /// A boolean that indicates whether or not the target is a singleton.
        /// </summary>
        bool IsSingleton { get; set; }

        /// <summary>
        /// Resolves the dependency to the instance, creating a new one if one doesn't exist yet.
        /// </summary>
        /// <param name="serviceLibrary">The <see cref="IServiceLibrary"/> to obtain the dependencies from.</param>
        /// <returns>An instance of the dependency.</returns>
        object Resolve(IServiceLibrary serviceLibrary);

        /// <summary>
        /// Sets the instance this resolver should use.
        /// </summary>
        /// <param name="instance">The instance to use.</param>
        void ToInstance(object instance);
    }

    /// <summary>
    /// A resolver to resolve a dependency to an instance.
    /// </summary>
    public interface IResolver<TType> : IResolver
        where TType : class {
        /// <summary>
        /// Resolves the dependency to the instance, creating a new one if one doesn't exist yet.
        /// </summary>
        /// <param name="serviceLibrary">The <see cref="IServiceLibrary"/> to obtain the dependencies from.</param>
        /// <returns>An instance of the dependency.</returns>
        new TType Resolve(IServiceLibrary serviceLibrary);
    }
}
