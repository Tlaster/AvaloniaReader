using System.Collections.Immutable;
using System.Windows.Input;

namespace Avalonia.Compose.Widget;

public record Button(ICommand OnClick, ImmutableList<WidgetObject> Children) : Panel(Children);