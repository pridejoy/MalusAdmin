using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Encryption {
    public class Md5Util
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] data)
        {
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            return md5Provider.ComputeHash(data);
        }

        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encrypt(string data)
        {
            byte[] bytes = Encrypt(Encoding.UTF8.GetBytes(data));
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                //x2为小写,X2为大写
                result.Append(bytes[i].ToString("X2"));
            }
            return result.ToString();
        }

    }
}
