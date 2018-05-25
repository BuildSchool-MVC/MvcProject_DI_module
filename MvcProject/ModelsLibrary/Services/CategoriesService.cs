using Abstracts;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class CategoriesService
    {
        private Container container = new Container();
        
        public void Init()
        {
            container.Register<IRepository<Categories>, CategoriesRepository>();
            container.Register<IRepository<Products>, ProductsRepository>();
        }

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

        public void UpdateCategoryNameByID(int cid, string cname)
        {
            var repository = new CategoriesRepository();
            repository.UpdateCategoryNameByID(cid, cname);
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
            var list = Product_repository.GetAll();
            
            var Category_repository = new CategoriesRepository();
            var model = Category_repository.GetByName(name);
      
            var result = new List<Products>();
            var real_result = new List<Products>();

            result = list.Where((x) => x.CategoryID == model.CategoryID).ToList();

            foreach (var items in result)
            {
                if(real_result.Any((x) => x.ProductName == items.ProductName) == false)
                {
                    real_result.Add(items);
                }
            }
            return real_result;
        }
    }
}
