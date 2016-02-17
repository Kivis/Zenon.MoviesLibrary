using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    class LibraryRepository
    {
      private const string ConnectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";


      public Library GetLibrary(int id)
      {
          var queryString =

              "SELECT Movie_ID, Title, ReleaseDate, Description, Genre_ID, Director_ID, Language_ID " +
              "FROM Movies " +
              "INNER JOIN Genres ON Movies.Genre_ID = Genres.Genre_ID " +
              "INNER JOIN Directors ON Movies.Director_ID = Directors.Director_ID " +
              "INNER JOIN Languages ON Movies.Language_ID = Languages.Language_ID " +
              "WHERE Movie_ID = " + id;

          using (var connection = new SqlConnection(ConnectionString))
          {
              var command = new SqlCommand(queryString, connection);

              connection.Open();

              SqlDataReader reader = command.ExecuteReader();
              Library library = null;
              if (reader.Read())
                  library = ReadLibrary(reader);

              reader.Close();

              return library;
          }
      }

        public List<Library> GetLibrary()
        {
            var queryString =
                    "SELECT Movie_ID, Title, ReleaseDate, Description, Genres.Name, Directors.FirstName, Directors.LastName, Languages.Name " +
                    "FROM Movies " +
                    "INNER JOIN Genres ON Movies.Genre_ID = Genres.Genre_ID " +
                    "INNER JOIN Directors ON Movies.Director_ID = Directors.Director_ID " +
                    "INNER JOIN Languages ON Movies.Language_ID = Languages.Language_ID ";

            var listOfMovies = new List<Library>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var library = ReadLibrary(reader);
                        listOfMovies.Add(library);
                    }
                }

                reader.Close();
            }
            return listOfMovies;
        }

        private Library ReadLibrary(SqlDataReader reader)
        {
            return new Library
            {
                MovieId = reader.GetInt32(0),
                Title = reader.GetString(1),
                ReleaseDate = reader.GetDateTime(2),
                Description = reader.GetString(3),
                GenresName = reader.GetString(4),
                DirectorsFirstName = reader.GetString(5),
                DirectorsLastName = reader.GetString(6),
                LanguagesName = reader.GetString(7)
            };
        }
    }
}


