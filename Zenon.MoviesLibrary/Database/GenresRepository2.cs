using System.Collections.Generic;
using System.Data;
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
            // find differences between array and list
            // fix insert to work
            // DEBUG if sth is not working ok

            var genreParameterList = new List<SqlParameter>() { new SqlParameter("@Name", genre.Name) };

            return Insert(genreParameterList);
        }

        public void Delete(int id)
        {
            DeleteItem(id);
        }

        //public void Update()
        //{
        //    base.Update();
        //}

    }
}

