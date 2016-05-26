using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Zenon.MoviesLibrary.API.Database
{
    public class BaseRepository2<T> where T : class
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;

        private readonly string _tableName = typeof (T).Name + "s";
        private readonly string _tableIdName = typeof (T).Name + "_ID";

        public T Get(int id, Func<SqlDataReader, T> mapEntity)
        {
            var queryString = $"SELECT * FROM {_tableName} WHERE {_tableIdName} = {id}";

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

        public List<T> GetItems( Func<SqlDataReader, T> mapEntity)
        {

            var queryString = $"SELECT {_tableIdName}, Name FROM {_tableName}";

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

        public int Insert(List<SqlParameter> paramList)
        {
            
            var insertName = typeof(T).Name;

            using (var connection = GetConnection())
            {
                var command = new SqlCommand("Insert" + insertName, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(paramList.ToArray());

                connection.Open();

                var returnValue = (int)command.ExecuteScalar();

                connection.Close();
                return returnValue;
            }

            //var insertName = typeof(T).Name;

            //var queryString = string.Format("Insert" + insertName + " '{0}'", objName);

            //using (var connection = GetConnection())
            //{
            //    var command = new SqlCommand(queryString, connection);
            //    connection.Open();

            //    var returnValue = (int)command.ExecuteScalar();

            //    connection.Close();
            //    return returnValue;
            //}
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int id)
        {
            var queryString = "DELETE FROM " + _tableName + " WHERE " + _tableIdName + " = " + id;

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
            return new SqlConnection(_connectionString);
        }
    }
}