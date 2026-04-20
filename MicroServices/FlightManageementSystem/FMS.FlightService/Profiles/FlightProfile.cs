
using AutoMapper;
using FMS.FlightService.Dtos;
using FMS.FlightService.Entities;

namespace FMS.FlightService.Profiles
{
    public class FlightProfile:Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, ReadFlightDto>();
            CreateMap<CreateFlightDto, Flight>();
            
        }
    }
}
