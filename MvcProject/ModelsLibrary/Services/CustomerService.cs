using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class CustomerService
    {
        public void Create(Customer model)
        {
            var repository = new CustomerRepository();
            var passworddata = new PasswordSaltService();

            var hashpassword = passworddata.PasswordsSalt(model.Password);
            model.Password = hashpassword.Password;
            model.Salt = hashpassword.Salt;
            repository.Create(model);
        }

        public void Update(Customer model)
        {
            var repository = new CustomerRepository();
            repository.Update(model);
        }
        public void AdminUpdate(Customer model)
        {
            var repository = new CustomerRepository();
            repository.AdminUpdate(model);
        }

        public void UpdatePassword(Customer model)
        {
            var repository = new CustomerRepository();
            var passworddata = new PasswordSaltService();

            var hashpassword = passworddata.PasswordsSalt(model.Password);
            model.Password = hashpassword.Password;
            model.Salt = hashpassword.Salt;
            repository.UpdatePassword(model);
        }

        public void UpdateShoppingCash(Customer model)
        {
            var repository = new CustomerRepository();
            repository.UpdateShoppingCash(model);
        }

        public void Delete(Customer model)
        {
            var repository = new CustomerRepository();
            repository.Delete(model);
        }

        public IEnumerable<Customer> GetAll()
        {
            var repository = new CustomerRepository();
            return repository.GetAll();
        }
        public Customer FindByCustomerId(int customerID)
        {
            var repository = new CustomerRepository();
            return repository.FindByCustomerId(customerID);
        }

        public Customer FindByCustomerAccount(string Account)
        {
            var repository = new CustomerRepository();
            return repository.FindByCustomerAccount(Account);
        }

        public Customer GetAccount(string Account)
        {
            var repository = new CustomerRepository();
            return repository.GetAccount(Account);
        }
    }
}
