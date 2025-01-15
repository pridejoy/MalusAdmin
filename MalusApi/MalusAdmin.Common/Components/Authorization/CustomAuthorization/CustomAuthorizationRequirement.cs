using MalusAdmin.Common;
using MalusAdmin.Repository.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthorizationRequirement : IAuthorizationRequirement
{
    // 自定义要求可以在这里定义属性
}

public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
{ 
    public IAuthenticationSchemeProvider Schemes { get; set; }

    //private readonly ISysRolePermission _permissionService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAppUser _userService;
    //private readonly ISettingService _settingService; 
    private readonly ITokenService _token;

    public CustomAuthorizationHandler(IAuthenticationSchemeProvider schemes, IHttpContextAccessor httpContextAccessor,
      IAppUser userService,
      ITokenService token)
    {
        _httpContextAccessor = httpContextAccessor;
        Schemes = schemes;
        _token = token;
    }

    // 自定义授权逻辑
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
    { 
        context.Succeed(requirement);
   
    }
}