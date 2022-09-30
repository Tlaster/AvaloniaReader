using Avalonia.Web.Blazor;

namespace AvaloniaReader.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<AvaloniaReader.App>()
            .SetupWithSingleViewLifetime();
    }
}