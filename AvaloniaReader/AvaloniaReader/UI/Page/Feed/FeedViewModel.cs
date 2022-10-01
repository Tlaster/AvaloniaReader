using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using AvaloniaReader.UI.Common;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaReader.UI.Page.Feed;

internal partial class FeedViewModel : BaseViewModel<IFeedState>
{
    private readonly BehaviorSubject<int> _count = new(0);

    private readonly IObservable<Exception?> _error = Observable.Return<Exception?>(null);

    private readonly IObservable<bool> _loading = Observable.Return(false);

    protected internal override IObservable<IFeedState> State =>
        _count.CombineLatest<int, bool, Exception?, IFeedState>(_loading,
            _error,
            (count, loading, error) =>
            {
                if (loading)
                {
                    return new IFeedState.Loading();
                }

                if (error != null)
                {
                    return new IFeedState.Error(error);
                }

                return new IFeedState.Data(count.ToString());
            });

    [RelayCommand]
    private void Add()
    {
        _count.OnNext(_count.Value + 1);
    }
}

internal interface IFeedState
{
    record Loading : IFeedState;

    record Error(Exception Exception) : IFeedState;

    record Data(string Count) : IFeedState;
}