// <copyright file="FileLoader.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.IO;
using System.Collections.Generic;
using System.IO;

namespace IdleOfTheAgesRuntime.IO;

/// <summary>
/// Allows for registering and loading files.
/// </summary>
public class FileLoader : IFileLoader {
    private class FileCategoryData {
        public string Category { get; init; } = string.Empty;

        public Dictionary<string, string> Files { get; } = [];

        public Dictionary<string, string> FileContents { get; } = [];
    }

    private readonly Dictionary<string, FileCategoryData> files = [];

    /// <inheritdoc/>
    public Result<string> GetFileContents(string category, string identifier, bool cacheFile = true) {
        if (!files.TryGetValue(category, out var data)) {
            return (null, $"The \"{category}\" category doesn't exist");
        }

        string? contents;

        if (cacheFile) {
            if (data.FileContents.TryGetValue(identifier, out contents)) {
                return contents;
            }
        }

        if (!data.Files.TryGetValue(identifier, out var path)) {
            return (null, $"No file with the identifier \"{identifier}\" has been registered to the \"{category}\" category");
        }

        if (!File.Exists(path)) {
            return (null, $"The file at the path \"{path}\" does not exist, so the file with the identifier \"{identifier}\" within the \"{category}\" category couldn't be loaded");
        }

        contents = File.ReadAllText(path);

        if (cacheFile) {
            data.FileContents[identifier] = contents;
        }

        return contents;
    }

    /// <inheritdoc/>
    public Result RegisterFile(string category, string identifier, string path, bool cacheFile = false) {
        if (!files.TryGetValue(category, out var data)) {
            data = new() {
                Category = category,
            };
            files[category] = data;
        }

        if (data.Files.ContainsKey(identifier)) {
            return (false, $"A file with the identifier \"{identifier}\" already exists within the \"{category}\" category");
        }

        if (!File.Exists(path)) {
            return (false, $"The file at the path \"{path}\" does not exist, so the file with the identifier \"{identifier}\" within the \"{category}\" category couldn't be registered");
        }

        data.Files[identifier] = path;

        if (cacheFile) {
            data.FileContents[identifier] = File.ReadAllText(path);
        }

        return true;
    }

    /// <inheritdoc/>
    public Result<string> ReadFile(string path) {
        if (!File.Exists(path)) {
            return (null, $"No file found at path {path}");
        }

        return File.ReadAllText(path);
    }
}
