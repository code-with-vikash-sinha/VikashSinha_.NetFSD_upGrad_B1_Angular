using FMS.BookingService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FMS.BookingService.Data
{
    public class BookingDbContext : DbContext 
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }
       
        public DbSet<Booking> Bookings { get; set; }


        }
    }
