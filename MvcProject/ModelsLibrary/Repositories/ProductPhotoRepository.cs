using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelsLibrary.DtO_Models;
using Abstracts;
using Dapper;

namespace ModelsLibrary.Repositories
{
    public class ProductPhotoRepository : IRepository<ProductPhoto>
    {
        public void Create(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "INSERT INTO [Product Photo](ProductID, PhotoPath) VALUES (@ProductID, @PhotoPath)";
            connection.Execute(sql, new { model.ProductID, model.PhotoPath });
        }

        public void Update(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE [Product Photo] SET PhotoPath=@PhotoPath WHERE PhotoID=@PhotoID AND ProductID=@ProductID";
            connection.Execute(sql, new { model.PhotoID, model.ProductID, model.PhotoPath });
        }

        public void Delete(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM [Product Photo] WHERE PhotoID=@PhotoID";
            connection.Execute(sql, new { model.PhotoID });
        }

        public IEnumerable<ProductPhoto> FindById(int ProductID)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Product Photo] WHERE ProductID = @ProductID";
            var result = connection.QueryMultiple(sql, new { ProductID });
            var productphoto = result.Read<ProductPhoto>().ToList();

            return productphoto;
        }

        public IEnumerable<ProductPhoto> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");

            return connection.Query<ProductPhoto>("SELECT * FROM [Product Photo]");
        }
    }
}
