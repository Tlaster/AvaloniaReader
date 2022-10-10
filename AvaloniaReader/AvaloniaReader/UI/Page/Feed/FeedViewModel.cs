using AvaloniaReader.UI.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;

namespace AvaloniaReader.UI.Page.Feed;

partial class FeedViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment => "Feed";
    public IScreen HostScreen { get; }
    public FeedViewModel(IScreen screen) => HostScreen = screen;
}