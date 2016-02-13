using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class MoviesRepository
    {
        private const string ConnectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";
        private GenresRepository _genresRepository = new GenresRepository();

        public Movie GetMovie(int id)
        {
            var queryString =
                "SELECT Movie_ID, Title, ReleaseDate, Description, Genre_ID, Director_ID, Language_ID " +
                "FROM Movies WHERE Movie_ID = " + id;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Movie movie = null;
                if (reader.Read())
                    movie = ReadMovie(reader);

                reader.Close();

                return movie;
            }
        }

        public List<Movie> GetMovies()
        {
            var queryString = "SELECT * FROM Movies";

            var listOfMovies = new List<Movie>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var movie = ReadMovie(reader);
                        listOfMovies.Add(movie);
                    }
                }

                reader.Close();
            }
            return listOfMovies;
        }

        private Movie ReadMovie(SqlDataReader reader)
        {
            var movieDbModel = new MovieDbModel()
            {
                MovieId = reader.GetInt32(0),
                Title = reader.GetString(1),
                ReleaseDate = reader.GetDateTime(2),
                Description = reader.GetString(3),
                GenreId = reader.GetInt32(4),
                DirectorId = reader.GetInt32(5),
                LanguageId = reader.GetInt32(6)
            };
            var movie = movieDbModel.GetMovieCore();

            MapGenres(movie, movieDbModel);

            return movie;
        }

        private void MapGenres(Movie movie, MovieDbModel movieDbModel)
        {
            var genre = _genresRepository.GetGenre(movieDbModel.GenreId);
            movie.Genre = genre;
        }
    }
}
