using NUnit.Framework;
using System;
using System.Linq;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class MoviesRepositoryTests
    {
        [Test]
        public void GetMovie_GetsMovieWithIdOne()
        {
            var repository = new MoviesRepository();

            var movie = repository.GetMovie(1);

            Assert.AreNotEqual(null, movie);
        }

        [Test]
        public void GetMovies_NormalFlow()
        {
            var repository = new MoviesRepository();

            var movie = repository.GetMovies();

            Assert.That(movie.Count > 0);
        }

        [Test]
        public void InsertMovies_NormalFlow()
        {
            var repository = new MoviesRepository();


            var movie = new Movie()
            {
                Title = "TestMovie " + Guid.NewGuid().ToString(),
                Description = "MyTestMovieDescription",
                Genre = new Genre { GenreId = 1 },
                Director = new Director { DirectorId = 1 },
                Language = new Language { LanguageId = 1 }
            };

            repository.InsertMovie(movie);

            var allMovies = repository.GetMovies();

            var movieFromDb = allMovies.FirstOrDefault(g => g.Title == movie.Title);

            Assert.That(movieFromDb != null);
        }
    }
}
