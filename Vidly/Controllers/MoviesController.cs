using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext context;

		public MoviesController()
		{
			context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			context.Dispose();
		}
		public ViewResult Index()
		{
			var movies = context.Movies.Include(c => c.Genre).ToList();

			return View(movies);
		}
		public ActionResult Details(int id)
		{
			var movies = context.Movies.Include(context => context.Genre).SingleOrDefault(c => c.Id == id);
			if (movies == null)
				return HttpNotFound();

			return View(movies);
		}
		public ActionResult MovieForm()
		{
			var genres = context.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{
				Movie = new Movie(),
				Genres=genres
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = context.Movies.SingleOrDefault(c => c.Id == id);
			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel
			{
				Movie = movie,
				Genres = context.Genres.ToList()
			};
			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{

			if(movie.Id==0)
			{
				movie.DateAdded = DateTime.Now;
				context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = context.Movies.SingleOrDefault(c => c.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.NumInStock = movie.NumInStock;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
			}

			try
			{
				context.SaveChanges();
			}
			catch(DbEntityValidationException e)
			{
				Console.WriteLine(e);
			}
			
			return RedirectToAction("Index", "Movies");
		}

		// GET: Movies/Random
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "Shrek!" };
			var customers = new List<Customer>
			{
				new Customer { Name = "Customer 1" },
				new Customer { Name = "Customer 2" }
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);
		}
	}
}