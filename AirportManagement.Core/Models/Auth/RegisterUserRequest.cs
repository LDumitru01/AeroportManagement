﻿namespace AirportManagement.Core.Models.Auth;

public class RegisterUserRequest
{
    public RegisterUserRequest(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}