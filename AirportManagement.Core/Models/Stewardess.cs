using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class Stewardess : Employee
{
    public double Salary { get; set;}
    public Stewardess(string firstName, string lastName, string email, string phone, DateTime hireDate, double salary) 
        : base(firstName, lastName, email, phone, hireDate,EmployeeType.Stewardess)
    {
        Salary = salary;
    }
}