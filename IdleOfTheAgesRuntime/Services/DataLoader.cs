// <copyright file="DataLoader.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IdleOfTheAgesRuntime {
    /// <summary>
    /// Allows for loading in data into the game.
    /// </summary>
    public class DataLoader : IDataLoader {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings() {
            ContractResolver = new DefaultContractResolver {
                NamingStrategy = new SnakeCaseNamingStrategy(),
            },
        };

        private readonly IModObject modObject;
        private readonly IAgeService ageService;
        private readonly ISkillService skillService;
        private readonly ITextureLibrary textureLibrary;
        private readonly ITranslationService translationService;
        private readonly IPageGroupService pageGroupService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLoader"/> class.
        /// </summary>
        /// <param name="modObject">The mod the data is loaded form.</param>
        /// <param name="ageService">The age service to load ages into.</param>
        /// <param name="skillService">The skill service to load skills into.</param>
        /// <param name="textureLibrary">The texture library to load textures into.</param>
        /// <param name="translationService">The translation service to load translation files into.</param>
        /// <param name="pageGroupService">THe page group service to load page info into.</param>
        public DataLoader(IModObject modObject, IAgeService ageService, ISkillService skillService, ITextureLibrary textureLibrary, ITranslationService translationService, IPageGroupService pageGroupService) {
            this.modObject = modObject;
            this.ageService = ageService;
            this.skillService = skillService;
            this.textureLibrary = textureLibrary;
            this.translationService = translationService;
            this.pageGroupService = pageGroupService;
        }

        /// <inheritdoc/>
        public Result LoadData(params string[] pathSegments) {
            var path = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods", modObject.Namespace, Path.Combine(pathSegments));

            if (!File.Exists(path)) {
                return (false, $"File does not exist: {path}");
            }

            var json = File.ReadAllText(path);

            ModData data;
            try {
                data = JsonConvert.DeserializeObject<ModData>(json, Settings) ?? throw new FormatException("Cannot deserialize json into mod data file!");
            } catch (Exception e) {
                return (false, $"Error parsing the json for file at path: {path}", e);
            }

            ProcessData(data, data.PageGroups, pageGroup => pageGroupService.RegisterPageGroup(pageGroup));
            ProcessData(data, data.Pages, page => pageGroupService.RegisterPage(page));
            ProcessData(data, data.Ages, age => ageService.RegisterAge(age));
            ProcessData(data, data.Skills, skill => skillService.RegisterSkillData(skill));

            return true;
        }

        /// <inheritdoc/>
        public Result LoadLanguages(params string[] pathSegments) {
            var path = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods", modObject.Namespace, Path.Combine(pathSegments));

            if (!Directory.Exists(path)) {
                return (false, "Directory does not exist");
            }

            List<string> failedFiles = new List<string>();

            foreach (var file in Directory.GetFiles(path)) {
                if (Enum.TryParse<Language>(Path.GetFileNameWithoutExtension(file), true, out var language)) {
                    translationService.LoadLanguagePath(language, file);
                } else {
                    failedFiles.Add(Path.GetFileName(path));
                }
            }

            if (failedFiles.Count > 0) {
                return (false, $"Failed loading {failedFiles.Count} files!{failedFiles.Aggregate(string.Empty, (acc, str) => Environment.NewLine + acc + str)}");
            } else {
                return true;
            }
        }

        /// <inheritdoc/>
        public Result RegisterTextures(params string[] pathSegments) {
            var rootPath = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods", modObject.Namespace, Path.Combine(pathSegments));

            if (!Directory.Exists(rootPath)) {
                return (false, "Directory does not exist");
            }

            Queue<string> directories = new Queue<string>();
            directories.Enqueue(rootPath);

            while (directories.Count > 0) {
                var directory = directories.Dequeue();

                foreach (var subFolder in Directory.GetDirectories(directory)) {
                    directories.Enqueue(subFolder);
                }

                foreach (var filePath in Directory.GetFiles(directory)) {
                    var fileExtension = Path.GetExtension(filePath);

                    if (fileExtension != ".png" && fileExtension != ".jpg") {
                        continue;
                    }

                    textureLibrary.RegisterTextures($"{modObject.Namespace}:{Path.GetFileNameWithoutExtension(filePath)}", filePath);
                }
            }

            return true;
        }

        private static void ProcessData<T>(ModData data, IEnumerable<T> elements, Action<T> processFunc) where T : BaseDataElement {
            foreach (var item in elements) {
                item.Namespace = data.Namespace;
                processFunc(item);
            }
        }
    }
}
