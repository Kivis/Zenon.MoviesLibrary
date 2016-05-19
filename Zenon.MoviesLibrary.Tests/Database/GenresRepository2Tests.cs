using System;
using FluentAssertions;
using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class GenresRepository2Tests
    {
        private readonly GenresRepository2 _genresRepository2 = new GenresRepository2();

        [Test]
        public void Get_GetsGenreWithIdOne()
        {
            var genre = _genresRepository2.Get(1);

            Assert.AreNotEqual(null, genre);
        }

        [Test]
        public void GetGenres_NormalFlow()
        {
            var genre = _genresRepository2.Get();

            Assert.That(genre.Count > 0);
        }

        [Test]
        public void InsertGenre_NormalFlow()
        {
            var genre = new Genre() { Name = "MyTestGenre" + Guid.NewGuid().ToString() };

            genre.GenreId = _genresRepository2.Insert(genre);
            var newRecord = _genresRepository2.Get(genre.GenreId);

            genre.ShouldBeEquivalentTo(newRecord);
        }

        [Test]
        public void DeleteGenreByID_DeleteById()
        {
            var genre = new Genre() { Name = "DeleteTest" };

            var idOfInsertedGenre = _genresRepository2.Insert(genre);
            _genresRepository2.Delete(genre, idOfInsertedGenre);
            var retrievedRecord = _genresRepository2.Get(idOfInsertedGenre);

            Assert.AreEqual(null, retrievedRecord);
        }

    }
}
