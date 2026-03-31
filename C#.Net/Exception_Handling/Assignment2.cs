using System;

// Custom Exception
public class TicketNotAvailableException : Exception
{
    public TicketNotAvailableException(string message) : base(message) { }
}

// Ticket Booking Class
public class TicketBooking
{
    private static int availableTickets = 15;

    public void BookTickets(int numberOfTickets)
    {
        if (numberOfTickets > availableTickets)
        {
            throw new TicketNotAvailableException($"Booking failed! Only {availableTickets} tickets available.");
        }
        else
        {
            availableTickets -= numberOfTickets;
            Console.WriteLine($"Successfully booked {numberOfTickets} tickets.");
            Console.WriteLine($"Remaining tickets: {availableTickets}");
        }
    }
}

// Example Usage
class MovieApp
{
    static void Main(string[] args)
    {
        TicketBooking booking = new TicketBooking();

        Console.Write("Do you want to book tickets? (yes/no): ");
        string choice = Console.ReadLine();

        if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter number of tickets to book: ");
            int tickets = Convert.ToInt32(Console.ReadLine());

            try
            {
                booking.BookTickets(tickets);
            }
            catch (TicketNotAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Thank you! Visit again.");
        }
    }
}
