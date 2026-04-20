namespace FMS.FlightService.Dtos
{
    public class ReadFlightDto
    {
        public int Id { get; set; }
        public string? FlightNumber { get; set; }
        public string? Source { get; set; }
        public string? destination { get; set; }
    }
}
