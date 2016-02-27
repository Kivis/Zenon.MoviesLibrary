using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Controllers
{
    public class DirectorsController : ApiController
    {
        private readonly DirectorsRepository _directorsRepository = new DirectorsRepository();
        // GET: Director
        public List<Director> Get()
        {
            return _directorsRepository.GetDirectors();
        }
        // GET: Directors by Id
        public Director Get(int id)
        {
            return _directorsRepository.GetDirector(id);
        }
        [HttpPost]
        // INSERT: Insert director firstName & lastName
        public void Insert(Director director)
        {
            _directorsRepository.InsertDirector(director);
        }

        // DELETE: DELETE director by id
        [HttpDelete]
        public void Delete(int id)
        {
            _directorsRepository.DeleteDirectorById(id);

        }
    }
}