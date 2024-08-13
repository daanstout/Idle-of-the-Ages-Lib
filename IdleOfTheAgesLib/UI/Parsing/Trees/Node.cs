// <copyright file="Node.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Parsing.Trees;

/// <summary>
/// A node that contains information about a HTML tag for the UI.
/// </summary>
public class Node {
    /// <summary>
    /// Gets the parent node of this node.
    /// </summary>
    public Node? Parent { get; private set; }

    /// <summary>
    /// Gets the child nodes of this node.
    /// </summary>
    public IReadOnlyList<Node> ChildNodes => childNodes;

    /// <summary>
    /// Gets the metadata of this node.
    /// </summary>
    public IReadOnlyDictionary<string, string> Metadata => metadata;

    /// <summary>
    /// Gets the HTML tag that this node is for.
    /// </summary>
    public string HtmlTag { get; }

    private readonly Dictionary<string, string> metadata = [];
    private readonly List<Node> childNodes = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="htmlTag">The HTML tag this node is parsing.</param>
    public Node(string htmlTag) => HtmlTag = htmlTag;

    /// <summary>
    /// Adds a node as a child of this node.
    /// </summary>
    /// <param name="child">The child node of this node.</param>
    public void AddChildNode(Node child) {
        child.SetParent(this);
        childNodes.Add(child);
    }

    /// <summary>
    /// Add Metadata.
    /// </summary>
    /// <param name="key">key.</param>
    /// <param name="value">value.</param>
    public void AddMetadata(string key, string value) => metadata[key] = value;

    private void SetParent(Node parent) {
        Parent?.childNodes.Remove(this);

        Parent = parent;
    }
}
