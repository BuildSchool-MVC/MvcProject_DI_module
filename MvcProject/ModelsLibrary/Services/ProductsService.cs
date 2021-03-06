﻿using ModelsLibrary.DtO_Models;
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

        public void Update(Products model)
        {
            repository.Update(model);
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
            string[] sizes = new[] { "XS", "S", "M", "L", "XL", "XXL" };
            ProductPhotoRepository productPhotoRepository = new ProductPhotoRepository();
            var items = repository.FindByName(ProductName).ToList();
            items = items.Where((x) => x.Downtime == null).ToList();
            ProductList productList = new ProductList()
            {
                ProductName = items[0].ProductName,
                UnitPrice = decimal.Round(items[0].UnitPrice),
                ProductDetails = items[0].ProductDetails,
                Size = items.Select(x => x.Size).Distinct().OrderBy(x=>sizes.Contains(x)?"0":"1").ThenBy(x=>Array.IndexOf(sizes,x)).ThenBy(x=>x).ToList(),
                Color = items.Select(x => x.Color).Distinct().ToList(),
            };
            productList.PhotoPath = new List<string>();
            foreach (var item in items)
            {
                foreach (var photo in productPhotoRepository.FindById(item.ProductID))
                {
                    if (productList.PhotoPath.Any((x) => x == photo.PhotoPath) == false)
                    {
                        productList.PhotoPath.Add(photo.PhotoPath);
                    }
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

        public Products FindIdByName(string ProductName, string Size, string Color)
        {
            return repository.FindIdByName(ProductName, Size, Color);
        }

        public IEnumerable<Products> GetBestProducts()
        {
            return repository.GetBestProducts();
        }

        public IEnumerable<Products> GetNewProducts()
        {
            return repository.GetNewProducts();
        }

        public int GetNewProductID()
        {
            return repository.GetNewProductID();
        }
    }
}
