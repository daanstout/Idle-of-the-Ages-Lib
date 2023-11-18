namespace IdleOfTheAgesLib.Data {
    /// <summary>
    /// Data that modifies certain stats within the game.
    /// </summary>
    public class ModifierData {
        /// <summary>
        /// The source of the modification data.
        /// </summary>
        public string ModifierSource { get; }

        /// <summary>
        /// The target stat this modifier is affecting.
        /// </summary>
        public string ModifierTarget { get; }

        /// <summary>
        /// The flat modifier that should be applied.
        /// </summary>
        public float flatModifier { get; set; }

        /// <summary>
        /// The percent modifier that shouldbe applied.
        /// </summary>
        public float percentModifier { get; }

        /// <summary>
        /// Instantiates a new instance of the Modifier Data class.
        /// </summary>
        /// <param name="modifierSource">The source of the modification data.</param>
        /// <param name="modifierTarget">The target stat this modifier is affecting.</param>
        public ModifierData(string modifierSource, string modifierTarget) {
            ModifierSource = modifierSource;
            ModifierTarget = modifierTarget;
        }
    }
}
