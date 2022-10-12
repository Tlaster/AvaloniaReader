using AvaloniaReader.UI.Page.Home;
using ReactiveUI;

namespace AvaloniaReader.UI.Hosting;

class RootViewModel: ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();

    public RootViewModel()
    {
    }
}