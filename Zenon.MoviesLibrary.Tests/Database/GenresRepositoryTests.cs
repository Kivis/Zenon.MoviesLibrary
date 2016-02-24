using NUnit.Framework;
using System;
using System.Linq;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class GenresRepositoryTests
    {
        [Test]
        public void GetGenre_GetsGenreWithIdOne()
        {
            var repository = new GenresRepository();

            var genre = repository.GetGenre(1);

            Assert.AreNotEqual(null, genre);
        }

        [Test]
        public void GetGenres_NormalFlow()
        {
            var repository = new GenresRepository();

            var genre = repository.GetGenres();

            Assert.That(genre.Count > 0);
        }

        [Test]
        public void InsertGenre_NormalFlow()
        {
            var repository = new GenresRepository();

            var genre = new Genre() { Name = "MyTestGenre" + Guid.NewGuid().ToString() };

            repository.InsertGenre(genre);

            var allGenres = repository.GetGenres();

            var genreFromDb = allGenres.FirstOrDefault(g => g.Name == genre.Name);

            Assert.That(genreFromDb != null);
        }

        [Test]
        public void DeleteGenreByID_DeleteById()
        {
            var repository = new GenresRepository();

            var genre = new Genre();

            repository.DeleteGenreById(repository.InsertGenre(genre));

            var allLanguages = repository.GetGenres();

            var genreFromDb = allLanguages.FirstOrDefault(g => g.GenreId == genre.GenreId);

            Assert.That(genreFromDb == null);
        }
    }
}
