using IdleOfTheAgesLib.DependencyInjection;

namespace IdleOfTheAgesLib.Data {
    /// <summary>
    /// Contains all relevant mod data.
    /// </summary>
    public interface IModObject {
        /// <summary>
        /// A logger to log data to.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// The instance of the mod's initializer class.
        /// </summary>
        IMod Mod { get; }

        /// <summary>
        /// The namespace of the mod.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// The service library containing this mod's services.
        /// </summary>
        IServiceLibrary ServiceLibrary { get; }
    }
}