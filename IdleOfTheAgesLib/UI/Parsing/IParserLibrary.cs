// <copyright file="IParserLibrary.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;
using System;

namespace IdleOfTheAgesLib.UI.Parsing;

/// <summary>
/// A library that stores all the parsers available.
/// </summary>
public interface IParserLibrary {
    /// <summary>
    /// Gets the parser for the specific tag.
    /// </summary>
    /// <param name="tag">The tag to get the parser for.</param>
    /// <returns>The requested parser.</returns>
    Result<ElementManager> GetElementManager(string tag);

    /// <summary>
    /// Gets the parser for the specific tag.
    /// </summary>
    /// <typeparam name="T">
    /// The type of UI element it should return.
    /// <para>
    /// This should only be used by the platform that also manages the UI.
    /// </para>
    /// </typeparam>
    /// <param name="tag">The tag to get the parser for.</param>
    /// <returns>The requested parser.</returns>
    Result<ElementManager<T>> GetElementManager<T>(string tag) where T : new();

    /// <summary>
    /// Gets a UI model.
    /// </summary>
    /// <param name="modelName">The model to obtain.</param>
    /// <returns>The requested model.</returns>
    Result<object> GetUIModel(string modelName);

    /// <summary>
    /// Registers a parser to the library.
    /// </summary>
    /// <typeparam name="T">The type of the parser.</typeparam>
    /// <param name="tag">The tag the parser should parse for.</param>
    /// <returns><see langword="true"/> if the parser was succesfully registered, otherwise <see langword="false"/>.</returns>
    Result RegisterElementManager<T>(string tag);

    /// <summary>
    /// Registers a parser to the library.
    /// </summary>
    /// <param name="parserType">The type of the parser.</param>
    /// <param name="tag">The tag the parser should parse for.</param>
    /// <returns><see langword="true"/> if the parser was succesfully registered, otherwise <see langword="false"/>.</returns>
    Result RegisterElementManager(Type parserType, string tag);

    /// <summary>
    /// Registers a UI model to the library.
    /// </summary>
    /// <typeparam name="T">The type of the UI model.</typeparam>
    /// <param name="modelName">The name of the UI model.</param>
    /// <returns><see langword="true"/> if the UI model was succesfully registered, otherwise <see langword="false"/>.</returns>
    Result RegisterUIModel<T>(string modelName);

    /// <summary>
    /// Registers a UI model to the library.
    /// </summary>
    /// <param name="modelType">The type of the UI model.</param>
    /// <param name="modelName">The name of the UI model.</param>
    /// <returns><see langword="true"/> if the UI model was succesfully registered, otherwise <see langword="false"/>.</returns>
    Result RegisterUIModel(Type modelType, string modelName);
}
