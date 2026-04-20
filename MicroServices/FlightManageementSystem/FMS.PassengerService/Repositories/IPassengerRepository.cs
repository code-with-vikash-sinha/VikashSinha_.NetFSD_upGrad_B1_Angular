using FMS.PassengerService.Entities;

namespace FMS.PassengerService.Repositories
{
    public interface IPassengerRepository
    {
        Task AddPassengerAsync(Passenger passenger);
        Task<List<Passenger>> GetAllPassengerAsync();
    }
}
