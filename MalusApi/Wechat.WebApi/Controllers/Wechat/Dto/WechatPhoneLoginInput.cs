/// <summary>
/// 微信电话号码
/// 一件登录模型
/// </summary>
public class WechatPhoneLoginInput
{
    /// <summary>
    /// 包括敏感数据在内的完整用户信息的加密数据
    /// https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/signature.html#%E5%8A%A0%E5%AF%86%E6%95%B0%E6%8D%AE%E8%A7%A3%E5%AF%86%E7%AE%97%E6%B3%95
    /// </summary>
    public string EncryptedData { get; set; }

    /// <summary>
    /// 加密算法的初始向量
    /// https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/signature.html#%E5%8A%A0%E5%AF%86%E6%95%B0%E6%8D%AE%E8%A7%A3%E5%AF%86%E7%AE%97%E6%B3%95
    /// </summary>
    public string IV { get; set; }

    /// <summary>
    /// 代码（小程序 jscode）
    /// </summary>
    public string Code { get; set; }
}