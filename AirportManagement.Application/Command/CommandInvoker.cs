namespace AirportManagement.Application.Command;

public class CommandInvoker: ICommandInvoker
{
    private readonly Stack<ICommand> _history = new();

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await command.ExecuteAsync();
        _history.Push(command);
    }

    public async Task UndoLastCommandAsync()
    {
        if (_history.Count > 0)
        {
            var lastCommand = _history.Pop();
            await lastCommand.UndoAsync();
        }
    }
}