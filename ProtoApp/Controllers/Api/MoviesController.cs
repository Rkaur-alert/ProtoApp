using ProtoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ProtoApp.Dtos;

namespace ProtoApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/movies/1
        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Movie, MovieDto>(movie);
        }

        //POST /api/movies
        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movie.Id = movieDto.Id;

            return movieDto;
        }

        //PUT /api/movies/1
        [HttpPut]
        public void UpdateCustomer(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            
            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDB);
            //movieInDB.Name = movie.Name;
            //movieInDB.ReleaseDate = movie.ReleaseDate;
            //movieInDB.NumberInStock = movie.NumberInStock;
            //movieInDB.GenreID = movie.GenreID;
            //movieInDB.ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();
        }

        //DELETE /api/movies/10
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();
        }
    }
}
