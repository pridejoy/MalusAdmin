using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AuthenticationMethod
{
    Guid,
    Jwt
}


public static class AuthenticationSettings
{
    //身份认证鉴权方式[jwt,guid]
    public const AuthenticationMethod CurrentAuthenticationMethod = AuthenticationMethod.Guid;

}