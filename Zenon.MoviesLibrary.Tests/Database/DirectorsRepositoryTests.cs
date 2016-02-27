using System;
using FluentAssertions;
using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class DirectorsRepositoryTests
    {
        private readonly DirectorsRepository _directorsRepository = new DirectorsRepository();
        [Test]
        public void GetDirector_GetsDirectorWithIdOne()
        {
            var director = _directorsRepository.GetDirector(1);

            Assert.AreNotEqual(null, director);
        }
        [Test]
        public void GetDirector_NormalFlow()
        {
            var director = _directorsRepository.GetDirectors();

            Assert.That(director.Count > 0);
        }
        [Test]
        public void InsertDirector_NormalFlow()
        {
            var director = new Director()
            {
                FirstName = "TestFirstName" + Guid.NewGuid().ToString(),
                LastName = "TestLastName" + Guid.NewGuid().ToString()
            };

            director.DirectorId = _directorsRepository.InsertDirector(director);
            var newRecord = _directorsRepository.GetDirector(director.DirectorId);

            director.ShouldBeEquivalentTo(newRecord);
        }
        [Test]
        public void DeleteDirectorByID_DeleteById()
        {
            var director = new Director() {FirstName = "Delete", LastName = "Test"};

            var idOfInsertedMovie = _directorsRepository.InsertDirector(director);
            _directorsRepository.DeleteDirectorById(idOfInsertedMovie);
            var retrievedRecord = _directorsRepository.GetDirector(idOfInsertedMovie);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
