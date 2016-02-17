using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly MoviesRepository _moviesRepository = new MoviesRepository();

        // GET api/values
        public List<Movie> Get()
        {
            return _moviesRepository.GetMovies();
        }
        // GET api/values/5
        public Movie Get(int id)
        {
            return _moviesRepository.GetMovie(id);
        }

        // INSERT: Insert movie
        public void Insert(Movie movie)
        {
            _moviesRepository.InsertMovie(movie);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
