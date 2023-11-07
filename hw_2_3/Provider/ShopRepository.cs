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
    public class ShopRepository
    {
        private readonly ShopDBContext _dbContext = new();
        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=hw_3_wild_berries;Trusted_Connection=True;Encrypt=False;";
        private const string GetShopsSQL =
    @"SELECT * FROM Shops";
        private const string GetShopSQL =
    @"SELECT * FROM Shops
    WHERE Id = '{0}'";

        public List<DbShops> GetShopsEF() // get all table
        {
            return _dbContext.Shops.ToList();
        }

        public DbShops GetShopEF(Guid shopId) // get one with id
        {
            return _dbContext.Shops
            .AsNoTracking()// составляем запрос
            .Where(u => u.Id == shopId) // модифицируем запрос
            .FirstOrDefault(); // берем один из всех вернувшихся уже из памяти
        }

        public void CreateShop(DbShops shop) // create one
        {
            _dbContext.Shops.Add(shop);
            _dbContext.SaveChanges();
        }

        public void DeleteShop(Guid shopId) // delete one with id
        {
            var shop = _dbContext.Shops.Where(u => u.Id == shopId).FirstOrDefault();
            _dbContext.Remove(shop);
            _dbContext.SaveChanges();
        }

        public void EditShop(Guid shopId, string newName, string newOwnerInfo) // update one with
        {
            var shop = _dbContext.Shops.Where(u => u.Id == shopId).FirstOrDefault();

            if (newName != string.Empty)
            {
                shop.Name = newName;
            }

            if (newOwnerInfo != string.Empty)
            {
                shop.OwnerInfo = newOwnerInfo;
            }

            _dbContext.SaveChanges();
        }

        //public string GetShopsFromDB()
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var sqlCommand = new SqlCommand(GetShopsSQL, sqlConnection);

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

        //public string GetShop(Guid shopId)
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var formatedSQL = string.Format(GetShopSQL, shopId);
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