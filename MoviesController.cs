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

        public ActionResult Index()
        {
            List<Movie> moviesList = new List<Movie>();

            moviesList.Add(new Movie { Id = 1, Name = "Shrek" });
            moviesList.Add(new Movie { Id = 2, Name = "Aladin" });
            moviesList.Add(new Movie { Id = 3, Name = "Lion King" });

            return View(moviesList);
        }

        //Get information
        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost] //Capture the informion gathered in AddMovie
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(Movie model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Customer 1"},
                new Customer { FirstName = "Customer 2"}

            };

            var viewModel = new RandomMovieViewModel
            {
                //initialize these properties
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            // Don't use ViewData or ViewBag: 
            //ViewData["RandomMovie"] = movie;
            //ViewBag.RandomMovie = movie;
            //return View();
            
            //just pass the movie object here:
            //return View(movie);


            //other return options:
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            /* 
            specify ("name of action", "controller", use anonymous object to pass arguments for target action)
            When run: this redirects to home page and browser address bar says: 
           https://localhost:44347/?page=1&sortBy=name 
           */
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
            /*
             browser url bar: https://localhost:44347/Movies/edit/1
             */
        }

        // navigates to /movies
        // int? the ? makes the int nullable, string is already nullable b/c it's a reference variable
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "FirstName";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //    //Default https://localhost:44347/movies returns: pageIndex=1&sortBy=FirstName
        //    //Change parameters using the browser address bar:
        //    //Override with https://localhost:44347/movies?pageIndex=2 returns pageIndex=2&sortBy=FirstName
        //    //Override with https://localhost:44347/movies?pageIndex=2&sortBy=ReleaseDate returns pageIndex=2&sortBy=ReleaseDate
        //    //embedding these parameters in the URL would require a custom route with 2 parameters
        //}

        //apply route attribute and pass url template (month with multiple constraints)
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}