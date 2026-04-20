using FMS.PassengerService.Dtos;

namespace FMS.PassengerService.Services
{
    public interface IPassengerServices
    {
        Task AddPassengerAsync(CreatePassengerDto createPassengerDto);
        Task<List<PassengerResponseDto>> GetAllPassengerAsync();
    }
}
