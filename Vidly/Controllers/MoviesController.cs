using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie { Id=1,Name="Interstellar" },
                new Movie { Id=2, Name="The man in the high castle" }
            };
        }

        public ActionResult Random()
        {
            var random = new Movie() { Id=1, Name="Interstellar" };

            var customers = new List<Customer>
            {
                new Customer { Id=1, Name="Vishnu" },
                new Customer { Id=2, Name="Tushar" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = random,
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)?}")]
        public ActionResult ByReleaseDate(int year, int? month)
        {
            return Content(year + "/" + month);
        }
    }
}