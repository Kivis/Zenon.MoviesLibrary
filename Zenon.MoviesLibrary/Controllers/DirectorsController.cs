using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.Controllers
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
    }
}