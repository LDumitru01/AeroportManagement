using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Repository;
using AirportManagement.Application.Services;
using Microsoft.EntityFrameworkCore;
using AirportManagement.Database.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Înregistrăm serviciile
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFlightRepository, FlightRepository>(); // Înregistrăm repository-ul
builder.Services.AddScoped<IFlightService, FlightService>(); // Înregistrăm serviciul
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airport API V1");
        c.RoutePrefix = string.Empty; // ✅ Accesează Swagger direct pe rădăcină
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
