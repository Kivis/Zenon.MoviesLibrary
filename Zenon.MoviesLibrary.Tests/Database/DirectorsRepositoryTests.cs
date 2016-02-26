using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;


namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class DirectorsRepositoryTests
    {
        [Test]
        public void GetDirector_GetsDirectorWithIdOne()
        {
            var repository = new DirectorsRepository();

            var director = repository.GetDirector(1);

            Assert.AreNotEqual(null, director);

        }
        [Test]
        public void GetDirector_NormalFlow()
        {
            var repository = new DirectorsRepository();

            var director = repository.GetDirectors();

            Assert.That(director.Count > 0);

        }
        [Test]
        public void InsertDirector_NormalFlow()
        {
            var repository = new DirectorsRepository();
            var director = new Director()
            {
                FirstName = "MyTest" + Guid.NewGuid().ToString(),
                LastName = "MyTest" + Guid.NewGuid().ToString()
            };

            director.DirectorId = repository.InsertDirector(director);

            var newRecord = repository.GetDirector(director.DirectorId);
            director.ShouldBeEquivalentTo(newRecord);
        }
        [Test]
        public void DeleteDirectorByID_DeleteById()
        {
            var repository = new DirectorsRepository();

            var director = new Director() {FirstName = "Delete", LastName = "Test"};

            var idOfInsertedMovie = repository.InsertDirector(director);
            repository.DeleteDirectorById(idOfInsertedMovie);

            var getId = repository.GetDirector(idOfInsertedMovie);
            Assert.That(getId == null);

            //var allLanguages = repository.GetDirectors();

            //var genreFromDb = allLanguages.FirstOrDefault(g => g.DirectorId == director.DirectorId);
            //Assert.That(genreFromDb == null);

        }

    }
}
