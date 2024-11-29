namespace MalusAdmin.Common;


[AutoInjection]
public class TokenService : ITokenService
{
    private readonly ICacheService _cacheService; 
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 60分钟内无操作
    /// </summary>
    private readonly int expiresTime = 60 * 4;

    /// <summary>
    /// 请求头的前缀
    /// </summary>
    private readonly string tokenTag = "Authorization";


    public TokenService(ICacheService cacheService, IHttpContextAccessor httpContextAccessor)
    {
        _cacheService = cacheService;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 生成token
    /// </summary>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    public async Task<string> GenerateTokenAsync(TokenData tokenData)
    {
        var token = Guid.NewGuid().ToString("N");
        tokenData.LoginTime = DateTime.Now;
        tokenData.ExpireTime = DateTime.Now.AddMinutes(expiresTime);
        //有效期为半个小时
        if (tokenData.UserId > 0) _cacheService.Set(Constant.Cache.UserToken + token, tokenData, 60 * expiresTime);
        return token;
    }


    /// <summary>
    /// 检查Token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public async Task<bool> ValidateToken(string token)
    {
        token = token.Replace("Bearer ", "");
        if (string.IsNullOrWhiteSpace(token)) return false;
        //是否在缓存，是否过期
        var userinfo = _cacheService.Get<TokenData>(Constant.Cache.UserToken + token);
        if (userinfo == null || userinfo.ExpireTime < DateTime.Now) return false;

        //此处可增加逻辑，限制单个账号只允许登录一个

        return true;
    }


    //刷新token
    public async Task RefreshTokenAsync(string token)
    {
        var tokeninfo = _cacheService.Get<TokenData>(Constant.Cache.UserToken + token);
        tokeninfo.ExpireTime = DateTime.Now.AddMinutes(expiresTime);
        //expiresTime 内操作，变增加30分钟的有效期
        _cacheService.Set(Constant.Cache.UserToken + token, tokeninfo, 60 * expiresTime);
    }


    //解析token
    public async Task<TokenData> ParseTokenAsync(string token)
    {
        var tokeninfo = _cacheService.Get<TokenData>(Constant.Cache.UserToken + token);
        return tokeninfo;
    }


    /// <summary>
    /// 获取heard的token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    /// <exception cref="SystemException"></exception>
    public async Task<string> GetHeadersToken()
    {
        if (_httpContextAccessor.HttpContext == null) throw new SystemException("参数错误");
        if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey(tokenTag))
            return _httpContextAccessor.HttpContext.Request.Headers[tokenTag].ToString().Replace("Bearer ", "");
        return "";
    }


    /// <summary>
    /// 获取当前登录的用户信息
    /// </summary>
    /// <returns></returns>
    public async Task<TokenData> GetCurrentUserInfo()
    {
        var token = await GetHeadersToken();
        try
        {
            return await ParseTokenAsync(token);
        }
        catch (Exception)
        {
            return new TokenData();
        }
    }
}