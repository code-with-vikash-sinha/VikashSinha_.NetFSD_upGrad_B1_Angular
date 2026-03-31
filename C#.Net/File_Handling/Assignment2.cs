using System;
using System.IO;

class StudentReport
{
    static void Main()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Roll Number: ");
        string roll = Console.ReadLine();

        int[] marks = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter marks for subject {i+1}: ");
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }

        int total = marks[0] + marks[1] + marks[2];
        double avg = total / 3.0;
        string grade = avg >= 75 ? "A" : avg >= 60 ? "B" : avg >= 40 ? "C" : "Fail";

        string content = $"Student Name: {name}\nRoll Number: {roll}\nMarks: {string.Join(", ", marks)}\nTotal: {total}\nAverage: {avg}\nGrade: {grade}";

        File.WriteAllText($"{roll}.txt", content);
        Console.WriteLine("Report saved successfully.");

        Console.Write("\nEnter Roll Number to read report: ");
        string rollToRead = Console.ReadLine();
        try
        {
            string report = File.ReadAllText($"{rollToRead}.txt");
            Console.WriteLine("\nReport:\n" + report);
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }
}
