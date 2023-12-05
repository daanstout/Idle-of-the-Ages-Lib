// <copyright file="App.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.Data;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesLib.UI;

using IdleOfTheAgesRuntime.Data;
using IdleOfTheAgesRuntime.DependencyInjection;
using IdleOfTheAgesRuntime.UI;

using Newtonsoft.Json;

using System;
using System.IO;
using System.Reflection;

using UnityEngine;

namespace IdleOfTheAgesRuntime {
    /// <summary>
    /// The entry point of the runtime.
    /// </summary>
    public class App {
        /// <summary>
        /// Gets the main service library.
        /// </summary>
        public IServiceLibrary ServiceLibrary => mainServiceLibrary;

        private readonly ServiceLibrary mainServiceLibrary;
        private readonly ServiceLibrary publicServiceLibrary;
        private readonly UIManagerService mainUIManagerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App() {
            mainServiceLibrary = new ServiceLibrary(null);
            publicServiceLibrary = new ServiceLibrary(mainServiceLibrary);
            mainUIManagerService = new UIManagerService(null, mainServiceLibrary);
            mainServiceLibrary.Bind<IUIManagerService>().ToInstance(mainUIManagerService);
        }

        /// <summary>
        /// Initializes the App Assembly.
        /// </summary>
        /// <param name="assembliesToInclude">Assemblies to also load with the main assembly.</param>
        public void Initialize(params Assembly[] assembliesToInclude) {
            var assembly = Assembly.GetExecutingAssembly();
            RegisterServices(assembly, mainServiceLibrary, publicServiceLibrary);
            RegisterUIElements(assembly, mainServiceLibrary.Get<IElementLibrary>());
            RegisterUIManagers(assembly, mainUIManagerService);

            foreach (var assemb in assembliesToInclude) {
                RegisterServices(assemb, mainServiceLibrary, publicServiceLibrary);
                RegisterUIElements(assemb, mainServiceLibrary.Get<IElementLibrary>());
                RegisterUIManagers(assemb, mainUIManagerService);
            }
        }

        /// <summary>
        /// Loads all the mods in the provided folder.
        /// </summary>
        /// <param name="rootPath">The folder the mods are all in.</param>
        public void LoadMods(string rootPath) {
            foreach (var modFolder in Directory.GetDirectories(rootPath)) {
                LoadMod(modFolder);
            }

            foreach (var mod in mainServiceLibrary.Get<IModLibrary>().GetAllMods()) {
                mod.Mod.AppLoaded(mod.ServiceLibrary);
            }
        }

        /// <summary>
        /// Indicates that the game has been loaded.
        /// </summary>
        public void GameLoaded() {
            foreach (var mod in mainServiceLibrary.Get<IModLibrary>().GetAllMods()) {
                mod.Mod.GameLoaded(mod.ServiceLibrary);
                RegisterSkills(mod.ModAssembly, mainServiceLibrary.Get<ISkillService>());
            }
        }

        private void LoadMod(string modDirectory) {
            var manifest = JsonConvert.DeserializeObject<ModManifest>(File.ReadAllText(Path.Combine(modDirectory, "Manifest.json")));

            if (manifest == null) {
                Debug.LogError($"No manifest found in folder: {modDirectory}");
                return;
            }

            Assembly assembly;
            try {
                assembly = Assembly.LoadFrom(Path.Combine(modDirectory, $"{manifest.Namespace}.dll"));
            } catch (Exception e) {
                Debug.LogException(e);
                return;
            }

            var modClass = assembly.GetType($"{manifest.Namespace}.{manifest.ModClass}");

            if (modClass == null) {
                Debug.LogError($"Could not load mod class: {manifest.Namespace}.{manifest.ModClass}!");
                return;
            }

            var modServiceLibrary = new ServiceLibrary(publicServiceLibrary);
            var modUIManagerService = new UIManagerService(mainUIManagerService, modServiceLibrary);
            modServiceLibrary.Bind<IUIManagerService>().ToInstance(modUIManagerService);

            ModObject modObject = new ModObject {
                Namespace = manifest.Namespace,
                Mod = (IMod)Activator.CreateInstance(modClass),
                Logger = new Logger(manifest.Namespace),
                ServiceLibrary = modServiceLibrary,
                ServiceRegistry = modServiceLibrary,
                ModAssembly = assembly,
            };

            mainServiceLibrary.Get<IModLibrary>().RegisterMod(manifest.Namespace, modObject);

            modObject.Init();
            RegisterModSpecificServices(modObject.ServiceRegistry);
            RegisterServices(assembly, publicServiceLibrary, modObject.ServiceRegistry);
            RegisterUIElements(assembly, mainServiceLibrary.Get<IElementLibrary>());
            RegisterUIManagers(assembly, modUIManagerService);
            modObject.Mod.RegisterPublicServices(publicServiceLibrary);
            modObject.Mod.RegisterServices(modServiceLibrary);
            modObject.Mod.ModLoaded(modObject.ServiceLibrary);
        }

        private static void RegisterModSpecificServices(IServiceRegistry serviceRegistry) {
            serviceRegistry.RegisterService<IDataLoader, DataLoader>(null);
        }

        private static void RegisterServices(Assembly assembly, IServiceRegistry publicServiceRegistry, IServiceRegistry modServiceRegistry) {
            foreach (var type in assembly.GetTypes()) {
                var serviceAttribute = type.GetCustomAttribute<ServiceAttribute>();

                if (serviceAttribute == null) {
                    continue;
                }

                var targetRegistry = serviceAttribute.ServiceLevel == ServiceAttribute.ServiceLevelEnum.Public ? publicServiceRegistry : modServiceRegistry;

                targetRegistry.RegisterService(serviceAttribute.InterfaceType, type, serviceAttribute.Key);
            }
        }

        private static void RegisterUIElements(Assembly assembly, IElementLibrary elementLibrary) {
            foreach (var type in assembly.GetTypes()) {
                var attrib = type.GetCustomAttribute<UIElementAttribute>();

                if (attrib == null)
                    continue;

                elementLibrary.RegisterElement(attrib.ElementInterface, type, attrib.Key);
            }
        }

        private static void RegisterUIManagers(Assembly assembly, UIManagerService uiManagerService) {
            foreach (var type in assembly.GetTypes()) {
                var attrib = type.GetCustomAttribute<UIManagerAttribute>();

                if (attrib == null)
                    continue;

                uiManagerService.RegisterManager(attrib.ManagerInterfaceType, type, attrib.Identifier);
            }
        }

        private static void RegisterSkills(Assembly assembly, ISkillService skillService) {
            foreach (var type in assembly.GetTypes()) {
                var skillAttribute = type.GetCustomAttribute<SkillAttribute>();

                if (skillAttribute == null) {
                    continue;
                }

                skillService.RegisterSkillImplementation(type, skillAttribute.SkillID);
            }
        }
    }
}
