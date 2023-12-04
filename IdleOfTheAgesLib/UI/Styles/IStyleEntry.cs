// <copyright file="IStyleEntry.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using UnityEngine.UIElements;

namespace IdleOfTheAgesLib.UI.Styles {
    /// <summary>
    /// Represents a style entry that contains style data for <see cref="Element"/>s.
    /// </summary>
    public interface IStyleEntry {
        /// <summary>
        /// Applies the entries's styles to the <paramref name="style"/>.
        /// </summary>
        /// <param name="style">The style to apply this entries's styles to.</param>
        void ApplyToStyle(IStyle style);
    }
}
