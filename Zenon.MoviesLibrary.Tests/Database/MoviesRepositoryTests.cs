using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;

namespace Zenon.MoviesLibrary.Tests
{
    [TestFixture]
    public class MoviesRepositoryTests
    {
        [Test]
        public void GetMovie_GetsMovieWithIdOne()
        {
            var repository = new MoviesRepository();

            var movie = repository.GetMovie(1);

            Assert.AreNotEqual(null, movie);
        }

        [Test]
        public void GetMovies_NormalFlow()
        {
            var repository = new MoviesRepository();

            var movie = repository.GetMovies();

            Assert.That(movie.Count > 0);
        }
    }
}
