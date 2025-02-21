namespace AirportManagement.Core.Models;
using AirportManagement.Core.Enums;

public class Pilot : Employee
{
    public double Salary { get; set; }
    public int Experience { get; set; }

    public Pilot(string firstName, string lastName, string email, string phone, DateTime hireDate, double salary, int experience) 
        : base(firstName, lastName, email, phone, hireDate, EmployeeType.Pilot)
    {
        Salary = salary;
        Experience = experience;
    }
}