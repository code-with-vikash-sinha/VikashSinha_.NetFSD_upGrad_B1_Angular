using System;
using System.IO;

class MiniNotepad
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Create New File");
            Console.WriteLine("2. Write to File");
            Console.WriteLine("3. Read File");
            Console.WriteLine("4. Append Text");
            Console.WriteLine("5. Delete File");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateFile(); break;
                case 2: WriteFile(); break;
                case 3: ReadFile(); break;
                case 4: AppendFile(); break;
                case 5: DeleteFile(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void CreateFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            Console.WriteLine("File created successfully.");
        }
    }

    static void WriteFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            Console.WriteLine("Enter text (type 'end' to stop):");
            string line;
            while ((line = Console.ReadLine()) != "end")
                sw.WriteLine(line);
        }
        Console.WriteLine("File written successfully.");
    }

    static void ReadFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                Console.WriteLine("\nFile Content:\n" + sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException) { Console.WriteLine("File not found."); }
        catch (UnauthorizedAccessException) { Console.WriteLine("Access denied."); }
    }

    static void AppendFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(fileName, true))
        {
            Console.WriteLine("Enter text to append (type 'end' to stop):");
            string line;
            while ((line = Console.ReadLine()) != "end")
                sw.WriteLine(line);
        }
        Console.WriteLine("Text appended successfully.");
    }

    static void DeleteFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        try
        {
            File.Delete(fileName);
            Console.WriteLine("File deleted successfully.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }
}
