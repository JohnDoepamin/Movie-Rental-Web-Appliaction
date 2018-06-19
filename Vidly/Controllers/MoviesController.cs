using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!", Description = "Movie about a green dude."};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer1"},
                new Customer {Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return RedirectToAction("Index");

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Movies");

            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(movie1 => movie1.Id == id);

            return View(movie);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        public ActionResult Index()
        {
            //if (!pageIndex.HasValue)
            //    pageIndex = 1;

            //if (string.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";

            //var viewModel = new MovieViewModel()
            //{
            //    Movies = _movies
            //};

            var movies = _context.Movies.Include(c => c.Genre);

            return View(movies);
            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres,
                Movie = new Movie()
                {
                    ReleaseDate = DateTime.Now,
                    NumberInStock = 0
                }
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = genres
                };

                return View("MovieForm", viewModel);
            }

            // If new object has been sent
            if(movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.Description = movie.Description;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}