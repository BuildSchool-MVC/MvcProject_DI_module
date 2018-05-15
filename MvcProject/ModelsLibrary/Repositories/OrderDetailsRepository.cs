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
    public class OrderDetailsRepository
    {
        public void Create(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                 "data source=.; database=BuildSchool; integrated security=true");
            var sql = "INSERT INTO OrderDetails VALUES (@OrderID, @ProductID, @Quantity)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
       
        public void Update(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE OrderDetails SET OrderID=@OrderID, ProductID=@ProductID, Quantity=@Quantity";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM OrderDetails WHERE Quantity = @Quantity";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<OrderDetails> FindById(string OrderId)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Order Details] WHERE OrderID=@OrderID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", OrderId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var orderdetails = new List<OrderDetails>();

            var properties = typeof(OrderDetails).GetProperties();
            OrderDetails orderdetail = null;

            while (reader.Read())
            {
                orderdetail = new OrderDetails();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault((p) => p.Name == fieldName);

                    if (property == null) continue;

                    if (!reader.IsDBNull(i)) property.SetValue(orderdetail, reader.GetValue(i));
                }
                orderdetails.Add(orderdetail);
            }
            reader.Close();
            return orderdetails;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM [Order Details]";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var orderdetails = new List<OrderDetails>();

            while (reader.Read())
            {
                var orderdetail = new OrderDetails();
                orderdetail.OrderID = (int)reader.GetValue(reader.GetOrdinal("OrderID"));
                orderdetail.ProductID = (int)reader.GetValue(reader.GetOrdinal("ProductID"));
                orderdetail.Quantity = (int)reader.GetValue(reader.GetOrdinal("Quantity"));

                orderdetails.Add(orderdetail);
            }

            reader.Close();

            return orderdetails;

        }
    }
}
