using System.Collections.Generic;
using System.Data.SqlClient;
using Zenon.MoviesLibrary.API.Models;

namespace Zenon.MoviesLibrary.API.Database
{
    public class DirectorsRepository2 : BaseRepository2<Director>
    {
        public Director Get(int id)
        {
            return Get(id, MapDirector);
        }

        public List<Director> Get()
        {
            return GetItems(MapDirector);
        }
        private Director MapDirector(SqlDataReader reader)
        {
            return new Director
            {
                DirectorId = (int)reader["Director_ID"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
            };
        }

        public int InsertDirector(Director director)
        {
            var directorParameterList = new[]
            {
                new SqlParameter("@FirstName", director.FirstName),
                new SqlParameter("@LastName", director.LastName)
            };

            return Insert(directorParameterList);
        }

        public void Delete(int id)
        {
            DeleteItem(id);
        }
    }
}

