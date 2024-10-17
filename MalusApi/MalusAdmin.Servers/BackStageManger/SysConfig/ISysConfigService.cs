namespace MalusAdmin.Servers;

/// <summary>
/// 参数配置
/// </summary>
public interface ISysConfigService
{
    Task<string> GetTypeKeyConfig(string key, string type);
}