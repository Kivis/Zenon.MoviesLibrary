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

        private readonly string _getOneQuery;
        private readonly string _getAllQuery;
        private readonly string _deleteOneQuery;
        private readonly string _insertStoredProcedureName;
        private readonly string _updateStoredProcedureName;

        public BaseRepository2()
        {
            var typeName = typeof(T).Name;
            var tableIdName = typeName + "_ID";
            var tableName = typeName + "s";
            _getOneQuery = $"SELECT * FROM {tableName} WHERE {tableIdName} = ";
            _getAllQuery = $"SELECT * FROM {tableName}";
            _deleteOneQuery = $"DELETE FROM { tableName} WHERE { tableIdName} = ";
            _insertStoredProcedureName = $"Insert{typeName}";
            _updateStoredProcedureName = $"Update{typeName}";
        }

        public T Get(int id, Func<SqlDataReader, T> mapEntity)
        {
            var queryString = _getOneQuery + id;

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
            List<T> entities = new List<T>();

            using (var connection = GetConnection())
            {
                var command = new SqlCommand(_getAllQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    while (reader.Read())
                        entities.Add(mapEntity(reader));

                reader.Close();
                return entities;
            }
        }

        public int Insert(SqlParameter[] paramList)
        {
            using (var connection = GetConnection())
            {
                var command = new SqlCommand(_insertStoredProcedureName, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(paramList);

                connection.Open();

                var returnValue = (int)command.ExecuteScalar();

                connection.Close();
                return returnValue;
            }
        }

        public void Update(SqlParameter[] paramList)
        {
            using (var connection = GetConnection())
            {
                var command = new SqlCommand(_updateStoredProcedureName, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(paramList);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteItem(int id)
        {
            var queryString = _deleteOneQuery + id;

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