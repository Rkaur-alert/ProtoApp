using ProtoApp.Dtos;
using ProtoApp.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProtoApp.Controllers.Api
{
    
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Route("api/newRentals")]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            try
            {

                var customer = _context.Customers.Single(
                    c => c.Id == newRental.CustomerId);

                var movies = _context.Movies.Where(
                    m => newRental.MovieIds.Contains(m.Id)).ToList();


            
                foreach (var movie in movies)
                {

                    movie.NumberAvailable--;

                    var rental = new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };
                    _context.Rentals.Add(rental);

                }
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.ToString());
            }

                return Ok();
        }
    }
}
