using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private ApplicationDbContext context;

		public MoviesController()
		{
			context = new ApplicationDbContext();
		}

		//Get /api/movies
		public IHttpActionResult GetMovies()
		{
			var movieDtos = context.Movies.Include(a => a.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);

			return Ok(movieDtos);
		}

		//Get /api/movies/1
		public IHttpActionResult GetMovie(int id)
		{
			var movie = context.Movies.SingleOrDefault(c=> c.Id == id);
			if (movie == null)
				return NotFound();
			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		//Post api/movies
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie> (movieDto);
			context.Movies.Add(movie);
			context.SaveChanges();

			movieDto.Id = movie.Id;

			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}

		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)

				return BadRequest();

			var movieInDb = context.Movies.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
				return NotFound();

			Mapper.Map(movieDto, movieInDb);
			context.SaveChanges();

			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var MovieInDb = context.Movies.SingleOrDefault(c => c.Id == id);

			if (MovieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			context.Movies.Remove(MovieInDb);
			context.SaveChanges();

			return Ok();
		}
	}
}
