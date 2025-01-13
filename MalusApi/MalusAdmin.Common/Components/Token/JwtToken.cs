using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common.Components
{
    public class JwtToken : ITokenService
    {
        public Task<string> GenerateTokenAsync(TokenData tokenData)
        {
            throw new NotImplementedException();
        }

        public Task<TokenData> GetCurrentUserInfo()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetHeadersToken()
        {
            throw new NotImplementedException();
        }

        public Task<TokenData> ParseTokenAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task RefreshTokenAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
