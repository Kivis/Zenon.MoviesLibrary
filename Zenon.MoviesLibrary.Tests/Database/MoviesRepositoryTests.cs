using NUnit.Framework;
using System;
using FluentAssertions;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class MoviesRepositoryTests
    {
        private readonly MoviesRepository _moviesRepository = new MoviesRepository();

        [Test]
        public void GetMovie_GetsMovieWithIdOne()
        {
            var movie = _moviesRepository.GetMovie(1);

            Assert.AreNotEqual(null, movie);
        }

        [Test]
        public void GetMovies_NormalFlow()
        {
            var movie = _moviesRepository.GetMovies();

            Assert.That(movie.Count > 0);
        }

        [Test]
        public void InsertMovies_NormalFlow()
        {
            var movie = new Movie()
            {
                Title = "TestTitle " + Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Parse("2016-02-28"),
                Description = "TestDescription",
                Genre = new Genre { GenreId = 1, Name = "Action"},
                Director = new Director { DirectorId = 1, FirstName = "Tim", LastName = "Miller"},
                Language = new Language { LanguageId = 1, Name = "English"}
            };

            movie.MovieId = _moviesRepository.InsertMovie(movie);
            var newRecord = _moviesRepository.GetMovie(movie.MovieId);

            movie.ShouldBeEquivalentTo(newRecord);
        }

        [Test]
        public void DeleteMovieByID_DeleteById()
        {
            var movie = new Movie()
            {
                Title = "TestTitle " + Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now,
                Description = "Test Description",
                Genre = new Genre() {GenreId = 1},
                Director = new Director() { DirectorId = 1 },
                Language = new Language() { LanguageId = 1 }
            };

            var idOfInsertedMovie = _moviesRepository.InsertMovie(movie);
            _moviesRepository.DeleteMovieById(idOfInsertedMovie);
            var retrievedRecord = _moviesRepository.GetMovie(idOfInsertedMovie);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
