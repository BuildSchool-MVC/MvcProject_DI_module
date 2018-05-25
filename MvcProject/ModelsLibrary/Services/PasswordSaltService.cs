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
        public Customer PasswordsSalt(string password)
        {
            var container = new Container();
            container.Register<IHashingProvider, SHA512HashingProvider>();
            container.Register<ISaltStrategy, DefaultSaltStrategy>();
            container.Register<IPasswordRule, HighComplexityPasswordRule>();
            container.Register<IPasswordValidationService, PasswordValidationService>();

            var service = container.GetInstance<IPasswordValidationService>();

            var randomGenerator = new RNGCryptoServiceProvider();
            var salt = new byte[16];
            randomGenerator.GetBytes(salt);

            byte[] storedPwdData = Encoding.UTF8.GetBytes(password);
            byte[] storedPwdHashed = service.HashPassword(storedPwdData, salt);

            var model = new Customer();
            model.Password=Convert.ToBase64String(storedPwdHashed);
            model.Salt=Convert.ToBase64String(salt);

            return model;
        }
    }
}
