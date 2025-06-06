using MalusAdmin.Servers.SysData.Dto;

namespace MalusAdmin.Servers;

/// <summary>
/// 系统数据服务接口
/// </summary>
public interface ISysDataService
{
    /// <summary>
    /// 获取服务器信息
    /// </summary>
    /// <returns></returns>
    Task<ServerInfo> GetSystemInfo();

    /// <summary>
    /// 获取当前使用的Nuget包
    /// </summary>
    /// <returns></returns>
    Task<List<NuGetPackage>> GetNuGetPackages();
}
