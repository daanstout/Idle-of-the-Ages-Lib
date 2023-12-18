// <copyright file="ModifierCalculationType.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.Skills {
    /// <summary>
    /// An enum that is used to indicate what type of calculations should be done with percentage values to calculate the final modifier time.
    /// </summary>
    public enum ModifierCalculationType {
        /// <summary>
        /// The percentages should be added together.
        /// </summary>
        Additive,

        /// <summary>
        /// The percentages should be multiplied together.
        /// </summary>
        Multiplicative,
    }
}
