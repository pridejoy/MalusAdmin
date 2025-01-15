using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public async Task<string> GenerateTokenAsync(Dictionary<string, string> dic)
        {
            // 获取配置
            var jwtConfiguration = App.GetOptions<JwtOptions>();

            var claims = new List<Claim>
             {
                new Claim("AppName", "MalusAdmin"), 
                new Claim("Author", "Malus"), 
            };

            dic.ToList().ForEach(kvp => claims.Add(new Claim(kvp.Key, kvp.Value)));

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
  
        public Task<bool> ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
