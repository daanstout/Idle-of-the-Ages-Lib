using System;

namespace IdleOfTheAgesLib.DependencyInjection {
    /// <summary>
    /// A registry where services can be registered to, which can then be obtained through the <see cref="IServiceLibrary"/>.
    /// </summary>
    public interface IServiceRegistry {
        /// <summary>
        /// Obtains the <see cref="IResolver"/> for the provided <paramref name="type"/> and <paramref name="key"/> combination.
        /// <para>If no resolver exists, a new one will be created.</para>
        /// <para>Note that if no resolver exists and <paramref name="type"/> is either an interface or an abstract class, a factory should be provided as otherwise the resolver will throw an error when resolving!</para>
        /// </summary>
        /// <param name="type">The type to get the resolver for.</param>
        /// <param name="key">The key to the specific dependency required.</param>
        /// <returns>The <see cref="IResolver"/> for the <paramref name="type"/> and <paramref name="key"/> combination.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="type"/> is null.</exception>
        IResolver Bind(Type type, string? key = null);

        /// <summary>
        /// Obtains the <see cref="IResolver{TInterface}"/> for the provided <typeparamref name="TType"/> and <paramref name="key"/> combination.
        /// <para>If no resolver exists, a new one will be created.</para>
        /// <para>Note that if no resolver exists and <typeparamref name="TType"/> is either an interface or an abstract class, a factory should be provided as otherwise the resolver will throw an error when resolving!</para>
        /// </summary>
        /// <typeparam name="TType">The type to get the resolver for.</typeparam>
        /// <param name="key">The key to the specific dependency required.</param>
        /// <returns>The <see cref="IResolver{TInterface}"/> for the <typeparamref name="TType"/> and <paramref name="key"/> combination.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <typeparamref name="TType"/> is null.</exception>
        IResolver<TType> Bind<TType>(string? key = null)
            where TType : class;

        /// <summary>
        /// Registers a service to the library.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key to store the service under.</param>
        /// <returns><see langword="true"/> if the service was successfully registered, <see langword="false"/> if not.</returns>
        Result RegisterService<TInterface, TImplementation>(string? key = null)
             where TInterface : class
             where TImplementation : class;

        /// <summary>
        /// Registers a service to the library.
        /// </summary>
        /// <param name="interfaceType">The type of the interface.</param>
        /// <param name="implementationType">The type of the implementation.</param>
        /// <param name="key">The key to store the service under.</param>
        /// <returns><see langword="true"/> if the service was successfully registered, <see langword="false"/> if not.</returns>
        Result RegisterService(Type interfaceType, Type implementationType, string? key = null);

        /// <summary>
        /// Registers a service to the library.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <param name="factory">A factory that is used to create the instance.</param>
        /// <param name="key">The key to store the service under.</param>
        /// <returns><see langword="true"/> if the service was successfully registered, <see langword="false"/> if not.</returns>
        Result RegisterService<TInterface>(Func<IServiceLibrary, TInterface> factory, string? key = null)
            where TInterface : class;

        /// <summary>
        /// Registers a service to the library.
        /// </summary>
        /// <param name="interfaceType">The type of the interface.</param>
        /// <param name="factory">A factory that is used to create the instance.</param>
        /// <param name="key">The key to store the service under.</param>
        /// <returns><see langword="true"/> if the service was successfully registered, <see langword="false"/> if not.</returns>
        Result RegisterService(Type interfaceType, Func<IServiceLibrary, object> factory, string? key = null);

        /// <summary>
        /// Registers a service to the library.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="factory">A factory that is used to create the instance.</param>
        /// <param name="key">The key to store the service under.</param>
        /// <returns><see langword="true"/> if the service was successfully registered, <see langword="false"/> if not.</returns>
        Result RegisterService<TInterface, TImplementation>(Func<IServiceLibrary, TInterface>? factory, string? key = null)
             where TInterface : class
             where TImplementation : class;

        /// <summary>
        /// Registers a service to the library.
        /// </summary>
        /// <param name="interfaceType">The type of the interface.</param>
        /// <param name="implementationType">The type of the implementation.</param>
        /// <param name="factory">A factory that is used to create the instance.</param>
        /// <param name="key">The key to store the service under.</param>
        /// <returns><see langword="true"/> if the service was successfully registered, <see langword="false"/> if not.</returns>
        Result RegisterService(Type interfaceType, Type implementationType, Func<IServiceLibrary, object>? factory, string? key = null);
    }
}
