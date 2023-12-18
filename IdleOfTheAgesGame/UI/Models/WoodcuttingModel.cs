// <copyright file="WoodcuttingModel.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

namespace IdleOfTheAgesGame.UI.Models {
    /// <summary>
    /// The model for the woodcutting element.
    /// </summary>
    public class WoodcuttingModel {
        /// <summary>
        /// Gets the name to display.
        /// </summary>
        public string Name { get; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="WoodcuttingModel"/> class.
        /// </summary>
        /// <param name="name">The name of the skill.</param>
        public WoodcuttingModel(string name) {
            Name = name;
        }
    }
}
