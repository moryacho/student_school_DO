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
    public class StockRepository
    {
        private readonly StockDBContext _dbContext = new();
        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=hw_3_wild_berries;Trusted_Connection=True;Encrypt=False;";
        private const string GetStocksSQL =
    @"SELECT * FROM Stocks";
        private const string GetStockSQL =
    @"SELECT * FROM Stocks
    WHERE Id = '{0}'";

        public List<DbStocks> GetStocksEF() // get all table
        {
            return _dbContext.Stocks.ToList();
        }

        public DbStocks GetStockEF(Guid stockId) // get one with id
        {
            return _dbContext.Stocks
            .AsNoTracking()// составляем запрос
            .Where(u => u.Id == stockId) // модифицируем запрос
            .FirstOrDefault(); // берем один из всех вернувшихся уже из памяти
        }

        public void CreateStock(DbStocks stock) // create one
        {
            _dbContext.Stocks.Add(stock);
            _dbContext.SaveChanges();
        }

        public void DeleteStock(Guid stockId) // delete one with id
        {
            var stock = _dbContext.Stocks.Where(u => u.Id == stockId).FirstOrDefault();
            _dbContext.Remove(stock);
            _dbContext.SaveChanges();
        }

        public void EditStock(Guid stockId, string newName, string newAdress) // update one with
        {
            var stock = _dbContext.Stocks.Where(u => u.Id == stockId).FirstOrDefault();

            if (newName != string.Empty)
            {
                stock.Name = newName;
            }

            if (newAdress != string.Empty)
            {
                stock.Adress = newAdress;
            }

            _dbContext.SaveChanges();
        }

        //public string GetStocksFromDB()
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var sqlCommand = new SqlCommand(GetStocksSQL, sqlConnection);

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

        //public string GetStock(Guid stockId)
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var formatedSQL = string.Format(GetStockSQL, stockId);
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