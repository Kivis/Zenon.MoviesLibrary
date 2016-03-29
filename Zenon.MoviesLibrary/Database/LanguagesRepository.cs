using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class LanguagesRepository : BaseRepository
    {
        public Language GetLanguage(int id)
        {
            var queryString =
                    "SELECT Language_ID, Name " +
                    "FROM Languages WHERE Language_ID = " + id;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Language language = null;
                if (reader.Read())
                    language = ReadLanguage(reader);

                reader.Close();

                return language;
            }
        }

        public List<Language> GetLanguages()
        {
            var queryString = 
                    "SELECT Language_ID, Name " +
                    "FROM Languages";

            var listOfLanguages = new List<Language>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var language = ReadLanguage(reader);
                        listOfLanguages.Add(language);
                    }
                }

                reader.Close();
            }
            return listOfLanguages;
        }
        private Language ReadLanguage(SqlDataReader reader)
        {
            return new Language
            {
                LanguageId = reader.GetInt32(0),
                Name = reader.GetString(1),
            };
        }

        public int InsertLanguage(Language language)
        {
            var queryString = string.Format("InsertLanguage '{0}'", language.Name);
            return ConnectionOfInsert(queryString);
        }

        public void DeleteLanguageById(int id)
        {
            var queryString =
                "DELETE FROM Languages " +
                "WHERE " +
                "Language_ID = "+ id ;

            ConnectionOfDelete(queryString);
        }
    }
}