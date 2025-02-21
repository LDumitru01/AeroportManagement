using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime HireDate { get; set; } //data angajarii
    public EmployeeType Role { get; set; }
    
    public Employee(string firstName, string lastName, string email, string phone, DateTime hireDate, EmployeeType role)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        HireDate = hireDate;
        Role = role;
    }
}