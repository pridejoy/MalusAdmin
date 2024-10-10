using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MalusAdmin.Common;

public static class JwtSetup
{
    /// <summary>
    ///     添加jwt认证
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IServiceCollection AddJwtSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        // 读取配置
        var symmetricKeyAsBase64 = AppSettings.Jwt.SecretKey;
        var issuer = AppSettings.Jwt.Issuer;
        var audience = AppSettings.Jwt.Audience;

        // 获取密钥
        var keyByteArray = Encoding.UTF8.GetBytes(symmetricKeyAsBase64);
        var signingKey = new SymmetricSecurityKey(keyByteArray);
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        // 令牌验证参数
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, // 是否验证SecurityKey 
            ValidateIssuer = true, // 是否验证Issuer 
            ValidateAudience = true, // 是否验证Audience
            ValidateLifetime = true, // 是否验证失效时间
            ClockSkew = TimeSpan.FromSeconds(30), // 过期时间容错值，解决服务器端时间不同步问题（秒）
            RequireExpirationTime = true,
            IssuerSigningKey = signingKey, // 拿到SecurityKey  指定用于签名验证的密钥
            ValidIssuer = issuer, // 发行人Issuer  指定发行者
            ValidAudience = audience // 订阅人Audience 指定受众
        };

        // events
        var jwtBearerEvents = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                // refresh token 
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("401");

                // 标识处理了响应
                context.HandleResponse();
            },
            OnForbidden = async context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("403");
            }
        };

        //添加身份验证
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            //验证token
            options.TokenValidationParameters = tokenValidationParameters;
            options.Events = jwtBearerEvents;
        });

        return services;
    }
}