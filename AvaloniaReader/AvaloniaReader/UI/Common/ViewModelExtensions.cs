using ReactiveUI;

namespace AvaloniaReader.UI.Common;

static class ViewModelExtensions
{
    public static void Navigate<T>(this IRoutableViewModel viewModel, T value) where T : IRoutableViewModel
    {
        var router = viewModel.HostScreen;
        router.Router.Navigate.Execute(value);
    }
}