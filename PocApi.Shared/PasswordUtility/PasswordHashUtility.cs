using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Shared.PasswordUtility
{
    public static class PasswordHashUtility
    {
        public static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmacsha = new HMACSHA512())
            {
                passwordSalt = hmacsha.Key;
                passwordHash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool CheckHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmacsha = new HMACSHA512(passwordSalt))
            {
                var calculatedHash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < calculatedHash.Length; i++)
                {
                    if (calculatedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
