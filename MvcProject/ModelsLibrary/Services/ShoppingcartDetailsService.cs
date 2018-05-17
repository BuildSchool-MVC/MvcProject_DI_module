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
        public void ConfirmOrders(ShoppingcartDetails model)
        {
            ShoppingcartDetailsRepository ShoppingcarRepository = new ShoppingcartDetailsRepository();
            ProductsRepository productsRepository = new ProductsRepository();

        }
    }
}
