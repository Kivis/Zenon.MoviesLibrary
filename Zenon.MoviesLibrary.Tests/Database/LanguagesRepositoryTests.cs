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
        private LanguagesRepository _languagesRepository = new LanguagesRepository();

        [SetUp]
        public void SetUp()
        {
            _languagesRepository = new LanguagesRepository();
        }


        [Test]
        public void GetLanguage_GetsLanguageWithIdOne()
        {
            var language = _languagesRepository.GetLanguage(1);

            Assert.AreNotEqual(null, language);

        }

        [Test]
        public void GetLanguage_NormalFlow()
        {
            var language = _languagesRepository.GetLanguages();

            Assert.That(language.Count > 0);
        }

        [Test]
        public void InsertLanguages_NormalFlow()
        {
            var language = new Language()
            {
                Name = "MyTestLanguages" + Guid.NewGuid().ToString(),
            };

            _languagesRepository.InsertLanguage(language);

            var allLanguages = _languagesRepository.GetLanguages(); // 1 - effectivness, we don't need all records in db(possibly thousands records)

            var languageFromDb = allLanguages.FirstOrDefault(g => g.Name == language.Name);

            //  we check if only some record with defined name is returned
            // there could be more records with such name
            // we could do errors on object retrieval(other properties)
            //Assert.That(languageFromDb == null && 1 == 2);
            Assert.AreEqual(null, languageFromDb);
        }

        [Test]
        public void DeleteLanguageByID_DeleteById()
        {
            // AAA

            // Arrange
            // Act
            // Assert
            var language = new Language() { Name = "DeleteTest" };

            var newLanguageId = _languagesRepository.InsertLanguage(language);
            _languagesRepository.DeleteLanguageById(newLanguageId);
            var retrievedRecord = _languagesRepository.GetLanguage(newLanguageId);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
