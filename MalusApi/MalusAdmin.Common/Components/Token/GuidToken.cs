namespace MalusAdmin.Common;

/// <summary>
/// 基于自定义GUID实现的Token
/// </summary>
[AutoInject]
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
    public async Task<string> GenerateTokenAsync(TokenData tokenData)
    {
        //redis存放的是用户信息-TokenData
        var token = Guid.NewGuid().ToString("N");
        _cacheService.Set(CacheConstant.UserToken + token, tokenData, 60 * expiresTime);
        return token;
    }
}