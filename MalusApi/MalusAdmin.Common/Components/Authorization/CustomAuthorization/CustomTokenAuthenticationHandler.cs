using System.Security.Claims;
using System.Text.Encodings.Web;
using MalusAdmin.Common;
using MalusAdmin.Common.Constant;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// 自定义token验证处理器
/// </summary>
public class CustomTokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{

    private readonly MalusAdmin.Common.ICacheService _cacheService;
    public CustomTokenAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock, MalusAdmin.Common.ICacheService cacheService)
        : base(options, logger, encoder, clock)
    {
        this._cacheService = cacheService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // 检查请求中是否包含 Token
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

        var token = Request.Headers["Authorization"].ToString();
         
        //获取用户信息 
        var userinfo = _cacheService.Get<TokenData>(CacheConstant.UserToken + token?.Replace("Bearer ", ""));
        if (userinfo is null)
            return AuthenticateResult.Fail("Token not found or expired");

        // 构建 ClaimsIdentity
        var claims = new[]
        {
            new Claim(AppUserConst.UserId, userinfo.UserId.ToString()),
            new Claim(AppUserConst.UserAccount, userinfo.UserAccount.ToString()), 
            new Claim(AppUserConst.UserRolesId, userinfo.UserRolesId.ToJson()), 
            new Claim(ClaimTypes.Name, "RedisUser")
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
