using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ProtoApp.Models;

namespace ProtoApp.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int GenreID { get; set; }

        public GenreDto Genre { get; set; }

        public Nullable<DateTime> DateAdded { get; set; }

        [Required]
        [Range(1, 20,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int NumberInStock { get; set; }
    }
}