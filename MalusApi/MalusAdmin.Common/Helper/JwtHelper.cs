using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace MalusAdmin.Common;

public static class JwtHelper
{
    /// <summary>
    ///     生成 JWT Token
    /// </summary>
    /// <param name="tokenModel"></param>
    /// <returns></returns>
    public static string Create(Dictionary<string, string> Dic)
    {
        // 获取配置
        var issuer = AppSettings.Jwt.Issuer;
        var audience = AppSettings.Jwt.Audience;
        var secret = AppSettings.Jwt.SecretKey;


        var claims = new List<Claim>
        {
            /*
            * 特别重要：
              1、这里将用户的部分信息，比如 uid 存到了Claim 中，如果你想知道如何在其他地方将这个 uid从 Token 中取出来，请看下边的SerializeJwt() 方法，或者在整个解决方案，搜索这个方法，看哪里使用了！
              2、你也可以研究下 HttpContext.User.Claims ，具体的你可以看看 Policys/PermissionHandler.cs 类中是如何使用的。
            */
            new(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
            new(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
            //这个就是过期时间，目前是过期1000秒，可自定义，注意JWT有自己的缓冲过期时间
            new(JwtRegisteredClaimNames.Exp,
                $"{new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds()}"),
            new(JwtRegisteredClaimNames.Iss, issuer),
            new(JwtRegisteredClaimNames.Aud, audience)
        };

        Dic.ToList().ForEach(kvp => claims.Add(new Claim(kvp.Key, kvp.Value)));

        //秘钥 (SymmetricSecurityKey 对安全性的要求，密钥的长度太短会报出异常)
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            issuer,
            claims: claims,
            signingCredentials: creds);

        var jwtHandler = new JwtSecurityTokenHandler();
        var encodedJwt = jwtHandler.WriteToken(jwt);

        return encodedJwt;
    }
}