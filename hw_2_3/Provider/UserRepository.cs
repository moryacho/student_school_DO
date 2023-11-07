using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    public class UserRepository
    {
        private readonly UserDBContext _dbContext = new();
        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=hw_3_wild_berries;Trusted_Connection=True;Encrypt=False;";
        private const string GetUsersSQL =
    @"SELECT * FROM Users";
        private const string GetUserSQL =
    @"SELECT * FROM Users
    WHERE Id = '{0}'";

        public List<DbUsers> GetUsersEF() // get all table
        {
            return _dbContext.Users.ToList();
        }

        public DbUsers GetUserEF(Guid userId) // get one with id
        {
            return _dbContext.Users
            .AsNoTracking()// составляем запрос
            .Where(u => u.Id == userId) // модифицируем запрос
            .FirstOrDefault(); // берем один из всех вернувшихся уже из памяти
        }

        public void CreateUser(DbUsers user) // create one
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(Guid userId) // delete one with id
        {
            var user = _dbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public void EditUser(Guid userId, string newFirstName, string newLastName, string newCardNumber) // update one with
        {
            var user = _dbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

            if (newFirstName != string.Empty)
            {
                user.FirstName = newFirstName;
            }

            if (newLastName != string.Empty)
            {
                user.LastName = newLastName;
            }

            if (newCardNumber != string.Empty)
            {
                user.CardNumber = newCardNumber;
            }
            _dbContext.SaveChanges();
        }

        //public string GetUsersFromDB()
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var sqlCommand = new SqlCommand(GetUsersSQL, sqlConnection);

        //    sqlConnection.Open();
        //    using var sqlDataReader = sqlCommand.ExecuteReader();

        //    while (sqlDataReader.Read())
        //    {
        //        result += sqlDataReader["Id"];
        //        result += " ";
        //        result += sqlDataReader["FirstName"];
        //        result += " ";
        //        result += sqlDataReader["LastName"];
        //        result += "\n";
        //    }

        //    return result;
        //}

        //public string GetUser(Guid userId)
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var formatedSQL = string.Format(GetUserSQL, userId);
        //    var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        //    sqlConnection.Open();
        //    using var sqlDataReader = sqlCommand.ExecuteReader();

        //    while (sqlDataReader.Read())
        //    {
        //        result += sqlDataReader["Id"];
        //        result += " ";
        //        result += sqlDataReader["FirstName"];
        //        result += " ";
        //        result += sqlDataReader["LastName"];
        //    }

        //    return result;
        //}
    }
}