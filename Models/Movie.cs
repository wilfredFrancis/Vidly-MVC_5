using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public short NumberInStock { get; set; }

        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage ="Genre must be selected")]
        public byte GenreId { get; set; }

        public byte NumberAvailable { get; set; }
    }
}