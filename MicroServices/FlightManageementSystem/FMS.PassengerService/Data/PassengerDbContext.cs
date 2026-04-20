using FMS.PassengerService.Entities;
using Microsoft.EntityFrameworkCore;

namespace FMS.PassengerService.Data
{
    public class PassengerDbContext :DbContext
    {
        public PassengerDbContext(DbContextOptions<PassengerDbContext> options) : base(options) { }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
