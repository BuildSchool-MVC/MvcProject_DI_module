using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Abstracts;

namespace ModelsLibrary.Repositories
{
    public class CategoriesRepository : IRepository<Categories>
    {
        public void Create(Categories model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=BuildSchool_new; integrated security=true");
            var sql = "INSERT INTO Categories VALUES (@Cid, @Cname)";

            connection.Execute(sql, new { Cid = model.CategoryID, Cname = model.CategoryName });

            //SqlCommand command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@Cid", model.CategoryID);
            //command.Parameters.AddWithValue("@Cname", model.CategoryName);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        public void Delete(Categories model)
        {
            SqlConnection connection = new SqlConnection(
               "data source=.; database=BuildSchool_new; integrated security=true");
            var sql = "DELETE FROM Categories WHERE CategoryID = @Cid";

            connection.Execute(sql, new { Cid = model.CategoryID });

            //SqlCommand command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@Cid", model.CategoryID);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        public void UpdateCategoryName(Categories model, string cname)
        {
            SqlConnection connection = new SqlConnection(
              "data source=.; database=BuildSchool_new; integrated security=true");
            var sql = "UPDATE Categories SET CategoryName = @inputCName WHERE CategoryName = @SearchCName";

            connection.Execute(sql, new { SearchCName = model.CategoryName, inputCName = cname });

            //SqlCommand command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@SearchCName", model_1.CategoryName);
            //command.Parameters.AddWithValue("@inputCName", model_2.CategoryName);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        public Categories GetByID(int Cid)
        {
            SqlConnection connection = new SqlConnection(
                "data source=DESKTOP-DO7A434\\BUILDSCHOOLSQL; database=BuildSchool_new; integrated security=true");

            var list = connection.Query<Categories>("SELECT * FROM Categories WHERE CategoryID = @id"
                , new { id = Cid });

            Categories category = null;
            foreach (var item in list)
            {
                category = item;
            }

            return category;
        }

        public IEnumerable<Categories> GetAll()
        {
            var connection = new SqlConnection("data source=DESKTOP-DO7A434\\BUILDSCHOOLSQL; database=BuildSchool_new; integrated security=true");
            return connection.Query<Categories>("SELECT * FROM Categories");
        }
    }
}
