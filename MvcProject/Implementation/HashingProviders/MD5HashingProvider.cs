using PasswordVaildationTools.Abstracts;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVaildationTools.Implementation.HashingProviders
{
    public class MD5HashingProvider : IHashingProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            var provider = new MD5CryptoServiceProvider();
            return provider.ComputeHash(data);
        }
    }
}
