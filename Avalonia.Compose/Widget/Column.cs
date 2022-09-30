using System.Collections.Immutable;

namespace Avalonia.Compose.Widget;

public record Column(ImmutableList<WidgetObject> Children) : Panel(Children);
