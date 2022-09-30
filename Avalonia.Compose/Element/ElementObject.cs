using Avalonia.Compose.Widget;
using Avalonia.Controls;

namespace Avalonia.Compose.Element;

internal class ElementObject<TWidget, TControl> where TWidget : WidgetObject where TControl : Control
{
    public ElementObject(TControl control, TWidget widget)
    {
        Control = control;
        Widget = widget;
    }

    public TControl Control { get; }

    public TWidget Widget { get; set; }
}