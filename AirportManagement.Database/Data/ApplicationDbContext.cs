using Microsoft.EntityFrameworkCore;
using AirportManagement.Core.Models;

namespace AirportManagement.Database.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger?> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(t => t.MealOption)
                .HasConversion<string>();
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Seat)
                .HasConversion<string>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}