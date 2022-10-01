using Avalonia.Compose.Widget;
using Avalonia.Controls;

namespace Avalonia.Compose.Renderer;

internal class TextRenderer : RendererObject<Text, TextBlock>
{
    protected internal override void Update(TextBlock control, Text widget)
    {
        control.Text = widget.Content;
    }
}