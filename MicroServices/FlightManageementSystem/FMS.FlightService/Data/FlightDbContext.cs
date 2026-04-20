using FMS.FlightService.Entities;
using Microsoft.EntityFrameworkCore;

namespace FMS.FlightService.Data
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options) { }
       public DbSet<Flight> Flights { get; set; }
    }
}
