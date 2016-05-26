﻿using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class LanguagesRepository2 : BaseRepository2<Language>
    {
        public Language Get(int id)
        {
            return Get(id, MapLanguage);
        }

        private Language MapLanguage(SqlDataReader reader)
        {
            return new Language
            {
                LanguageId = (int)reader["Language_ID"],
                Name = (string)reader["Name"],
            };
        }

        public List<Language> Get()
        {
            return GetItems(MapLanguage);
        }


        //public int Insert(Language language)
        //{
        //    List<SqlParameter> languageParameterList = new List<SqlParameter>();
        //    languageParameterList.Add(new SqlParameter("@Name", "Name"));

        //    return Insert(languageParameterList);
        //}

        public void Delete(int id)
        {
            DeleteItem(id);
        }
    }
}