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

        public List<Genre> Get()
        {
            return GetItems(MapGenre);
        }

        private Genre MapGenre(SqlDataReader reader)
        {
            return new Genre
            {
                GenreId = (int)reader["Genre_ID"],
                Name = (string)reader["Name"],
            };
        }

        public int Insert(Genre genre)
        {
            var genreParameterList = new[]
            {
                new SqlParameter("@Name", genre.Name)
            };

            return Insert(genreParameterList);
        }

        public void Update(Genre genre)
        {
            var genreParameterList = new[]
            {
                new SqlParameter("@ID", genre.GenreId),
                new SqlParameter("@Name", genre.Name)
            };
            Update(genreParameterList);
        }
    }
}

