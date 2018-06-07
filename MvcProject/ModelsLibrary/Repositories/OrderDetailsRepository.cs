using Abstracts;
using Dapper;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.ViewModels;
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

        public IEnumerable<OrderDetails> FindById(int OrderId)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM [Order Details] WHERE OrderID = @OrderID";
            var result = connection.Query<OrderDetails>(sql, new { OrderId });

            return result;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<OrderDetails>("SELECT * FROM [Order Details]");

        }

        public IEnumerable<AdminOrderModel> FindOrderDetail(int OrderId)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = @"select p.ProductID,ph.PhotoPath,p.ProductName,od.Quantity,p.UnitPrice,(p.UnitPrice*od.Quantity) as Total
                        from [Order] o
                        inner join [Order Details] od on o.OrderID = od.OrderID 
                        inner join [Product Photo] ph on od.ProductID = ph.ProductID
                        inner join Products p on p.ProductID = ph.ProductID
                        Where o.OrderID = @OrderID";
            var result = connection.Query<AdminOrderModel>(sql, new { OrderId });

            return result;
        }

    }
}
