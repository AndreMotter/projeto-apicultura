using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Helpers
{
    public static class EncryptionHelper
    {
        public static string Sha1(this string valor)
        {
            using (var sha1 = SHA1.Create())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(valor))).Replace("-", "").ToLower();
            }
        }

        public static string Md5(this string valor)
        {
            using (var md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(valor))).Replace("-", "").ToLower();
            }
        }

        public static string Sha512(this string valor)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();

            byte[] arrHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(valor));

            StringBuilder sbHash = new StringBuilder();

            for (int i = 0; i < arrHash.Length; i++)
            {
                sbHash.Append(arrHash[i].ToString("x2"));
            }
            return sbHash.ToString();
        }
    }
}
