using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class GenresRepository2 : BaseRepository2<Genre>
    {
        public Genre Get(int id)
        {
            return Get(id, MapGenre);
        }

        private Genre MapGenre(SqlDataReader reader)
        {
            return new Genre
            {
                GenreId = (int)reader["Genre_ID"],
                Name = (string)reader["Name"],
            };
        }

        public List<Genre> Get()
        {
            return GetItems(MapGenre);
        }

        public int Insert(Genre genre)
        {
            var genreName = genre.Name;
            return Insert(genreName);
        }

        //public void Update()
        //{
        //    base.Update();
        //}

    }
}

