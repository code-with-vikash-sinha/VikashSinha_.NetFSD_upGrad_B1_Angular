using AutoMapper;
using FMS.PassengerService.Dtos;
using FMS.PassengerService.Entities;
using FMS.PassengerService.Repositories;

namespace FMS.PassengerService.Services
{
    public class PassengerServices : IPassengerServices
    {
        private readonly IPassengerRepository repository;
        private readonly IMapper mapper;
        public PassengerServices(IPassengerRepository repository , IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddPassengerAsync(CreatePassengerDto createPassengerDto)
        {
            var passenger = mapper.Map<Passenger>(createPassengerDto);
            await repository.AddPassengerAsync(passenger);
        }

        public async Task<List<PassengerResponseDto>> GetAllPassengerAsync()
        {
            var passenger = await repository.GetAllPassengerAsync();
            var passengerDto = mapper.Map<List<PassengerResponseDto>>(passenger);
            return passengerDto;
        }
    }
}
