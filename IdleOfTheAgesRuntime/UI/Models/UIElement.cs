using IdleOfTheAgesLib.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleOfTheAgesRuntime.UI.Models;

public class UIElement : IUIElement {
    /// <inheritdoc/>
    public required string ID { get; init; }

    /// <inheritdoc/>
    public required IReadOnlyCollection<string> Classes { get; init; }

    /// <inheritdoc/>
    public List<IUIElement> Children { get; } = [];
}
