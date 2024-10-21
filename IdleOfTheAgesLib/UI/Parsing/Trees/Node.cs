// <copyright file="Node.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Parsing.Trees;

/// <summary>
/// A node that contains information about a HTML tag for the UI.
/// </summary>
/// <typeparam name="T">The type of the node.</typeparam>
public abstract class Node<T> where T : Node<T> {
    /// <summary>
    /// Gets the parent node of this node.
    /// </summary>
    public T? Parent { get; private set; }

    /// <summary>
    /// Gets the child nodes of this node.
    /// </summary>
    public IReadOnlyList<T> ChildNodes => childNodes;

    /// <summary>
    /// Gets the HTML tag that this node is for.
    /// </summary>
    public string Identifier { get; init; } = string.Empty;

    private readonly List<T> childNodes = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class.
    /// </summary>
    protected Node() { }

    /// <summary>
    /// Adds a node as a child of this node.
    /// </summary>
    /// <param name="child">The child node of this node.</param>
    public void AddChildNode(T child) {
        child.SetParent((this as T)!);
        childNodes.Add(child);
    }

    private void SetParent(T parent) {
        Parent?.childNodes.Remove((this as T)!);

        Parent = parent;
    }
}
