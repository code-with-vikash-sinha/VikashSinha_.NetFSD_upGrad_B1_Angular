using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FMS.PassengerService.Entities
{
    public class Passenger
    {
        public int passengerId { get; set; }
        public string ? name { get; set; }
        public int age { get; set; }
    }
}
