using System;
using System.Linq;
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
           
            repository.InsertDirector(director);

            var allDirectors = repository.GetDirectors();

            var directorFromDb = allDirectors.FirstOrDefault(g => g.FirstName == director.FirstName);
            Assert.That(directorFromDb != null);
        }

    }
}
