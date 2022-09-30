using System;
using System.Collections.Generic;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.ReactiveUI;
using AvaloniaReader.UI.Common;

namespace AvaloniaReader.UI.Page.Feed;

class FeedView : BaseView<IFeedState, FeedViewModel>
{
    protected override Control ProduceView(IFeedState state)
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

    private Control FeedLoadingView()
    {
        return new TextBlock
        {
            Text = "Loading..."
        };
    }

    private Control FeedErrorView(IFeedState.Error error)
    {
        return new TextBlock
        {
            Text = error.Exception.Message
        };
    }

    private Control FeedDataView(
        IFeedState.Data data,
        ICommand addCommand
    )
    {
        return new StackPanel
        {
            Orientation = Orientation.Vertical,
            Children =
            {
                new TextBlock
                {
                    Text = data.Count,
                },
                new Button
                {
                    Content = new TextBlock
                    {
                        Text = "Add"
                    },
                    Command = addCommand
                }
            }
        };
    }
}