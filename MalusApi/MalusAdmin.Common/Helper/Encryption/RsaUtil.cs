using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static MalusAdmin.Encryption.RsaUtil;

namespace MalusAdmin.Encryption
{
    public class RsaUtil
    {
        /// <summary>
        /// 生成公钥和私钥
        /// </summary>
        /// <returns></returns>
        public static RsaKey CreateKey()
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            RsaKey rsaKey = new RsaKey();

            rsaKey.PublicKey = rsaProvider.ToXmlString(false);
            rsaKey.PrivateKey = rsaProvider.ToXmlString(true);
            return rsaKey;
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="rsaModel"></param>
        /// <returns></returns>
        public static byte[] Encrypt(RsaModel rsaModel)
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            byte[] result = null;
            try
            {
                rsaProvider.FromXmlString(rsaModel.Key);
                result = rsaProvider.Encrypt(rsaModel.Data, false);
            }
            catch { }
            return result;
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="rsaModel"></param>
        /// <returns></returns>
        public static byte[] Decrypt(RsaModel rsaModel)
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            byte[] result = null;
            try
            {
                rsaProvider.FromXmlString(rsaModel.Key);
                result = rsaProvider.Decrypt(rsaModel.Data, false);
            }
            catch { }
            return result;
        }

        /// <summary>
        /// RSA加密字符串
        /// </summary>
        /// <param name="data">要加密的字符串</param>
        /// <param name="key">公钥</param>
        /// <returns></returns>
        public static string Encrypt(string data, string key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] result = Encrypt(new RsaModel
            {
                Data = bytes,
                Key = key
            });
            if (result == null)
            {
                return "";
            }
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// RSA解密字符串
        /// </summary>
        /// <param name="data">要解密的字符串</param>
        /// <param name="key">私钥</param>
        /// <returns></returns>
        public static string Decrypt(string data, string key)
        {
            byte[] bytes = Convert.FromBase64String(data);
            byte[] result = Decrypt(new RsaModel
            {
                Data = bytes,
                Key = key
            });
            if (result == null)
            {
                return "";
            }
            return Encoding.UTF8.GetString(result);
        }

        public static string DecryptPkcs8(string data, string key)
        {
            byte[] bytes = Convert.FromBase64String(data);
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            byte[] result;
            try
            {
                rsaProvider.ImportPkcs8PrivateKey(Convert.FromBase64String(key), out _);
                result = rsaProvider.Decrypt(bytes, false);
            }
            catch
            {
                return "";
            }
            return Encoding.UTF8.GetString(result);
        }

        public class RsaKey
        {
            /// <summary>
            /// 公钥
            /// </summary>
            public string PublicKey { get; set; }

            /// <summary>
            /// 私钥
            /// </summary>
            public string PrivateKey { get; set; }
        }

        public class RsaModel
        {
            /// <summary>
            /// 需要加密/解密的数据
            /// </summary>
            public byte[] Data { get; set; }

            /// <summary>
            /// 密钥(加密:公钥;解密:私钥)
            /// </summary>
            public string Key { get; set; }
        }
    }
}
