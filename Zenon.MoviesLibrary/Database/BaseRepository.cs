using System.Configuration;
using System.Data.SqlClient;
using System.Web.ModelBinding;
using Microsoft.Ajax.Utilities;


namespace Zenon.MoviesLibrary.API.Database
{
    public class BaseRepository
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public int Insert(string queryString)
        {
            using (var connection = GetConnection()) // this part repeats in other method, but it shouldn't
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var returnValue = (int)command.ExecuteScalar();

                connection.Close();
                return returnValue;
            }
        }

        public void DeleteRow(string queryString)
        {
            using (var connection = GetConnection())
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        //public void Execute(string queryString, Operation operation)
        //{
        //    using (var connection = GetConnection())
        //    {
        //        var command = new SqlCommand(queryString, connection);
        //        connection.Open();
        //        if (operation == Operation.Insert)
        //        {
        //            var returnValue = (int)command.ExecuteScalar();
        //        }
        //        else if (operation == Operation.Delete)
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        connection.Close();
        //    }
        //}

    }

    public enum Operation
    {
        Insert,
        Delete
    }
}