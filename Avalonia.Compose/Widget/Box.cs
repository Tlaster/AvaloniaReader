using System.Collections.Immutable;

namespace Avalonia.Compose.Widget;

public record Box(ImmutableList<WidgetObject> Children) : Panel(Children);
