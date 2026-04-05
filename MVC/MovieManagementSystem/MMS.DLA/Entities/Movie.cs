using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MMS.DLA.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        [StringLength(200)]
        public string? Title { get; set; }
        [StringLength(100)]
        public string? Genre { get; set; }

        public DateTime ? ReleaseDate { get; set; }
       
        
        [Range(1,int.MaxValue)]
        public int Duration { get; set; }
        
        
        [Range(0,10)]
        public double Rating { get; set; }
        
        
        [StringLength(50)]
        public string? Language { get; set; }

    }
}
