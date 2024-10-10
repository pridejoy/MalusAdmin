namespace MalusAdmin.Servers.BackStageManger;

public interface ISysLogService
{
    Task AddLog(string type, string Message);
}