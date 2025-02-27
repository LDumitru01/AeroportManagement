namespace AirportManagement.Core.Interfaces;

public interface IPrototype<T>
{
    T Clone(string newFirstName, string newLastName, string newPassportNumber);
}