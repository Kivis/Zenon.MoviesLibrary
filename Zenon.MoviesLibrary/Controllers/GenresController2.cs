using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Controllers
{
    public class GenresController2 : ApiController
    {
        private readonly GenresRepository2 _genresRepository2 = new GenresRepository2();
        // GET: Genres
        public List<Genre> Get()
        {
            return _genresRepository2.Get();
        }
        // GET: Genre by Id
        public Genre Get(int id)
        {
            return _genresRepository2.Get(id);
        }

        // INSERT: Insert genre name
        [HttpPost]
        public void Insert(Genre genre)
        {
            _genresRepository2.Insert(genre);
        }

        // DELETE: DELETE genre by id
        [HttpDelete]
        public void Delete(int id)
        {
            _genresRepository2.Delete(id);

        }
        // UPDATE
        [HttpPut]
        public void Update(Genre genre)
        {
            _genresRepository2.Update(genre);
        }
    }
}