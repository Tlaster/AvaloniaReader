using Avalonia.Compose.Widget;
using Avalonia.Compose.Widget.Layout;
using Panel = Avalonia.Controls.Panel;

namespace Avalonia.Compose.Renderer;

internal class BoxRenderer : RendererObject<Box, Panel>
{
    protected internal override void Update(Panel control, Box widget)
    {
        control.VerticalAlignment = widget.ContentAlignment switch
        {
        };
    }
}