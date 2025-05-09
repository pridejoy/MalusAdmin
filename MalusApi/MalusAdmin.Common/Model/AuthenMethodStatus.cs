using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AuthenMethodStatus
{
    Guid,
    Jwt
}


public static class AuthenticateSettings
{
    //身份认证鉴权方式[jwt,guid]
    public const AuthenMethodStatus AuthenMethod = AuthenMethodStatus.Guid;

}