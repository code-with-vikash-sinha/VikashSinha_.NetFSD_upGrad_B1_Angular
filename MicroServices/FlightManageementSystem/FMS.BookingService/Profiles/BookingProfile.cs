using AutoMapper;
using FMS.BookingService.Dtos;
using FMS.BookingService.Entities;

namespace FMS.BookingService.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingResponseDto>();
            CreateMap<CreateBookingDto, Booking>();
        }
    }
}
