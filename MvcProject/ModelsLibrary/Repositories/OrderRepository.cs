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
            var result = connection.Execute(sql, 
                new {
                    model.OrderID,
                    model.OrderDay,
                    model.CustomerID,
                    model.Transport,
                    model.Payment,
                    model.Status,
                    model.StatusUpdateDay
                });

           /* SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"INSERT INTO [Order] 
                        VALUES (@OrderID , @OrderDay , @CustomerID , @Transport , @Payment , @Status , @StatusUpdateDay)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@OrderDay", model.OrderDay);
            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@Transport", model.Transport);
            command.Parameters.AddWithValue("@Payment", model.Payment);
            command.Parameters.AddWithValue("@Status", model.Status);
            command.Parameters.AddWithValue("@StatusUpdateDay", model.StatusUpdateDay);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            */
        }

        public void Update(Order model)  //修改訂單
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"UPDATE [Order] 
                        SET OrderDay = @OrderDay , CustomerID = @CustomerID , Transport = @Transport , Payment = @Payment , Status = @Status , StatusUpdateDay = @StatusUpdateDay 
                        WHERE OrderID = @OrderID";
            var result = connection.Execute(sql,
                new
                {
                    model.OrderID,
                    model.OrderDay,
                    model.CustomerID,
                    model.Transport,
                    model.Payment,
                    model.Status,
                    model.StatusUpdateDay
                });

            /*
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"UPDATE [Order] 
                        SET OrderDay = @OrderDay , CustomerID = @CustomerID , Transport = @Transport , Payment = @Payment , Status = @Status , StatusUpdateDay = @StatusUpdateDay 
                        WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@OrderDay", model.OrderDay);
            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@Transport", model.Transport);
            command.Parameters.AddWithValue("@Payment", model.Payment);
            command.Parameters.AddWithValue("@Status", model.Status);
            command.Parameters.AddWithValue("@StatusUpdateDay", model.StatusUpdateDay);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            */
        }


        public void UpdateStatus(Order model)  //修改訂單狀態
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"UPDATE [Order] 
                        SET Status = @Status , StatusUpdateDay = @StatusUpdateDay 
                        WHERE OrderID = @OrderID";
            var result = connection.Execute(sql,
                new
                {
                    model.OrderID,
                    model.Status,
                    model.StatusUpdateDay
                });

            /*
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"UPDATE [Order] 
                        SET Status = @Status , StatusUpdateDay = @StatusUpdateDay 
                        WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@Status", model.Status);
            command.Parameters.AddWithValue("@StatusUpdateDay", model.StatusUpdateDay);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            */
        }

        public Order CheckStatus(string orderId) //查詢訂單狀態
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"SELECT Status
                        FROM [Order]
                        WHERE OrderID = @OrderID";
            var result =  connection.QueryMultiple(sql , new {orderId});
            var orders = result.Read<Order>().Single();

            return orders;

            /*
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"SELECT Status
                        FROM [Order]
                        WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", orderId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Order).GetProperties();
            Order order = null;


            while (reader.Read())
            {
                order = new Order();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = "Status";
                    var property = properties.FirstOrDefault(
                        p => p.Name == fieldName);

                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(order,
                            reader.GetValue(i));
                }

            }

            reader.Close();

            return order;
*/
        }

        public Order FindById(string orderId) //用id查詢
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            var sql = @"SELECT * FROM [Order] 
                                    WHERE OrderID = @OrderID";
            var result = connection.QueryMultiple(sql, new { orderId });
            var orders = result.Read<Order>().Single();

            return orders;

            /*

                        var sql = @"SELECT * FROM [Order] 
                                    WHERE OrderID = @OrderID";

                        SqlCommand command = new SqlCommand(sql, connection);

                        command.Parameters.AddWithValue("@OrderID", orderId);

                        connection.Open();

                        var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        var properties = typeof(Order).GetProperties();
                        Order order = null;


                        while (reader.Read())
                        {
                            order = new Order();
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                var fieldName = reader.GetName(i);
                                var property = properties.FirstOrDefault(
                                    p => p.Name == fieldName);

                                if (property == null)
                                    continue;

                                if (!reader.IsDBNull(i))
                                    property.SetValue(order,
                                        reader.GetValue(i));
                            }

                        }

                        reader.Close();

                        return order;*/
        }

        public IEnumerable<Order> GetAll()  //查詢所有資料
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            return connection.Query<Order>("SELECT * FROM [Order]");

            /*
            var sql = "SELECT * FROM [Order]";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var orders = new List<Order>();

            while (reader.Read())
            {
                var order = new Order();
                order.OrderID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderID")));
                order.OrderDay = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("OrderDay")));
                order.CustomerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CustomerID")));
                order.Transport = reader.GetValue(reader.GetOrdinal("Transport")).ToString();
                order.Payment = reader.GetValue(reader.GetOrdinal("Payment")).ToString();
                order.Status = reader.GetValue(reader.GetOrdinal("Status")).ToString();
                order.StatusUpdateDay = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("StatusUpdateDay")));
                orders.Add(order);
            }

            reader.Close();

            return orders;
            */
        }
    }
}

