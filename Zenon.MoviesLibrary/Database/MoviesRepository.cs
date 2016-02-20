using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.Models;
using System.Configuration;

namespace Zenon.MoviesLibrary.API.Database
{
    public class MoviesRepository
    {
        //private const string ConnectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;
        private readonly GenresRepository _genresRepository = new GenresRepository();
        private readonly LanguagesRepository _languagesRepository = new LanguagesRepository();
        private readonly DirectorsRepository _directorsRepository = new DirectorsRepository();

        public Movie GetMovie(int id)
        {
            var queryString =
                    "SELECT Movie_ID, Title, ReleaseDate, Description, Genre_ID, Director_ID, Language_ID " +
                    "FROM Movies WHERE Movie_ID = " + id;

            using (var connection = new SqlConnection(_connectionString))
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
            var queryString =
                   "SELECT Movie_ID, Title, ReleaseDate, Description, Genre_ID, Director_ID, Language_ID " +
                   "FROM Movies ";

            var listOfMovies = new List<Movie>();

            using (var connection = new SqlConnection(_connectionString))
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

        public void InsertMovie(Movie movie)
        {
            var queryString =

                   "IF NOT EXISTS (SELECT * FROM Movies " +
                   "WHERE " +
                   "Title = '" + movie.Title + "' " +
                   "AND " +
                   "Description = '" + movie.Description + "') " +
                   "BEGIN " +
                   "INSERT INTO Movies (Title, ReleaseDate, Description, Genre_ID, Director_ID, Language_ID) " +
                   "VALUES ('" + movie.Title + "', " +
                   "        '" + movie.ReleaseDate + "', " +
                   "        '" + movie.Description + "', " +
                   "        '" + movie.Genre.GenreId + "', " +
                   "        '" + movie.Director.DirectorId + "', " +
                   "        '" + movie.Language.LanguageId + "') " +
                   "END";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
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
            MapDirectors(movie, movieDbModel);
            MapLanguages(movie, movieDbModel);

            return movie;
        }


        public void DeleteMovieById(int id)
        {
            var queryString =
                "DELETE FROM Movies " +
                "WHERE " +
                "Movie_ID = " + id;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void MapGenres(Movie movie, MovieDbModel movieDbModel)
        {
            var genre = _genresRepository.GetGenre(movieDbModel.GenreId);
            movie.Genre = genre;
        }

        private void MapDirectors(Movie movie, MovieDbModel movieDbModel)
        {
            var director = _directorsRepository.GetDirector(movieDbModel.DirectorId);
            movie.Director = director;
        }
        private void MapLanguages(Movie movie, MovieDbModel movieDbModel)
        {
            var language = _languagesRepository.GetLanguage(movieDbModel.LanguageId);
            movie.Language = language;
        }
    }
}
