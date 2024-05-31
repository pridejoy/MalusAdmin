using System.Security.Cryptography;

namespace MalusAdmin.Encryption;

public class ShaUtil
{
    public enum ShaType
    {
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }

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

    public static string Encrypt(string data, ShaType shaType)
    {
        var bytes = Encrypt(Encoding.UTF8.GetBytes(data), shaType);
        var result = new StringBuilder();
        for (var i = 0; i < bytes.Length; i++)
            //x2为小写,X2为大写
            result.Append(bytes[i].ToString("X2"));
        return result.ToString();
    }
}