﻿using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Controllers
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

        // INSERT: Insert genre name
        [HttpPost]
        public void Insert(Genre genre)
        {
            _genresRepository.InsertGenre(genre);
        }

        // DELETE: DELETE genre by id
        [HttpDelete]
        public void Delete(int id)
        {
            _genresRepository.DeleteGenreById(id);

        }
    }
}