using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class LanguagesRepositoryTests
    {
        [Test]
        public void GetLanguage_GetsLanguageWithIdOne()
        {
            var repository = new LanguagesRepository();

            var language = repository.GetLanguage(1);

            Assert.AreNotEqual(null, language);

        }

        [Test]
        public void GetLanguage_NormalFlow()
        {
            var repository = new LanguagesRepository();

            var language = repository.GetLanguages();

            Assert.That(language.Count > 0);
        }
    }
}
