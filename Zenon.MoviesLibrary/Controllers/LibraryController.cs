using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.Controllers
{
    public class LibraryController : ApiController
    {
        private readonly LibraryRepository _libraryRepository = new LibraryRepository();

        // GET api/values
        public List<Library> Get()
        {
            return _libraryRepository.GetLibrary();
        }
        // GET api/values/5
        public void Get(int id)
        {
           
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
