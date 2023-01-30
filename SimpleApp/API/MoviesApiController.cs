using SimpleApp.Context;
using SimpleApp.Dtos;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.Entity;

namespace SimpleApp.API
{
    public class MoviesApiController : ApiController
    {
        private CustomerContext _context;
        public MoviesApiController()
        {
            _context = new CustomerContext();
        }

        //GET  Api/MoviesApi
        public IEnumerable<MoviesDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movies, MoviesDto>);
        }

        //GET  Api/MoviesApi/id
        public IHttpActionResult GetMovies(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return BadRequest();
            return Ok(Mapper.Map<Movies, MoviesDto>(movies));
        }

        //POST  Api/MoviesApi
        [HttpPost]
        public IHttpActionResult CreateMovieDetails (MoviesDto moviesDto)
        {
            if (!ModelState.IsValid) 
            return BadRequest();
            var movies = Mapper.Map<MoviesDto, Movies>(moviesDto);
            _context.Movies.Add(movies);
            _context.SaveChanges();
            moviesDto.Id = movies.Id;
            return Created(new Uri(Request.RequestUri + "/" + movies.Id), moviesDto);
        }


        //PUT api/moviesapi/1
        [HttpPut]
        public void UpdateMovieDetails (int id, MoviesDto moviesDto)
        {
            var dbContext = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(dbContext == null )
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Mapper.Map<MoviesDto, Movies>(moviesDto, dbContext);
            _context.SaveChanges();
        }
        //Delete api/moviesapi/1
        [HttpDelete]
        public void DeleteMovieDetails (int id) 
        {
        var dbContext = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(dbContext == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(dbContext);
            _context.SaveChanges();
        }
    }
}
