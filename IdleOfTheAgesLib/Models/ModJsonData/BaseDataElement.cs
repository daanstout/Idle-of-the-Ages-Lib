// <copyright file="BaseDataElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesLib.Models.ModJsonData;

/// <summary>
/// A base class for data elements.
/// </summary>
public abstract class BaseDataElement : IEquatable<BaseDataElement?> {
    /// <summary>
    /// Gets the namespace of the object.
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// Gets the ID of the object.
    /// </summary>
    public string ID { get; }

    /// <summary>
    /// Gets the name of the object.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the object's namespaced ID.
    /// </summary>
    public string NamespacedID => $"{Namespace}:{ID}";

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDataElement"/> class.
    /// </summary>
    /// <param name="namespace">The namespace of the element.</param>
    /// <param name="id">The ID of the element.</param>
    /// <param name="name">The name of the element.</param>
    public BaseDataElement(string @namespace, string id, string name) {
        Namespace = @namespace;
        ID = id;
        Name = name;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as BaseDataElement);

    /// <inheritdoc/>
    public bool Equals(BaseDataElement? other) => other is not null && NamespacedID == other.NamespacedID;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(NamespacedID);

    /// <summary>
    /// Checks whether 2 data elements are equal.
    /// </summary>
    /// <param name="left">The left data element.</param>
    /// <param name="right">The right data element.</param>
    /// <returns><see langword="true"/> if both elements are considered equal, <see langword="false"/> if not.</returns>
    public static bool operator ==(BaseDataElement? left, BaseDataElement? right) => EqualityComparer<BaseDataElement>.Default.Equals(left, right);

    /// <summary>
    /// Checks whether 2 data elements are not equal.
    /// </summary>
    /// <param name="left">The left data element.</param>
    /// <param name="right">The right data element.</param>
    /// <returns><see langword="true"/> if the elements are not considered equal, <see langword="false"/> if they are.</returns>
    public static bool operator !=(BaseDataElement? left, BaseDataElement? right) => !(left == right);
}

/// <summary>
/// A base class for data elements that are visible to the user.
/// </summary>
public abstract class VisisbleDataElement : BaseDataElement {
    /// <summary>
    /// Gets the translation key of the element.
    /// </summary>
    public string TranslationKey { get; }

    /// <summary>
    /// Gets the sorting order of this element.
    /// </summary>
    public SortingOrderData SortingOrder { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VisisbleDataElement"/> class.
    /// </summary>
    /// <param name="namespace">The namespace of the element.</param>
    /// <param name="id">The ID of the element.</param>
    /// <param name="name">The name of the element.</param>
    /// <param name="translationKey">The translation key of the element.</param>
    /// <param name="sortingOrder">The sorting order of the element.</param>
    public VisisbleDataElement(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder) : base(@namespace, id, name) {
        TranslationKey = translationKey;
        SortingOrder = sortingOrder;
    }
}

/// <summary>
/// A base class for data elements that are visible to the user and have a thumbnail.
/// </summary>
public abstract class ThumbnailDataElement : VisisbleDataElement {
    /// <summary>
    /// Gets the thumbnail ID of the object.
    /// </summary>
    public string? Thumbnail { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThumbnailDataElement"/> class.
    /// </summary>
    /// <param name="namespace">The namespace of the element.</param>
    /// <param name="id">The ID of the element.</param>
    /// <param name="name">The name of the element.</param>
    /// <param name="translationKey">The translation key of the element.</param>
    /// <param name="sortingOrder">The sorting order of the element.</param>
    /// <param name="thumbnail">The thumbnail for the element.</param>
    public ThumbnailDataElement(string @namespace, string id, string name, string translationKey, SortingOrderData sortingOrder, string thumbnail) : base(@namespace, id, name, translationKey, sortingOrder) {
        Thumbnail = thumbnail;
    }
}
