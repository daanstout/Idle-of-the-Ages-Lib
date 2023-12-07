// <copyright file="Language.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace IdleOfTheAgesLib.Translation {
    /// <summary>
    /// A list of languages the game supports.
    /// </summary>
    public enum Language {
        /// <summary>
        /// Default case
        /// </summary>
        None = 0,

        /// <summary>
        /// American English
        /// </summary>
        [Description("en_US")]
        EN_US,

        /// <summary>
        /// Dutch
        /// </summary>
        [Description("nl_NL")]
        NL_NL,
    }
}
