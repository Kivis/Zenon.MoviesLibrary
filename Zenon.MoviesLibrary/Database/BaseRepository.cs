using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Zenon.MoviesLibrary.API.Database
{
    public class BaseRepository
    {
        protected readonly string _connectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;


        public int InsertionConnection(string queryString)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var returnValue = (int)command.ExecuteScalar();
                connection.Close();
                return returnValue;
            }
        }

        public void DeleteConnection(string queryString)
        {
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