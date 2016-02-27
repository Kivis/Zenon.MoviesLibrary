using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class GenresRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;
        public Genre GetGenre(int id)
        {
            var queryString =
                    "SELECT Genre_ID, Name " +
                    "FROM Genres WHERE Genre_ID = " + id;

            using (var connection = new SqlConnection(_connectionString))
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
            var queryString = 
                    "SELECT Genre_ID, Name " +
                    "FROM Genres";

            var listOfGenres = new List<Genre>();

            using (var connection = new SqlConnection(_connectionString))
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

        public int InsertGenre(Genre genre)
        {
            var queryString = string.Format("InsertGenre '{0}'",  genre.Name);

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var returnValue = (int)command.ExecuteScalar();
                connection.Close();
                return returnValue;
            }
        }

        public void DeleteGenreById(int id)
        {
            var queryString =
                "DELETE FROM Genres " +
                "WHERE " +
                "Genre_ID = " + id;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

