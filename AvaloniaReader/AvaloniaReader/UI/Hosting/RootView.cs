using Avalonia.Controls;
using AvaloniaReader.UI.Page.Feed;

namespace AvaloniaReader.UI.Hosting;

class RootView : UserControl
{
    public RootView()
    {
        Content = new FeedView();
    }
}