using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class ShoppingcartDetailsService
    {
        public bool ConfirmOrders(ShoppingcartDetails model)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var stock = productsRepository.CheckStock(model.ProductID);
            return stock;
        }
    }
}
