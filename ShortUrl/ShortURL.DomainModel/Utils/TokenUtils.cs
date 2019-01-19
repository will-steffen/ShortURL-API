using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ShortURL.DomainModel.Utils
{
    public class TokenUtils
    {
        public static string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public static string GetHash(string str, string saltStr)
        {
            byte[] salt = Convert.FromBase64String(saltStr);
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: str,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
        }

        public static string GenerateCode(int length = 10)
        {
            string code = GenerateSalt();
            code = code.Replace("+", "");
            code = code.Replace("=", "");
            return code.Substring(0, length);
        }
    }
}
