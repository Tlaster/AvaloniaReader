using Avalonia.Compose.Internal;
using Avalonia.Compose.Widget;
using Avalonia.Controls;
using Avalonia.LogicalTree;

namespace Avalonia.Compose;

public class ComposeView : UserControl
{
    private readonly WidgetRenderer _renderer = new();
    private WidgetObject? _widget;

    protected void Render(WidgetObject widget)
    {
        if (Content is Control control)
        {
            Content = _renderer.RenderIfNeeded(_widget, widget, control);
        }
        else
        {
            Content = _renderer.RenderIfNeeded(_widget, widget, null);
        }

        _widget = widget;
    }
}

public abstract class ComposeView<T> : ComposeView
{
    private IDisposable? _disposable;
    protected abstract IObservable<T> State { get; }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        _disposable = State.Subscribe(state => Render(Render(state)));
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);
        _disposable?.Dispose();
    }

    protected abstract WidgetObject Render(T state);
}