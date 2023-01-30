using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SimpleApp.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

       

       
        [Required]
        public byte GenreId { get; set; }

        public DateTime? DateAdded { get; set; }

        
        [Required]
        public DateTime ReleaseDate { get; set; }

       
        [Range(1, 20, ErrorMessage = "Must be between 1-20")]
        [Required]
        public byte NumberInStock { get; set; }
    }
}