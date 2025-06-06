﻿using MalusAdmin.Common.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MalusAdmin.Common;

public static class AuthorizationSetup
{
    public static IServiceCollection AddAuthorizationSetup(this IServiceCollection services)
    {
  
        switch (AuthenticationSettings.CurrentAuthenticationMethod)
        {
            case AuthenticationMethod.Jwt: 
                // 启动Jwt授权
                services.AddJwtSetup();
                break;

            case AuthenticationMethod.Guid:
                services.AddAuthentication("CustomScheme")
                     .AddScheme<AuthenticationSchemeOptions, CustomTokenAuthenticationHandler>("CustomScheme", null); 
                break;
        } 
        return services;
    }
}