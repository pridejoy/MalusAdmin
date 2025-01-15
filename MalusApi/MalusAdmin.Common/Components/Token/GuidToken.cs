namespace MalusAdmin.Common;

/// <summary>
/// 基于自定义GUID实现的Token
/// </summary>
[AutoInjection]
public class GuidToken : ITokenService
{
    private readonly ICacheService _cacheService; 
    private readonly IHttpContextAccessor _httpContextAccessor;
     
    private readonly int expiresTime=TokenConstant.TokenExpiresTime;

    public GuidToken(ICacheService cacheService, IHttpContextAccessor httpContextAccessor)
    {
        _cacheService = cacheService;
        _httpContextAccessor = httpContextAccessor;
    } 

    /// <summary>
    /// 生成token
    /// </summary>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    public async Task<string> GenerateTokenAsync(Dictionary<string, string> dic)
    {
        var token = Guid.NewGuid().ToString("N");
        _cacheService.Set(CacheConstant.UserToken + token, dic, 60 * expiresTime);
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
        var userinfo = _cacheService.Get<TokenData>(CacheConstant.UserToken + token);
        if (userinfo == null || userinfo.ExpireTime < DateTime.Now) return false;

        //此处可增加逻辑，限制单个账号只允许登录一个

        return true;
    }  
}