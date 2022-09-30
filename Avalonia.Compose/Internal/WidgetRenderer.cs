using Avalonia.Compose.Widget;
using Avalonia.Controls;

namespace Avalonia.Compose.Internal;

internal class WidgetRenderer
{
    public bool IsChanged(WidgetObject oldValue, WidgetObject newValue) 
    {
        return oldValue != newValue;
    }
    
    public Control Render(WidgetObject widget)
    {
        var renderer = RendererPool.GetRenderer(widget.GetType());
        var control = renderer.Create();
        renderer.Update(control, widget);
        if (widget is IPanelWidget panel)
        {
            foreach (var childControl in panel.Children.Select(Render))
            {
                renderer.AddChild(control, childControl);
            }
        }
        return control;
    }

    public Control RenderIfNeeded(WidgetObject? oldValue, WidgetObject newValue, Control control)
    {
    }
}