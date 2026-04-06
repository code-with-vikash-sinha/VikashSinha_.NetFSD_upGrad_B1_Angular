using Dapper;
using DapperAssignment1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace DapperAssignment1
{
    public class BookRepository
    {
        string connectionString = "Data Source=VIKASH\\SQLEXPRESS;Initial Catalog=BookDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IDbConnection db;
        public BookRepository()
        {
            db = new SqlConnection(connectionString);
        }

        public void GetAllBook()
        {
            try
            {
                db.Open();
                var books = db.Query<Book>("Select * from Book").ToList();
                foreach(var book in books)
                {
                    Console.WriteLine($"BookId : {book.BookId} Title : {book.Title} Price : {book.Price} Author : {book.Author} Publisher : {book.Publisher} Language : {book.Language} PublishDate : {book.PublishDate}");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Close();
            }
        }
        public void AddBook(Book book)
        {
            try
            {
                db.Open();
                var sql = "Insert into Book (Title,Price,Author,Publisher,Language,PublishDate) values (@title,@price,@author,@publisher,@language,@publishDate)";
                db.Execute(sql, book);
                Console.WriteLine("Book added Sucessfully");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

        }
        public void EditBook(Book book)
        {
            try
            {
                db.Open();
                var sql = "Update Book Set Price = @price , Author = @author where BookId = @BookId";
                db.Execute(sql, book);
                Console.WriteLine("Book is Updated");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Close();
            }
        }

        public void DeleteBook(int id) {
         try
            {
                db.Open();
                var sql = "Delete from Book where BookId = @id";
                db.Execute(sql, new { BookId = id });
                Console.WriteLine("Product Delete Successfully");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Close();
            }
        }
        public void GetBook(string name)
        {
            try
            {
                db.Open();
                var sql = "Select * from Book where Title = @Title";
                var book = db.QuerySingleOrDefault<Book>(sql, new { Title = @name });
                if(book == null)
                {
                    Console.WriteLine($"No Book is Find With Name : {book.Title}");
                }
                else
                {
                    Console.WriteLine($"BookId : {book.BookId} Title : {book.Title} Price : {book.Price} Author : {book.Author} Publisher : {book.Publisher} Language : {book.Language} PublishDate : {book.PublishDate}");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

        }

        public void GetAllBooksByAuthor(string author)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM Book WHERE Author = @author";
                var books = db.Query<Book>(sql, new { author }).ToList();

                if (books == null || books.Count == 0)
                {
                    Console.WriteLine($"No Book is found with the given author.");
                }
                else
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine(
                            $"BookId: {book.BookId} | Title: {book.Title} | Price: {book.Price} | Author: {book.Author} | Publisher: {book.Publisher} | Language: {book.Language} | PublishDate: {book.PublishDate}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            finally
            {
                db.Close();
            }
        }


        public void GetAllBooksByLang(string lang)
        {
            try
            {
                db.Open();
                var sql = "SELECT * FROM Book WHERE Language = @lang";
                var books = db.Query<Book>(sql, new { lang });

                if (books == null || !books.Any())
                {
                    Console.WriteLine("No Book is found with the given language.");
                }
                else
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine(
                            $"BookId: {book.BookId} | Title: {book.Title} | Price: {book.Price} | Author: {book.Author} | Publisher: {book.Publisher} | Language: {book.Language} | PublishDate: {book.PublishDate}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            finally
            {
                db.Close();
            }
        }



    }
}
