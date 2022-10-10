using AvaloniaReader.UI.Page.Feed;
using ReactiveUI;

namespace AvaloniaReader.UI.Hosting;

class RootViewModel: ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();

    public RootViewModel()
    {
        Router.Navigate.Execute(new FeedViewModel(this));
    }
}