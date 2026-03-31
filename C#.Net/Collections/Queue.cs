using System;
using System.Collections.Generic;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Disease { get; set; }
}

class HospitalQueue
{
    static void Main()
    {
        Queue<Patient> patients = new Queue<Patient>();
        patients.Enqueue(new Patient{Id=1, Name="John", Disease="Flu"});
        patients.Enqueue(new Patient{Id=2, Name="Mary", Disease="Cold"});
        patients.Enqueue(new Patient{Id=3, Name="Sam", Disease="Fever"});
        patients.Enqueue(new Patient{Id=4, Name="Anna", Disease="Cough"});
        patients.Enqueue(new Patient{Id=5, Name="Tom", Disease="Injury"});

        Console.WriteLine("Serving 2 patients:");
        Console.WriteLine("Served: " + patients.Dequeue().Name);
        Console.WriteLine("Served: " + patients.Dequeue().Name);

        Console.WriteLine("\nNext patient:");
        Console.WriteLine(patients.Peek().Name);

        Console.WriteLine("\nRemaining patients:");
        foreach (var p in patients) Console.WriteLine($"{p.Name} - {p.Disease}");
    }
}
