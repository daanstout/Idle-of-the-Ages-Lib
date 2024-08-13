// <copyright file="ModManifest.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace IdleOfTheAgesLib.Data;

/// <summary>
/// The data object of a mod's manifest.json.
/// </summary>
public class ModManifest {
    /// <summary>
    /// Gets the namespace of a mod.
    /// </summary>
    [JsonProperty("namespace")]
    public string Namespace { get; init; } = string.Empty;

    /// <summary>
    /// Gets the path to the mod's thumbnail.
    /// </summary>
    [JsonProperty("thumbnail")]
    public string Thumbnail { get; init; } = string.Empty;

    /// <summary>
    /// Gets the name of the mod class.
    /// </summary>
    [JsonProperty("mod_class")]
    public string ModClass { get; init; } = string.Empty;

    /// <summary>
    /// Gets the dependencies of this mod.
    /// </summary>
    [JsonProperty("dependencies")]
    public string[] Dependencies { get; init; } = [];
}
