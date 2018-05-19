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

        public void UpdateStockPplus(Products model,int input)
        {
            repository.UpdateStockPplus(model,input);
        }

        public void UpdateStockPminus(Products model, int input)
        {
            repository.UpdateStockPminus(model, input);
        }

        public void UpdateDowntime(Products model)
        {
            repository.UpdateDowntime(model);
        }

        public Products FindByID(int productid)
        {
            return repository.FindByID(productid);
        }

        public IEnumerable<Products> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<Products> GetColor(string Color)
        {
            return repository.GetbyColor(Color);
        }

        public IEnumerable<Products> GetProductName(string Name)
        {
            return repository.GetbyProductName(Name);
        }

        public bool CheckStock(int productid, int carquantity)
        {
            return repository.CheckStock(productid, carquantity);
        }
    }
}
