using IdleOfTheAgesLib.UI;

using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine.UIElements;

namespace IdleOfTheAgesGame.UI {
    public class MiningSkillUI : Element<Box> {
        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            target.Add(new Label("Mining"));

            return target;
        }
    }
}
