using NUnit.Framework;
using System;
using System.Linq;
using FluentAssertions;
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
        
            genre.GenreId = repository.InsertGenre(genre);

            var newRecord = repository.GetGenre(genre.GenreId);
            genre.ShouldBeEquivalentTo(newRecord);
        }

        [Test]
        public void DeleteGenreByID_DeleteById()
        {
            var repository = new GenresRepository();

            var genre = new Genre() {Name = "DeleteTest"};

            var idOfInsertedGenre = repository.InsertGenre(genre);
            repository.DeleteGenreById(idOfInsertedGenre);

            var getId = repository.GetGenre(idOfInsertedGenre);
            Assert.That(getId == null);

            //var allLanguages = repository.GetGenres();

            //var genreFromDb = allLanguages.FirstOrDefault(g => g.Name == genre.Name);

            //Assert.That(genreFromDb == null);
        }
    }
}
