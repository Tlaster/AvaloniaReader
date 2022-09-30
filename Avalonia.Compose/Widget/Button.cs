using System.Collections.Immutable;

namespace Avalonia.Compose.Widget;

public record Button(Action OnClick, ImmutableList<WidgetObject> Children) : Panel(Children);