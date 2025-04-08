namespace AirportManagement.Application.Command;

public interface ICommandInvoker
{
   Task ExecuteCommandAsync(ICommand command);
   Task UndoLastCommandAsync();
}