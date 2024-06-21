namespace MalusAdmin.Common;

public class TokenService : ITokenService
{
    private readonly ICacheService _cacheService;

    private readonly IHttpContextAccessor _httpContextAccessor;


    /// <summary>
    /// 30分钟内无操作
    /// </summary>
    private readonly int expiresTime = 30;

    /// <summary>
    /// 请求头的前缀
    /// </summary>
    private readonly string tokenTag = "Token";

    public TokenService(ICacheService cacheService, IHttpContextAccessor httpContextAccessor)
    {
        _cacheService = cacheService;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 检查登录的Token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public bool CheckToken(HttpContext httpContext)
    {
        var token = GetToken(httpContext);
        if (string.IsNullOrWhiteSpace(token)) return false;

        _ = ParseTokenByCaChe(token);

        //此处可增加逻辑，限制单个账号只允许登录一个

        return true;
    }

    /// <summary>
    /// 生成一个token，并缓存
    /// </summary>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    public string GenerateToken(TokenData tokenData)
    {
        var token = Guid.NewGuid().ToString("N");
        AddCheckToken(token, tokenData);
        return token;
    }

    public void RemoveToken(HttpContext httpContext)
    {
        var token = GetToken(httpContext);
        _cacheService.Remove(token);
    }

    public TokenData ParseToken(HttpContext httpContext)
    {
        var token = GetToken(httpContext);
        if (string.IsNullOrEmpty(token)) return new TokenData();
        return ParseTokenByCaChe(token);
    }

    /// <summary>
    /// 刷新Token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public string RefreshToken(HttpContext httpContext)
    {
        var token = GetToken(httpContext);
        var tokenData = ParseToken(httpContext);
        if (tokenData != null)
        {
            tokenData.ExpireTime = DateTime.Now.AddMinutes(expiresTime);
            _cacheService.Set(Constant.Cache.UserToken + token, tokenData, 60 * 60);
        }

        return token;
    }

    /// <summary>
    /// 添加登录的缓存
    /// </summary>
    /// <param name="token"></param>
    /// <param name="tokeninfo"></param>
    public void AddCheckToken(string token, TokenData tokeninfo)
    {
        tokeninfo.LoginTime = DateTime.Now;
        tokeninfo.ExpireTime = DateTime.Now.AddMinutes(expiresTime);
        if (tokeninfo.UserId > 0) _cacheService.Set(Constant.Cache.UserToken + token, tokeninfo, 60 * 60);
    }

    /// <summary>
    /// 移除缓存
    /// </summary>
    /// <param name="userId"></param>
    public void RemoveCheckToken(int userId)
    {
        _cacheService.Remove(Constant.Cache.UserToken + userId);
    }

    /// <summary>
    /// 通过缓存解析Token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public TokenData ParseTokenByCaChe(string token)
    {
        var userinfo = _cacheService.Get<TokenData>(Constant.Cache.UserToken + token);
        if (userinfo == null) throw new Exception("解析用户信息失败");
        return userinfo;
    }

    //public TokenData TokenDataInfo => ;


    /// <summary>
    /// 获取heard的token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    /// <exception cref="SystemException"></exception>
    private string GetToken(HttpContext httpContext)
    {
        if (httpContext == null) throw new SystemException("参数错误");
        if (httpContext.Request.Headers.ContainsKey(tokenTag))
            return httpContext.Request.Headers[tokenTag].ToString().Replace("Bearer ", "");
        return "";
    }
}