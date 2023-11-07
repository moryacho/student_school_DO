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
    public class PickUpPointRepository
    {
        private readonly PickUpPointDBContext _dbContext = new();
        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=hw_3_wild_berries;Trusted_Connection=True;Encrypt=False;";
        private const string GetPickUpPointsSQL =
    @"SELECT * FROM PickUpPoints";
        private const string GetPickUpPointSQL =
    @"SELECT * FROM PickUpPoints
    WHERE Id = '{0}'";

        public List<DbPickUpPoints> GetPickUpPointsEF() // get all table
        {
            return _dbContext.PickUpPoints.ToList();
        }

        public DbPickUpPoints GetPickUpPointEF(Guid pickUpPointId) // get one with id
        {
            return _dbContext.PickUpPoints
            .AsNoTracking()// составляем запрос
            .Where(u => u.Id == pickUpPointId) // модифицируем запрос
            .FirstOrDefault(); // берем один из всех вернувшихся уже из памяти
        }

        public void CreatePickUpPoint(DbPickUpPoints pickUpPoint) // create one
        {
            _dbContext.PickUpPoints.Add(pickUpPoint);
            _dbContext.SaveChanges();
        }

        public void DeletePickUpPoint(Guid pickUpPointId) // delete one with id
        {
            var pickUpPoint = _dbContext.PickUpPoints.Where(u => u.Id == pickUpPointId).FirstOrDefault();
            _dbContext.Remove(pickUpPoint);
            _dbContext.SaveChanges();
        }

        public void EditPickUpPoint(Guid pickUpPointId, string newAdress) // update one with
        {
            var pickUpPoint = _dbContext.PickUpPoints.Where(u => u.Id == pickUpPointId).FirstOrDefault();

            if (newAdress != string.Empty)
            {
                pickUpPoint.Adress = newAdress;
            }

            _dbContext.SaveChanges();
        }

        //public string GetPickUpPointsFromDB()
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var sqlCommand = new SqlCommand(GetPickUpPointsSQL, sqlConnection);

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

        //public string GetPickUpPoint(Guid pickUpPointId)
        //{
        //    var result = string.Empty;

        //    using var sqlConnection = new SqlConnection(ConnectionString);
        //    var formatedSQL = string.Format(GetPickUpPointSQL, pickUpPointId);
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