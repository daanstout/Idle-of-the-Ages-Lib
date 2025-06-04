// <copyright file="IElementBuilderLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Models;
using System;

namespace IdleOfTheAgesLib.UI.Services;

/// <summary>
/// Holds all known element builders that are available.
/// </summary>
public interface IElementBuilderLibrary {
    /// <summary>
    /// Registers an element builder to the library.
    /// </summary>
    /// <typeparam name="TBuilderType">The type of the element builder that is being added.</typeparam>
    /// <param name="htmlTag">The html tag it can build.</param>
    /// <returns><see langword="true"/> if the element was succesfully registered, and false if not.</returns>
    Result RegisterElementBuilder<TBuilderType>(string htmlTag) where TBuilderType : IElementBuilder;

    /// <summary>
    /// Registers an element builder to the library.
    /// </summary>
    /// <param name="htmlTag">The html tag it can build.</param>
    /// <param name="builderType">The type of the element builder that is being added.</param>
    /// <returns><see langword="true"/> if the element was succesfully registered, and false if not.</returns>
    Result RegisterElementBuilder(string htmlTag, Type builderType);

    /// <summary>
    /// Gets an element builder for the specified tag.
    /// </summary>
    /// <param name="htmlTag">The tag to get the builder for.</param>
    /// <returns>The requested builder.</returns>
    Result<IElementBuilder> GetBuilder(string htmlTag);
}
