using SimpleApp.Context;
using SimpleApp.Models;
using SimpleApp.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimpleApp.ViewModel;
using System.Data.Entity.Validation;

namespace SimpleApp.Controllers
{
    public class MoviesController : Controller
    {

        private CustomerContext _context;

        public MoviesController()
        {
            _context = new CustomerContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



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
 
        
        
        
        //public ActionResult Edit(int movieid)
        //{
        //    return Content("id= " + movieid);
        //}
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
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);


        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ViewResult MovieForm()
        {
            var genre = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movies = new Movies(),
                Genre = genre
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movies = movies,
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movies)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movies = movies,
                    Genre = _context.Genre.ToList(),


                };
                return View("MovieForm", viewModel);
            }

                if (movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                _context.Movies.Add(movies);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movies.Id);
                movieInDb.Title = movies.Title;
                movieInDb.GenreId = movies.GenreId;
                movieInDb.NumberInStock = movies.NumberInStock;
                movieInDb.ReleaseDate = movies.ReleaseDate;
            }
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}
