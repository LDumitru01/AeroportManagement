using Microsoft.EntityFrameworkCore;
using AirportManagement.Core.Models;
using AirportManagement.Core.Models.Auth;

namespace AirportManagement.Database.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; } 
        public DbSet<User> Users { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(t => t.MealOption)
                .HasConversion<string>();
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Seat)
                .HasConversion<string>();
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasDefaultValueSql("NEWID()");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}