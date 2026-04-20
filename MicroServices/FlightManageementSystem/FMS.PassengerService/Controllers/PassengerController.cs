using FMS.PassengerService.Dtos;
using FMS.PassengerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.PassengerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerServices service;

        public PassengerController(IPassengerServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassengerAsync()
        {
          var passenger= await service.GetAllPassengerAsync();
            return Ok(passenger);
        }
        [HttpPost]
        public async Task<IActionResult> AddPassengerAsync( [FromBody]CreatePassengerDto createPassengerDto)
        {
           await service.AddPassengerAsync(createPassengerDto);
            return Ok();
        }
    }
}
