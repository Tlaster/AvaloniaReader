using System;

namespace AvaloniaReader.UI.Common;

internal abstract class BaseViewModel<TState>
{
    protected internal abstract IObservable<TState> State { get; }
}