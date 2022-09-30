using System.Windows.Input;
using Avalonia.Compose.Widget;
using ReactiveUI;

namespace Avalonia.Compose.Renderer;

internal class ButtonRenderer : RendererObject<Button, Controls.Button>
{
    protected internal override void Update(Controls.Button control, Button widget)
    {
        control.Command = new RelayCommand(widget.OnClick);
    }
}

internal class RelayCommand : ICommand
{
    private readonly Action _action;

    public RelayCommand(Action action)
    {
        _action = action;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _action.Invoke();
    }
}