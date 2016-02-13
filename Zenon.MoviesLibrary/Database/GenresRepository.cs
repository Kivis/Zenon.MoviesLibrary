﻿using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class GenresRepository
    {
        private const string ConnectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";

        public Genre GetGenre(int id)
        {
            var queryString =
                "SELECT Genre_ID, Name " +
                "FROM Genres WHERE Genre_ID = " + id;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Genre genre = null;
                if (reader.Read())
                    genre = ReadGenre(reader);

                reader.Close();

                return genre;
            }
        }

        public List<Genre> GetGenres()
        {
            var queryString = "SELECT * FROM Genres";

            var listOfGenres = new List<Genre>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var genre = ReadGenre(reader);
                        listOfGenres.Add(genre);
                    }
                }

                reader.Close();
            }
            return listOfGenres;
        }
        private Genre ReadGenre(SqlDataReader reader)
        {
            return new Genre
            {
                GenreId = reader.GetInt32(0),
                Name = reader.GetString(1),
            };
        }
    }
}
