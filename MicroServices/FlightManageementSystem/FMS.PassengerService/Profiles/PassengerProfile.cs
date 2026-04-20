using AutoMapper;
using FMS.PassengerService.Dtos;
using FMS.PassengerService.Entities;

namespace FMS.PassengerService.Profiles
{
    public class PassengerProfile:Profile
    {
        public PassengerProfile()
        {
            CreateMap<Passenger, PassengerResponseDto>();
            CreateMap<CreatePassengerDto, Passenger>();
        }
    }
}
