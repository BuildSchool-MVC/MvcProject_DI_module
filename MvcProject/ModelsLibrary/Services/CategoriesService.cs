using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class CategoriesService
    {
        public void Create(Categories model)
        {
            var repository = new CategoriesRepository();
            repository.Create(model);
        }

        public void Delete(Categories model)
        {
            var repository = new CategoriesRepository();
            repository.Delete(model);
        }

        public void UpdateCategoryName(Categories model, string cname)
        {
            var repository = new CategoriesRepository();
            repository.UpdateCategoryName(model, cname);
        }

        public Categories GetByID(int Cid)
        {
            var repository = new CategoriesRepository();
            return repository.GetByID(Cid);
        }

        public IEnumerable<Categories> GetAll()
        {
            var repository = new CategoriesRepository();
            return repository.GetAll();
        }

        public IEnumerable<Products> ClassifyByCategoryName(string name)
        {
            var Product_repository = new ProductsRepository();
            var list = Product_repository.GetAll().ToList();

            var Category_repository = new CategoriesRepository();
            var model = Category_repository.GetByName(name);
      
            var result = new List<Products>();
            foreach(var item in list)
            {
                if(item.CategoryID == model.CategoryID)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
