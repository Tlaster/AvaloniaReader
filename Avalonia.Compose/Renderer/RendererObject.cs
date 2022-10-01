using Avalonia.Compose.Widget;
using Avalonia.Controls;
using Panel = Avalonia.Controls.Panel;

namespace Avalonia.Compose.Renderer;

internal abstract class RendererObject<TWidget, TControl> : IRenderer
    where TWidget : WidgetObject where TControl : class, new()
{
    public void Update(Control control, WidgetObject widget)
    {
        Update(control as TControl ?? throw new InvalidOperationException(), (TWidget)widget);
    }

    public void AddChild(Control control, Control childControl)
    {
        AddChild(control as TControl ?? throw new InvalidOperationException(), childControl);
    }

    public void RemoveChild(Control control, Control childControl)
    {
        RemoveChild(control as TControl ?? throw new InvalidOperationException(), childControl);
    }

    public void ReplaceChild(Control control, int index, Control newChildControl)
    {
        ReplaceChild(control as TControl ?? throw new InvalidOperationException(), index, newChildControl);
    }

    Control IRenderer.Create()
    {
        return Create() as Control ?? throw new InvalidOperationException();
    }

    protected internal virtual TControl Create()
    {
        return new TControl();
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

    protected internal virtual void RemoveChild(TControl control, Control childControl)
    {
        switch (control)
        {
            case Panel panel:
                panel.Children.Remove(childControl);
                break;
            case ContentControl contentControl:
            {
                contentControl.Content ??= new Panel();
                var panel = (Panel)contentControl.Content;
                panel.Children.Remove(childControl);
                break;
            }
        }
    }

    protected internal virtual void ReplaceChild(TControl control, int index, Control newChildControl)
    {
        switch (control)
        {
            case Panel panel:
                panel.Children[index] = newChildControl;
                break;
            case ContentControl contentControl:
            {
                contentControl.Content ??= new Panel();
                var panel = (Panel)contentControl.Content;
                panel.Children[index] = newChildControl;
                break;
            }
        }
    }

    protected internal abstract void Update(TControl control, TWidget widget);
}

internal interface IRenderer
{
    Control Create();
    void Update(Control control, WidgetObject widget);
    void AddChild(Control control, Control childControl);
    void RemoveChild(Control control, Control childControl);
    void ReplaceChild(Control control, int index, Control newChildControl);
}