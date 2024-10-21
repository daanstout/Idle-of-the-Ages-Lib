// <copyright file="HtmlNode.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Parsing.Trees;

/// <summary>
/// Represents a node for a HTML element.
/// </summary>
public class HtmlNode : Node<HtmlNode> {
    /// <summary>
    /// Gets the metadata of this node.
    /// </summary>
    public IReadOnlyDictionary<string, string> Metadata => metadata;

    private readonly Dictionary<string, string> metadata = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlNode"/> class.
    /// </summary>
    public HtmlNode() : base() { }

    /// <summary>
    /// Add Metadata.
    /// </summary>
    /// <param name="key">key.</param>
    /// <param name="value">value.</param>
    public void AddMetadata(string key, string value) => metadata[key] = value;
}
