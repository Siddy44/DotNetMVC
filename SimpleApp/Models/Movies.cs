using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleApp.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public Genre Genre { get; set; }
       
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        
        public DateTime? DateAdded { get; set; }
       
        [Display(Name = "Release Date")]

        public DateTime ReleaseDate { get; set; }
        
        [Display(Name = "Number in Stock")]

        public byte NumberInStock { get; set; }
    }
}