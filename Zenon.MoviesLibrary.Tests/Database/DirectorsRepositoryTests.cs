using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;


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

    }
}
