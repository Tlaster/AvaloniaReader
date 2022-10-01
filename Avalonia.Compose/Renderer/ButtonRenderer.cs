using Avalonia.Compose.Widget;

namespace Avalonia.Compose.Renderer;

internal class ButtonRenderer : RendererObject<Button, Controls.Button>
{
    protected internal override void Update(Controls.Button control, Button widget)
    {
        control.Command = widget.OnClick;
    }
}