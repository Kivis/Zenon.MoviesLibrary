using System;
using FluentAssertions;
using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class LanguagesRepositoryTests
    {
        private readonly LanguagesRepository _languagesRepository = new LanguagesRepository();

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
            var language = new Language(){ Name = "InsertTest" + Guid.NewGuid().ToString() };

            language.LanguageId = _languagesRepository.InsertLanguage(language);
            var newRecord = _languagesRepository.GetLanguage(language.LanguageId);

            language.ShouldBeEquivalentTo(newRecord);
        }

        [Test]
        public void DeleteLanguageByID_DeleteById()
        {
            var language = new Language() { Name = "DeleteTest" };

            var newLanguageId = _languagesRepository.InsertLanguage(language);
            _languagesRepository.DeleteLanguageById(newLanguageId);
            var retrievedRecord = _languagesRepository.GetLanguage(newLanguageId);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
