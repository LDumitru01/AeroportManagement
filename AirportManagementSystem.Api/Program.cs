using AirportManagement.Application.Intefaces.IRepository;
using AirportManagement.Application.Intefaces.IServices;
using AirportManagement.Application.Repository;
using AirportManagement.Application.Services;
using AirportManagement.Database.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Adăugăm conexiunea la baza de date
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Înregistrăm repository și service
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  Configurare middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();