using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class OrderDetailsService
    {
        public void Create(OrderDetails model)
        {
            var repository = new OrderDetailsRepository();
            repository.Create(model);
        }

        public void Update(OrderDetails model)
        {
            var repository = new OrderDetailsRepository();
            repository.Update(model);
        }

        public void Delete(OrderDetails model)
        {
            var repository = new OrderDetailsRepository();
            repository.Delete(model);
        }

        public IEnumerable<OrderDetails> FindById(string OrderId)
        {
            var repository = new OrderDetailsRepository();
            return repository.FindById(OrderId);
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            var repository = new OrderDetailsRepository();
            return repository.GetAll();
        }
    }
}
