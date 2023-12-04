// <copyright file="SidebarElementModel.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Elements;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains data for the <see cref="ISidebarElement"/> to initialize itself.
    /// </summary>
    public class SidebarElementModel {
        /// <summary>
        /// Gets the skill elements to render in the sidebar.
        /// </summary>
        public IReadOnlyCollection<ISkillSidebarElement> SkillElements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SidebarElementModel"/> class.
        /// </summary>
        /// <param name="skillElements">The skill elements to render in the sidebar.</param>
        public SidebarElementModel(IReadOnlyCollection<ISkillSidebarElement> skillElements) {
            SkillElements = skillElements;
        }
    }
}
