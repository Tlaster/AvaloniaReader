using System;

namespace AvaloniaReader.UI.Common;

abstract class BaseViewModel<TState>
{
    protected internal abstract IObservable<TState> State { get; }
}