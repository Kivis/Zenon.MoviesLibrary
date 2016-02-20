﻿using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.Controllers
{
    public class LanguagesController : ApiController
    {
        private readonly LanguagesRepository _languagesRepository = new LanguagesRepository();

        // GET: Languages
        public List<Language> Get()
        {
            return _languagesRepository.GetLanguages();
        }

        // GET: Language by Id
        public Language Get(int id)
        {
            return _languagesRepository.GetLanguage(id);
        }
        // INSERT: Insert language name
        [HttpPost]
        public void Insert([FromBody]Language language)
        {
            _languagesRepository.InsertLanguage(language);
        }
    }
}