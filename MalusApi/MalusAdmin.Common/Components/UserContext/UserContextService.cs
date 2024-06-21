
using Microsoft.AspNetCore.Http;

namespace MalusAdmin.Common;

/// <summary>
/// 用户上下文服务，用于获取当前的用户信息
/// </summary>
public class UserContextService : IUserContextService
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITokenService _tokenService;

    public UserContextService(IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenService = tokenService;
    }

    public TokenData GetUserTokenData()
    {
        var tokenData = _tokenService.ParseToken(_httpContextAccessor.HttpContext);
        return tokenData;
    }

}
