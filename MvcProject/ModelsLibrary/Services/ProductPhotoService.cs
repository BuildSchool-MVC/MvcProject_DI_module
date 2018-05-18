using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class ProductPhotoService
    {
        ProductPhotoRepository repository = new ProductPhotoRepository();

        public void Create(ProductPhoto model)
        {
            repository.Create(model);
        }

        public void Update(ProductPhoto model)
        {
            repository.Update(model);
        }

        public void Delete(ProductPhoto model)
        {
            repository.Delete(model);
        }

        public IEnumerable<ProductPhoto> FindById(int ProductID)
        {
            return repository.FindById(ProductID);
        }

        public IEnumerable<ProductPhoto> GetAll()
        {
            return repository.GetAll();
        }
    }
}
