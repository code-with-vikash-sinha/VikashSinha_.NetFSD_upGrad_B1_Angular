using FMS.PassengerService.Data;
using FMS.PassengerService.Entities;
using Microsoft.EntityFrameworkCore;

namespace FMS.PassengerService.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly PassengerDbContext context;

        public PassengerRepository(PassengerDbContext context)
        {
            this.context = context;
        }

        public async Task AddPassengerAsync(Passenger passenger)
        {
            context.Passengers.Add(passenger);
            await context.SaveChangesAsync();
        }

        public async Task<List<Passenger>> GetAllPassengerAsync()
        {
            return await context.Passengers.ToListAsync();
        }
    }
}
