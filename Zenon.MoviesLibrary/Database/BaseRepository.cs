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
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;

        public int ConnectionOfInsert(string queryString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var returnValue = (int)command.ExecuteScalar();
                connection.Close();
                return returnValue;
            }
        }

        public void ConnectionOfDelete(string queryString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}