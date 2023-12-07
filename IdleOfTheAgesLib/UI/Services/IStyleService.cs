// <copyright file="IStyleService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Styles;

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// A service to hold all the style sheets.
    /// </summary>
    public interface IStyleService {
        /// <summary>
        /// Adds a style to the collection.
        /// </summary>
        /// <param name="identifier">The identifier of the style.</param>
        /// <param name="json">The style in json format.</param>
        /// <returns>A <see cref="Result"/> object to check if the call was successful.</returns>
        Result AddStyle(string identifier, string json);

        /// <summary>
        /// Gets a style based on it's identifier.
        /// </summary>
        /// <param name="style">The style to request.</param>
        /// <returns>The requested style.</returns>
        Result<IStyleEntry> GetStyle(string style);
    }
}
