using System;
using System.Collections.Generic;

class EventRegistration
{
    static void Main()
    {
        HashSet<string> emails = new HashSet<string>
        {
            "a@gmail.com","b@gmail.com","c@gmail.com","d@gmail.com","a@gmail.com",
            "e@gmail.com","f@gmail.com","g@gmail.com","h@gmail.com","c@gmail.com"
        };

        Console.WriteLine("Unique Emails:");
        foreach (var email in emails) Console.WriteLine(email);

        Console.WriteLine("\nCheck if 'b@gmail.com' is registered:");
        Console.WriteLine(emails.Contains("b@gmail.com") ? "Registered" : "Not Registered");

        Console.WriteLine("\nRemoving 'f@gmail.com'...");
        emails.Remove("f@gmail.com");

        HashSet<string> event2 = new HashSet<string> { "a@gmail.com", "x@gmail.com", "y@gmail.com" };
        Console.WriteLine("\nCommon participants:");
        emails.IntersectWith(event2);
        foreach (var email in emails) Console.WriteLine(email);
    }
}
