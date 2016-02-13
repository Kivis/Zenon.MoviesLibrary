using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;

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
    }
}
