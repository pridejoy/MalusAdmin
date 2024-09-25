using MalusAdmin.Servers;

namespace MalusAdmin.WebApi
{
    public static class RegisterService
    {

        //注册项目所需的服务
        public static IServiceCollection AddSomeServices(this IServiceCollection services)
        {

            services.AddSingleton<ITokenService, TokenService>();  
            services.AddScoped<ISysRolePermission, SysRolePermissionService>();

            return services;
        }
    }
}
