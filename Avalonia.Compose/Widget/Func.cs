using System.Collections.Immutable;
using System.Windows.Input;

namespace Avalonia.Compose.Widget;

public static class FuncUi
{
    public static Text Text(string text)
    {
        return new(text);
    }

    public static Button Button(ICommand onClick, params WidgetObject[] children)
    {
        return new(onClick, children.ToImmutableList());
    }

    public static Column Column(params WidgetObject[] children)
    {
        return new(children.ToImmutableList());
    }

    public static Row Row(params WidgetObject[] children)
    {
        return new(children.ToImmutableList());
    }

    public static Box Box(params WidgetObject[] children)
    {
        return new(children.ToImmutableList());
    }
}