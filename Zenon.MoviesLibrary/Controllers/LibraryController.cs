using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.Controllers
{
    public class LibraryController : ApiController
    {

        private MoviesRepository getMoviesRepository = new MoviesRepository();

        // GET api/values
        public List<Movie> Get()
        {
            return getMoviesRepository.GetMovies();
        }
        // GET api/values/5
        public string Get(int id)
        {
            return getMoviesRepository.GetMovie(id).ToString();
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
