﻿using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class GenresRepository2 : BaseRepository2<Genre>
    {
        public Genre Get(int id)
        {
            var queryString =
                "SELECT Genre_ID, Name " +
                "FROM Genres WHERE Genre_ID = " + id;

            return Get(queryString, MapGenre);
        }

        private Genre MapGenre(SqlDataReader reader)
        {
            return new Genre
            {
                GenreId = reader.GetInt32(0), // first result table column
                Name = reader.GetString(1), // second result table column
            };
        }

        public List<Genre> Get()
        {
            var queryString =
                     "SELECT Genre_ID, Name " +
                     "FROM Genres";

            return GetItems(queryString, MapGenre);
        }

        //public void Delete()
        //{
        //    base.Delete();
        //}

        //public void Update()
        //{
        //    base.Update();
        //}
    }
}

