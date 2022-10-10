using System.Collections.Immutable;

namespace Avalonia.Compose.Widget.Layout;

public record Column(ImmutableList<WidgetObject> Children, Alignment.Horizontal HorizontalAlignment, Alignment.Vertical VerticalAlignment) : Panel(Children);