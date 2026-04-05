using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MMS.BAL.DTOs
{
    public class MovieDto
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string ? Title { get; set; }

        public string? Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be a positive number.")]
        public int Duration { get; set; } // in minutes

        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public double Rating { get; set; } // e.g., IMDB rating

        public string? Language { get; set; }
    }
}
