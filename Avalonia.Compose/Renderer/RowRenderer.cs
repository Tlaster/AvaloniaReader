using Avalonia.Compose.Widget;
using Avalonia.Controls;

namespace Avalonia.Compose.Renderer;

internal class RowRenderer : RendererObject<Row, StackPanel>
{
    protected internal override StackPanel Create()
    {
        return new StackPanel
        {
            Orientation = Orientation.Horizontal,
        };
    }

    protected internal override void Update(StackPanel control, Row widget)
    {
    }
}