using FMS.FlightService.Dtos;

namespace FMS.FlightService.Services
{
    public interface IFlightServices
    {
        Task CreateFlightAsync(CreateFlightDto createFlightDto);
        Task UpdateFlightAsync(int id, CreateFlightDto createFlightDto);
        Task DeleteFlightAsync(int id);
        Task<ReadFlightDto> GetFlightById(int id);
        Task<List<ReadFlightDto>> GetAllFlights();
    }
}
