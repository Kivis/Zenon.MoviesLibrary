using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class GenresRepository
    {
        //private const string _connectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";
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

        public void InsertGenre(Genre genre)
        {
            var queryString =
                   "IF NOT EXISTS (SELECT * FROM Genres " +
                   "WHERE Name = '" + genre.Name + "') " +
                   "BEGIN " +
                   "INSERT INTO Genres (Name) " +
                   "VALUES ('" + genre.Name + "') " +
                   "END";

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

