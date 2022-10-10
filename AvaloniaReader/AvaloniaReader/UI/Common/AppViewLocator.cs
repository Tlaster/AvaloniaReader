using System;
using AvaloniaReader.UI.Page.Feed;
using ReactiveUI;

namespace AvaloniaReader.UI.Common;

class AppViewLocator : ReactiveUI.IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        return viewModel switch
        {
            FeedViewModel => new FeedView(),
            _ => null
        };
    }
}