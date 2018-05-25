using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelsLibrary.DtO_Models;
using Dapper;
using Abstracts;
using System.Configuration;

namespace ModelsLibrary.Repositories
{

   public class CustomerRepository : IRepository<Customer>
    {
        private string sqlstr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public void Create(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = @"INSERT INTO Customer(CustomerName,Birthday,Password,ShoppingCash,Account,Phone,Email) 
                            VALUES(@CustomerName,@Birthday,@Password,@ShoppingCash,@Account,@Phone,@Email)";
             connection.Execute(sql, 
                new {
                        model.CustomerName,
                        model.Birthday,
                        model.Password,
                        model.ShoppingCash,
                        model.Account,
                        model.Phone,
                        model.Email
                    });
        }

        public void Update(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Customer SET CustomerName=@CustomerName,Password=@Password,ShoppingCash=@ShoppingCash,Email=@Email,Phone=@Phone WHERE CustomerID=@CustomerID";
            connection.Execute(sql,
                new {
                        model.CustomerID,
                        model.Account,
                        model.CustomerName,    
                        model.Password,
                        model.ShoppingCash,
                        model.Email,
                        model.Phone
                    });
        }
        public void Delete(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "DELETE FROM Customer WHERE CustomerID=@CustomerID";
            connection.Execute(sql,new {model.CustomerID});

        }
        public Customer FindByCustomerId(int customerId)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM Customer WHERE customerId=@customerId";
            var result = connection.QueryFirstOrDefault<Customer>(sql,new { customerId });
            return result;
        }

        public Customer FindByCustomerAccount(string customerAccount)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT * FROM Customer WHERE Account=@customerAccount";
            var result = connection.QueryFirstOrDefault<Customer>(sql, new { customerAccount });
            return result;
        }

        public IEnumerable<Customer> GetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);   
            return connection.Query<Customer>("SELECT * FROM Customer");

        }

    }
}
