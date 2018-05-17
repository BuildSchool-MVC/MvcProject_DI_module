using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class ProductsService
    {
        ProductsRepository repository = new ProductsRepository();

        public void Create(Products model)
        {
            repository.Create(model);
        }

        public void UpdateUnitPrice(Products model)
        {
            repository.UpdateUnitPrice(model);
        }

        public void UpdateStock(Products model,int input)
        {
            repository.UpdateStock(model,input);
        }

        public void UpdateDowntime(Products model)
        {
            repository.UpdateDowntime(model);
        }

        public Products FindByID(string productid)
        {
            return repository.FindByID(productid);
        }

        public IEnumerable<Products> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<Products> GetColor(string Color)
        {
            return repository.GetColor(Color);
        }

        public IEnumerable<Products> GetProductName(string Name)
        {
            return repository.GetProductName(Name);
        }
    }
}
