// <copyright file="ElementBuilderAttribute.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace IdleOfTheAgesLib.UI.Attributes;

/// <summary>
/// Can be used to indicate that a class is used to build attributes.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ElementBuilderAttribute : Attribute {
    /// <summary>
    /// Gets the name of the element the builder can build.
    /// </summary>
    [Required]
    public required string ElementName { get; init; }
}
