using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random (movies controller with Action called Random)
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel); //pass the movie object here
        }

        //attribute route
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //This action will be called when we navigate to movies.
        //It will return a list of movies in the database.
        //To make parameters optional, make it nullable:
        //add ? after int to make it nullable.
        //string is a reference type and nullable in C#
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //check to see if parameters have a value
            if (!pageIndex.HasValue)
                pageIndex = 1; //if no value, initialize with 1

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            //no parameters specified: pageIndex=1&sortBy=Name
            //specify parameters in web browser: localhost/movies?pageIndex=2&sortBy=ReleaseDate --> pageIndex=2&sortBy=ReleaseDate
        }
    }
}