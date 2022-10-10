using System.Collections.Immutable;
using System.Windows.Input;
using Avalonia.Compose.Widget.Layout;

namespace Avalonia.Compose.Widget;

public record Button(ICommand OnClick, ImmutableList<WidgetObject> Children) : Panel(Children);