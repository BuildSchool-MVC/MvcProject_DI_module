﻿using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Abstracts;
using SimpleInjector;

namespace ModelsLibrary.Repositories
{
    public class ProductsRepository: IRepository<Products>
    {
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection("data source=.; database=BuildSchool; integrated security=true");
            var sql = @"INSERT INTO Products (ProductID,ProductName,CategoryID,UnitPrice,UnitsInStock,Size,Color,Uptime)
                                            VALUES (@ProductID,@ProductName,@CategoryID,@UnitPrice,@UnitsInStock,@Size,@Color,@Uptime)";
            connection.Execute(sql,new { model.ProductID, model.ProductName, model.CategoryID, model.UnitPrice, model.UnitsInStock, model.Size, model.Color, model.Uptime });
        }

        public void UpdateUnitPrice(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE Products SET UnitPrice=@UnitPrice WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID,  model.UnitPrice });
        }

        public void UpdateStock(Products model,int input)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE Products SET UnitsInStock=UnitsInStock+@input WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID,input });
        }

        public void UpdateDowntime(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "UPDATE Products SET Downtime=@Downtime WHERE ProductID=@ProductID";
            connection.Execute(sql, new { model.ProductID, model.Downtime });
        }

        public Products FindByID(string productid)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            var result=connection.QueryMultiple(sql, new { productid });
            var products= result.Read<Products>().Single();
            return products;            
        }

        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection("data source=.; database=BuildSchool; integrated security=true");
            return connection.Query<Products>("SELECT * FROM Products");
        }

        public IEnumerable<Products> GetColor(string Color)
        {
            SqlConnection connection = new SqlConnection("data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Products WHERE Color=@Color";
            var result=connection.QueryMultiple(sql, new {Color});
            var products = result.Read<Products>().ToList();
            return products;
        }

        public IEnumerable<Products> GetProductName(string Name)
        {
            SqlConnection connection = new SqlConnection("data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Products WHERE ProductName LIKE '%'+ @Name +'%'";
            var result = connection.QueryMultiple(sql, new { Name });
            var products = result.Read<Products>().ToList();
            return products;
        }

        public bool CheckStock(string productid)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool; integrated security=true");
            var sql = "SELECT * FROM Products WHERE ProductID =@ProductID";
            var result = connection.QueryMultiple(sql, new { productid });
            var products = result.Read<Products>().Single();

            if (products.UnitsInStock > 0)
            {
                return false;
            }

            return true;
        }
    }
}
