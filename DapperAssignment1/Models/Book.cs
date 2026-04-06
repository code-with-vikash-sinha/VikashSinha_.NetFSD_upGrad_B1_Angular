using System;
using System.Collections.Generic;
using System.Text;

namespace DapperAssignment1.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public double  Price { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string  Language { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
