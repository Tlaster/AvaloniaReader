using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AvaloniaReader.Repository;
using AvaloniaReader.UI.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using FluentAvalonia.Converters;
using ReactiveUI;

namespace AvaloniaReader.UI.Page.Home;

[ObservableObject]
partial class HomeViewModel
{
    private readonly FeedRepository _repository = Ioc.Default.GetRequiredService<FeedRepository>();
    [ObservableProperty] private bool _isFeedLoading = false;
    [ObservableProperty] private bool _isArticleLoading = false;
    public ObservableCollection<UiFeedSource> FeedSources { get; } = new();
    [ObservableProperty] private UiFeedSource? _selectedFeedSource = null;
    [ObservableProperty] private ImmutableList<UiFeedItem> _feedItems = ImmutableList<UiFeedItem>.Empty;
    [ObservableProperty] private UiFeedItem? _selectedFeedItem = null;
    [ObservableProperty] private UiArticle? _article = null;
    
    partial void OnSelectedFeedSourceChanged(UiFeedSource? value)
    {
        RefreshFeedItemCommand.Execute(null);
    }

    partial void OnSelectedFeedItemChanged(UiFeedItem? value)
    {
        LoadArticleCommand.Execute(null);
    }
    
    public HomeViewModel()
    {
        RefreshSourcesCommand.Execute(null);
    }

    [RelayCommand]
    private async Task RefreshSources()
    {
        FeedSources.AddRange(await _repository.GetFeedSource());
    }
    
    [RelayCommand]
    private async Task RefreshFeedItem()
    {
        if (string.IsNullOrEmpty(SelectedFeedSource?.Url))
            return;
        IsFeedLoading = true;
        FeedItems = await _repository.GetFeedItems(SelectedFeedSource.Url);
        IsFeedLoading = false;
    }
    
    [RelayCommand]
    private async Task LoadArticle()
    {
        if (string.IsNullOrEmpty(SelectedFeedItem?.Link))
            return;
        IsArticleLoading = true;
        Article = await _repository.GetArticle(SelectedFeedItem.Link);
        IsArticleLoading = false;
    }
}