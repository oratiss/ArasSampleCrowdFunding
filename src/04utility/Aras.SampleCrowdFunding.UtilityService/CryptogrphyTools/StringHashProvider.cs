using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Aras.SampleCrowdFunding.UtilityService.CryptogrphyTools
{
    public static class StringHashProvider
    {
        public static (string Hash, string Salt) HashPassword(string password)
        {
            var salt = GenerateSalt(16);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: 100_000,
                HashAlgorithmName.SHA256,
                outputLength: 32
            );

            return (
                Convert.ToBase64String(hash),
                Convert.ToBase64String(salt)
            );
        }

        public static byte[] GenerateSalt(int size = 16)
        {
            var salt = new byte[size];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }
    }
}
