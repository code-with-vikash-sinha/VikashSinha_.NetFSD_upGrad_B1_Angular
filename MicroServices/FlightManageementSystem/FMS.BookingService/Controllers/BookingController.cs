using FMS.BookingService.Dtos;
using FMS.BookingService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingServices service;

        public BookingController(IBookingServices service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooking()
        {
            var booking = await service.GetAllBookingAsync();
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody]CreateBookingDto createBookingDto)
        {
            await service.AddBookingAsync(createBookingDto);
            return Ok();
        }
    }
}
