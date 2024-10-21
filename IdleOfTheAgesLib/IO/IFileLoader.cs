﻿// <copyright file="IFileLoader.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesLib.IO;

/// <summary>
/// Allows for registering and loading files.
/// </summary>
public interface IFileLoader {
    /// <summary>
    /// Registers a file to the file loader.
    /// </summary>
    /// <param name="category">The category the file belongs to.</param>
    /// <param name="identifier">The identifier for the file.</param>
    /// <param name="path">The path to the file.</param>
    /// <param name="cacheFile">If <see langword="true"/>, immediately reads and caches the file contents.</param>
    /// <returns><see langword="true"/> if the file was succesfully cached, <see langword="false"/> if something went wrong.</returns>
    public Result RegisterFile(string category, string identifier, string path, bool cacheFile = false);

    /// <summary>
    /// Reads the contents of a file.
    /// </summary>
    /// <param name="category">The category the file belongs to.</param>
    /// <param name="identifier">The identifier for the file.</param>
    /// <param name="cacheFile">Whether to cache the file for faster lookup next time.</param>
    /// <returns>The contents of the requested file.</returns>
    public Result<string> GetFileContents(string category, string identifier, bool cacheFile = true);
}
