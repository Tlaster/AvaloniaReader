using System;
using System.Windows.Input;
using Avalonia.Compose.Widget;
using AvaloniaReader.UI.Common;
using static Avalonia.Compose.Widget.FuncUi;

namespace AvaloniaReader.UI.Page.Feed;

internal class FeedView : BaseView<IFeedState, FeedViewModel>
{
    protected override WidgetObject Render(IFeedState state)
    {
        return state switch
        {
            IFeedState.Data data => FeedDataView(
                data,
                ViewModel.AddCommand
            ),
            IFeedState.Error error => FeedErrorView(error),
            IFeedState.Loading loading => FeedLoadingView(),
            _ => throw new ArgumentOutOfRangeException(nameof(state))
        };
    }

    private WidgetObject FeedLoadingView()
    {
        return Text("Loading...");
    }

    private WidgetObject FeedErrorView(IFeedState.Error error)
    {
        return Text(error.Exception.Message);
    }

    private WidgetObject FeedDataView(
        IFeedState.Data data,
        ICommand addCommand
    )
    {
        return Column(
            Text(data.Count),
            Button(
                addCommand,
                Text("Add")
            )
        );
    }
}