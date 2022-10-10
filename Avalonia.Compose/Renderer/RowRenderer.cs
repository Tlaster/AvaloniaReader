using Avalonia.Compose.Widget;
using Avalonia.Compose.Widget.Layout;
using Avalonia.Controls;
using Avalonia.Layout;

namespace Avalonia.Compose.Renderer;

internal class RowRenderer : RendererObject<Row, StackPanel>
{
    protected internal override StackPanel Create()
    {
        return new StackPanel
        {
            Orientation = Orientation.Horizontal
        };
    }

    protected internal override void Update(StackPanel control, Row widget)
    {
    }
}