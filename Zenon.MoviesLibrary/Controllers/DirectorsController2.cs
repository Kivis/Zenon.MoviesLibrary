using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Controllers
{
    public class DirectorsController : ApiController
    {
        private readonly DirectorsRepository2 _directorsRepository2 = new DirectorsRepository2();
        // GET: Director
        public List<Director> Get()
        {
            return _directorsRepository2.Get();
        }
        // GET: Directors by Id
        public Director Get(int id)
        {
            return _directorsRepository2.Get(id);
        }
        [HttpPost]
        // INSERT: Insert director firstName & lastName
        public void Insert(Director director)
        {
            _directorsRepository2.Insert(director);
        }

        // DELETE: DELETE director by id
        [HttpDelete]
        public void Delete(int id)
        {
            _directorsRepository2.Delete(id);
        }
        // UPDATE
        [HttpPut]
        public void Update(Director director)
        {
            _directorsRepository2.Update(director);
        }
    }
}