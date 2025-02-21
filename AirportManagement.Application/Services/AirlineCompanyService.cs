using AirportManagement.Core.Models;

namespace AirportManagement.Application.Services;

public class AirlineCompanyService
{
    public void AddPilot(AirlineCompany company, Pilot pilot)
    {
        company.Pilots.Add(pilot);
    }

    public void AddStewardess(AirlineCompany company, Stewardess stewardess)
    {
        company.Stewardesses.Add(stewardess);
    }
}