using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;

namespace GiveMePresent.Common
{
    public class Tools
    {
        private static Random random = new Random();
        
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
        
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool SendEmail(string userEmail, string personaContacto)
        {
            bool check;
            string subject = "Hola " + personaContacto + " este es tu usuario y contraseña";
            string body = "Username: " + userEmail + "\n" + "Password: 1234";

            try
            {
                WebMail.Send(userEmail, subject, body, null, null, null, true, null, null, null, null, null, null);
                return check = true;
            }
            catch (Exception e)
            {

                throw new Exception("no se ha podido enviar el mail: " + e);
                return check = false;
            }

        }
    }
}