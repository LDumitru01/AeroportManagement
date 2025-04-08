using AirportManagement.Application.Command;
using AirportManagement.Application.Facade;
using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Repository;
using AirportManagement.Application.Services;
using AirportManagement.Application.Services.Proxy;
using AirportManagement.Core.Memento;
using AirportManagement.Core.Models.FlyWeightPattern;
using AirportManagement.Core.Strategy;
using AirportManagement.Database.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICompositeFlightService, CompositeFlightService>();
builder.Services.AddScoped<IPaymentFactory, PaymentFactory>();
builder.Services.AddScoped<IBookingFacade, BookingFacade >();
builder.Services.AddSingleton<SeatFlyweightFactory>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ProxyTicketService>();
builder.Services.AddScoped<IPassengerValidationStrategy, DomesticFlightValidationStrategy>();

builder.Services.AddScoped<DomesticFlightValidationStrategy>();
builder.Services.AddScoped<InternationalFlightValidationStrategy>();
builder.Services.AddScoped<VipPassengerValidationStrategy>();

builder.Services.AddScoped<IPassengerValidationStrategySelector, PassengerValidationStrategySelector>();
builder.Services.AddScoped<ICommandInvoker, CommandInvoker>();
builder.Services.AddSingleton<FlightHistoryManager>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airport API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();