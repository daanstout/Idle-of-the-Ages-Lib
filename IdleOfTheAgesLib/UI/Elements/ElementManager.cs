// <copyright file="ElementManager.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesLib.UI.Elements;

/// <summary>
/// The base class for UI elements.
/// </summary>
/// <typeparam name="T">The type of the element that is created.</typeparam>
public abstract class ElementManager<T> : ElementManager where T : new() {
    /// <summary>
    /// Gets the element that is being managed.
    /// </summary>
    protected T Element => element;

    private readonly T element;

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementManager{T}"/> class.
    /// </summary>
    protected ElementManager() : base() {
        element = new();
    }
}

/// <summary>
/// The base class for UI elements.
/// </summary>
public abstract class ElementManager {
    /// <summary>
    /// Constructs a UI element based on the node.
    /// <para>If no element should be shown, <see langword="null"/> should be returned.</para>
    /// </summary>
    /// <param name="node">The node that contains data about the element.</param>
    /// <param name="context">The ui context to use while constructing the element.</param>
    /// <returns>The constructed UI element.</returns>
    public virtual Result<object?> ConstructObject(HtmlNode node, UIContext context) => new(null);

    /// <summary>
    /// Allows the element manager to initialize the context or element with relevant data.
    /// </summary>
    /// <param name="node">The node that contains data about the element.</param>
    /// <param name="context">The ui context to use while constructing the element.</param>
    /// <returns><see langword="true"/> if the initialisation was succesful, <see langword="false"/> if something went wrong.</returns>
    public virtual Result Initialize(HtmlNode node, UIContext context) => true;

    /// <summary>
    /// Updates the element to ensure the view changes when the state of the game changes.
    /// </summary>
    /// <param name="context">The ui context to use while updating the element.</param>
    /// <returns><see langword="true"/> if the object was succesfully updated, <see langword="false"/> if something went wrong.</returns>
    public virtual Result Update(UIContext context) => true;
}
