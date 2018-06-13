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
using ModelsLibrary.ViewModels;

namespace ModelsLibrary.Repositories
{

   public class CustomerRepository : IRepository<Customer>
    {
        private string sqlstr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public void Create(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = @"INSERT INTO Customer(CustomerName,Birthday,Password,ShoppingCash,Account,Phone,Email,Salt) 
                            VALUES(@CustomerName,@Birthday,@Password,0,@Account,@Phone,@Email,@Salt)";
            connection.Execute(sql,
               new
               {
                   model.CustomerName,
                   model.Birthday,
                   model.Password,
                   model.Account,
                   model.Phone,
                   model.Email,
                   model.Salt
               });
        }

        public void Update(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Customer SET CustomerName=@CustomerName,Email=@Email,Phone=@Phone,Birthday=@Birthday WHERE CustomerID=@CustomerID";
            connection.Execute(sql,
                new
                {
                    model.CustomerID,
                    model.CustomerName,
                    model.Email,
                    model.Phone,
                    model.Birthday
                });
        }
        public void AdminUpdate(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Customer SET CustomerName=@CustomerName,Email=@Email,Phone=@Phone,Birthday=@Birthday,ShoppingCash=@ShoppingCash WHERE CustomerID=@CustomerID";
            connection.Execute(sql,
                new
                {
                    model.CustomerID,
                    model.CustomerName,
                    model.Email,
                    model.Phone,
                    model.Birthday,
                    model.ShoppingCash
                });
        }

        public void UpdatePassword(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Customer SET Password=@Password,Salt=@Salt WHERE CustomerID=@CustomerID";
            connection.Execute(sql,
                new
                {
                    model.CustomerID,
                    model.Password,
                    model.Salt
                });
        }

        public void UpdateShoppingCash(Customer model)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "UPDATE Customer SET ShoppingCash=ShoppingCash+@ShoppingCash WHERE CustomerID=@CustomerID";
            connection.Execute(sql,
                new
                {
                    model.CustomerID,
                    model.ShoppingCash
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

        public Customer GetAccount(string Account)
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = "SELECT Account FROM Customer WHERE Account=@Account";
            var result = connection.QueryFirstOrDefault<Customer>(sql, new { Account });
            return result;
        }

        public IEnumerable<AdminCustomer> GetAllCustomerTotal()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            var sql = @"select c.CustomerID,c.CustomerName,c.Account,c.Birthday,c.Email,c.Phone,c.ShoppingCash,(
                        select ISNULL(sum(p.UnitPrice*od.Quantity),0) as total
                        from [Order Details] as od
                        inner join [Order] as o on o.OrderID=od.OrderID
                        inner join Products as p on p.ProductID=od.ProductID
                        where o.CustomerID=c.CustomerID and o.Status not in ('訂單已取消')
                        ) as total
                        from Customer as c";
            return connection.Query<AdminCustomer>(sql);
             
        }

    }
}
