// <copyright file="UIService.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;

using System.Collections.Generic;

namespace IdleOfTheAgesRuntime.UI {
    /// <summary>
    /// A service to interact with the UI elements that exist.
    /// </summary>
    [Service(typeof(IUIService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class UIService : IUIService {
        private static readonly string RootString = "root";

        private readonly Dictionary<string, Element> elements = new Dictionary<string, Element>();

        /// <inheritdoc/>
        public Result<Element> GetRoot() {
            if (!elements.TryGetValue(RootString, out var element)) {
                return (null!, "No root element has been registered!");
            }

            return element;
        }

        /// <inheritdoc/>
        public Result AddElement(Element element, string identifier) {
            if (string.IsNullOrWhiteSpace(identifier)) {
                return (false, "The passed identifier is empty!");
            }

            if (elements.ContainsKey(identifier)) {
                return (false, $"An element with the identifier {identifier} already exists!");
            }

            elements.Add(identifier, element);

            return true;
        }

        /// <inheritdoc/>
        public Result<TElement> GetElement<TElement>(string identifier) where TElement : Element => (GetElement(identifier) as TElement) !;

        /// <inheritdoc/>
        public Result<Element> GetElement(string identifier) {
            if (!elements.TryGetValue(identifier, out var element)) {
                return (null!, $"No element with identifier {identifier} has been registered!");
            }

            return element;
        }
    }
}
