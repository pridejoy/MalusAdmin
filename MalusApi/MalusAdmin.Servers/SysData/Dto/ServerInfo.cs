using MalusAdmin.Common.Helper;

namespace MalusAdmin.Servers.SysData.Dto;

/// <summary>
/// 服务器信息类
/// </summary>
public class ServerInfo
{
    public string MachineName { get; set; }
    public string OSName { get; set; }
    public string OSArchitecture { get; set; }
    public string DoNetName { get; set; }
    public string IP { get; set; }
    public int CpuCount { get; set; }
    public string UseRam { get; set; }
    public string StartTime { get; set; }
    public string RunTime { get; set; }
    public List<DiskInfo> DiskInfo { get; set; }
    public MemoryInfo MemoryInfo { get; set; }
}