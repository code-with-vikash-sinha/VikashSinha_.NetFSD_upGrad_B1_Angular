using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class ProductCatalog
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product{Id=1, Name="Laptop", Price=50000, Category="Electronics"},
            new Product{Id=2, Name="Phone", Price=15000, Category="Electronics"},
            new Product{Id=3, Name="Shoes", Price=1200, Category="Fashion"},
            new Product{Id=4, Name="Watch", Price=800, Category="Fashion"},
            new Product{Id=5, Name="TV", Price=30000, Category="Electronics"},
            new Product{Id=6, Name="Book", Price=400, Category="Education"},
            new Product{Id=7, Name="Bag", Price=2000, Category="Fashion"},
            new Product{Id=8, Name="Tablet", Price=18000, Category="Electronics"},
            new Product{Id=9, Name="Headphones", Price=2500, Category="Electronics"},
            new Product{Id=10, Name="Pen", Price=50, Category="Education"}
        };

        Console.WriteLine("All Products:");
        products.ForEach(p => Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.Category}"));

        Console.WriteLine("\nProducts with price > 1000:");
        var expensive = products.Where(p => p.Price > 1000);
        foreach (var p in expensive) Console.WriteLine($"{p.Name} - {p.Price}");

        Console.WriteLine("\nSorted by Price Ascending:");
        foreach (var p in products.OrderBy(p => p.Price)) Console.WriteLine($"{p.Name} - {p.Price}");

        Console.WriteLine("\nSorted by Price Descending:");
        foreach (var p in products.OrderByDescending(p => p.Price)) Console.WriteLine($"{p.Name} - {p.Price}");

        Console.WriteLine("\nRemoving product with Id=3...");
        products.RemoveAll(p => p.Id == 3);

        Console.WriteLine("\nFilter by Category (Electronics):");
        var electronics = products.Where(p => p.Category == "Electronics");
        foreach (var p in electronics) Console.WriteLine($"{p.Name} - {p.Price}");
    }
}
