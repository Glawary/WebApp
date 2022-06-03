using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;


namespace WebApplication1.Data
{
    public class TravelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;Database=travel;Username=postgres;Password=Mydatabase")
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().Property(p => p.CountryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Trip>().Property(p => p.TripId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(p => p.CustomerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Hotel>().Property(p => p.HotelId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Air_Flight>().Property(p => p.Air_FlightId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Trip>().HasMany(trip => trip.Customers).WithOne(customer => customer.Trip);
            modelBuilder.Entity<Air_Flight>().HasOne(air_flight => air_flight.Trip).WithOne(trip => trip.Air_Flight).HasForeignKey<Trip>(trip => trip.Air_FlightId);
            modelBuilder.Entity<Country>().HasOne(country => country.Trip).WithOne(trip => trip.Country).HasForeignKey<Trip>(trip => trip.CountryId);
            modelBuilder.Entity<Hotel>().HasOne(hotel => hotel.Trip).WithOne(trip => trip.Hotel).HasForeignKey<Trip>(trip => trip.HotelId);
        }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Customer> Customers{ get; set;}
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Air_Flight> Air_Flights { get; set; }

    }
}
