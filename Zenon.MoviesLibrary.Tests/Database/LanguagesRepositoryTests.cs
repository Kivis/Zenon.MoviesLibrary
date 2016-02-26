using System;
using System.Linq;
using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

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

        [Test]
        public void InsertLanguages_NormalFlow()
        {
            var repository = new LanguagesRepository();

            var language = new Language() { Name = "MyTestLanguages" + Guid.NewGuid().ToString() };

            repository.InsertLanguage(language);

            var allLanguages = repository.GetLanguages();

            var languageFromDb = allLanguages.FirstOrDefault(g => g.Name == language.Name);

            Assert.That(languageFromDb != null);
        }

        [Test]
        public void DeleteLanguageByID_DeleteById()
        {
            var repository = new LanguagesRepository();

            var language = new Language() {Name = "DeleteTest"};
            
            repository.DeleteLanguageById(repository.InsertLanguage(language));

            var allLanguages = repository.GetLanguages();

            var languageFromDb = allLanguages.FirstOrDefault(g => g.Name == language.Name);

            Assert.That(languageFromDb == null);
        }
    }
}
