using FMS.BookingService.Dtos;

namespace FMS.BookingService.Services
{
    public interface IBookingServices
    {
        Task AddBookingAsync(CreateBookingDto createBookingDto);
        Task<List<BookingResponseDto>> GetAllBookingAsync();
    }
}
