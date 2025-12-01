// <copyright file="App.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Data;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Models;
using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesRuntime.Data;
using IdleOfTheAgesRuntime.DependencyInjection;
using IdleOfTheAgesRuntime.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace IdleOfTheAgesRuntime;

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

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App() {
        mainServiceLibrary = new ServiceLibrary(null);
        publicServiceLibrary = new ServiceLibrary(mainServiceLibrary);
    }

    /// <summary>
    /// Initializes the App Assembly.
    /// </summary>
    /// <param name="assembliesToInclude">Assemblies to also load with the main assembly.</param>
    public void Initialize(params Assembly[] assembliesToInclude) {
        var assembly = Assembly.GetExecutingAssembly();
        RegisterServices(assembly, mainServiceLibrary, publicServiceLibrary);

        foreach (var includedAssembly in assembliesToInclude) {
            RegisterServices(includedAssembly, mainServiceLibrary, publicServiceLibrary);
        }
    }

    /// <summary>
    /// Loads all the mods in the provided folder.
    /// </summary>
    /// <param name="rootPath">The folder the mods are all in.</param>
    /// <param name="assemblyLoadContext">The load context to load the mod assemblies with.</param>
    /// <returns>Whether the loading of the mods contained any errors.</returns>
    public Result LoadMods(string rootPath, AssemblyLoadContext assemblyLoadContext) {
        ResultBuilder resultBuilder = new();

        foreach (var modFolder in Directory.GetDirectories(rootPath)) {
            LoadMod(modFolder, assemblyLoadContext, resultBuilder);
        }

        foreach (var mod in mainServiceLibrary.Get<IModLibrary>().GetAllMods()) {
            mod.Mod.AppLoaded(mod.ServiceLibrary);
        }

        return resultBuilder.Build();
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

    private void LoadMod(string modDirectory, AssemblyLoadContext assemblyLoadContext, ResultBuilder resultBuilder) {
        var manifest = JsonConvert.DeserializeObject<ModManifest>(File.ReadAllText(Path.Combine(modDirectory, "Manifest.json")));

        if (manifest == null) {
            resultBuilder.AddError(($"Couldn't load manifest for {modDirectory}", new InvalidOperationException()));
            return;
        }

        Assembly assembly;
        try {
            assembly = assemblyLoadContext.LoadFromAssemblyPath($"{modDirectory}/{manifest.Namespace}.dll");
        } catch (Exception exception) {
            resultBuilder.AddError(($"Couldn't load assembly for {manifest.Namespace} due to exception of type {exception.GetType().FullName}", exception));
            return;
        }

        var modClass = assembly.GetType($"{manifest.Namespace}.{manifest.ModClass}");

        if (modClass == null) {
            resultBuilder.AddError(($"Couldn't load mod class for {manifest.Namespace} (class = {manifest.ModClass}, assembly = {assembly.FullName})", new InvalidOperationException()));
            return;
        }

        var modServiceLibrary = new ServiceLibrary(publicServiceLibrary);

        ModObject modObject = new() {
            Namespace = manifest.Namespace,
            Mod = (IMod)Activator.CreateInstance(modClass)!,
            ServiceLibrary = modServiceLibrary,
            ServiceRegistry = modServiceLibrary,
            ModAssembly = assembly,
        };

        mainServiceLibrary.Get<IModLibrary>().RegisterMod(manifest.Namespace, modObject);

        RegisterServices(assembly, publicServiceLibrary, modObject.ServiceRegistry);
        modObject.Mod.RegisterPublicServices(publicServiceLibrary);
        modObject.Mod.RegisterServices(modServiceLibrary);
        modObject.Init();
        modObject.Mod.LoadData(modObject.ServiceLibrary);
        modObject.Mod.ModLoaded(modObject.ServiceLibrary);
    }

    private static void RegisterServices(Assembly assembly, IServiceRegistry publicServiceRegistry, IServiceRegistry privateServiceRegistry) {
        foreach (var type in assembly.GetTypes()) {
            foreach (var serviceAttribute in type.GetCustomAttributes(typeof(ServiceAttribute<>))) {
                var interfaceType = serviceAttribute.GetType().GetGenericArguments()[0];
                var serviceLevel = (serviceAttribute.GetType().GetProperty(nameof(ServiceAttribute<int>.ServiceLevel), BindingFlags.Public | BindingFlags.Instance)?.GetValue(serviceAttribute) as ServiceLevelEnum?) ?? ServiceLevelEnum.None;
                var serviceKey = serviceAttribute.GetType().GetProperty(nameof(ServiceAttribute<int>.Key), BindingFlags.Public | BindingFlags.Instance)!.GetValue(serviceAttribute) as string;

                if (serviceLevel == ServiceLevelEnum.None) {
                    continue;
                }

                (serviceLevel switch {
                    ServiceLevelEnum.Public => publicServiceRegistry,
                    ServiceLevelEnum.Private => privateServiceRegistry,
                    _ => null,
                })?.RegisterService(interfaceType, type, serviceKey);
            }
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
