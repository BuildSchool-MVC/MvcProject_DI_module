using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IPasswordValidationService
    {
        byte[] HashPassword(byte[] pwd, byte[] salt);

        bool VaildatePassword(byte[] pwd, byte[] pwdCheck, byte[] salt);

        string GeneratePassword();
    }
}
