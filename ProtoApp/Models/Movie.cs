using ProtoApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProtoApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int GenreID { get; set; }

        public Genre Genre { get; set; }

        public Nullable<DateTime> DateAdded { get; set; }

        [Required]
        [Range(1, 20,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}