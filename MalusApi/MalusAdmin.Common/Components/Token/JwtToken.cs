using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MalusAdmin.Common.Constant;
using Microsoft.IdentityModel.Tokens;

namespace MalusAdmin.Common.Components
{
    public class JwtToken : ITokenService
    {
        private readonly ICacheService _cacheService; 
         
        private readonly int expiresTime = TokenConstant.TokenExpiresTime;

        public JwtToken(ICacheService cacheService)
        {
            _cacheService = cacheService; 
        }

        public async Task<string> GenerateTokenAsync(TokenData tokenData)
        {
            // 获取配置
            var jwtConfiguration = App.GetOptions<JwtOptions>();
             
            var claims = new List<Claim>
             {
                new Claim("AppName", "MalusAdmin"), 
                new Claim("Author", "Malus"),
                //和guidtoken存放的内容保持一直
                new Claim(AppUserConst.UserId, tokenData.UserId.ToString()),
                new Claim(AppUserConst.UserAccount, tokenData.UserAccount.ToString()),
            };

            //dic.ToList().ForEach(kvp => claims.Add(new Claim(kvp.Key, kvp.Value)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtConfiguration.Issuer,
                audience: jwtConfiguration.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(jwtConfiguration.ExpireDays),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
   
    }
}
