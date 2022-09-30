using System.Collections.Immutable;
using Avalonia.Compose.Renderer;

namespace Avalonia.Compose.Widget;

public record WidgetObject;

internal interface IPanelWidget
{
    ImmutableList<WidgetObject> Children { get; }
}