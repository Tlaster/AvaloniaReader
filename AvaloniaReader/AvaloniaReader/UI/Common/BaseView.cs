using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using static Avalonia.Compose.Widget.Func;

namespace AvaloniaReader.UI.Common;

abstract class BaseView<TState, TViewModel> : UserControl where TViewModel : BaseViewModel<TState>, new()
{
    protected TViewModel ViewModel { get; } = new();
    private IDisposable? _disposable;

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        _disposable = ViewModel.State.Subscribe(state => Content = ProduceView(state));
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);
        _disposable?.Dispose();
    }

    protected abstract Control ProduceView(TState state);
}