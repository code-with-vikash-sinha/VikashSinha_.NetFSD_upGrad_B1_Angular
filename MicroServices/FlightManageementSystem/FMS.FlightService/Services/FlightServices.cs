using AutoMapper;
using FMS.FlightService.Dtos;
using FMS.FlightService.Entities;
using FMS.FlightService.Repositories;
using System.Runtime.CompilerServices;

namespace FMS.FlightService.Services
{
    public class FlightServices : IFlightServices
    {
        private readonly IFlightRepository repository;
        private readonly IMapper mapper;
        public FlightServices(IFlightRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateFlightAsync(CreateFlightDto createFlightDto)
        {
            var flight = mapper.Map<Flight>(createFlightDto);

            await repository.AddFlightAsync(flight);
           
        }

        public async Task DeleteFlightAsync(int id)
        {
            await repository.DeleteFlightAsync(id);
        }

        public async Task<List<ReadFlightDto>> GetAllFlights()
        {
            var flights = await repository.GetAllFlightAsync();
            var flightdto = mapper.Map<List<ReadFlightDto>>(flights);
            return flightdto;
        }

        public async Task<ReadFlightDto> GetFlightById(int id)
        {
            var flight = await repository.GetFlightByIDAsync(id);
            return mapper.Map<ReadFlightDto>(flight);
        }

        public async Task UpdateFlightAsync(int id, CreateFlightDto createFlightDto)
        {
            var flight = mapper.Map<Flight>(createFlightDto);
            flight.Id = id;
            await repository.UpdateFlightAsync(id, flight);
        }
    }
}
