using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;

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
    }
}
