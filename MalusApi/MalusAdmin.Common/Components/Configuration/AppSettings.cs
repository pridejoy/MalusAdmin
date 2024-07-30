using Microsoft.Extensions.Configuration;
using SqlSugar.Extensions;

namespace MalusAdmin.Common;

public static class AppSettings
{
    private static IConfiguration? _configuration;

    public static IConfiguration Configuration
    {
        get
        {
            if (_configuration == null) throw new NullReferenceException(nameof(Configuration));
            return _configuration;
        }
    }


    /// <summary>
    /// 设置 Configuration 的实例
    /// </summary>
    /// <param name="configuration"></param>
    /// <exception cref="Exception"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddConfigSteup(IConfiguration? configuration)
    {
        if (_configuration != null)  throw ResultHelper.Exception207Bad($"{nameof(Configuration)}不可修改！");
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    #region 以下存放的全部都是静态配置

    /// <summary>
    /// 允许跨域请求列表
    /// </summary>
    public static string[] AllowCors => Configuration.GetSection("AllowCors").Get<string[]>();

    /// <summary>
    /// 是否演示环境
    /// </summary>
    public static bool IsDemo => Configuration["IsDemo"].ObjToBool();

    public static string SqlServerConnection => Configuration["SqlServerConnection"];

    /// <summary>
    /// Jwt 配置
    /// </summary>
    public static class Jwt
    {
        public static string SecretKey => Configuration["Jwt:SecretKey"];
        public static string Issuer => Configuration["Jwt:Issuer"];
        public static string Audience => Configuration["Jwt:Audience"];
    }


    /// <summary>
    /// Redis 配置
    /// </summary>
    public static class Redis
    {
        public static bool Enabled => Configuration.GetValue<bool>("Redis:Enabled");
        public static string ConnectionString => Configuration["Redis:ConnectionString"] ?? "ConnectionStringError";
        public static string Instance => Configuration["Redis:Instance"] ?? "Default";
    }

    #endregion
}