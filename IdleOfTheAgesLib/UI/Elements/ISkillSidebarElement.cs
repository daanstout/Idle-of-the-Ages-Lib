// <copyright file="ISkillSidebarElement.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.UI.Models;

using System;

namespace IdleOfTheAgesLib.UI.Elements {
    /// <summary>
    /// Represents a skill element in the sidebar menu.
    /// </summary>
    public interface ISkillSidebarElement : IElement<SkillSidebarModel> {
        /// <summary>
        /// Invoked when the user clicks on the side bar element.
        /// <para>The parameter is the ID of the skill that got clicked on.</para>
        /// </summary>
        event Action<string> SkillClickedEvent;
    }
}
