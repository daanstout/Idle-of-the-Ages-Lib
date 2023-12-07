// <copyright file="UIManagerService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Managers;

using IdleOfTheAgesRuntime.DependencyInjection;

using System;
using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.UI
{
    /// <summary>
    /// A service to keep track of the <see cref="IUIManager"/> instances.
    /// </summary>
    public class UIManagerService : IUIManagerService
    {
        private readonly IUIManagerService? parent;
        private readonly ServiceLibrary serviceLibrary;
        private readonly Dictionary<string, IUIManager> managerInstances = new Dictionary<string, IUIManager>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UIManagerService"/> class.
        /// </summary>
        /// <param name="parent">The parent UI manager of this service.</param>
        /// <param name="serviceLibrary">The service library to obtain services from.</param>
        public UIManagerService(IUIManagerService? parent, IServiceLibrary serviceLibrary)
        {
            this.parent = parent;
            this.serviceLibrary = new ServiceLibrary(serviceLibrary);
        }

        /// <inheritdoc/>
        public Result<TManager> GetManager<TManager>(string instanceIdentifier, string? key = null) where TManager : IUIManager => (TManager)GetManager(typeof(TManager), instanceIdentifier, key);

        /// <inheritdoc/>
        public Result<IUIManager> GetManager(Type managerType, string instanceIdentifier, string? key = null)
        {
            if (!managerInstances.TryGetValue(instanceIdentifier, out var manager))
            {
                if (!serviceLibrary.ContainsService(managerType, key))
                {
                    if (parent != null)
                    {
                        return parent.GetManager(managerType, instanceIdentifier, key);
                    }
                    else
                    {
                        return (null!, $"No manager has been registered to solve for elements of type: {managerType.FullName} with key: {key}");
                    }
                }

                manager = (IUIManager)serviceLibrary.Get(managerType, key);
                managerInstances[instanceIdentifier] = manager;
            }

            return new Result<IUIManager>(manager);
        }

        /// <inheritdoc/>
        public Result RegisterManager<TManagerInterface, TManagerImplementation>(string? key = null) where TManagerInterface : IUIManager where TManagerImplementation : TManagerInterface
            => RegisterManager(typeof(TManagerInterface), typeof(TManagerImplementation), key);

        /// <inheritdoc/>
        public Result RegisterManager(Type managerTypeInterface, Type managerTypeImplementation, string? key = null)
        {
            if (!managerTypeInterface.IsInterface)
            {
                return (false, $"{managerTypeInterface.FullName} is not an interface!", new ArgumentException(null, nameof(managerTypeInterface)));
            }

            if (managerTypeImplementation.IsInterface || managerTypeImplementation.IsAbstract)
            {
                return (false, $"{managerTypeInterface.FullName} is either an interface or an abstract class!", new ArgumentException(null, nameof(managerTypeInterface)));
            }

            var resolver = serviceLibrary.Bind(managerTypeInterface, key);
            resolver.IsSingleton = false;
            resolver.SetInstanceType(managerTypeImplementation);

            return true;
        }
    }
}
