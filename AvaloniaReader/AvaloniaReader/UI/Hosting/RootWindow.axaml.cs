using Avalonia;
using FluentAvalonia.UI.Controls;

namespace AvaloniaReader.UI.Hosting;

public partial class RootWindow : CoreWindow
{
    public RootWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
}