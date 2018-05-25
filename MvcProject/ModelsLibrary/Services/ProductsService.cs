using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibrary.ViewModels;

namespace ModelsLibrary.Services
{
    public class ProductsService
    {
        ProductsRepository repository = new ProductsRepository();

        public object ProductList { get; private set; }

        public void Create(Products model)
        {
            repository.Create(model);
        }

        public void UpdateUnitPrice(Products model)
        {
            repository.UpdateUnitPrice(model);
        }

        public void UpdateStockPplus(Products model, int input)
        {
            repository.UpdateStockPplus(model, input);
        }

        public void UpdateStockPminus(Products model, int input)
        {
            repository.UpdateStockPminus(model, input);
        }

        public void UpdateProductDetails(Products model, string ProductDetails)
        {
            repository.UpdateProductDetails(model, ProductDetails);
        }

        public void UpdateDowntime(Products model)
        {
            repository.UpdateDowntime(model);
        }

        public Products FindByID(int productid)
        {
            return repository.FindByID(productid);
        }
        public ProductList FindByName(string ProductName)
        {
            ProductPhotoRepository productPhotoRepository = new ProductPhotoRepository();
            var items = repository.FindByName(ProductName).ToList();
            ProductList productList = new ProductList()
            {
                ProductName = items[0].ProductName,
                UnitPrice = items[0].UnitPrice,
                ProductDetails = items[0].ProductDetails,
                Size = items.Select(x => x.Size).Distinct().ToList(),
                Color = items.Select(x => x.Color).Distinct().ToList(),

            };
            productList.PhotoPath = new List<string>();
            foreach (var item in items)
            {
                foreach (var photo in productPhotoRepository.FindById(item.ProductID))
                {
                    productList.PhotoPath.Add(photo.PhotoPath);
                }
            }
            return productList;
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

        public IEnumerable<Products> GetSizebyProductNamebyColor(string name, string color)
        {
            return repository.GetSizebyProductNamebyColor(name, color);
        }

        public bool CheckStock(int productid, int carquantity)
        {
            return repository.CheckStock(productid, carquantity);
        }
    }
}
