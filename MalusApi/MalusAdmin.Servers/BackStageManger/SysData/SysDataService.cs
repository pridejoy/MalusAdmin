using MalusAdmin.Common.Helper;
using MalusAdmin.Servers.SysData.Dto;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.Servers;

/// <summary>
/// 基础服务
/// </summary>
[ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BackStageManger))]
[ResponseCache(Duration = 500)]
[AllowAnonymous]
public class SysDataService : ApiControllerBase,ISysDataService
{
    /// <summary>
    /// 获取服务器信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("ServerInfo2")] 
    public async Task<ServerInfo> GetSystemInfo()
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
    [HttpGet]
    
    public async Task<List<NuGetPackage>> GetNuGetPackages()
    {
        //var runtimeDependencies = DependencyContext.Default.RuntimeLibraries;
        //var nuGetPackages = runtimeDependencies
        //    //.Where(lib => lib.Type == "package" && lib.Dependencies.Any())
        //    .Select(lib => new NuGetPackage
        //    {
        //        Name = lib.Name,
        //        Version = lib.Version
        //    });

        //return nuGetPackages.ToList();
        return new List<NuGetPackage>
        {
            new NuGetPackage
            {
                Name = "MalusAdmin",
                Version = "1.0.0"
            }
        };
    }
}