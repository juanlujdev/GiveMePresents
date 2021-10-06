using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace GiveMePresent.Common
{
    public class Tools
    {
        public static string SHA256_Encrypt_hex(string text)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = provider.ComputeHash(inputBytes);

            StringBuilder hexacedimal = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hexacedimal.Append(hashBytes[i].ToString("x2"));
            }

            return hexacedimal.ToString();
        }
    }
}