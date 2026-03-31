using System;
using System.IO;

class EmployeeLog
{
    static string filePath = "employee_log.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Login Entry");
            Console.WriteLine("2. Update Logout Time");
            Console.WriteLine("3. Display All Logs");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: AddLoginEntry(); break;
                case 2: UpdateLogoutTime(); break;
                case 3: DisplayLogs(); break;
                case 4: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void AddLoginEntry()
    {
        try
        {
            Console.Write("Enter Employee Id: ");
            string id = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            string loginTime = DateTime.Now.ToString();

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{id} | {name} | {loginTime} | ");
            }
            Console.WriteLine("Login entry added.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void UpdateLogoutTime()
    {
        try
        {
            Console.Write("Enter Employee Id to update logout: ");
            string id = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(id + " "))
                {
                    string logoutTime = DateTime.Now.ToString();
                    string[] parts = lines[i].Split('|');
                    lines[i] = $"{parts[0]}|{parts[1]}|{parts[2]}| {logoutTime}";
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Logout updated.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    static void DisplayLogs()
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                Console.WriteLine("\nEmployee Logs:");
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }
}
