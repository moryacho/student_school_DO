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
    public class ProductRepository
    {
        private readonly ProductsDBContext _dbContext = new();
        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=hw_3_wild_berries;Trusted_Connection=True;Encrypt=False;";
        private const string GetUsersSQL =
    @"SELECT * FROM Products";
        private const string GetUserSQL =
    @"SELECT * FROM Products
    WHERE Id = '{0}'";

        public List<DbProducts> GetProductsEF() // get all table
        {
            return _dbContext.Products.ToList();
        }

        public DbProducts GetProductEF(Guid productId) // get one with id
        {
            return _dbContext.Products
            .AsNoTracking()// составляем запрос
            .Where(u => u.Id == productId) // модифицируем запрос
            .FirstOrDefault(); // берем один из всех вернувшихся уже из памяти
        }

        public void CreateProduct(DbProducts product) // create one
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(Guid productId) // delete one with id
        {
            var product = _dbContext.Products.Where(u => u.Id == productId).FirstOrDefault();
            _dbContext.Remove(product);
            _dbContext.SaveChanges();
        }

        public void EditProduct(Guid productId, string newName, string newDescription, int newQuantityStock) // update one with
        {
            var product = _dbContext.Products.Where(u => u.Id == productId).FirstOrDefault();

            if (newName != string.Empty)
            {
                product.Name = newName;
            }

            if (newDescription != string.Empty)
            {
                product.Description = newDescription;
            }

            if (newQuantityStock >= 0)
            {
                product.QuantityStock = newQuantityStock;
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