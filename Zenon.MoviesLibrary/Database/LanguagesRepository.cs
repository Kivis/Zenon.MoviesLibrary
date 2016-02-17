using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.Models;
using System.Configuration;
namespace Zenon.MoviesLibrary.API.Database
{
    public class LanguagesRepository 
    {
        //private const string _connectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;
        public Language GetLanguage(int id)
        {
            var queryString =
                    "SELECT Language_ID, Name " +
                    "FROM Languages WHERE Language_ID = " + id;

            using (var connection = new SqlConnection(_connectionString))
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

            using (var connection = new SqlConnection(_connectionString))
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

        public void InsertLanguage(Language language)
        {
            var queryString =
                   "INSERT INTO Languages (Name) " +
                   "VALUES ('" + language.Name + "')";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}