using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class OrderService
    {
        
        public void Create(Order model)
        {
            var repository = new OrderRepository();
            repository.Create(model);
            
        }

        public void UpdateStatus(Order model)
        {
            var repository = new OrderRepository();
            repository.UpdateStatus(model);
        }

        public Order CheckStatus(int orderId)
        {
            var repository = new OrderRepository();
            return repository.CheckStatus(orderId);
        }

        public Order FindById(int orderId)
        {
            var repository = new OrderRepository();
            return repository.FindById(orderId);
        }

        public IEnumerable<Order> FindCustomerOrderByCustomerID(int customerID)
        {
            var repository = new OrderRepository();
            return repository.FindCustomerOrderByCustomerID(customerID);
        }

        public IEnumerable<Order> GetAll()
        {
            var repository = new OrderRepository();
            return repository.GetAll();
        }

    }
}
