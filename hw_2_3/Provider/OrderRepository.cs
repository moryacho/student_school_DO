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
    public class OrderRepository
    {
        private readonly OrderDBContext _dbContext = new();
        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=hw_3_wild_berries;Trusted_Connection=True;Encrypt=False;";
        private const string GetOrdersSQL =
    @"SELECT * FROM Orders";
        private const string GetOrderSQL =
    @"SELECT * FROM Orders
    WHERE Id = '{0}'";

        public List<DbOrders> GetOrdersEF() // get all table
        {
            return _dbContext.Orders.ToList();
        }

        public DbOrders GetOrderEF(Guid orderId) // get one with id
        {
            return _dbContext.Orders
            .AsNoTracking()// составляем запрос
            .Where(u => u.Id == orderId) // модифицируем запрос
            .FirstOrDefault(); // берем один из всех вернувшихся уже из памяти
        }

        public void CreateOrder(DbOrders order) // create one
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(Guid orderId) // delete one with id
        {
            var order = _dbContext.Orders.Where(u => u.Id == orderId).FirstOrDefault();
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        //public void EditOrder(Guid orderId, string newFirstName, string newLastName, string newCardNumber) // update one with
        //{
        //    var order = _dbContext.Orders.Where(u => u.Id == orderId).FirstOrDefault();

        //    if (newFirstName != string.Empty)
        //    {
        //        order.FirstName = newFirstName;
        //    }

        //    if (newLastName != string.Empty)
        //    {
        //        order.LastName = newLastName;
        //    }

        //    if (newCardNumber != string.Empty)
        //    {
        //        order.CardNumber = newCardNumber;
        //    }
        //    _dbContext.SaveChanges();
        //}

        //public string GetOrdersFromDB()
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var sqlCommand = new SqlCommand(GetOrdersSQL, sqlConnection);

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

        //public string GetOrder(Guid orderId)
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var formatedSQL = string.Format(GetOrderSQL, orderId);
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