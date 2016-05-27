using System;
using FluentAssertions;
using NUnit.Framework;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Tests.Database
{
    [TestFixture]
    public class LanguagesRepository2Tests
    {
        private readonly LanguagesRepository2 _languagesRepository2 = new LanguagesRepository2();

        [Test]
        public void GetLanguage_GetsLanguageWithIdOne()
        {
            var language = _languagesRepository2.Get(1);

            Assert.AreNotEqual(null, language);
        }

        [Test]
        public void GetLanguage_NormalFlow()
        {
            var language = _languagesRepository2.Get();

            Assert.That(language.Count > 0);
        }

        [Test]
        public void InsertLanguages_NormalFlow()
        {
            var language = new Language(){ Name = "InsertTest" + Guid.NewGuid().ToString() };

            language.LanguageId = _languagesRepository2.Insert(language);
            var newRecord = _languagesRepository2.Get(language.LanguageId);

            language.ShouldBeEquivalentTo(newRecord);
        }

        [Test]
        public void UpdateLanguage_NormalFlow()
        {
            var language = new Language()
            {
                LanguageId = 82,
                Name = "InsertTest" + Guid.NewGuid().ToString()
            };

            _languagesRepository2.Update(language);
            var newRecord = _languagesRepository2.Get(language.LanguageId);

            language.ShouldBeEquivalentTo(newRecord);
        }

        [Test]
        public void DeleteLanguageByID_DeleteById()
        {
            var language = new Language() { Name = "DeleteTest" };

            var newLanguageId = _languagesRepository2.Insert(language);
            _languagesRepository2.Delete(newLanguageId);
            var retrievedRecord = _languagesRepository2.Get(newLanguageId);

            Assert.AreEqual(null, retrievedRecord);
        }
    }
}
