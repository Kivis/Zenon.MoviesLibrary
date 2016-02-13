using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class LanguagesRepository
    {
        private const string ConnectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";

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
            var queryString = "SELECT * FROM Languages";

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
    }
}