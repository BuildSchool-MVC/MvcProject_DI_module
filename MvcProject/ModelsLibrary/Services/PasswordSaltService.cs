using Client;
using ModelsLibrary.DtO_Models;
using PasswordVaildationTools.Abstracts;
using PasswordVaildationTools.Implementation.HashingProviders;
using PasswordVaildationTools.Implementation.PasswordRules;
using PasswordVaildationTools.Implementation.SaltStrategies;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Services
{
    public class PasswordSaltService
    {
        public static IPasswordValidationService Simpleinject()
        {
            Container container = Inject();

            return container.GetInstance<IPasswordValidationService>();
        }

        private static Container Inject()
        {
            var container = new Container();
            container.Register<IHashingProvider, SHA512HashingProvider>();
            container.Register<ISaltStrategy, DefaultSaltStrategy>();
            container.Register<IPasswordRule, LowComplexityPasswordRule>();
            container.Register<IPasswordValidationService, PasswordValidationService>();
            return container;
        }

        public Customer PasswordsSalt(string password)
        {
            var service = Simpleinject();

            var guid = (Guid.NewGuid()).ToString();
            var salt= Encoding.UTF8.GetBytes(guid);

            byte[] storedPwdData = Encoding.UTF8.GetBytes(password);
            byte[] storedPwdHashed = service.HashPassword(storedPwdData, salt);

            var model = new Customer();
            model.Password= Encoding.UTF8.GetString(storedPwdHashed);
            model.Salt= guid;

            return model;
        }

        public bool PasswordsCheck(Customer customer, string userInputPwd)
        {
            var service = Simpleinject();

            byte[] salt= Encoding.UTF8.GetBytes(customer.Salt);
            byte[] userPwdData = Encoding.UTF8.GetBytes(userInputPwd);
           
            return service.VaildatePassword(customer.Password, userPwdData, salt);
        }

        public bool Validate(string password)
        {
            var service = Simpleinject();

            return service.Validate(password);
        }
    }
}
