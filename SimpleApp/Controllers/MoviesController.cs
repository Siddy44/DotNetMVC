using SimpleApp.Models;
using SimpleApp.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SimpleApp.Controllers
{
    public class MoviesController : Controller
    {
        //  [Route("movies/name/")]
        //public ActionResult ByReleaseDate()
        //{
        //return Content("My Default"); 
        //}
        public ActionResult Random()
        {
            var movie = new Movies() { Title = "Mission Impossible!" };
            var customers = new List<Customer>
            {
                new Customer{Name="Customer1"},
                new Customer{Name="Customer2"}
            };
            var viewModel = new RandomViewModel()
            {
                Movie = movie,
                customers = customers
            };
            /*  ViewBag.Movie = hello;
              return View();  */

            /*  ViewData["Movie"] = hello;
            return View(); */

            //var customers = new List<Customer>
            //{
            //new Customer {Name="Customer1" },
            //new Customer {Name="Customer2" }
            //};







            //var obj = new RandomModelView()
            // {
            //  Movie = hello,
            //customers = customers,

            //};

            return View(viewModel);
            // return PartialView(obj);
        }
        public ActionResult Edit(int movieid)
        {
            return Content("id= " + movieid);
        }
        //Get Movies
        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if(!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}


        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);


        }

        private IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies { Id = 1, Title = "Shrek" },
                new Movies { Id = 2, Title = "Wall-e" }
            };
        }
    }
}
