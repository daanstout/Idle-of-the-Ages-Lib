using IdleOfTheAgesLib.UI.Elements;

using System.Collections.Generic;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains data for the <see cref="ISidebarElement"/> to initialize itself.
    /// </summary>
    public class SidebarElementModel {
        /// <summary>
        /// The skill elements to render in the sidebar.
        /// </summary>
        public IReadOnlyCollection<ISkillSidebarElement> SkillElements { get; }

        /// <summary>
        /// Initializes a new Sidebar Element Model.
        /// </summary>
        /// <param name="skillElements">The skill elements to render in the sidebar.</param>
        public SidebarElementModel(IReadOnlyCollection<ISkillSidebarElement> skillElements) {
            SkillElements = skillElements;
        }
    }
}
