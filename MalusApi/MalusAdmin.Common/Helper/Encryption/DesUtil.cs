using System.Security.Cryptography;

namespace MalusAdmin.Encryption;

public class DesUtil
{
    /// <summary>
    /// DES加密
    /// </summary>
    /// <param name="desModel"></param>
    /// <returns></returns>
    public static byte[] Encrypt(DesModel desModel)
    {
        //使用8位密钥
        var key8 = new byte[8];
        //如果我们的密钥不是8为，则自动补全到8位
        var byteKey = Encoding.UTF8.GetBytes(desModel.Key.PadRight(key8.Length));
        //复制密钥
        Array.Copy(byteKey, key8, key8.Length);

        //使用8位向量
        var iv8 = new byte[8];
        //如果我们的向量不是8为，则自动补全到8位
        var byteIv = Encoding.UTF8.GetBytes(desModel.IV.PadRight(iv8.Length));
        //复制向量
        Array.Copy(byteIv, iv8, iv8.Length);

        // 创建加密对象
        var desProvider = new DESCryptoServiceProvider();
        desProvider.Mode = desModel.Mode;
        desProvider.Padding = desModel.Padding;
        desProvider.Key = key8;
        desProvider.IV = iv8;
        byte[] result = null;
        try
        {
            using (var ms = new MemoryStream())
            {
                using (var EncryptStream = new CryptoStream(ms, desProvider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    EncryptStream.Write(desModel.Data, 0, desModel.Data.Length);
                    EncryptStream.FlushFinalBlock();
                    result = ms.ToArray();
                }
            }
        }
        catch
        {
        }

        return result;
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="desModel"></param>
    /// <returns></returns>
    public static byte[] Decrypt(DesModel desModel)
    {
        //使用8位密钥
        var key8 = new byte[8];
        //如果我们的密钥不是8为，则自动补全到8位
        var byteKey = Encoding.UTF8.GetBytes(desModel.Key.PadRight(key8.Length));
        //复制密钥
        Array.Copy(byteKey, key8, key8.Length);

        //使用8位向量
        var iv8 = new byte[8];
        //如果我们的向量不是8为，则自动补全到8位
        var byteIv = Encoding.UTF8.GetBytes(desModel.IV.PadRight(iv8.Length));
        //复制向量
        Array.Copy(byteIv, iv8, iv8.Length);

        // 创建解密对象
        var desProvider = new DESCryptoServiceProvider();
        desProvider.Mode = desModel.Mode;
        desProvider.Padding = desModel.Padding;
        desProvider.Key = key8;
        desProvider.IV = iv8;
        byte[] result = null;
        try
        {
            using (var ms = new MemoryStream(desModel.Data))
            {
                using (var DecryptStream = new CryptoStream(ms, desProvider.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (var msResult = new MemoryStream())
                    {
                        var temp = new byte[1024 * 1024];
                        var len = 0;
                        while ((len = DecryptStream.Read(temp, 0, temp.Length)) > 0) msResult.Write(temp, 0, len);

                        result = msResult.ToArray();
                    }
                }
            }
        }
        catch
        {
        }

        return result;
    }

    /// <summary>
    /// DES加密字符串
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <returns></returns>
    public static string Encrypt(string data, string key, string iv = "")
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var result = Encrypt(new DesModel
        {
            Data = bytes,
            Key = key,
            IV = iv,
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7
        });
        if (result == null) return "";
        return Convert.ToBase64String(result);
    }

    /// <summary>
    /// DES解密字符串
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <returns></returns>
    public static string Decrypt(string data, string key, string iv = "")
    {
        var bytes = Convert.FromBase64String(data);
        var result = Decrypt(new DesModel
        {
            Data = bytes,
            Key = key,
            IV = iv,
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7
        });
        if (result == null) return "";
        return Encoding.UTF8.GetString(result);
    }


    public class DesModel
    {
        /// <summary>
        /// 需要加密/解密的数据
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 向量
        /// </summary>
        public string IV { get; set; }

        /// <summary>
        /// 加密模式
        /// </summary>
        public CipherMode Mode { get; set; }

        /// <summary>
        /// 填充模式
        /// </summary>
        public PaddingMode Padding { get; set; }
    }
}