using IdleOfTheAgesLib.UI;

using UnityEngine.UIElements;

namespace IdleOfTheAgesGame.UI {
    public class WoodcuttingSkillUI : Element<Box> {
        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            target.Add(new Label("Woodcutting"));

            return target;
        }
    }
}
