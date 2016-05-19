using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Zenon.MoviesLibrary.API.Database
{
    public class BaseRepository2<T> where T : class
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;

        protected readonly string table = typeof (T).Name + "s";
        protected readonly string tableIdName = typeof (T).Name + "_ID";

        public T Get(int id, Func<SqlDataReader, T> mapEntity)
        {
            //var table = typeof(T).Name + "s";
            //var tableIdName = typeof(T).Name + "_ID";

            var queryString = "SELECT * FROM " + table + " WHERE " + tableIdName + " = " + id;

            using (var connection = GetConnection())
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                T entity = null;
                if (reader.Read())
                    entity = mapEntity(reader);

                reader.Close();

                return entity;
            }
        }

        public List<T> GetItems(string queryString, Func<SqlDataReader, T> mapEntity)
        {
            List<T> entities = new List<T>();

            using (var connection = GetConnection())
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    while (reader.Read())
                        entities.Add(mapEntity(reader));

                reader.Close();
                return entities;
            }
        }

        public int Insert(T obj, string objName)
        {
            var insertName = typeof(T).Name;

            var queryString = string.Format("Insert" + insertName + " '{0}'", objName);

            using (var connection = GetConnection())
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var returnValue = (int)command.ExecuteScalar();

                connection.Close();
                return returnValue;
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete(T obj, int id)
        {
            var queryString = "DELETE FROM " + table + " WHERE " + tableIdName + " = " + id;

            using (var connection = GetConnection())
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}