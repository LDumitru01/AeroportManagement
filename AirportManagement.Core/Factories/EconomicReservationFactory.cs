﻿using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models.ReservationType;

namespace AirportManagement.Core.Factories;

public class EconomicReservationFactory : IReservationFactory
{
    public IReservation CreateReservation()
    {
        return new EconomicReservation();
    }
}