using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Encryption {
    public class ShaUtil
    {
        public static byte[] Encrypt(byte[] data, ShaType shaType)
        {
            HashAlgorithm ShaProvider = new SHA256CryptoServiceProvider();
            switch (shaType)
            {
                case ShaType.SHA1:
                    ShaProvider = new SHA1CryptoServiceProvider();
                    break;
                case ShaType.SHA256:
                    ShaProvider = new SHA256CryptoServiceProvider();
                    break;
                case ShaType.SHA384:
                     ShaProvider = new SHA384CryptoServiceProvider();
                    break;
                case ShaType.SHA512:
                    ShaProvider = new SHA512CryptoServiceProvider();
                    break;
            }
            return ShaProvider.ComputeHash(data);
        }

        public static string Encrypt(string data,ShaType shaType)
        {
            byte[] bytes = Encrypt(Encoding.UTF8.GetBytes(data), shaType);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                //x2为小写,X2为大写
                result.Append(bytes[i].ToString("X2"));
            }
            return result.ToString();
        }


        public enum ShaType
        {
            SHA1, SHA256, SHA384, SHA512
        }
    }
}
