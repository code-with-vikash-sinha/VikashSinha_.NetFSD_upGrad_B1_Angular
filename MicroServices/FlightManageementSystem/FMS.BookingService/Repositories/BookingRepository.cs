using FMS.BookingService.Data;
using FMS.BookingService.Entities;
using Microsoft.EntityFrameworkCore;
namespace FMS.BookingService.Repositories
{
    public class BookingRepository : IBookingReporistory
    {
        private readonly BookingDbContext context;

        public BookingRepository(BookingDbContext context)
        {
            this.context = context;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllBookingAsync()
        {
           return  await context.Bookings.ToListAsync();
        }
    }
}
