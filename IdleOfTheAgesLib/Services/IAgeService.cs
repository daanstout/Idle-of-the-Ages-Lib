using IdleOfTheAgesLib.Models.ModJsonData;

namespace IdleOfTheAgesLib.Skills {
    /// <summary>
    /// A service that holds all the ages that exist.
    /// </summary>
    public interface IAgeService {
        /// <summary>
        /// Registers an age that he player can reach.
        /// <para>If a later age is set to be after the same age as this age, that age will precede this age.</para>
        /// <para>The namespace field will be filled in automatically.</para>
        /// </summary>
        /// <param name="age">The age to register.</param>
        Result RegisterAge(AgeData age);
    }
}
