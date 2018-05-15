using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelsLibrary.DtO_Models;
using Dapper;

namespace ModelsLibrary.Repositories
{
   public class CustomerRepository
    {
        public void Cterae(Customer model)
        {
            var connection = new SqlConnection("data source=.;database=BuildSchool;integrated security=true");
            var sql = "INSERT INTO Customer VALUES(@CustomerID,@CustomerName,@Birthday,@Password,@ShoppingCash,@Account,@Phone,@Email)";
            var result = connection.Execute(sql, 
                new {
                        model.CustomerID,
                        model.CustomerName,
                        model.Birthday,
                        model.Password,
                        model.ShoppingCash,
                        model.Account,
                        model.Phone,
                        model.Email
                    });
           // connection.Execute(sql);
            //SqlConnection connection = new SqlConnection(
            //    "data source=.;database=BuildSchool;integrated security=true");
            //var sql = "INSERT INTO Customer VALUES(@CustomerID,@CustomerName,@Birthday,@Password,@ShoppingCash,@Account,@Phone,@Email)";
            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            //command.Parameters.AddWithValue("@CustomerName", model.CustomerName);
            //command.Parameters.AddWithValue("@Birthday", model.Birthday);
            //command.Parameters.AddWithValue("@Account", model.Account);
            //command.Parameters.AddWithValue("@Password", model.Password);
            //command.Parameters.AddWithValue("@ShoppingCash", model.ShoppingCash);
            //command.Parameters.AddWithValue("@Phone", model.Phone);
            //command.Parameters.AddWithValue("@Email", model.Email);         
            //connection.Open();
            // command.ExecuteNonQuery();        
            //connection.Close();
        }

        public void Update(Customer model)
        {
            var connection = new SqlConnection("data source=.;database=BuildSchool;integrated security=true");
            var sql = "UPDATE Customer SET CustomerName=@CustomerName,Password=@Password,ShoppingCash=@ShoppingCash,Email=@Email,Phone=@Phone WHERE CustomerID=@CustomerID";
            var result = connection.Execute(sql,
                new {
                        model.CustomerID,
                        model.CustomerName,
                        model.Password,
                        model.ShoppingCash,
                        model.Email,
                        model.Phone
                    });
            //SqlConnection connection = new SqlConnection(
            //    "data source=.;database=BuildSchool;integrated security=true");
            //var sql = "UPDATE Customer SET CustomerName=@CustomerName,Password=@Password,ShoppingCash=@ShoppingCash,Email=@Email,Phone=@Phone WHERE CustomerID=@CustomerID";
            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            //command.Parameters.AddWithValue("@CustomerName", model.CustomerName);        
            //command.Parameters.AddWithValue("@Password", model.Password);
            //command.Parameters.AddWithValue("@ShoppingCash", model.ShoppingCash);
            //command.Parameters.AddWithValue("@Email", model.Email);
            //command.Parameters.AddWithValue("@Phone", model.Phone);
            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }
        public void Delete(Customer model)
        {
            var connection = new SqlConnection("data source=.;database=BuildSchool;integrated security=true");
            var sql = "DELETE FROM Customer WHERE CustomerID=@CustomerID";
            var result = connection.Execute(sql,new {model.CustomerID});
            //SqlConnection connection = new SqlConnection(
            //    "data source=.;database=BuildSchool;integrated security=true");
            //var sql = "DELETE FROM Customer WHERE CustomerID=@CustomerID";
            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@CustomerID", model.CustomerID);        
            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }
        public Customer FindById(int customerId)
        {
            var connection = new SqlConnection("data source=.;database=BuildSchool;integrated security=true");
            var sql = "SELECT * FROM Customer WHERE CustomerID=@CustomerID";
            var result = connection.QueryMultiple(sql,new {customerId});
            return result.Read<Customer>().Single();

            //SqlConnection connection = new SqlConnection(
            //    "data source=.;database=BuildSchool;integrated security=true");
            //var sql = "SELECT * FROM Customer WHERE CustomerID=@CustomerID";
            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@CustomerID", customerId);
            //connection.Open();
            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var customer = new Customer();
            //while (reader.Read())
            //{
            //    customer.CustomerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CustomerID")));
            //    customer.CustomerName = reader.GetValue(reader.GetOrdinal("CustomerName")).ToString();
            //    customer.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")).ToString());
            //    customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
            //    customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
            //    customer.ShoppingCash = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("ShoppingCash")));
            //    customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
            //    customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
            //}
            //reader.Close();
            //return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            var connection = new SqlConnection("data source=.;database=BuildSchool;integrated security=true");            
            return connection.Query<Customer>("SELECT * FROM Customer");

            //SqlConnection connection = new SqlConnection(
            //    "data source=.;database=BuildSchool;integrated security=true");
            //var sql = "SELECT * FROM Customer";
            //SqlCommand command = new SqlCommand(sql, connection);
            //connection.Open();
            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var customers = new List<Customer>();
            //while (reader.Read())
            //{
            //    var customer = new Customer();
            //    customer.CustomerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CustomerID")));
            //    customer.CustomerName = reader.GetValue(reader.GetOrdinal("CustomerName")).ToString();
            //    customer.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")).ToString());
            //    customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
            //    customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
            //    customer.ShoppingCash = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("ShoppingCash")));
            //    customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
            //    customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();

            //    customers.Add(customer);
            //}
            //reader.Close();
            //return customers;
        }

    }
}
