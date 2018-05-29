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
using System.Configuration;

namespace ModelsLibrary.Repositories
{
    public class ProductPhotoRepository : IRepository<ProductPhoto>
    {

        private string sqlstr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public void Create(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "INSERT INTO [Product Photo](ProductID, PhotoPath) VALUES (@ProductID, @PhotoPath)";
            connection.Execute(sql, new { model.ProductID, model.PhotoPath });
        }

        public void Update(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE [Product Photo] SET PhotoPath=@PhotoPath WHERE PhotoID=@PhotoID AND ProductID=@ProductID";
            connection.Execute(sql, new { model.PhotoID, model.ProductID, model.PhotoPath });
        }

        public void Delete(ProductPhoto model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "DELETE FROM [Product Photo] WHERE PhotoID=@PhotoID";
            connection.Execute(sql, new { model.PhotoID });
        }

        public IEnumerable<ProductPhoto> FindById(int ProductID)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM [Product Photo] WHERE ProductID = @ProductID";
            var result = connection.QueryMultiple(sql, new { ProductID });
            var productphoto = result.Read<ProductPhoto>().ToList();

            return productphoto;
        }

        public IEnumerable<ProductPhoto> GetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<ProductPhoto>("SELECT * FROM [Product Photo]");
        }

        public ProductPhoto FindPicById(int ProductID)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM [Product Photo] WHERE ProductID = @ProductID";
            var result = connection.QueryMultiple(sql, new { ProductID });
            var PhotoPath = result.Read<ProductPhoto>().Single();
            return PhotoPath;

        }
    }
}
