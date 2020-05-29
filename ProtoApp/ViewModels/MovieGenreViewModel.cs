using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtoApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ProtoApp.ViewModels
{
    public class MovieGenreViewModel
    {
        
        public IEnumerable<Genre> Genres { get; set; }

        public int ?  Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ? ReleaseDate { get; set; }

        [Required]
        public int ? GenreID { get; set; }

        [Required]
        [Range(1, 20,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Number In Stock")]
        public int ? NumberInStock { get; set; }
        public string Title 
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }

        }

        public MovieGenreViewModel()
        {
            Id = 0;
        }
        public MovieGenreViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreID = movie.GenreID;
        }
    }
}