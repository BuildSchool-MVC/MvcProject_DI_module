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
    public class ShoppingcartDetailsRepository : IRepository<ShoppingcartDetails>
    {
        public void Create(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "INSERT INTO [Shoppingcart Details] VALUES (@CustomerID, @ProductID, @Quantity)";

            connection.Execute(sql, new
            {   CustomerID = model.CustomerID,
                ProductID = model.ProductID,
                Quantity = model.Quantity
            });
        }

        public void Update(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE [Shoppingcart Details] SET Quantity = Quantity+@amount where CustomerID = @CustomerID AND ProductID = @ProductID";

            connection.Execute(sql, new
            {
                amount = model.Quantity,
                CustomerID = model.CustomerID,
                ProductID = model.ProductID
            });
        }

        public void DeleteAllForUser(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM [Shoppingcart Details] WHERE CustomerID = @CustomerID";

            connection.Execute(sql, new
            {
                CustomerID = model.CustomerID
            });
        }

        public void DeleteOneForUser(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM [Shoppingcart Details] WHERE CustomerID = @CustomerID AND ProductID = @ProductID";

            connection.Execute(sql, new
            {
                CustomerID = model.CustomerID,
                ProductID = model.ProductID
            });
        }

        public ShoppingcartDetails FindById(int CustomerID, int ProductID)
        {//可找Quantity
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Shoppingcart Details] WHERE CustomerID = @CustomerID AND ProductID = @ProductID";

            var list = connection.Query<ShoppingcartDetails>(sql, new
            {
                CustomerID = CustomerID,
                ProductID = ProductID
            }).ToList();

            return list.First();
        }

        public IEnumerable<ShoppingcartDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Shoppingcart Details]";

            return connection.Query<ShoppingcartDetails>(sql);
        }

        public decimal GetProductTotal(int Cid)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT SUM(p.UnitPrice * sp.Quantity) FROM[Shoppingcart Details] sp INNER JOIN Products p ON p.ProductID = sp.ProductID GROUP BY sp.CustomerID HAVING sp.CustomerID = @id";

            var list = connection.Query(sql, new { id = Cid }).ToList();

            return list.First();
        }
    }
}
