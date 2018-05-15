using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelsLibrary.DtO_Models;

namespace ModelsLibrary.Repositories
{
    public class ShoppingcartDetailsRepository
    {
        public void Create(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "INSERT INTO ShoppingcartDetails VALUES (@CustomerID, @ProductID, @Quantity)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE ShoppingcartDetails SET CustomerID=@CustomerID, ProductID=@ProductID, Quantity=@Quantity";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(ShoppingcartDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "DELETE FROM ShoppingcartDetails WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public ShoppingcartDetails FindById(int CustomerID, int ProductID)
        {//可找Quantity
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM ShoppingcartDetails WHERE CustomerID = @CustomerID && ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@ProductID", ProductID);

            connection.Open();

            var properties = typeof(ProductPhoto).GetProperties();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            ShoppingcartDetails Cart = null;

            while (reader.Read())
            {
                Cart = new ShoppingcartDetails();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);

                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(Cart, reader.GetValue(i));
                }
            }

            reader.Close();

            return Cart;
        }

        public IEnumerable<ShoppingcartDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM ShoppingcartDetails";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var Carts = new List<ShoppingcartDetails>();

            while (reader.Read())
            {
                var Cart = new ShoppingcartDetails();
                Cart.CustomerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CustomerID")));
                Cart.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                Cart.Quantity = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Quantity")));
                Carts.Add(Cart);
            }

            reader.Close();

            return Carts;
        }

        public decimal GetProductTotal (ShoppingcartDetails Cart)
        {
            decimal Total = 0;
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Products WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProductID", Cart.ProductID);

            connection.Open();

            var properties = typeof(Products).GetProperties();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            Products Pt = null;

            while (reader.Read())
            {
                Pt = new Products();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);

                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(Pt, reader.GetValue(i));
                }
            }

            reader.Close();
            Total = Cart.Quantity * Pt.UnitPrice;
            return Total;
        }
    }
}
