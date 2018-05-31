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
        OrderDetailsRepository repository = new OrderDetailsRepository();

        public void Create(OrderDetails model)
        {
            repository.Create(model);
        }

        public void Update(OrderDetails model)
        {
            repository.Update(model);
        }

        public void Delete(OrderDetails model)
        {
            repository.Delete(model);
        }

        public OrderDetails FindById(int OrderId)
        {
            return repository.FindById(OrderId);
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            return repository.GetAll();
        }

    }
}
