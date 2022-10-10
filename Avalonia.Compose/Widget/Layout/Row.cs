using System.Collections.Immutable;

namespace Avalonia.Compose.Widget.Layout;

public record Row(ImmutableList<WidgetObject> Children, Alignment.Horizontal HorizontalAlignment, Alignment.Vertical VerticalAlignment) : Panel(Children);