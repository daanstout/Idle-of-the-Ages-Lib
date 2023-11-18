using IdleOfTheAgesLib.DependencyInjection;

using System;

namespace IdleOfTheAgesLib {
    /// <summary>
    /// An attribute that can be put on services to indicate they are a service.
    /// <para>Using this attribute makes it so you don't have to register services in a <see cref="IServiceRegistry"/>.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ServiceAttribute : Attribute {
        /// <summary>
        /// Can be used to indicate whether the service is only for private use, or also for public use.
        /// </summary>
        public enum ServiceLevelEnum {
            /// <summary>
            /// The service is only for the mod itself.
            /// </summary>
            Private,
            /// <summary>
            /// The service can also be requested by other mods.
            /// </summary>
            Public
        }

        /// <summary>
        /// The type of the interface this service is implementing.
        /// </summary>
        public Type InterfaceType { get; }

        /// <summary>
        /// The key for identifying this service.
        /// </summary>
        public string? Key { get; }
        
        /// <summary>
        /// Indicates whether this service should be public or private.
        /// </summary>
        public ServiceLevelEnum ServiceLevel { get; }

        /// <summary>
        /// Instantiates a new Service Attribute.
        /// </summary>
        /// <param name="interfaceType">The Type of the interface the service is implemting.</param>
        /// <param name="key">The key for identifying the service.</param>
        /// <param name="serviceLevel">Whether the service is public or private.</param>
        public ServiceAttribute(Type interfaceType, string? key = null, ServiceLevelEnum serviceLevel = ServiceLevelEnum.Private) {
            InterfaceType = interfaceType;
            Key = key;
            ServiceLevel = serviceLevel;
        }
    }
}
