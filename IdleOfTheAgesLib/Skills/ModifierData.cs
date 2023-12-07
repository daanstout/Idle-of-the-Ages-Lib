// <copyright file="ModifierData.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Skills
{
    /// <summary>
    /// Data that modifies certain stats within the game.
    /// </summary>
    public class ModifierData
    {
        /// <summary>
        /// Gets the source of the modification data.
        /// </summary>
        public string ModifierSource { get; }

        /// <summary>
        /// Gets the target stat this modifier is affecting.
        /// </summary>
        public string ModifierTarget { get; }

        /// <summary>
        /// Gets or sets the flat modifier that should be applied.
        /// </summary>
        public float FlatModifier { get; set; }

        /// <summary>
        /// Gets the percent modifier that shouldbe applied.
        /// </summary>
        public float PercentModifier { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierData"/> class.
        /// </summary>
        /// <param name="modifierSource">The source of the modification data.</param>
        /// <param name="modifierTarget">The target stat this modifier is affecting.</param>
        public ModifierData(string modifierSource, string modifierTarget)
        {
            ModifierSource = modifierSource;
            ModifierTarget = modifierTarget;
        }
    }
}
