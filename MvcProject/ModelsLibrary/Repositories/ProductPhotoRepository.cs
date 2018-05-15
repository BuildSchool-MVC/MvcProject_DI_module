using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelsLibrary.DtO_Models;
using Abstracts;

namespace ModelsLibrary.Repositories
{
    public class ProductPhotoRepository : IRepository<ProductPhoto>
    {
        public void Create(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "INSERT INTO ProductPhoto VALUES (@PhotoID, @ProductID, @PhotoPath)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@PhotoID", model.PhotoID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@PhotoPath", model.PhotoPath);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE ProductPhoto SET PhotoID=@PhotoID, ProductID=@ProductID, PhotoPath=@PhotoPath";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@PhotoID", model.PhotoID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@PhotoPath", model.PhotoPath);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM ProductPhoto WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", model.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<ProductPhoto> FindById(int ProductID)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM ProductPhoto WHERE ProductID = @ProductID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", ProductID);
            
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var Photos = new List<ProductPhoto>();

            while (reader.Read())
            {
                var Photo = new ProductPhoto();
                Photo.PhotoID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("PhotoID")));
                Photo.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                Photo.PhotoPath = reader.GetValue(reader.GetOrdinal("PhotoPath")).ToString();
                Photos.Add(Photo);
            }

            reader.Close();

            return Photos;
        }

        public IEnumerable<ProductPhoto> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM ProductPhoto";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var Photos = new List<ProductPhoto>();

            while (reader.Read())
            {
                var Photo = new ProductPhoto();
                Photo.PhotoID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("PhotoID")));
                Photo.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                Photo.PhotoPath = reader.GetValue(reader.GetOrdinal("PhotoPath")).ToString();
                Photos.Add(Photo);
            }

            reader.Close();

            return Photos;
        }
    }
}
