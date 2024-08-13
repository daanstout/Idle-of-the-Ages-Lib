// <copyright file="ElementManagerAttribute.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.UI.Elements;

/// <summary>
/// An <see cref="Attribute"/> used to indicate that a class can create UI elements.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ElementManagerAttribute : Attribute {
    /// <summary>
    /// Gets the tag the class is meant to construct elements for.
    /// </summary>
    public string HtmlTag { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementManagerAttribute"/> class.
    /// </summary>
    /// <param name="htmlTag">The html tag the elements constructs for.</param>
    public ElementManagerAttribute(string htmlTag) => HtmlTag = htmlTag;
}
