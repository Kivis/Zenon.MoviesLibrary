using NUnit.Framework;
using System;
using FluentAssertions;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class MoviesRepository2Tests
    {
        private readonly MoviesRepository2 _moviesRepository2 = new MoviesRepository2();

        [Test]
        public void GetMovie_GetsMovieWithIdOne()
        {
            var movie = _moviesRepository2.Get(1);

            Assert.AreNotEqual(null, movie);
        }

        [Test]
        public void GetMovies_NormalFlow()
        {
            var movie = _moviesRepository2.Get();

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

            movie.MovieId = _moviesRepository2.Insert(movie);
            var newRecord = _moviesRepository2.Get(movie.MovieId);

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

            var idOfInsertedMovie = _moviesRepository2.Insert(movie);
            _moviesRepository2.Delete(idOfInsertedMovie);
            var retrievedRecord = _moviesRepository2.Get(idOfInsertedMovie);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
