using System.Collections.Immutable;

namespace Avalonia.Compose.Widget;

public record WidgetObject;

internal interface IPanelWidget
{
    ImmutableList<WidgetObject> Children { get; }
}