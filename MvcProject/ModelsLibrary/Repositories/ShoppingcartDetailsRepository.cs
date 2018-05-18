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
            {   model.CustomerID,
                model.ProductID,
                model.Quantity
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
                model.CustomerID,
                model.ProductID
            });
        }

        public void DeleteAllForUser(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM [Shoppingcart Details] WHERE CustomerID = @CustomerID";

            connection.Execute(sql, new
            {
                model.CustomerID
            });
        }

        public void DeleteOneForUser(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM [Shoppingcart Details] WHERE CustomerID = @CustomerID AND ProductID = @ProductID";

            connection.Execute(sql, new
            {
                model.CustomerID,
                model.ProductID
            });
        }

        public ShoppingcartDetails FindById(int CustomerID, int ProductID)
        {//可找Quantity
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Shoppingcart Details] WHERE CustomerID = @CustomerID AND ProductID = @ProductID";

            var result = connection.Query<ShoppingcartDetails>(sql, new { CustomerID, ProductID }).ToList();
            
            if(result.Count() == 0)
            {
                return null;
            }

            return result.Single();
        }

        public IEnumerable<ShoppingcartDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Shoppingcart Details]";

            return connection.Query<ShoppingcartDetails>(sql);
        }

        public IEnumerable<ShoppingcartDetails> FindByCustomer(int CustomerID)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Shoppingcart Details] WHERE CustomerID = @CustomerID";

            var list = connection.Query<ShoppingcartDetails>(sql, new{CustomerID}).ToList();

            return list;
        }

        public decimal GetProductTotal(int Cid)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT SUM(p.UnitPrice * sp.Quantity) AS Total FROM[Shoppingcart Details] sp INNER JOIN Products p ON p.ProductID = sp.ProductID GROUP BY sp.CustomerID HAVING sp.CustomerID = @id";

            var list = connection.QueryFirst(sql, new { id = Cid });

            var result = Convert.ToDecimal(list.Total);

            return result;
        }
    }
}
