using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Razor;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using ProtoApp.Models;
using ProtoApp.ViewModels;

namespace ProtoApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        private ApplicationDbContext _movieContext;

        public MoviesController()
        {
            _movieContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _movieContext.Dispose();
        }

        public ActionResult Index()
        {
            //lowercase
            var movies = _movieContext.Movies.Include(genre => genre.Genre).ToList();
            return View(movies);
        }

        
        public ActionResult New()
        {
            var genres = _movieContext.Genres;
            var viewModel = new MovieGenreViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            //if(!ModelState.IsValid)
            //{
            //    var genres = _movieContext.Genres;
            //    var viewModel = new MovieGenreViewModel
            //    {
            //        Movie = movie,
            //        Genres = genres
            //    };

            //    RedirectToAction("New", viewModel);
            //}

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _movieContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _movieContext.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.NumberInStock = movie.NumberInStock;
                
            }

            _movieContext.SaveChanges();
            return RedirectToAction("Index", movie);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _movieContext.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieGenreViewModel
            {
                Movie = movie,
                Genres = _movieContext.Genres.ToList()
            };
            return View("New",viewModel);
        }

        public ActionResult Details(int Id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            var movie = _movieContext.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            return View(movie);
        }

        public ActionResult Random()
        {
            //return View(movie);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
           
            var movie = new Movie() { Name = "Race!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1"},
                new Customer { Name = "Customer2"}

            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

        }

     

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}



        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        
    }
}