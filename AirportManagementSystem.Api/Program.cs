using System.Text;
using AirportManagement.Application.ChainOfResposibilityApp;
using AirportManagement.Application.Command;
using AirportManagement.Application.Facade;
using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Repository;
using AirportManagement.Application.Services;
using AirportManagement.Application.Services.Proxy;
using AirportManagement.Core.Mediator;
using AirportManagement.Core.Memento;
using AirportManagement.Core.Models.FlyWeightPattern;
using AirportManagement.Core.Strategy;
using AirportManagement.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<ITicketService>(provider =>
{
    var realService = provider.GetRequiredService<TicketService>();
    var httpContext = provider.GetRequiredService<IHttpContextAccessor>();
    var ticketRepository = provider.GetRequiredService<TicketRepository>();
    return new ProxyTicketService(realService, httpContext, ticketRepository);
});

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

builder.Services.AddScoped<PassengerValidationHandler>();
builder.Services.AddScoped<LuggageValidationHandler>();
builder.Services.AddScoped<SeatAvailabilityHandler>();
builder.Services.AddSingleton<IMediator, EmergencyMediator>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<TicketRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Airport API", Version = "v1" });

    // 👇 JWT bearer definition
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Introduceți tokenul JWT așa: `Bearer <token>`"
    });

    // 👇 obligatoriu pentru toate endpoint-urile
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



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


app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();