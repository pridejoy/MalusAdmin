namespace MalusAdmin.WebApi
{
    public class CheckToken
    {
        readonly RequestDelegate _next;
        readonly IServiceScopeFactory _serviceScopeFactory;
        public CheckToken(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //Tode 自动获取allow的特性的接口
            //var IgnoreVerifyTokenPaths = AssemblyHelper.GetAllowAnonymousEndpoints();
            var IgnoreVerifyTokenPaths = new string[] { "/Home", "api/SysLogin/Login" };

            if (!IgnoreVerifyTokenPaths.ToList().Exists(s => context.Request.Path.ToString().Contains(s)))
            {
                using (IServiceScope serviceScope = _serviceScopeFactory.CreateScope())
                {
                    ITokenService tokenService = serviceScope.ServiceProvider.GetService<ITokenService>();
                    if (!tokenService.CheckToken(context))
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("登录已过期，请重新登录");
                        return;
                    }
                    else
                    {
                        tokenService.RefreshToken(context);
                    }
                }
            }
            await _next(context);



        }
    }
}