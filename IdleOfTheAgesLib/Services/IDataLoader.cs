// <copyright file="IDataLoader.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.Models;

namespace IdleOfTheAgesLib;

/// <summary>
/// Allows for loading in <see cref="ModData"/> objects.
/// </summary>
public interface IDataLoader {
    /// <summary>
    /// Loads in the files in the mod's 'data' folder.
    /// </summary>
    /// <param name="mod">The mod to load the data in for..</param>
    /// <returns><see langword="true"/> if the data was successfully loaded..</returns>
    Result LoadData(IModObject mod);
}
