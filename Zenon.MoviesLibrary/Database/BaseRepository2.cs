using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Zenon.MoviesLibrary.API.Database
{
    public class BaseRepository2<T> where T : class
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;

        public T Get(string queryString, Func<SqlDataReader, T> mapEntity)
        {
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

        public int Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}