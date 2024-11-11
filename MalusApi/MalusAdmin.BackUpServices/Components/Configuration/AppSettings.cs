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
        //if (_configuration != null) throw Exception($"{nameof(Configuration)}不可修改！");
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    #region 以下存放的全部都是静态配置
 
    /// <summary>
    /// 数据库链接
    /// </summary>
    public static string SqlServerConnection => Configuration["SqlServerConnection"]??"";


    /// <summary>
    /// RabbitMq链接
    /// </summary>
    public static string RabbitMqConnetion => Configuration["RabbitMqConnetion"]??"";

 

    #endregion
}