namespace AirportManagement.Application.Command;

public interface ICommand
{
    Task ExecuteAsync();
    Task UndoAsync();
}