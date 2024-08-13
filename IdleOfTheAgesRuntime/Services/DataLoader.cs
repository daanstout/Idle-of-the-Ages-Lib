// <copyright file="DataLoader.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models;
using IdleOfTheAgesLib.Models.JsonConverters;
using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI.Parsing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;

namespace IdleOfTheAgesRuntime;

/// <summary>
/// Allows for loading in data into the game.
/// </summary>
public class DataLoader : IDataLoader {
    private static readonly JsonSerializerSettings SETTINGS = new() {
        ContractResolver = new DefaultContractResolver {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        Converters = [new ModDataConverter()],
    };

    /// <summary>
    /// Extensions we explicitly ignore during the loading of data and don't log errors for.
    /// </summary>
    private static readonly string[] EXPLICITLY_IGNORED_EXTENSIONS = [".import"];

    private readonly ISkillService skillService;
    private readonly ITranslationService translationService;
    private readonly IActionLibrary actionLibrary;
    private readonly IParserService parserService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataLoader"/> class.
    /// </summary>
    /// <param name="skillService">The skill service to load skills into.</param>
    /// <param name="translationService">The translation service to load translation files into.</param>
    /// <param name="actionLibrary">The action library to load actions into.</param>
    /// <param name="parserService">The parser service to load UI files into.</param>
    public DataLoader(ISkillService skillService, ITranslationService translationService, IActionLibrary actionLibrary, IParserService parserService) {
        this.skillService = skillService;
        this.translationService = translationService;
        this.actionLibrary = actionLibrary;
        this.parserService = parserService;
    }

    /// <inheritdoc/>
    public Result LoadData(IModObject mod) {
        ResultBuilder builder = new();

        var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Mods", mod.Namespace, "Assets");

        if (!Directory.Exists(path))
            return (false, "Directory does not exist!", new ArgumentException($"No data directory for mod {mod.Namespace}"));

        LoadDataInDirectory(mod.Namespace, path, builder);

        return builder.Build(true);
    }

    private void LoadDataInDirectory(string modNamespace, string directory, ResultBuilder builder) {
        foreach (var file in Directory.GetFiles(directory)) {
            LoadFile(modNamespace, file, builder);
        }

        foreach (var subDirectory in Directory.GetDirectories(directory)) {
            LoadDataInDirectory(modNamespace, subDirectory, builder);
        }
    }

    private void LoadFile(string modNamespace, string file, ResultBuilder builder) {
        var extension = Path.GetExtension(file);

        if (EXPLICITLY_IGNORED_EXTENSIONS.Contains(extension)) {
            return;
        }

        switch (extension) {
            case ".txt":
                var language = Path.GetFileNameWithoutExtension(file);

                if (Languages.IsLanguageSupported(language)) {
                    translationService.LoadLanguagePath(language, file);
                } else {
                    builder.AddError($"Failed loading language file: {file}. The language is not supported.");
                }

                break;
            case ".json":
                var rawJson = File.ReadAllText(file);

                try {
                    var data = JsonConvert.DeserializeObject<ModData>(rawJson, SETTINGS);

                    if (data == null) {
                        builder.AddError($"Error while parsing json at file path: {file}");
                        break;
                    }

                    LoadModData(data, builder);
                } catch (Exception e) {
                    builder.AddError(($"Error while parsing json at file path: {file}", e));
                }

                break;
            case ".html":
                var fileName = Path.GetFileNameWithoutExtension(file);
                fileName = $"{modNamespace}:{fileName}";

                builder.AddResult(parserService.RegisterFile(fileName, file));

                break;
            case ".png":
                break;
            default:
                builder.AddError($"File extensions '{extension}' is not supported");
                break;
        }
    }

    private void LoadModData(ModData data, ResultBuilder builder) {
        foreach (var skill in data.Skills) {
            builder.AddResult(skillService.RegisterSkillData(skill));
        }

        foreach (var action in data.Actions) {
            builder.AddResult(actionLibrary.RegisterAction(action));
        }
    }
}
