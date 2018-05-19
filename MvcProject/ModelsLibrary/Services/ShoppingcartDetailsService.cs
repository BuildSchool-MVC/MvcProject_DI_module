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
        public void Create(ShoppingcartDetails model)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            shoppingcarRepository.Create(model);
        }

        public void Update(ShoppingcartDetails model)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            shoppingcarRepository.Update(model);
        }

        public void DeleteAllForUser(ShoppingcartDetails model)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            shoppingcarRepository.DeleteAllForUser(model);
        }

        public void DeleteOneForUser(ShoppingcartDetails model)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            shoppingcarRepository.DeleteOneForUser(model);
        }

        public ShoppingcartDetails FindById(int CustomerID, int ProductID)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            return shoppingcarRepository.FindById(CustomerID, ProductID);
        }

        public IEnumerable<ShoppingcartDetails> GetAll()
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            return shoppingcarRepository.GetAll();
        }

        public IEnumerable<ShoppingcartDetails> FindByCustomer(int CustomerID)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            return shoppingcarRepository.FindByCustomer(CustomerID);
        }

        public decimal GetProductTotal(int Cid)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            return shoppingcarRepository.GetProductTotal(Cid);
        }

        public bool AddProducttoShoppingcar(ShoppingcartDetails model)
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            var productsRepository = new ProductsRepository();
            var stock = productsRepository.CheckStock(model.ProductID,model.Quantity);
            if (stock)
            {
                var product = shoppingcarRepository.FindById(model.CustomerID, model.ProductID);
                if (product == null)
                {
                    shoppingcarRepository.Create(model);
                }
                else
                {
                    shoppingcarRepository.Update(model);
                }

                return true;
            }
            else
            {
                return false;
            }

            
        }      

        public string ConfirmOrders(List<ShoppingcartDetails> shoppingcar,Order order)//新增訂單
        {
            var shoppingcarRepository = new ShoppingcartDetailsRepository();
            var productsRepository = new ProductsRepository();
            var orderRepository = new OrderRepository();
            var orderDetailsRepository = new OrderDetailsRepository();

            foreach(var item in shoppingcar)//每一件是否都有庫存
            {
                var stock = productsRepository.CheckStock(item.ProductID, item.Quantity);
                if (!stock)
                {
                    return $"{item.ProductID}";
                }
            }

            orderRepository.Create(order);//新增訂單
            var orderid=orderRepository.FindIDByCustomerID(order.CustomerID);
            foreach(var item in shoppingcar)//新增訂單明細
            {
                var orderDetails = new OrderDetails()
                {
                    OrderID = orderid,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity
                };
                orderDetailsRepository.Create(orderDetails);
            }
            //扣庫存
            foreach(var item in shoppingcar)
            {
                var product = new Products()
                {
                    ProductID = item.ProductID
                };
                productsRepository.UpdateStockPminus(product, item.Quantity);
            }
            //刪購物車內容
            //先判斷購物車商品數量與訂單商品數量
            var shoppingcartDetails=shoppingcarRepository.FindByCustomer(order.CustomerID);
            foreach(var item in shoppingcar)
            {
                foreach(var bag in shoppingcartDetails)
                {
                    var shoppingcart = new ShoppingcartDetails()
                    {
                        ProductID = item.ProductID, CustomerID = item.CustomerID, Quantity = item.Quantity
                    };

                    if(bag.ProductID==item.ProductID && bag.Quantity == item.Quantity)
                    {
                        shoppingcarRepository.DeleteOneForUser(shoppingcart);
                        break;
                    }
                    else
                    {
                        shoppingcarRepository.Updateminus(shoppingcart);
                        break;
                    }
                }
            }
            return "OrderSuccess";
        }
    }
}
