using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Abstracts;
using SimpleInjector;
using System.Configuration;

namespace ModelsLibrary.Repositories
{
    public class ProductsRepository : IRepository<Products>
    {

        private string sqlstr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = @"INSERT INTO Products (ProductName,CategoryID,UnitPrice,UnitsInStock,Size,Color,Uptime,ProductDetails)
                                            VALUES (@ProductName,@CategoryID,@UnitPrice,@UnitsInStock,@Size,@Color,@Uptime,@ProductDetails)";
            connection.Execute(sql, new { model.ProductName, model.CategoryID, model.UnitPrice, model.UnitsInStock, model.Size, model.Color, model.Uptime, model.ProductDetails });
        }

        public void Delete(Products model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = @"DELETE FROM Products WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID });
        }

        public void UpdateUnitPrice(Products model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Products SET UnitPrice=@UnitPrice WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID, model.UnitPrice });
        }

        public void UpdateStockPplus(Products model, int input)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Products SET UnitsInStock=UnitsInStock+@input WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID, input });
        }

        public void UpdateStockPminus(Products model, int input)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Products SET UnitsInStock=UnitsInStock-@input WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID, input });
        }

        public void UpdateProductDetails(Products model, string ProductDetails)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Products SET ProductDetails=@ProductDetails WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID, ProductDetails });
        }

        public void UpdateDowntime(Products model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Products SET Downtime=@Downtime WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID, model.Downtime });
        }

        public Products FindByID(int productid)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            var result = connection.QueryMultiple(sql, new { productid });
            var products = result.Read<Products>().Single();
            return products;
        }

        public IEnumerable<Products> FindByName(string ProductName)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<Products>
                ("SELECT * FROM Products WHERE ProductName = @ProductName", new { ProductName });
        }

        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<Products>("SELECT * FROM Products");
        }

        public IEnumerable<Products> GetbyColor(string Color)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM Products WHERE Color=@Color";
            var result = connection.QueryMultiple(sql, new { Color });
            var products = result.Read<Products>().ToList();
            return products;
        }

        public IEnumerable<Products> GetbyProductName(string Name)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM Products WHERE ProductName LIKE '%'+ @Name +'%'";
            var result = connection.QueryMultiple(sql, new { Name });
            var products = result.Read<Products>().ToList();
            return products;
        }

        public IEnumerable<Products> GetSizebyProductNamebyColor(string name, string color)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT Size FROM Products WHERE ProductName=@Name AND Color=@Color";
            var result = connection.QueryMultiple(sql, new { name, color });
            var products = result.Read<Products>().ToList();
            return products;
        }

        public bool CheckStock(int productid, int carquantity)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            var result = connection.QueryMultiple(sql, new { productid });
            var products = result.Read<Products>().Single();

            if (products.UnitsInStock - carquantity < 0)
            {
                return false;
            }

            return true;
        }

        public Products FindIdByName(string ProductName, string Size, string Color)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "select ProductID from Products where ProductName = @ProductName and Size = @Size and Color = @Color";
            var result = connection.QueryMultiple(sql, new { ProductName, Size, Color });
            var products = result.Read<Products>().ToList().First();
            return products;
        }

        public IEnumerable<Products> GetBestProducts()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<Products>(@"select TOP 12
                                                od.ProductID
                                                from[Product Photo] ph
                                                inner join[Order Details] od on od.ProductID = ph.ProductID
                                                group by od.ProductID, ph.PhotoPath
                                                order by SUM(Quantity) desc");

        }

        public IEnumerable<Products> GetNewProducts()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<Products>(@"select Top 12
                                                ProductID
                                                from Products
                                                order by Uptime desc");
        }

        public void Update(Products model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Products SET ProductName = @ProductName" +
                            ", CategoryID = @CategoryID" +
                            ", UnitPrice = @UnitPrice" +
                            ", UnitsInStock = @UnitsInStock" +
                            ", Size = @Size, Color = @Color" +
                            ", ProductDetails = @ProductDetails" +
                            " WHERE ProductID = @ProductID";
            connection.Execute(sql,
                new
                {
                    model.ProductID,
                    model.ProductName,
                    model.CategoryID,
                    model.UnitPrice,
                    model.UnitsInStock,
                    model.Color,
                    model.ProductDetails,
                    model.Size
                });
        }
    }
}
