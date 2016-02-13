using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.Controllers
{
    public class GenresController : ApiController
    {
        private readonly GenresRepository _genresRepository = new GenresRepository();
        // GET: Genres
        public List<Genre> Get()
        {
            return _genresRepository.GetGenres();
        }
        // GET: Genre by Id
        public Genre Get(int id)
        {
            return _genresRepository.GetGenre(id);
        }
    }
}