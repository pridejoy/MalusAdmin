using MalusAdmin.Common.Helper;
using MalusAdmin.Servers.SysData.Dto;
using Microsoft.Extensions.DependencyModel;

namespace MalusAdmin.Servers;

public class SysDataService
{
    /// <summary>
    /// 获取服务器信息
    /// </summary>
    /// <returns></returns>
    public async Task<ServerInfo> GetServerInfo()
    {
        var serverInfo = new ServerInfo
        {
            MachineName = ServerInfoUtil.MachineName,
            OSName = ServerInfoUtil.OSName,
            OSArchitecture = ServerInfoUtil.OSArchitecture,
            DoNetName = ServerInfoUtil.DoNetName,
            IP = ServerInfoUtil.IP[0],
            CpuCount = ServerInfoUtil.CpuCount,
            UseRam = ServerInfoUtil.UseRam,
            StartTime = ServerInfoUtil.StartTime,
            RunTime = ServerInfoUtil.RunTime,
            DiskInfo = ServerInfoUtil.DiskInfo,
            MemoryInfo = ServerInfoUtil.MemoryInfo
        };

        return serverInfo;
    }

    /// <summary>
    /// 获取当前使用的Nuget包
    /// </summary>
    /// <returns></returns>
    public async Task<List<NuGetPackage>> GetNuGetPackages()
    {
        var runtimeDependencies = DependencyContext.Default.RuntimeLibraries;
        var nuGetPackages = runtimeDependencies
            //.Where(lib => lib.Type == "package" && lib.Dependencies.Any())
            .Select(lib => new NuGetPackage
            {
                Name = lib.Name,
                Version = lib.Version
            });

        return nuGetPackages.ToList();
    }
}