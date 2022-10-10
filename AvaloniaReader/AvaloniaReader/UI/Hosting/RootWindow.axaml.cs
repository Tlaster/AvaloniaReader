using Avalonia;
using AvaloniaReader.UI.Controls;

namespace AvaloniaReader.UI.Hosting;

partial class RootWindow : ModernWindow
{
    public RootWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
}
