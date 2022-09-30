using Avalonia.Compose.Widget;
using Avalonia.Controls;
using Panel = Avalonia.Controls.Panel;

namespace Avalonia.Compose.Renderer;

internal abstract class RendererObject<TWidget, TControl> : IRenderer
    where TWidget : WidgetObject where TControl : class, new()
{
    protected internal virtual TControl Create()
    {
        return new TControl();
    }

    public void Update(Control control, WidgetObject widget)
    {
        Update(control as TControl ?? throw new InvalidOperationException(), (TWidget)widget);
    }

    public void AddChild(Control control, Control childControl)
    {
        AddChild(control as TControl ?? throw new InvalidOperationException(), childControl);
    }

    protected internal virtual void AddChild(TControl control, Control childControl)
    {
        switch (control)
        {
            case Panel panel:
                panel.Children.Add(childControl);
                break;
            case ContentControl contentControl:
            {
                contentControl.Content ??= new Panel();
                var panel = (Panel)contentControl.Content;
                panel.Children.Add(childControl);
                break;
            }
        }
    }

    protected internal abstract void Update(TControl control, TWidget widget);

    Control IRenderer.Create()
    {
        return Create() as Control ?? throw new InvalidOperationException();
    }
}

internal interface IRenderer
{
    Control Create();
    void Update(Control control, WidgetObject widget);
    void AddChild(Control control, Control childControl);
}