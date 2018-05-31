using Abstracts;
using Dapper;
using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Repositories
{
    public class OrderDetailsRepository : IRepository<OrderDetails>
    {

        private string sqlstr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public void Create(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
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
            SqlConnection connection = new SqlConnection(sqlstr);
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
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "DELETE FROM [Order Details] WHERE OrderID=@OrderID";
            connection.Execute(sql, new { model.OrderID });
        }

        public OrderDetails FindById(int OrderId)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM [Order Details] WHERE OrderID = @OrderID";
            var result = connection.QueryMultiple(sql, new { OrderId });
            var orderdetails = result.Read<OrderDetails>().Single();

            return orderdetails;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<OrderDetails>("SELECT * FROM [Order Details]");

        }

    }
}
