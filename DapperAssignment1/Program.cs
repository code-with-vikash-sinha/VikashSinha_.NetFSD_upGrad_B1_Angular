using DapperAssignment1.Models;
namespace DapperAssignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BookRepository repo = new BookRepository();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("===== Book Repository Menu =====");
                Console.WriteLine("1. Get All Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Get Book By Title");
                Console.WriteLine("6. Get All Books By Author");
                Console.WriteLine("7. Get All Books By Language");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        repo.GetAllBook();
                        break;

                    case 2:
                        Book newBook = new Book();
                        Console.Write("Enter Title: ");
                        newBook.Title = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        newBook.Price = double.Parse(Console.ReadLine());
                        Console.Write("Enter Author: ");
                        newBook.Author = Console.ReadLine();
                        Console.Write("Enter Publisher: ");
                        newBook.Publisher = Console.ReadLine();
                        Console.Write("Enter Language: ");
                        newBook.Language = Console.ReadLine();
                        Console.Write("Enter Publish Date (yyyy-mm-dd): ");
                        newBook.PublishDate = DateTime.Parse(Console.ReadLine());
                        repo.AddBook(newBook);
                        break;

                    case 3:
                        Book editBook = new Book();
                        Console.Write("Enter BookId to Edit: ");
                        editBook.BookId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Price: ");
                        editBook.Price = double.Parse(Console.ReadLine());
                        Console.Write("Enter New Author: ");
                        editBook.Author = Console.ReadLine();
                        repo.EditBook(editBook);
                        break;

                    case 4:
                        Console.Write("Enter BookId to Delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        repo.DeleteBook(deleteId);
                        break;

                    case 5:
                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();
                        repo.GetBook(title);
                        break;

                    case 6:
                        Console.Write("Enter Author Name: ");
                        string author = Console.ReadLine();
                        repo.GetAllBooksByAuthor(author);
                        break;

                    case 7:
                        Console.Write("Enter Language: ");
                        string lang = Console.ReadLine();
                        repo.GetAllBooksByLang(lang);
                        break;

                    case 8:
                        exit = true;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}