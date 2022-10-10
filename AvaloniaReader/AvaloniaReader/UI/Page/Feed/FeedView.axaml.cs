using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace AvaloniaReader.UI.Page.Feed;

partial class FeedView : ReactiveUserControl<FeedViewModel>
{
    public FeedView()
    {
        InitializeComponent();
    }
}