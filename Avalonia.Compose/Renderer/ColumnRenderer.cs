using Avalonia.Compose.Widget;
using Avalonia.Compose.Widget.Layout;
using Avalonia.Controls;
using Avalonia.Layout;

namespace Avalonia.Compose.Renderer;

internal class ColumnRenderer : RendererObject<Column, StackPanel>
{
    protected internal override StackPanel Create()
    {
        return new StackPanel
        {
            Orientation = Orientation.Vertical
        };
    }

    protected internal override void Update(StackPanel control, Column widget)
    {
    }
}