using FMS.FlightService.Data;
using FMS.FlightService.Entities;
using Microsoft.EntityFrameworkCore;

namespace FMS.FlightService.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext context;

        public FlightRepository(FlightDbContext context)
        {
            this.context = context;
        }

        public async Task AddFlightAsync(Flight flight)
        {
            context.Flights.Add(flight);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await context.Flights.FindAsync(id);
            if(flight != null)
            {
                context.Flights.Remove(flight);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Flight>> GetAllFlightAsync()
        {
            return await context.Flights.ToListAsync();
        }

        public async Task<Flight> GetFlightByIDAsync(int id)
        {
            return await context.Flights.FindAsync(id);
        }

        public async Task UpdateFlightAsync(int id, Flight flight)
        {
            var existingFlight = await context.Flights.FindAsync(id);
            if(existingFlight != null)
            {
                existingFlight.FlightNumber = flight.FlightNumber;
                existingFlight.Source = flight.Source;
                existingFlight.destination = flight.destination;
                await context.SaveChangesAsync();
            }
        }
    }
}
