namespace MalusAdmin.Servers;

public interface ISysRolePermission
{
    Task<bool> HavePermission(string RouthPath);
}