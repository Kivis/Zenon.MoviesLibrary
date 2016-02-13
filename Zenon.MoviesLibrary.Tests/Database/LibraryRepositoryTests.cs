using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Zenon.MoviesLibrary.API.Database
{
   [TestFixture]
    class LibraryRepositoryTests
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
