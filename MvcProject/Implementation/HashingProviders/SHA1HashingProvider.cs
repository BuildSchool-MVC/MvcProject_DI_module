using PasswordVaildationTools.Abstracts;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVaildationTools.Implementation.HashingProviders
{
    public class SHA1HashingProvider : IHashingProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            var provider = new SHA1CryptoServiceProvider();
            return provider.ComputeHash(data);
        }
    }
}
