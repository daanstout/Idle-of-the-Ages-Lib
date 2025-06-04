// <copyright file="IUIElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Models;

/// <summary>
/// Represents a UI element in the game.
/// </summary>
public interface IUIElement {
    /// <summary>
    /// Gets the ID of the UI Element.
    /// </summary>
    public string ID { get; }

    /// <summary>
    /// Gets the classes of this UI element.
    /// </summary>
    public IReadOnlyCollection<string> Classes { get; }

    /// <summary>
    /// Gets the children of this UI element.
    /// </summary>
    public List<IUIElement> Children { get; }
}
