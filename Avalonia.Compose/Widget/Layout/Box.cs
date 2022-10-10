using System.Collections.Immutable;

namespace Avalonia.Compose.Widget.Layout;

public record Box(ImmutableList<WidgetObject> Children, Alignment ContentAlignment) : Panel(Children);