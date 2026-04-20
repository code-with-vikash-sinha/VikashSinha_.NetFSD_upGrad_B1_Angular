using FMS.BookingService.Entities;

namespace FMS.BookingService.Repositories
{
    public interface IBookingReporistory
    {
        Task AddBookingAsync(Booking booking);
        Task<List<Booking>> GetAllBookingAsync();
    }
}
