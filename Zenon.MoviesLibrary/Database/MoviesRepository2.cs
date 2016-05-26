using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class MoviesRepository2 : BaseRepository2<Movie>
    {
        
        private readonly GenresRepository2 _genresRepository2 = new GenresRepository2();
        private readonly LanguagesRepository2 _languagesRepository2 = new LanguagesRepository2();
        private readonly DirectorsRepository2 _directorsRepository2 = new DirectorsRepository2();

        public Movie Get(int id)
        {
            return Get(id, MapMovie);
        }

        public List<Movie> Get()
        {
            return GetItems(MapMovie);
        }

        private Movie MapMovie(SqlDataReader reader)
        {
            var movieDbModel = new MovieDbModel()
            {
                MovieId = (int)reader["Movie_ID"],
                Title = (string)reader["Title"],
                ReleaseDate = (DateTime)reader["ReleaseDate"],
                Description = (string)reader["Description"],
                GenreId = (int)reader["Genre_ID"],
                DirectorId = (int)reader["Director_ID"],
                LanguageId = (int)reader["Language_ID"]
            };

            var movie = movieDbModel.GetMovieCore();

            MapGenres(movie, movieDbModel);
            MapDirectors(movie, movieDbModel);
            MapLanguages(movie, movieDbModel);

            return movie;
        }


        //public int Insert(Movie movie)
        //{
        //    List<SqlParameter> movieParameterList = new List<SqlParameter>();
        //    movieParameterList.Add(new SqlParameter("@Title", "Title"));
        //    movieParameterList.Add(new SqlParameter("@ReleaseDate", "ReleaseDate"));
        //    movieParameterList.Add(new SqlParameter("@Description", "Description"));
        //    movieParameterList.Add(new SqlParameter("@GenreId", "GenreId"));
        //    movieParameterList.Add(new SqlParameter("@DirectorId", "DirectorId"));
        //    movieParameterList.Add(new SqlParameter("@LanguageId", "LanguageId"));

        //    return Insert(movieParameterList);
        //}

        public void Delete(int id)
        {
           DeleteItem(id);
        }

        private void MapGenres(Movie movie, MovieDbModel movieDbModel)
        {
            var genre = _genresRepository2.Get(movieDbModel.GenreId);
            movie.Genre = genre;
        }

        private void MapDirectors(Movie movie, MovieDbModel movieDbModel)
        {
            var director = _directorsRepository2.Get(movieDbModel.DirectorId);
            movie.Director = director;
        }
        private void MapLanguages(Movie movie, MovieDbModel movieDbModel)
        {
            var language = _languagesRepository2.Get(movieDbModel.LanguageId);
            movie.Language = language;
        }
    }
}
