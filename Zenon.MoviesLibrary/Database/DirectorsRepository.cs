﻿using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class DirectorsRepository
    {
        //private const string _connectionString = @"Data Source=AK-PC\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;MultipleActiveResultSets=True;Application Name=MoviesLibrary";
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MoviesLibrary"].ConnectionString;
        public Director GetDirector(int id)
        {
            var queryString =
                    "SELECT Director_ID, FirstName, LastName " +
                    "FROM Directors WHERE Director_ID = " + id;

            using (var connection = new SqlConnection(_connectionString))
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
            var queryString = 
                    "SELECT Director_ID, FirstName, LastName " +
                    "FROM Directors";

            var listOfDirectors = new List<Director>();

            using (var connection = new SqlConnection(_connectionString))
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

        public void InsertDirector(Director director)
        {
            var queryString =
                   "IF NOT EXISTS (SELECT * FROM Directors " +
                   "WHERE " +
                   "FirstName = '" + director.FirstName + "' " +
                   "AND " +
                   "LastName = '" + director.LastName + "') " +
                   "BEGIN " +
                   "INSERT INTO Directors (FirstName, LastName) " +
                   "VALUES ('" + director.FirstName + "', '" + director.LastName + "' )" +
                   "END";



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

