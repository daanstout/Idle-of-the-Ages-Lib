// <copyright file="UIModelAttribute.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;

namespace IdleOfTheAgesLib.UI.Parsing;

/// <summary>
/// An attribute used to indicate that a class is a model for UI.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class UIModelAttribute : Attribute { }
