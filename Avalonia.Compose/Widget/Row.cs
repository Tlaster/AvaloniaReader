using System.Collections.Immutable;

namespace Avalonia.Compose.Widget;

public record Row(ImmutableList<WidgetObject> Children) : Panel(Children);