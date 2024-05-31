namespace MalusAdmin.Servers.SysRolePermission;

public interface ISysRolePermission
{
    Task<bool> HavePermission(string RouthPath);
}