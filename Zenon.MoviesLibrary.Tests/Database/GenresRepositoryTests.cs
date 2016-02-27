using NUnit.Framework;
using System;
using FluentAssertions;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class GenresRepositoryTests
    {
        private readonly GenresRepository _genresRepository = new GenresRepository();

        [Test]
        public void GetGenre_GetsGenreWithIdOne()
        {
            var genre = _genresRepository.GetGenre(1);

            Assert.AreNotEqual(null, genre);
        }

        [Test]
        public void GetGenres_NormalFlow()
        {
            var genre = _genresRepository.GetGenres();

            Assert.That(genre.Count > 0);
        }

        [Test]
        public void InsertGenre_NormalFlow()
        {
            var genre = new Genre() { Name = "MyTestGenre" + Guid.NewGuid().ToString() };
        
            genre.GenreId = _genresRepository.InsertGenre(genre);
            var newRecord = _genresRepository.GetGenre(genre.GenreId);

            genre.ShouldBeEquivalentTo(newRecord);
        }

        [Test]
        public void DeleteGenreByID_DeleteById()
        {
            var genre = new Genre() {Name = "DeleteTest"};

            var idOfInsertedGenre = _genresRepository.InsertGenre(genre);
            _genresRepository.DeleteGenreById(idOfInsertedGenre);
            var retrievedRecord = _genresRepository.GetGenre(idOfInsertedGenre);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
