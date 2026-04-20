using FMS.FlightService.Entities;

namespace FMS.FlightService.Repositories
{
    public interface IFlightRepository
    {
        Task AddFlightAsync(Flight flight);
        Task UpdateFlightAsync(int id, Flight flight);
        Task DeleteFlightAsync(int id);
        Task<Flight> GetFlightByIDAsync(int id);
        Task<List<Flight>> GetAllFlightAsync();
    }
}
