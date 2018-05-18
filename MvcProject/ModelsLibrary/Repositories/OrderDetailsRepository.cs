using Abstracts;
using Dapper;
using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Repositories
{
    public class OrderDetailsRepository : IRepository<OrderDetails>
    {
        public void Create(OrderDetails model)
        {
            var connection = new SqlConnection("data source=.;database=BuildSchool;integrated security=true");
            var sql = @"INSERT INTO [Order Details] (OrderID,ProductID,Quantity)
                        VALUES (@OrderID, @ProductID, @Quantity)";
            connection.Execute(sql,
                new
                {
                    model.OrderID,
                    model.ProductID,
                    model.Quantity
                });
        }

        public void Update(OrderDetails model)
        {
            var connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE [Order Details] SET ProductID=@ProductID, Quantity=@Quantity where OrderID=@OrderID";
            connection.Execute(sql,
                new
                {
                    model.OrderID,
                    model.ProductID,
                    model.Quantity
                });
        }

        public void Delete(OrderDetails model)
        {
            var connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM [Order Details] WHERE OrderID=@OrderID";
            connection.Execute(sql, new { model.OrderID });
        }

        public OrderDetails FindById(int OrderId)
        {
            var connection = new SqlConnection("data source=.; database=BuildSchool; integrated security=true");
           
            var sql = "SELECT * FROM [Order Details] WHERE OrderID = @OrderID";
            var result = connection.QueryMultiple(sql, new { OrderId });
            var orderdetails = result.Read<OrderDetails>().Single();

            return orderdetails;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            var connection = new SqlConnection("data source=.; database=BuildSchool; integrated security=true");
            return connection.Query<OrderDetails>("SELECT * FROM [Order Details]");

        }
    }
}
