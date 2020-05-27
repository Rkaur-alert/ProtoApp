using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtoApp.Models;

namespace ProtoApp.ViewModels
{
    public class MovieGenreViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}