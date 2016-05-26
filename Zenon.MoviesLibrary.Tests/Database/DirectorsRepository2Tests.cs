using System;
using FluentAssertions;
using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class DirectorsRepository2Tests
    {
        private readonly DirectorsRepository2 _directorsRepository2 = new DirectorsRepository2();
        [Test]
        public void GetDirector_GetsDirectorWithIdOne()
        {
            var director = _directorsRepository2.Get(1);

            Assert.AreNotEqual(null, director);
        }
        [Test]
        public void GetDirector_NormalFlow()
        {
            var director = _directorsRepository2.Get();

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
            director.DirectorId = _directorsRepository2.InsertDirector(director);
            var newRecord = _directorsRepository2.Get(director.DirectorId);

            director.ShouldBeEquivalentTo(newRecord);
        }
        [Test]
        public void DeleteDirectorByID_DeleteById()
        {
            var director = new Director() {FirstName = "Delete", LastName = "Test"};

            var idOfInsertedMovie = _directorsRepository2.InsertDirector(director);
            _directorsRepository2.Delete(idOfInsertedMovie);
            var retrievedRecord = _directorsRepository2.Get(idOfInsertedMovie);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
