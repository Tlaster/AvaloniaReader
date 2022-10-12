using AvaloniaReader.UI.Page.Home;
using ReactiveUI;
using HomeView = AvaloniaReader.UI.Page.Home.HomeView;

namespace AvaloniaReader.UI.Common;

class AppViewLocator : ReactiveUI.IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        return viewModel switch
        {
            HomeViewModel => new HomeView(),
            _ => null
        };
    }
}