using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly2.Models;
using System.Net;
using Vidly2.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //[Authorize(Roles = RoleName.Admin)]
        /* public IHttpActionResult GetMovies()
         {
             var movies = _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);

             return Ok(movies);

         }
         */

        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        // [Authorize(Roles = RoleName.Admin)]
        public IHttpActionResult GetMovies(int Id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
           
            if (movie == null)
           // throw new HttpResponseException(HttpStatusCode.NotFound);
            return NotFound();
            //return movie;
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
              // throw new HttpResponseException(HttpStatusCode.BadRequest);
               return BadRequest();
            // mapping movieDto back to Domain object
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            movieDto.DateAdded = DateTime.Now;
            movieDto.NumberAvailable = movieDto.NumberInStock;
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            //return movieDto;
           return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }


        [HttpPut]
        // public void UpdateMovie(MovieDto movieDto, int Id)
        [Authorize(Roles = RoleName.Admin)]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int Id)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            //  below lines not req coz we are using automapping which takes care of it 
            /*
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.Genre = movie.Genre;
            movieInDb.NumberInStock = movie.NumberInStock;

            */
            movieDto.DateAdded = movieInDb.DateAdded;
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.Admin)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _context.Movies.Single(m => m.Id == Id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();

        }

    }
}