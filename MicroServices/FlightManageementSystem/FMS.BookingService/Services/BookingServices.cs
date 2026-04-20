using AutoMapper;
using FMS.BookingService.Dtos;
using FMS.BookingService.Entities;
using FMS.BookingService.Repositories;

namespace FMS.BookingService.Services
{
    public class BookingServices : IBookingServices
    {
        private readonly IBookingReporistory reporistory;
        private readonly IMapper mapper;

        public BookingServices(IBookingReporistory reporistory,IMapper mapper)
        {
            this.reporistory = reporistory;
            this.mapper = mapper;
        }

        public async Task AddBookingAsync(CreateBookingDto createBookingDto)
        {
            var booking = mapper.Map<Booking>(createBookingDto);
            await reporistory.AddBookingAsync(booking);
        }

        public async Task<List<BookingResponseDto>> GetAllBookingAsync()
        {
            var booking = await reporistory.GetAllBookingAsync();
            var bookingDto = mapper.Map<List<BookingResponseDto>>(booking);
            return bookingDto;
        }
    }
}
