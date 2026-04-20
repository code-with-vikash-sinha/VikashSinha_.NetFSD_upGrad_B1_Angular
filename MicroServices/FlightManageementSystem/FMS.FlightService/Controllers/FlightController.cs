using FMS.FlightService.Dtos;
using FMS.FlightService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FMS.FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightServices flightServices;

        public FlightController(IFlightServices flightServices)
        {
            this.flightServices = flightServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] CreateFlightDto createFlightDto)
        {
            await flightServices.CreateFlightAsync(createFlightDto);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id , [FromBody] CreateFlightDto createFlightDto)
        {
            await flightServices.UpdateFlightAsync(id, createFlightDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var flight = await flightServices.GetFlightById(id);
            return Ok(flight);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await flightServices.GetAllFlights();
            return Ok(flights);
        }
    }
}
