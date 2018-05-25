using PasswordVaildationTools.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVaildationTools.Implementation.PasswordRules
{
    public class LowComplexityPasswordRule : IPasswordRule
    {

        private const int LeastLength = 6;
        private const string PasswordCharBase = "23456789abcdefghijkmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ@#%^&!";

        public string Generate()
        {
            var random = new Random();
            var passwordBuilder = new StringBuilder();
            do
            {
                passwordBuilder.Clear();

                while (passwordBuilder.Length < LeastLength)
                {
                    var idx = random.Next(0, PasswordCharBase.Length - 1);
                    passwordBuilder.Append(PasswordCharBase[idx]);
                }
            }
            while (!Validate(passwordBuilder.ToString()));

            return passwordBuilder.ToString();
        }

        public bool Validate(string password)
        {
            return password.Length >= LeastLength;
        }
    }
}
