using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.Controllers
{
    public class LibraryController : ApiController
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

        // POST api/values
        public void Post([FromBody]string value)
        {
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
