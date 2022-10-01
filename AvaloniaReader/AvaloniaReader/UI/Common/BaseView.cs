using System;
using Avalonia.Compose;

namespace AvaloniaReader.UI.Common;

internal abstract class BaseView<TState, TViewModel> : ComposeView<TState>
    where TViewModel : BaseViewModel<TState>, new()
{
    protected TViewModel ViewModel { get; } = new();
    protected override IObservable<TState> State => ViewModel.State;
}