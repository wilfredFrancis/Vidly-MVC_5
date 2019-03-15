using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModel;
using System.Data.Entity.Migrations;

namespace Vidly2.Controllers
{
    
    public class MovieController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ViewResult Index()
        {
            // var movies = _context.Movies.Include(c => c.Genre);

            if (User.IsInRole(RoleName.Admin))
            {
                return View("Index");
            }
            return View("ReadOnlyList");
            //  return View(movies);
        }


        [Authorize(Roles = RoleName.Admin)]
        public ViewResult New()
        {
            var genres = _context.Genre.ToList();

            var viewModel = new MovieViewModel
            {
                Genre = genres,
            };
            return View("New", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int Id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieViewModel(movies)
            {
                Genre = _context.Genre.ToList(),
            };

            return View("New", viewModel);

        }


        public ActionResult Details(byte Id)
        {

            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            var num = movie.NumberInStock;
                if (!ModelState.IsValid)
                {

                    var viewModel = new MovieViewModel(movie)
                    {

                        Genre = _context.Genre.ToList()

                    };
                    return View("New", viewModel);
                }           

            if (movie.Id == 0)
                {
                    movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = (byte) num;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var moviesInDb = _context.Movies.Single(c => c.Id == movie.Id);
                    moviesInDb.Name = movie.Name;
                    moviesInDb.NumberInStock = movie.NumberInStock;
                    moviesInDb.ReleaseDate = movie.ReleaseDate;
                    moviesInDb.GenreId = movie.GenreId;
                }

                _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
             

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie> {

                 new Movie{Id = 1, Name = "Fate Of The Furious"},
                 new Movie{Id = 2, Name = "Infinit War"}
            };
        }

   
    }
}