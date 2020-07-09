using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Web;
using ProtoApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ProtoApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
 
        [Required]
        public Customer Customer { get; set; }
        
        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}