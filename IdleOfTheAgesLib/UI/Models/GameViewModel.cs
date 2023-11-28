using IdleOfTheAgesLib.UI.Elements;

namespace IdleOfTheAgesLib.UI.Models {
    /// <summary>
    /// Contains data for the game view model.
    /// </summary>
    public class GameViewModel {
        /// <summary>
        /// The sidebar element.
        /// </summary>
        public ISidebarElement SidebarElement { get; set; } = null!;
    }
}
