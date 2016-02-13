using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class DirectorsRepository
    {
        private const string ConnectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";

        public Director GetDirector(int id)
        {
            var queryString =
                "SELECT Director_ID, FirstName, LastName " +
                "FROM Directors WHERE Director_ID = " + id;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Director director = null;
                if (reader.Read())
                    director = ReadDirector(reader);

                reader.Close();

                return director;
            }
        }

        public List<Director> GetDirectors()
        {
            var queryString = "SELECT * FROM Directors";

            var listOfDirectors = new List<Director>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var director = ReadDirector(reader);
                        listOfDirectors.Add(director);
                    }
                }

                reader.Close();
            }
            return listOfDirectors;
        }
        private Director ReadDirector(SqlDataReader reader)
        {
            return new Director
            {
                DirectorId = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
            };
        }
    }
}

