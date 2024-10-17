namespace Wechat.Servers;

public class WeChatGetOpenId
{
    private const string OpenIDUrl = "https://api.weixin.qq.com/sns/jscode2session";
    private readonly ISqlSugarClient _db;

    public WeChatGetOpenId(ISqlSugarClient db)
    {
        _db = db;
    }

    /// <summary>
    /// 获取OpenID
    /// 小程序登录凭证校验
    /// URL：https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/user-login/code2Session.html
    /// </summary>
    /// <param name="code">登录时获取的 code</param>
    /// <returns></returns>
    public async Task<WechatOpenIDInfo> GetOpenID(string code)
    {
        var entity = _db.Queryable<BsWxConfig>().First();
        if (entity == null) throw new Exception("获取微信授权失败，请联系管理员");
        var url =
            $"{OpenIDUrl}?appid={entity.WechatAppID}&secret={entity.WechatAppSecret}&js_code={code}&grant_type=authorization_code";
        using (var http = new HttpClient())
        {
            var res = await http.GetFromJsonAsync<WechatOpenIDInfo>(url);
            switch (res.errcode)
            {
                case 0:
                    return res;

                default:
                    //todo 记录登录失败的日志
                    throw new Exception($"小程序登录错误，错误代码：{res.ToJson()}");
            }
        }
    }


    /// <summary>
    /// 微信小程序登录
    /// </summary>
    public class WechatOpenIDInfo
    {
        /// <summary>
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// </summary>
        public string session_key { get; set; }

        /// <summary>
        /// </summary>
        public string unionid { get; set; }

        /// <summary>
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// </summary>
        public string errmsg { get; set; }
    }
}