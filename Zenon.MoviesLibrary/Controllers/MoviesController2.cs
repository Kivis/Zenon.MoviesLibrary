using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Controllers
{
    public class MoviesController2 : ApiController
    {
        private readonly MoviesRepository2 _moviesRepository2 = new MoviesRepository2();

        // GET api/values
        [HttpGet]
        public List<Movie> Get()
        {
            return _moviesRepository2.Get();
        }

        // GET api/values/5
        [HttpGet]
        public Movie Get(int id)
        {
            return _moviesRepository2.Get(id);
        }

        // INSERT: Insert movie
        [HttpPost]
        public void Insert(Movie movie)
        {
            _moviesRepository2.Insert(movie);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            _moviesRepository2.Delete(id);
        }
        // UPDATE
        [HttpPut]
        public void Update(Movie movie)
        {
            _moviesRepository2.Update(movie);
        }
    }
}
