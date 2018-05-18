using Abstracts;
using Dapper;
using ModelsLibrary.DtO_Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ModelsLibrary.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private string _connectionString = "data source =. ; database = BuildSchool ; integrated security=true";

        public void Create(Order model)  //新增訂單
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"INSERT INTO [Order] 
                        VALUES (@OrderID , @OrderDay , @CustomerID , @Transport , @Payment , @Status , @StatusUpdateDay)";
            connection.Execute(sql, 
                new {
                    model.OrderID,
                    model.OrderDay,
                    model.CustomerID,
                    model.Transport,
                    model.Payment,
                    model.Status,
                    model.StatusUpdateDay
                });

        }

       

        public void UpdateStatus(Order model)  //修改訂單狀態
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"UPDATE [Order] 
                        SET Status = @Status , StatusUpdateDay = GETDATE()
                        WHERE OrderID = @OrderID";
            connection.Execute(sql,
                new
                {
                    model.OrderID,
                    model.Status,
                });

        }

        public Order CheckStatus(int orderId) //查詢訂單狀態
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"SELECT Status
                        FROM [Order]
                        WHERE OrderID = @OrderID";
            var result =  connection.QueryMultiple(sql , new {orderId});
            var orders = result.Read<Order>().Single();

            return orders;

        }

        public Order FindById(int orderId) //用id查詢
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"SELECT * FROM [Order] 
                                    WHERE OrderID = @OrderID";
            var result = connection.QueryMultiple(sql, new { orderId });
            var orders = result.Read<Order>().Single();

            return orders;

            
        }

        public IEnumerable<Order> GetAll()  //查詢所有資料
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            return connection.Query<Order>("SELECT * FROM [Order]");

        }
    }
}

