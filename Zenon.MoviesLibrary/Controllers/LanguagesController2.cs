using System.Collections.Generic;
using System.Web.Http;
using Zenon.MoviesLibrary.API.Database;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Controllers
{
    public class LanguagesController2 : ApiController
    {
        private readonly LanguagesRepository2 _languagesRepository2 = new LanguagesRepository2();

        // GET: Languages
        public List<Language> Get()
        {
            return _languagesRepository2.Get();
        }

        // GET: Language by Id
        public Language Get(int id)
        {
            return _languagesRepository2.Get(id);
        }
        // INSERT: Insert language name
        [HttpPost]
        public void Insert([FromBody]Language language)
        {
            _languagesRepository2.Insert(language);
            
        }
        // DELETE: DELETE language by id
        [HttpDelete]
        public void Delete(int id)
        {
            _languagesRepository2.Delete(id);

        }
        // UPDATE
        [HttpPut]
        public void Update(Language language)
        {
            _languagesRepository2.Update(language);
        }
    }
}